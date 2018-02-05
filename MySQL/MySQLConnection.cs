using System;
using System.Data;
using System.Data.SqlClient;
using Contracts;
using MySql.Data.MySqlClient;

namespace ReopMySQL
{
    public class MySQLConnection : IRepoConnection {
		string m_Database = "Party";
		string m_ConnectionString;


		public IDbConnection Connection(string aConnectionString) {

			var vConnection = new MySqlConnection { ConnectionString = aConnectionString };

			return (vConnection);
		}

		public string ConnectionString {
			get {return m_ConnectionString;}
			set { m_ConnectionString = value; }
		}

		public string DatabaseName {
			get {return m_Database;}
			set { m_Database = value;} 
		}
	}
}
