using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Reflection;
using ServiceStack.Logging;
using ServiceStack.Text;
using ServiceStack.Common.Utils;
using ServiceStack.OrmSimple;

using ServiceStack.OrmSimple.StringExtensions;
using ServiceStack.OrmSimple.TypeExtensions;
using ServiceStack.OrmSimple.CollectionExtensions;
using ServiceStack.OrmSimple.ObjectExtensions;

namespace System.Data
{
	public static class ReadExtensions
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(ReadExtensions));

		[Conditional("DEBUG")]
		private static void LogDebug(string fmt, params object[] args)
		{
	
			if (args.Length > 0)
				Log.DebugFormat(fmt, args);
			else
				Log.Debug(fmt);
		}

		internal static IDataReader ExecReader(this IDbCommand dbCmd, string sql)
		{
			LogDebug(sql);
			dbCmd.CommandText = sql;
			return dbCmd.ExecuteReader();
		}

		public static Func<int, object> GetValueFn<T>(IDataRecord reader)
		{
			var type = typeof(T);

			if (type == typeof(string))
				return reader.GetString;

			if (type == typeof(short))
				return i => reader.GetInt16(i);

			if (type == typeof(int))
				return i => reader.GetInt32(i);

			if (type == typeof(long))
				return i => reader.GetInt64(i);

			if (type == typeof(bool))
				return i => reader.GetBoolean(i);

			if (type == typeof(DateTime))
				return i => reader.GetDateTime(i);

			if (type == typeof(Guid))
				return i => reader.GetGuid(i);

			if (type == typeof(float))
				return i => reader.GetFloat(i);

			if (type == typeof(double))
				return i => reader.GetDouble(i);

			if (type == typeof(decimal))
				return i => reader.GetDecimal(i);

			return reader.GetValue;
		}


		

		public static List<T> Select<T>(this IDbCommand dbCommand)
			where T : new()
		{
			return Select<T>(dbCommand, (string)null);
		}

		public static List<T> Select<T>(this IDbCommand dbCommand, string sqlFilter, params object[] filterParams)
			where T : new()
		{
			using (var reader = dbCommand.ExecReader(typeof(T).ToSelectStatement( sqlFilter, filterParams)))
			{
				return reader.ConvertToList<T>();
			}
		}

		public static List<TModel> Select<TModel>(this IDbCommand dbCommand, Type fromTableType)
			where TModel : new()
		{
			return Select<TModel>(dbCommand, fromTableType, null);
		}

		public static List<TModel> Select<TModel>(this IDbCommand dbCommand, Type fromTableType, string sqlFilter, params object[] filterParams)
			where TModel : new()
		{
			
			var modelType = typeof(TModel);
			var sql = fromTableType.ToSelectStatement(modelType,sqlFilter, filterParams);
		
			using (var reader = dbCommand.ExecReader(sql))
			{
				return reader.ConvertToList<TModel>();
			}
		}

		public static IEnumerable<T> Each<T>(this IDbCommand dbCommand)
			where T : new()
		{
			return Each<T>(dbCommand, null);
		}

		public static IEnumerable<T> Each<T>(this IDbCommand dbCommand, string filter, params object[] filterParams)
			where T : new()
		{
			var fieldDefs = typeof(T).GetModelDefinition().FieldDefinitionsArray;

			using (var reader = dbCommand.ExecReader(typeof(T).ToSelectStatement( filter, filterParams)) )
			{
				while (reader.Read())
				{
					var row = new T();
					row.PopulateWithSqlReader(reader, fieldDefs);
					yield return row;
				}
			}
		}

		public static T First<T>(this IDbCommand dbCommand, string filter, params object[] filterParams)
			where T : new()
		{
			return First<T>(dbCommand, filter.SqlFormat(filterParams));
		}

		public static T First<T>(this IDbCommand dbCommand, string filter)
			where T : new()
		{
			var result = FirstOrDefault<T>(dbCommand, filter);
			if (Equals(result, default(T)))
			{
				throw new ArgumentNullException(string.Format(
					"{0}: '{1}' does not exist", typeof(T).Name, filter));
			}
			return result;
		}

		public static T FirstOrDefault<T>(this IDbCommand dbCommand, string filter, params object[] filterParams)
			where T : new()
		{
			return FirstOrDefault<T>(dbCommand, filter.SqlFormat(filterParams));
		}

		public static T FirstOrDefault<T>(this IDbCommand dbCommand, string filter)
			where T : new()
		{
			using (var dbReader = dbCommand.ExecReader(typeof(T).ToSelectStatement( filter)))
			{
				return dbReader.ConvertTo<T>();
			}
		}

		public static T GetById<T>(this IDbCommand dbCommand, object idValue)
			where T : new()
		{
			var modelDef = typeof (T).GetModelDefinition();
			return First<T>(dbCommand, modelDef.PrimaryKey.FieldName + " = {0}".SqlFormat(idValue));
		}

		public static T GetByIdOrDefault<T>(this IDbCommand dbCommand, object idValue)
			where T : new()
		{
			var modelDef = typeof(T).GetModelDefinition();
			return FirstOrDefault<T>(dbCommand, modelDef.PrimaryKey.FieldName + " = {0}".SqlFormat(idValue));
		}

		public static List<T> GetByIds<T>(this IDbCommand dbCommand, IEnumerable idValues)
			where T : new()
		{
			var sql = idValues.GetIdsInSql();
			if (sql == null) return new List<T>();

			var modelDef = typeof(T).GetModelDefinition();
			return Select<T>(dbCommand, string.Format(modelDef.PrimaryKey.FieldName + " IN ({0})", sql));
		}

		public static T GetScalar<T>(this IDbCommand dbCmd, string sql, params object[] sqlParams)
		{
			using (var reader = dbCmd.ExecReader(sql.SqlFormat(sqlParams)))
			{
				return GetScalar<T>(reader);
			}
		}

		public static T GetScalar<T>(this IDataReader reader)
		{
			while (reader.Read())
			{
				return TypeSerializer.DeserializeFromString<T>(reader.GetValue(0).ToString());
			}
			return default(T);
		}

		public static long GetLastInsertId(this IDbCommand dbCmd)
		{
			return Config.DialectProvider.GetLastInsertId(dbCmd);
		}

		public static List<T> GetFirstColumn<T>(this IDbCommand dbCmd, string sql, params object[] sqlParams)
		{
			using (var dbReader = dbCmd.ExecReader(sql.SqlFormat(sqlParams)))
			{
				return GetFirstColumn<T>(dbReader);
			}
		}

		public static List<T> GetFirstColumn<T>(this IDataReader reader)
		{
			var columValues = new List<T>();
			var getValueFn = GetValueFn<T>(reader);
			while (reader.Read())
			{
				var value = getValueFn(0);
				columValues.Add((T)value);
			}
			return columValues;
		}

		public static HashSet<T> GetFirstColumnDistinct<T>(this IDbCommand dbCmd, string sql, params object[] sqlParams)
		{
			using (var dbReader = dbCmd.ExecReader(sql.SqlFormat(sqlParams)))
			{
				return GetFirstColumnDistinct<T>(dbReader);
			}
		}

		public static HashSet<T> GetFirstColumnDistinct<T>(this IDataReader reader)
		{
			var columValues = new HashSet<T>();
			var getValueFn = GetValueFn<T>(reader);
			while (reader.Read())
			{
				var value = getValueFn(0);
				columValues.Add((T)value);
			}
			return columValues;
		}

		public static Dictionary<K, List<V>> GetLookup<K, V>(this IDbCommand dbCmd, string sql, params object[] sqlParams)
		{
			using (var dbReader = dbCmd.ExecReader(sql.SqlFormat(sqlParams)))
			{
				return GetLookup<K, V>(dbReader);
			}
		}

		public static Dictionary<K, List<V>> GetLookup<K, V>(this IDataReader reader)
		{
			var lookup = new Dictionary<K, List<V>>();

			List<V> values;
			var getKeyFn = GetValueFn<K>(reader);
			var getValueFn = GetValueFn<V>(reader);
			while (reader.Read())
			{
				var key = (K)getKeyFn(0);
				var value = (V)getValueFn(1);

				if (!lookup.TryGetValue(key, out values))
				{
					values = new List<V>();
					lookup[key] = values;
				}
				values.Add(value);
			}

			return lookup;
		}

		public static Dictionary<K, V> GetDictionary<K, V>(this IDbCommand dbCmd, string sql, params object[] sqlParams)
		{
			using (var dbReader = dbCmd.ExecReader(sql.SqlFormat(sqlParams)))
			{
				return GetDictionary<K, V>(dbReader);
			}
		}

		public static Dictionary<K, V> GetDictionary<K, V>(this IDataReader reader)
		{
			var map = new Dictionary<K, V>();

			var getKeyFn = GetValueFn<K>(reader);
			var getValueFn = GetValueFn<V>(reader);
			while (reader.Read())
			{
				var key = (K)getKeyFn(0);
				var value = (V)getValueFn(1);

				map.Add(key, value);
			}

			return map;
		}
		
		public static T ConvertTo<T>(this IDataReader dataReader)
			where T : new()
		{
			var fieldDefs = typeof(T).GetModelDefinition().FieldDefinitionsArray;

			using (dataReader)
			{
				if (dataReader.Read())
				{
					var row = new T();
					row.PopulateWithSqlReader(dataReader, fieldDefs);
					return row;
				}
				return default(T);
			}
		}

		public static List<T> ConvertToList<T>(this IDataReader dataReader)
			where T : new()
		{
			var fieldDefs = typeof(T).GetModelDefinition().FieldDefinitionsArray;

			var to = new List<T>();
			using (dataReader)
			{
				while (dataReader.Read())
				{
					var row = new T();
					row.PopulateWithSqlReader(dataReader, fieldDefs);
					to.Add(row);
				}
			}
			return to;
		}
		
		
		public static long GetNextValue(this IDbCommand dbCmd, string sequence) 
		{
			return Config.DialectProvider.GetNextValue(dbCmd, sequence);
			
		}
			
		
		
		public static bool HasChildren<T>(this IDbCommand dbCmd, object record){
			return HasChildren<T>(dbCmd, record, string.Empty);
		}
		
		private static bool HasChildren<T>(this IDbCommand dbCmd, object record, string sqlFilter,
		                                  params object[] filterParams){
			
			Type fromTableType = typeof(T);
			
			string sql = Config.DialectProvider.ToExistStatement(fromTableType, record,sqlFilter, filterParams);
			dbCmd.CommandText = sql;
			object result =  dbCmd.ExecuteScalar();
			return result==null? false: true ;
		}
		
		
		public static bool Exists<T>(this IDbCommand dbCmd,  string sqlFilter,
		                                  params object[] filterParams){
			
			return HasChildren<T>(dbCmd, null, sqlFilter, filterParams);
		}
		
		public  static bool Exists<T>(this IDbCommand dbCmd, object record){
			
			return HasChildren<T>(dbCmd, record, string.Empty);
		}
		
		
		
		
	}
}