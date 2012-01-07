
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

namespace ServiceStack.OrmSimple.CollectionExtensions
{
	public static partial class Extensions
	{
		
		internal static string GetIdsInSql(this IEnumerable idValues)
		{
			var sql = new StringBuilder();
			foreach (var idValue in idValues)
			{
				if (sql.Length > 0) sql.Append(",");
				sql.AppendFormat("{0}".SqlFormat(idValue));
			}
			return sql.Length == 0 ? null : sql.ToString();
		}

		
		public static string SqlJoin<T>(this List<T> values)
		{
			var sb = new StringBuilder();
			foreach (var value in values)
			{
				if (sb.Length > 0) sb.Append(",");
				sb.Append(Config.DialectProvider.GetQuotedValue(value, value.GetType()));
			}

			return sb.ToString();
		}

		public static string SqlJoin(IEnumerable values)
		{
			var sb = new StringBuilder();
			foreach (var value in values)
			{
				if (sb.Length > 0) sb.Append(",");
				sb.Append(Config.DialectProvider.GetQuotedValue(value, value.GetType()));
			}

			return sb.ToString();
		}

		public static SqlInValues SqlInValues<T>(this List<T> values)
		{
			return new SqlInValues(values);
		}

		public static SqlInValues SqlInValues<T>(this T[] values)
		{
			return new SqlInValues(values);
		}
		
		
	}
}