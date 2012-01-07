using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ServiceStack.Common.Extensions;
using ServiceStack.Common.Utils;
using ServiceStack.Logging;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.StringExtensions;
using ServiceStack.OrmSimple.TypeExtensions;
using ServiceStack.OrmSimple.CollectionExtensions;
using ServiceStack.OrmSimple.ObjectExtensions;

namespace System.Data
{
	public static class WriteExtensions
	{
		public static string IdField{
			get {return  ConfigExtensions.IdField ;}
		}
		
		private static readonly ILog Log = LogManager.GetLogger(typeof(WriteExtensions));

		[Conditional("DEBUG")]
		private static void LogDebug(string fmt, params object[] args)
		{
			//Console.WriteLine("Debug WriteExtensions : {0} ",  fmt);
			if (args.Length > 0)
				Log.DebugFormat(fmt, args);
			else
				Log.Debug(fmt);
		}

		
		public static void CreateTables(this IDbCommand dbCommand, bool overwrite, params Type[] tableTypes)
		{
			foreach (var tableType in tableTypes)
			{
				CreateTable(dbCommand, overwrite, tableType);
			}
		}

		public static void CreateTable<T>(this IDbCommand dbCommand, bool overwrite)
			where T : new()
		{
			var tableType = typeof(T);
			CreateTable(dbCommand, overwrite, tableType);
		}

		public static void CreateTable(this IDbCommand dbCommand, bool overwrite, Type modelType)
		{
			var modelDef = modelType.GetModelDefinition();
			if (overwrite)
			{
				try
				{
					dbCommand.ExecuteSql(string.Format("DROP TABLE \"{0}\";", modelDef.ModelName));
				}
				catch (Exception ex)
				{
					Log.DebugFormat("Cannot drop non-existing table '{0}': {1}", modelDef.ModelName, ex.Message);
				}
			}

			try
			{
				ExecuteSql(dbCommand, modelType.ToCreateTableStatement() );

				var sqlIndexes = modelType.ToCreateIndexStatements();
				foreach (var sqlIndex in sqlIndexes)
				{
					try
					{
						dbCommand.ExecuteSql(sqlIndex);
					}
					catch (Exception exIndex)
					{
						if (IgnoreAlreadyExistsError(exIndex))
						{
							Log.DebugFormat("Ignoring existing index '{0}': {1}", sqlIndex, exIndex.Message);
							continue;
						}
						throw;
					}
				}
			}
			catch (Exception ex)
			{
				if (IgnoreAlreadyExistsError(ex))
				{
					Log.DebugFormat("Ignoring existing table '{0}': {1}", modelDef.ModelName, ex.Message);
					return;
				}
				throw;
			}
		}

		internal static void ExecuteSql(this IDbCommand dbCommand, string sql)
		{
			LogDebug(sql);
			dbCommand.CommandText = sql;
			dbCommand.ExecuteNonQuery();
		}

		private static bool IgnoreAlreadyExistsError(Exception ex)
		{
			//ignore Sqlite table already exists error
			const string sqliteAlreadyExistsError = "already exists";
			const string sqlServerAlreadyExistsError = "There is already an object named";
			return ex.Message.Contains(sqliteAlreadyExistsError)
			       || ex.Message.Contains(sqlServerAlreadyExistsError);
		}
		
		
		public static void Insert<T>(this IDbCommand dbCommand, T obj)
			where T : new()
		{
			dbCommand.ExecuteSql(obj.ToInsertRowStatement( dbCommand) );
		}

		

		public static void Update<T>(this IDbCommand dbCommand, T obj)
			where T : new()
		{
			dbCommand.ExecuteSql(obj.ToUpdateRowStatement() );
		}

		
		public static void Delete<T>(this IDbCommand dbCommand, T obj)
			where T : new()
		{
			dbCommand.ExecuteSql(obj.ToDeleteRowStatement());
		}

		public static void DeleteById<T>(this IDbCommand dbCommand, object id)
			where T : new()
		{
			var modelDef = typeof(T).GetModelDefinition();

			var sql = string.Format("DELETE FROM \"{0}\" WHERE \"{1}\" = {2}",
				modelDef.ModelName, modelDef.PrimaryKey.FieldName, 
				Config.DialectProvider.GetQuotedValue(id, id.GetType()));

			dbCommand.ExecuteSql(sql);
		}

