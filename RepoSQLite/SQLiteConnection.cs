using Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

namespace RepoSQLite 
{
    public class SqliteConnection : IRepoConnection { 
		string m_DbFileName; // "SQLiteDB.sqlite";
		string m_ConnectionString; // "Data Source=" + m_DbFileName + ";"; //Data Source=SQLiteDB.sqlite;
		string m_Database = "";

		//###	Properties

		//Returns Database name-
		public string DatabaseName {
			get { return m_Database; }
			set { m_Database = value; }
		}

		public string ConnectionString {
			get {
				return m_ConnectionString;
			}
			set {
				m_ConnectionString = value;
				m_DbFileName = ParseFileNameFromConnectionString(ConnectionString); //set database name
			}
		}

		//Returns connection string with Database name
		public string DbConnectionString {
			get {
				string dbName = "";
				if (DatabaseName != "") dbName = "; database =" + DatabaseName;

				return ConnectionString + dbName;
			}
		}


		//####	Constuctor

		//I realize using IConfiguration here means this Implementation assumes use with ASP.NET Core
		//However since constructors are not determined by Interfaces, IRepoConnection makes no such assumption
		//I feel it is reasonable to either re-implement IRepoConnection for a non(ASP.NET Core) app or,
		//Sub-class this class and change the constructor to as needed

		public SqliteConnection(IConfiguration aConfiguration) { 
			var vConnectionString = aConfiguration.GetSection("ConnectionStrings:SQLiteConnection");
			ConnectionString = vConnectionString.Value;
		}


		//####	Methods

		//Takes connection string returns SQLiteConnection
		public IDbConnection Connection(string aConnectionString) {
		
			//Create SQLite file if it does not exist
			if (File.Exists(m_DbFileName) == false) {
				SQLiteConnection.CreateFile(m_DbFileName);
			}

			//This is where we provide a SQLite implementation of System.Data.IDbConnection
			var vConnection = new SQLiteConnection(aConnectionString);

			return (vConnection);
		}

		//Returns Open IDbconnection
		public IDbConnection Connection() {
			var vConnection = Connection(DbConnectionString);
			vConnection.Open();

			return (vConnection);
		}


		//###  Private Fuctions ####

		//Parses File Name From Connection String
		private string ParseFileNameFromConnectionString(string ConnectionString) {

			string vFileName = ConnectionString.Substring(ConnectionString.IndexOf("=") + 1, ConnectionString.Length - ConnectionString.IndexOf("=") - 2);

			return vFileName;
		}

	}
}