using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Reflection;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.Common.Utils;
using ServiceStack.OrmSimple.StringExtensions;


namespace ServiceStack.OrmSimple.ObjectExtensions
{
	public static partial class Extensions
	{
				
		public  static string ToInsertRowStatement(this object objWithProperties){
			return Config.DialectProvider.ToInsertRowStatement(objWithProperties, null);
		}	
		
		public static string ToInsertRowStatement(this object objWithProperties, IDbCommand dbCommand)
		{
			return Config.DialectProvider.ToInsertRowStatement(objWithProperties, dbCommand);
		}

		
		public static string ToUpdateRowStatement(this object objWithProperties)
		{
			return Config.DialectProvider.ToUpdateRowStatement(objWithProperties);
		}
		
		public static string ToDeleteRowStatement(this object objWithProperties)
		{
			return Config.DialectProvider.ToDeleteRowStatement(objWithProperties);
		}

		
		public static T PopulateWithSqlReader<T>(this T objWithProperties, IDataReader dataReader)
		{
			var modelDef = typeof(T).GetModelDefinition();
			var fieldDefs = modelDef.FieldDefinitions.ToArray();

			return Config.DialectProvider.PopulateWithSqlReader(objWithProperties, dataReader, fieldDefs);
		}

		public static T PopulateWithSqlReader<T>(this T objWithProperties, IDataReader dataReader, FieldDefinition[] fieldDefs)
		{
			return Config.DialectProvider.PopulateWithSqlReader(objWithProperties, dataReader, fieldDefs);
		}
		
		public  static string ToExecuteProcedureStatement(this object objWithProperties){
			
			return Config.DialectProvider.ToExecuteProcedureStatement(objWithProperties);
		}

		public static string ToSelectFromProcedureStatement(this  object fromObjWithProperties,
		                                          Type outputModelType){
			return ToSelectFromProcedureStatement(fromObjWithProperties, outputModelType, string.Empty);
		}
		
		
		public static string ToSelectFromProcedureStatement(this  object fromObjWithProperties,
		                                          Type outputModelType,       
		                                          string sqlFilter, 
		                                          params object[] filterParams)
		
		{
						
			return Config.DialectProvider.ToSelectFromProcedureStatement(fromObjWithProperties,
			                                                             outputModelType,
			                                                             sqlFilter,
			                                                             filterParams);
		}

		
		
		
		
	}
}