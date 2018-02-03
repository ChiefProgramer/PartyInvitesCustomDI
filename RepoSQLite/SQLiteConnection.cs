using Contracts;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

namespace RepoSQLite
{
    public class SqliteConnection : IRepoConnection { 

		const string m_DbFileName = "SQLiteDB.sqlite";
		const string m_ConnectionString = "Data Source=" + m_DbFileName + ";";
		const string m_Database = "";

		public string ConnectionString {
			get { return m_ConnectionString; }
		}

		public string DatabaseName {
			get { return m_Database; }
		}

		//Takes connection string returns SQLiteConnection
		public IDbConnection Connection(string aConnectionString) {
			//Create SQLite file if it does not exist

			if (File.Exists(m_DbFileName) == false) {
				SQLiteConnection.CreateFile(m_DbFileName);
			}

			var vConnection = new SQLiteConnection(aConnectionString);

			return (vConnection);
		}


	}
}