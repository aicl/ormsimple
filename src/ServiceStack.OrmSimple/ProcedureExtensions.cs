using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using ServiceStack.Common.Extensions;
using ServiceStack.Common.Utils;
using ServiceStack.Logging;
using ServiceStack.OrmSimple;

using ServiceStack.OrmSimple.StringExtensions;
using ServiceStack.OrmSimple.TypeExtensions;
using ServiceStack.OrmSimple.ObjectExtensions;

namespace System.Data
{
	public static class ProcedureExtensions
	{
				
		
		public static List<TOutputModel> SelectFromProcedure<TOutputModel>(this IDbCommand dbCommand,
		                                          object fromObjWithProperties
		                                          )
			where TOutputModel : new()
		{
			return SelectFromProcedure<TOutputModel>(dbCommand, fromObjWithProperties,string.Empty);
		}
		
		
		public static List<TOutputModel> SelectFromProcedure<TOutputModel>(this IDbCommand dbCommand,
		                                          object fromObjWithProperties,
		                                          string sqlFilter, 
		                                          params object[] filterParams)
			where TOutputModel : new()
		{
			var modelType = typeof(TOutputModel);	
			
			string sql = fromObjWithProperties.ToSelectFromProcedureStatement(modelType, sqlFilter, filterParams);
			
			
			using (var reader = dbCommand.ExecReader(sql ) )
			{
				return reader.ConvertToList<TOutputModel>();
			}

		}
		
		
		// Execute Procedure XX(par1, par2, par3 )		
		// Execute Procedure XX -- without input params
		// XX modelName of obj
		// par1 , par2, par2 properties of obj
		
		public static void ExecuteProcedure<T>(this IDbCommand dbCommand, T obj){
			
			
			
			string sql= obj.ToExecuteProcedureStatement();
			dbCommand.CommandType= CommandType.StoredProcedure;
			dbCommand.ExecuteSql(sql);
		}
		
				
	}
}

