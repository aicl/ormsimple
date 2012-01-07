using System;
using System.Data;

namespace ServiceStack.OrmSimple
{
	/// <summary>
	/// Allow for mocking and unit testing by providing non-disposing 
	/// connection factory with injectable IDbCommand and IDbTransaction proxies
	/// </summary>
	public class ConnectionFactory : IDbConnectionFactory
	{
		private static ConnectionFactory cf;
		public static ConnectionFactory CreateInstance(string connectionString, 
		                                               bool autDisposeConnection,
		                                               IDialectProvider dialectProvider) 
		{
			if(cf==null) cf = new ConnectionFactory(connectionString, autDisposeConnection, dialectProvider);
			return cf;
		}
		
		
		public ConnectionFactory()
			: this(null, true)
		{
		}

		public ConnectionFactory(string connectionString)
			: this(connectionString, true)
		{
		}

		public ConnectionFactory(string connectionString, bool autoDisposeConnection)
			: this(connectionString, autoDisposeConnection, null)
		{
		}

		public ConnectionFactory(string connectionString, IDialectProvider dialectProvider)
			: this(connectionString, true, dialectProvider)
		{
		}

		public ConnectionFactory(string connectionString, bool autoDisposeConnection, IDialectProvider dialectProvider)
		{
			ConnectionString = connectionString;
			AutoDisposeConnection = autoDisposeConnection;

			if (dialectProvider != null)
			{
				Config.DialectProvider = dialectProvider;
			}
		}

		public string ConnectionString { get; set; }

		public bool AutoDisposeConnection { get; set; }

		/// <summary>
		/// Force the IDbConnection to always return this IDbCommand
		/// </summary>
		public IDbCommand AlwaysReturnCommand { get; set; }

		/// <summary>
		/// Force the IDbConnection to always return this IDbTransaction
		/// </summary>
		public IDbTransaction AlwaysReturnTransaction { get; set; }

		private Connection connection;
		private Connection Connection
		{
			get
			{
				if (connection == null)
				{
					connection = new Connection(this);
				}
				return connection;
			}
		}

		public IDbConnection OpenDbConnection()
		{
			var connection = CreateDbConnection();
			connection.Open();

			return connection;
		}

		public IDbConnection CreateDbConnection()
		{
			if (this.ConnectionString == null)
				throw new ArgumentNullException("ConnectionString", "ConnectionString must be set");

			var connection = AutoDisposeConnection
				? new Connection(this)
				: Connection;

			return connection;
		}
	}

	public static class OrmLiteConnectionFactoryExtensions
	{
		public static void Exec(this IDbConnectionFactory connectionFactory, Action<IDbCommand> runDbCommandsFn)
		{
			using (var dbConn = connectionFactory.OpenDbConnection())
			using (var dbCmd = dbConn.CreateCommand())
			{
				runDbCommandsFn(dbCmd);
			}
		}

		public static T Exec<T>(this IDbConnectionFactory connectionFactory, Func<IDbCommand, T> runDbCommandsFn)
		{
			using (var dbConn = connectionFactory.OpenDbConnection())
			using (var dbCmd = dbConn.CreateCommand())
			{
				return runDbCommandsFn(dbCmd);
			}
		}
	}
}