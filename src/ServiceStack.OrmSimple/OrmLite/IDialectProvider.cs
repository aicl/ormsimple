using System;
using System.Collections.Generic;
using System.Data;

namespace ServiceStack.OrmSimple
{
	public interface IDialectProvider
	{
		int DefaultStringLength { get; set; }
		
		bool UseUnicode { get; set; }

		string EscapeParam(object paramValue);

		object ConvertDbValue(object value, Type type);

		string GetQuotedValue(object value, Type fieldType);

		IDbConnection CreateConnection(string filePath, Dictionary<string, string> options);

		string GetColumnDefinition(
			string fieldName, Type fieldType, bool isPrimaryKey, bool autoIncrement, 
			bool isNullable, int? fieldLength, string defaultValue);

		long GetLastInsertId(IDbCommand command);
		
		long LastInsertId{
			get; set;
		}
		
		string GetColumnNames( Type tableType);
		
		long GetNextValue(IDbCommand dbCmd, string sequence) ;
		
		string ToSelectStatement(Type tableType, string sqlFilter, params object[] filterParams);
		
		string ToSelectStatement( Type fromTableType, Type modelType, string sqlFilter,
		                                         params object[] filterParams);
		
		string ToInsertRowStatement(object objWithProperties, IDbCommand dbCommand);
		
		string ToUpdateRowStatement(object objWithProperties);
		
		string ToDeleteRowStatement(object objWithProperties);
		
		string ToSelectFromProcedureStatement( object fromObjWithProperties,
		                                       Type outputModelType,       
		                                        string sqlFilter, 
		                                        params object[] filterParams);
		
		string ToExecuteProcedureStatement(object objWithProperties);
		
		T PopulateWithSqlReader<T>( T objWithProperties, IDataReader dataReader, FieldDefinition[] fieldDefs);
		
		string ToExistStatement( Type fromTableType, object objWithProperties, string sqlFilter,
		                                         params object[] filterParams);
		
	}
}