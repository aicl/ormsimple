
using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace ServiceStack.OrmSimple.DbSchema
{
	public interface ISchema <TTable,TColumn,TProcedure,TParameter> 
		where TTable :ITable, new()
		where TColumn:IColumn, new()
		where TProcedure:IProcedure, new()
		where TParameter:IParameter, new()
	{
		IDbConnection Connection { set; }
		
		List<TTable> Tables{get;}
		
		TTable GetTable(string tableName);
		
		List<TColumn> GetColumns(string tableName);
					
		List<TColumn> GetColumns(TTable table);
		
		TProcedure GetProcedure(string name);
		
		List<TParameter> GetParameters( TProcedure procedure);
		
		List<TParameter> GetParameters( string procedureName);
	}
}
