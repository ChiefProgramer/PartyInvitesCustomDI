using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryMySql {
	public static class DataConnector {
		private static string m_ConnectionString = "server=localhost;user id=root;password=596b8c4dfd9207b6;persistsecurityinfo=True;port=3305";
		private static string m_Database = "Party";

		public static string ConnectionString {
			get { return m_ConnectionString; }
		}

		public static string DbConnectionString { 
			get { return m_ConnectionString +"; database =" + m_Database; }
		}

		public static string DatabaseName {
			get { return m_Database; }
		}

		public static MySqlConnection Connection() {
			var vConnection = new MySqlConnection {ConnectionString = DbConnectionString};

			return (vConnection);
		}

		public static MySqlConnection Connection(string aConnectionString) {
			var vConnection = new MySqlConnection { ConnectionString = aConnectionString };

			return (vConnection);
		}


	}


}
