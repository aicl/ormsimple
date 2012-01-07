using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using ServiceStack.Logging;

namespace ServiceStack.OrmSimple
{
	public class Queryable<T>
		: IQueryable<T>
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(QueryProvider));

		public IEnumerator<T> GetEnumerator()
		{
			Log.DebugFormat("IEnumerator<T> GetEnumerator()");
			return new List<T>().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			Log.DebugFormat("IEnumerator IEnumerable.GetEnumerator()");
			return GetEnumerator();
		}

		public Expression Expression { get; set; }

		public Type ElementType
		{
			get
			{
				Log.DebugFormat("Type ElementType");
				return typeof(T);
			}
		}

		public IQueryProvider Provider { get; set; }
	}

	public class QueryProvider
		: IQueryProvider
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(QueryProvider));

		public IQueryable CreateQuery(Expression expression)
		{
			Log.DebugFormat("IQueryable CreateQuery(Expression expression)");
			throw new NotImplementedException();
		}

		public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
		{
			Log.DebugFormat("IQueryable<TElement> CreateQuery<TElement>(Expression expression)");
			return new Queryable<TElement>();
		}

		public object Execute(Expression expression)
		{
			Log.DebugFormat("object Execute(Expression expression)");
			throw new NotImplementedException();
		}

		public TResult Execute<TResult>(Expression expression)
		{
			Log.DebugFormat("TResult Execute<TResult>(Expression expression)");
			throw new NotImplementedException();
		}
	}

}


namespace System.Data{
	
	using ServiceStack.OrmSimple;
	
	public static class LinqExtensions
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(LinqExtensions));

		public static IQueryable<T> From<T>(this IDbCommand dbCmd)
		{
			Log.DebugFormat("IQueryable<T> From<T>(this IDbCommand dbCmd)");
			return new Queryable<T>();
		}
	}
}