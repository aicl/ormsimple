using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;

using ServiceStack.Common.Utils;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.StringExtensions;
using ServiceStack.OrmSimple.TypeExtensions;

using FirebirdSql.Data.FirebirdClient;

namespace ServiceStack.OrmSimple.Firebird
{
	public class FirebirdDialectProvider
		:DialectProviderBase
		
	{
			
		public static FirebirdDialectProvider Instance = new FirebirdDialectProvider();

		public FirebirdDialectProvider()
		{
			base.BoolColumnDefinition = base.IntColumnDefinition;
			base.GuidColumnDefinition = "CHAR(16) character set octets";
			base.InitColumnTypeMap();
		}

		

		public override IDbConnection CreateConnection(string connectionString, Dictionary<string, string> options)
		{
			return new FbConnection(connectionString);
		}

		public override object ConvertDbValue(object value, Type type)
		{
			if (value == null || value is DBNull) return null;

			if (type == typeof(bool))
			{
				var intVal = int.Parse(value.ToString());
				return intVal != 0;
			}
			
			if(type == typeof(System.Double))
				return double.Parse(value.ToString());
			try
			{
				return base.ConvertDbValue(value, type);
			}
			catch (Exception )
			{				
				throw;
			}
		}

		public override string GetQuotedValue(object value, Type fieldType)
		{
						
			if (value == null) return "NULL";

			if (fieldType == typeof(Guid))
			{
				var guidValue = (Guid)value;
				return string.Format("CAST('{0}' AS CHAR(16) character set octets)", guidValue);  // TODO : check this !!!
			}
			if (fieldType == typeof(DateTime) || fieldType == typeof( DateTime?) )
			{
				var dateValue = (DateTime)value;
				string iso8601Format= dateValue.ToString("yyyy-MM-dd HH:mm:ss.fff").EndsWith("00:00:00.000")?
						"yyyy-MM-dd"
						:"yyyy-MM-dd HH:mm:ss.fff";		
				return base.GetQuotedValue(dateValue.ToString(iso8601Format), typeof(string));
			}
			if (fieldType == typeof(bool ?) || fieldType == typeof(bool))
			{
				var boolValue = (bool)value;
				return base.GetQuotedValue(boolValue ? "1" : "0", typeof(string));
			}

			return base.GetQuotedValue(value, fieldType);
		}

		
		public override long GetLastInsertId(IDbCommand dbCmd)
		{
			return LastInsertId;			
		}
		
		
		public override long GetNextValue(IDbCommand dbCmd, string sequence) 
		{
			dbCmd.CommandText = string.Format("select next value for {0} from RDB$DATABASE",sequence);
			long result = (long) dbCmd.ExecuteScalar();
			LastInsertId=  result;
			return  result;	
		}
		
		public override string ToSelectStatement(Type tableType, string sqlFilter, params object[] filterParams)
		{
			var sql = new StringBuilder();
			const string SelectStatement = "SELECT ";

			var isFullSelectStatement = 
				!string.IsNullOrEmpty(sqlFilter)
				&& sqlFilter.Length > SelectStatement.Length
				&& sqlFilter.Substring(0, SelectStatement.Length).ToUpper().Equals(SelectStatement);

			if (isFullSelectStatement) 	return sqlFilter.SqlFormat(filterParams);
			

			var modelDef = tableType.GetModel();
			sql.AppendFormat("SELECT {0} FROM \"{1}\"", 
			                 GetColumnNames(tableType), 
			                 modelDef.ModelName);
			if (!string.IsNullOrEmpty(sqlFilter))
			{
				sqlFilter = sqlFilter.SqlFormat(filterParams);
				if (!sqlFilter.StartsWith("ORDER ", StringComparison.InvariantCultureIgnoreCase)
					&& !sqlFilter.StartsWith("ROWS ", StringComparison.InvariantCultureIgnoreCase)) // ROWS <m> [TO <n>])
				{
					sql.Append(" WHERE ");
				}
				sql.Append(sqlFilter);
			}

			return sql.ToString();
		}
		
		public override string ToSelectStatement( Type fromTableType, Type modelType, string sqlFilter,
		                                         params object[] filterParams)
		{
			var modelDef = fromTableType.GetModel();
			var sql = new StringBuilder();
			sql.AppendFormat("SELECT {0} FROM \"{1}\"", 
			                 GetColumnNames(modelType),
			                 modelDef.ModelName);
			if (!string.IsNullOrEmpty(sqlFilter))
			{
				sqlFilter = sqlFilter.SqlFormat(filterParams);
				if (!sqlFilter.StartsWith("ORDER ", StringComparison.InvariantCultureIgnoreCase)
					&& !sqlFilter.StartsWith("ROWS ", StringComparison.InvariantCultureIgnoreCase)) // ROWS <m> [TO <n>])
				{
					sql.Append(" WHERE ");
				}
				sql.Append(sqlFilter);
			}

			return sql.ToString();
		}
		
		public override string ToInsertRowStatement(object objWithProperties, IDbCommand dbCommand)
		{
			var sbColumnNames = new StringBuilder();
			var sbColumnValues = new StringBuilder();

			var tableType = objWithProperties.GetType();
			var modelDef = tableType.GetModel();
			foreach (var fieldDef in modelDef.FieldDefinitions)
			{
				if( (fieldDef.AutoIncrement && string.IsNullOrEmpty(fieldDef.Sequence) ) 
				   || fieldDef.IsComputed) continue;
				
				if( !string.IsNullOrEmpty(fieldDef.Sequence)  && dbCommand!=null ){
					PropertyInfo pi = ReflectionUtils.GetPropertyInfo(tableType, fieldDef.Name);
					
					var result = dbCommand.GetNextValue( fieldDef.Sequence );
					if( pi.PropertyType== typeof(String))
						ReflectionUtils.SetProperty(objWithProperties, pi,  result.ToString());	
					else if(pi.PropertyType== typeof(Int16))
						ReflectionUtils.SetProperty(objWithProperties, pi, Convert.ToInt16(result));	
					else if(pi.PropertyType== typeof(Int32))
						ReflectionUtils.SetProperty(objWithProperties, pi, Convert.ToInt32(result));	
					else
						ReflectionUtils.SetProperty(objWithProperties, pi, Convert.ToInt64( result));			
				}
				

				if (sbColumnNames.Length > 0) sbColumnNames.Append(",");
				if (sbColumnValues.Length > 0) sbColumnValues.Append(",");

				try
				{
					sbColumnNames.Append(string.Format("\"{0}\"", fieldDef.FieldName));
					if( ! string.IsNullOrEmpty( fieldDef.Sequence )  &&  dbCommand==null )
						sbColumnValues.Append(string.Format("@{0}",fieldDef.Name));
					else
						sbColumnValues.Append(fieldDef.GetQuotedValue(objWithProperties));
				}
				catch (Exception )
				{
					throw;
				}
			}

			var sql = string.Format("INSERT INTO \"{0}\" ({1}) VALUES ({2});",
									modelDef.ModelName, sbColumnNames, sbColumnValues);

			return sql;
		}

		
		public override string ToUpdateRowStatement(object objWithProperties)
		{
			var sqlFilter = new StringBuilder();
			var sql = new StringBuilder();

			var tableType = objWithProperties.GetType();
			var modelDef = tableType.GetModel();
			foreach (var fieldDef in modelDef.FieldDefinitions)
			{
				if( fieldDef.IsComputed) continue;
				
				try
				{
					if (fieldDef.IsPrimaryKey || fieldDef.Name== WriteExtensions.IdField )
					{
						if (sqlFilter.Length > 0) sqlFilter.Append(" AND ");

						sqlFilter.AppendFormat("\"{0}\" = {1}", fieldDef.FieldName, fieldDef.GetQuotedValue(objWithProperties));
							
						continue;
					}

					if (sql.Length > 0) sql.Append(",");
					sql.AppendFormat("\"{0}\" = {1}", fieldDef.FieldName, fieldDef.GetQuotedValue(objWithProperties));
				}
				catch (Exception )
				{
					throw;
				}
			}

			var updateSql = string.Format("UPDATE \"{0}\" SET {1} WHERE {2}",
				modelDef.ModelName, sql, sqlFilter);

			return updateSql;
		}
		
		
		//select cast(1  as smallint) as  "EXISTS" from RDB$DATABASE where exists
		// (select 1 from EMPLOYEE where emp_no='12')
		public override string ToExistStatement( Type fromTableType, object objWithProperties, string sqlFilter,
		                                         params object[] filterParams)
		{
			
			var fromModelDef=fromTableType.GetModel();
			var sql = new StringBuilder();
			sql.AppendFormat("SELECT 1 FROM \"{0}\"", 
			                 fromModelDef.ModelName);
			
			var filter = new StringBuilder();
			
			if(objWithProperties!=null){
				var tableType = objWithProperties.GetType();
				
				if(fromTableType!=tableType){
					int i=0;
					List<FieldDefinition> fpk= new List<FieldDefinition>();					
					var modelDef = tableType.GetModel();
					
					foreach(var def in modelDef.FieldDefinitions){
						if( def.IsPrimaryKey) fpk.Add(def);
					}
					
					foreach (var fieldDef in fromModelDef.FieldDefinitions)
					{
						if( fieldDef.IsComputed) continue;
						try{
						
							if ( fieldDef.ReferencesType !=null 
							    && fieldDef.ReferencesType.GetModel().ModelName == modelDef.ModelName ){
								if (filter.Length > 0) filter.Append(" AND ");
								filter.AppendFormat("\"{0}\" = {1}", fieldDef.FieldName,
								                    fpk[i].GetQuotedValue(objWithProperties));	
								i++;
								continue;
							}
						}
	
						catch (Exception ){
							throw;
						}
					}	
					
				}
				else{
					var modelDef = tableType.GetModel();
					foreach (var fieldDef in modelDef.FieldDefinitions)
					{
						if( fieldDef.IsComputed) continue;
						try{
						
							if ( fieldDef.IsPrimaryKey ){
								if (filter.Length > 0) filter.Append(" AND ");
								filter.AppendFormat("\"{0}\" = {1}", fieldDef.FieldName, fieldDef.GetQuotedValue(objWithProperties));	
								continue;
							}
						}
	
						catch (Exception ){
							throw;
						}
					}
				}
				
				
				
				if( filter.Length>0) sql.AppendFormat(" WHERE {0} ", filter.ToString());
			}	
			
			if (!string.IsNullOrEmpty(sqlFilter))
			{
				sqlFilter = sqlFilter.SqlFormat(filterParams);
				if (!sqlFilter.StartsWith("ORDER ", StringComparison.InvariantCultureIgnoreCase)
					&& !sqlFilter.StartsWith("ROWS ", StringComparison.InvariantCultureIgnoreCase)) // ROWS <m> [TO <n>])
				{
					sql.Append( filter.Length>0? " AND  ": " WHERE ");
				}
				sql.Append(sqlFilter);
			}
			 		
			StringBuilder s = new StringBuilder("select 1  from RDB$DATABASE where");
			s.AppendFormat(" exists ({0})", sql.ToString() );
			return s.ToString();
		}
		
		
		public override string ToDeleteRowStatement( object objWithProperties)
		{
			var sqlFilter = new StringBuilder();

			var tableType = objWithProperties.GetType();
			var modelDef = tableType.GetModel();
			foreach (var fieldDef in modelDef.FieldDefinitions)
			{
				try
				{
					if (fieldDef.IsPrimaryKey || fieldDef.Name== WriteExtensions.IdField)
					{
						if (sqlFilter.Length > 0) sqlFilter.Append(" AND ");

						sqlFilter.AppendFormat("\"{0}\" = {1}", fieldDef.FieldName, fieldDef.GetQuotedValue(objWithProperties));
					}
				}
				catch (Exception )
				{
					throw;
				}
			}

			var deleteSql = string.Format("DELETE FROM \"{0}\" WHERE {1}",
				modelDef.ModelName, sqlFilter);

			return deleteSql;
		}
		
		
		public override string ToSelectFromProcedureStatement(object fromObjWithProperties,
		                                          Type outputModelType,       
		                                          string sqlFilter, 
		                                          params object[] filterParams)
		
		{
						
			var sbColumnValues = new StringBuilder();
			
			Type fromTableType = fromObjWithProperties.GetType();
			
			var modelDef = fromTableType.GetModel();
			
			foreach (var fieldDef in modelDef.FieldDefinitions)
			{	
				if (sbColumnValues.Length > 0) sbColumnValues.Append(",");

				try
				{
					sbColumnValues.Append( fieldDef.GetQuotedValue(fromObjWithProperties) );	
				}
				catch (Exception )
				{	
					throw;
				}
			}
				
			
			StringBuilder sql = new StringBuilder();
			sql.AppendFormat("SELECT {0} FROM  \"{1}\" {2}{3}{4}  \n", 
			                 GetColumnNames(outputModelType), 
			                 modelDef.ModelName,
			                 sbColumnValues.Length>0?"(":"",
			                 sbColumnValues.ToString(),
			                 sbColumnValues.Length>0?")":"");
			
			
			if(!string.IsNullOrEmpty(sqlFilter)){
				sqlFilter = sqlFilter.SqlFormat(filterParams);
				if (!sqlFilter.StartsWith("ORDER ", StringComparison.InvariantCultureIgnoreCase)
						&& !sqlFilter.StartsWith("ROWS ", StringComparison.InvariantCultureIgnoreCase)) // ROWS <m> [TO <n>]
				{
					sql.Append(" WHERE ");
				}
				sql.Append(sqlFilter);
			}
			
			return sql.ToString();
			
		}
		
		public  override string ToExecuteProcedureStatement(object objWithProperties){
			
			var sbColumnValues = new StringBuilder();
			
			var tableType = objWithProperties.GetType();
			var modelDef = tableType.GetModel();
			
			foreach (var fieldDef in modelDef.FieldDefinitions)
			{
				if (sbColumnValues.Length > 0) sbColumnValues.Append(",");
				try
				{
					sbColumnValues.Append( fieldDef.GetQuotedValue(objWithProperties) );
					
				}
				catch (Exception )
				{
					throw;
				}
			}
			
			var sql = string.Format("EXECUTE PROCEDURE \"{0}\" {1}{2}{3};",
									modelDef.ModelName,  
			                        sbColumnValues.Length>0?"(":"",
			                        sbColumnValues,
			                        sbColumnValues.Length>0?")":"");
			
			return sql;
		}

		
		
		public override T PopulateWithSqlReader<T>(T objWithProperties, IDataReader dataReader, FieldDefinition[] fieldDefs)
		{
			for (var i = 0; i < fieldDefs.Length; i++)
			{
				var fieldDef = fieldDefs[i];
				var value = dataReader.GetValue(i);
				fieldDef.SetValue(objWithProperties, value);
			}
			return objWithProperties;
		}
		
		
	}
}

