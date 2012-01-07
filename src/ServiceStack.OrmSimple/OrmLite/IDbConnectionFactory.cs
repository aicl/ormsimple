using System.Data;

namespace ServiceStack.OrmSimple
{
	public interface IDbConnectionFactory
	{
		IDbConnection OpenDbConnection();
		IDbConnection CreateDbConnection();
	}
}