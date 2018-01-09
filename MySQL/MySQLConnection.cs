using System;
using System.Data;
using System.Data.SqlClient;
using Contracts;

namespace ReopMySQL
{
    public class MySQLConnection : IReopConnection {

		const string m_ConnectionString = "server=localhost;user id=root;password=596b8c4dfd9207b6;persistsecurityinfo=True;port=3305";
		const string m_Database = "Party";


		public IDbConnection Connection(string aConnectionString) {

			var vConnection = new SqlConnection { ConnectionString = aConnectionString };

			return (vConnection);
		}

		public string ConnectionString {
			get {return m_ConnectionString;}
		}

		public string DatabaseName {
			get {return m_Database;}
		}
	}
}
