using Contracts;
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace RepoSQLite
{
    public class SqliteConnection : IReopConnection { 

		const string m_DbFileName = "SQLiteDB.sqlite";
		const string m_ConnectionString = "Data Source=" + m_DbFileName + ";";
		const string m_Database = "";


		public IDbConnection Connection(string aConnectionString) {

			if (File.Exists(m_DbFileName) == false) {
				SQLiteConnection.CreateFile(m_DbFileName);
			}

			var vConnection = new SQLiteConnection(aConnectionString);

			return (vConnection);
		}

		public string ConnectionString {
			get { return m_ConnectionString; }
		}

		public string DatabaseName {
			get { return m_Database; }
		}
	}
}