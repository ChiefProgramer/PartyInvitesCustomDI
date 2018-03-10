using System;
using Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using xData_Layer_EFCore_SQLite;

namespace RepoRFCoreConnectorSQLite
{
	public class SqliteEFCoreConnection : IRepoEFCoreConnection {

		private string m_DbFileName; // "SQLiteDB.sqlite";
		private string m_ConnectionString; // "Data Source=" + m_DbFileName + ";"; //Data Source=SQLiteDB.sqlite;

		//###	Properties
		public string ConnectionString {
			get {
				return m_ConnectionString;
			}
			set {
				m_ConnectionString = value;
				m_DbFileName = ParseFileNameFromConnectionString(ConnectionString); //set database name
			}
		}

		public string DbFileName {
			get {
				return m_DbFileName;
			}
		}

		//####	Constuctor
		public SqliteEFCoreConnection(IConfiguration aConfiguration) {
			var vConnectionString = aConfiguration.GetSection("ConnectionStrings:SQLiteConnection");
			ConnectionString = vConnectionString.Value;
		}



		//###  Private Fuctions ####

		//Parses File Name From Connection String
		private string ParseFileNameFromConnectionString(string ConnectionString) {

			string vFileName = ConnectionString.Substring(ConnectionString.IndexOf("=") + 1, ConnectionString.Length - ConnectionString.IndexOf("=") - 2);

			return vFileName;
		}
	}
}