using System.Collections;

namespace ServiceStack.OrmSimple
{
	public class SqlInValues
	{
		private readonly IEnumerable values;

		public SqlInValues(IEnumerable values)
		{
			this.values = values;
		}

		public string ToSqlInString()
		{
			return CollectionExtensions.Extensions.SqlJoin(values);
		}
	}
}