		public static void DeleteByIds<T>(this IDbCommand dbCommand, IEnumerable idValues)
			where T : new()
		{
			var sqlIn = idValues.GetIdsInSql();
			if (sqlIn == null) return;

			var modelDef = typeof(T).GetModelDefinition();

			var sql = string.Format("DELETE FROM \"{0}\" WHERE \"{1}\" IN ({2})",
				modelDef.ModelName, modelDef.PrimaryKey.FieldName, sqlIn);

			dbCommand.ExecuteSql(sql);
		}

		public static void DeleteAll<T>(this IDbCommand dbCommand)
		{
			DeleteAll(dbCommand, typeof(T));
		}

		public static void DeleteAll(this IDbCommand dbCommand, Type tableType)
		{
			Delete(dbCommand, tableType, null);
		}

		public static void Delete<T>(this IDbCommand dbCommand, string sqlFilter, params object[] filterParams)
			where T : new()
		{
			Delete(dbCommand, typeof(T), sqlFilter, filterParams);
		}

		public static void Delete(this IDbCommand dbCommand, Type tableType, string sqlFilter, params object[] filterParams)
		{
			dbCommand.ExecuteSql(ToDeleteStatement(tableType, sqlFilter, filterParams));
		}

		public static string ToDeleteStatement(this Type tableType, string sqlFilter, params object[] filterParams)
		{
			var sql = new StringBuilder();
			const string deleteStatement = "DELETE ";

			var isFullDeleteStatement = 
				!string.IsNullOrEmpty(sqlFilter)
				&& sqlFilter.Length > deleteStatement.Length
				&& sqlFilter.Substring(0, deleteStatement.Length).ToUpper().Equals(deleteStatement);

			if (isFullDeleteStatement) return sqlFilter.SqlFormat(filterParams);

			var modelDef = tableType.GetModelDefinition();
			sql.AppendFormat("DELETE FROM \"{0}\"", modelDef.ModelName);
			if (!string.IsNullOrEmpty(sqlFilter))
			{
				sqlFilter = sqlFilter.SqlFormat(filterParams);
				sql.Append(" WHERE ");
				sql.Append(sqlFilter);
			}

			return sql.ToString();
		}

		public static void Save<T>(this IDbCommand dbCommand, T obj)
			where T : new()
		{
			var id = IdUtils.GetId(obj);
			var existingRow = dbCommand.GetByIdOrDefault<T>(id);
			if (Equals(existingRow, default(T)))
			{
				dbCommand.Insert(obj);
			}
			else
			{
				dbCommand.Update(obj);
			}
		}

		public static void SaveAll<T>(this IDbCommand dbCommand, IEnumerable<T> objs)
			where T : new()
		{
			var saveRows = objs.ToList();

			var firstRow = saveRows.FirstOrDefault();
			if (Equals(firstRow, default(T))) return;

			var defaultIdValue = ReflectionUtils.GetDefaultValue(IdUtils.GetId(firstRow).GetType());

			var idMap = defaultIdValue != null 
				? saveRows.Where(x => !defaultIdValue.Equals(IdUtils.GetId(x))).ToDictionary(x => IdUtils.GetId(x))
				: saveRows.Where(x => IdUtils.GetId(x) != null).ToDictionary(x => IdUtils.GetId(x));

			var existingRowsMap = dbCommand.GetByIds<T>(idMap.Keys).ToDictionary(x => IdUtils.GetId(x));

			using (var dbTrans = dbCommand.Connection.BeginTransaction())
			{
				dbCommand.Transaction = dbTrans;

				foreach (var saveRow in saveRows)
				{
					var id = IdUtils.GetId(saveRow);
					if (id != defaultIdValue && existingRowsMap.ContainsKey(id))
					{
						dbCommand.Update(saveRow);
					}
					else
					{
						dbCommand.Insert(saveRow);
					}
				}

				dbTrans.Commit();
			}
		}

		public static IDbTransaction BeginTransaction(this IDbCommand dbCmd)
		{
			var dbTrans = dbCmd.Connection.BeginTransaction();
			dbCmd.Transaction = dbTrans;
			return dbTrans;
		}

		public static IDbTransaction BeginTransaction(this IDbCommand dbCmd, IsolationLevel isolationLevel)
		{
			var dbTrans = dbCmd.Connection.BeginTransaction(isolationLevel);
			dbCmd.Transaction = dbTrans;
			return dbTrans;
		}

	}
}