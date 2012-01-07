using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Reflection;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.Common.Utils;

namespace ServiceStack.OrmSimple.StringExtensions
{
	public static partial class Extensions
	{
		
		
		public static string SqlFormat(this string sqlText, params object[] sqlParams)
		{
			var escapedParams = new List<string>();
			foreach (var sqlParam in sqlParams)
			{
				if (sqlParam == null)
				{
					escapedParams.Add("NULL");
				}
				else
				{
					var sqlInValues = sqlParam as SqlInValues;
					if (sqlInValues != null)
					{
						escapedParams.Add(sqlInValues.ToSqlInString());
					}
					else
					{
						escapedParams.Add(Config.DialectProvider.GetQuotedValue(sqlParam, sqlParam.GetType()));
					}
				}
			}
			return string.Format(sqlText, escapedParams.ToArray());
		}		
		
	}
}