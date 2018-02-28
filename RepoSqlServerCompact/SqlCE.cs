using Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlServerCe;
using System.Data;
using System.IO;

namespace RepoSqlServerCompact
{
	public class SqlCeConnection : IRepoConnection {
		string m_DbFileName; // "SqlCeDB.sdf";
		string m_ConnectionString; //"data source=SqlCeDB.sdf;password=596b8c4dfd9207b6;encrypt database=TRUE"
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
		private string DbConnectionString {
			get { return ConnectionString; }
		}

		//####	Constuctor

		//I realize using IConfiguration here means this Implementation assumes use with ASP.NET Core
		//However since constructors are not determined by Interfaces, IRepoConnection makes no such assumption
		//I feel it is reasonable to either re-implement IRepoConnection for a non(ASP.NET Core) app or,
		//Sub-class this class and change the constructor to as needed

		public SqlCeConnection(IConfiguration aConfiguration) {
			var vConnectionString = aConfiguration.GetSection("ConnectionStrings:SqlCeConnection");
			ConnectionString = vConnectionString.Value;
		}

		//####	Methods

		//Takes connection string returns SqlCeConnection
		public IDbConnection Connection(string aConnectionString) {

			//Create SQLite file if it does not exist
			if (File.Exists(m_DbFileName) == false) {
				SqlCeEngine SqlEngine = new SqlCeEngine(aConnectionString);
				SqlEngine.CreateDatabase();
				SqlEngine.Dispose();
			}

			//This is where we provide a SqlCe implementation of System.Data.IDbConnection
			var vConnection = new System.Data.SqlServerCe.SqlCeConnection();

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
			
			string vFileName = ConnectionString.Substring(ConnectionString.IndexOf("=") + 1, ConnectionString.IndexOf(";") - ConnectionString.IndexOf("=") - 1);

			return vFileName;
		}

	}
}
