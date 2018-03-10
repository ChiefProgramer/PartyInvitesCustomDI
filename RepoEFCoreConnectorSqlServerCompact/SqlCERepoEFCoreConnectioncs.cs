using Contracts;
using Microsoft.Extensions.Configuration;
using System;

namespace RepoEFCoreConnectorSqlServerCompact
{
	public class SqlCEEFCoreConnection : IRepoEFCoreConnection {

		string m_DbFileName; // "SqlCeDB.sdf";
		string m_ConnectionString; //"data source=SqlCeDB.sdf;password=596b8c4dfd9207b6;encrypt database=TRUE"
		string m_Database = "";

		//###	Properties

		//Returns Database name-
		public string DatabaseName {
			get { return m_Database; }
			set { m_Database = value; }
		}

		public string DbFileName{
			get { return m_DbFileName ; }
			set { m_DbFileName = value; }
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

		//####	Constuctor
		public SqlCEEFCoreConnection(IConfiguration aConfiguration) {
			var vConnectionString = aConfiguration.GetSection("ConnectionStrings:SqlCeConnection");
			ConnectionString = vConnectionString.Value;
		}


		//###  Private Fuctions ####

		//Parses File Name From Connection String
		private string ParseFileNameFromConnectionString(string ConnectionString) {

			string vFileName = ConnectionString.Substring(ConnectionString.IndexOf("=") + 1, ConnectionString.IndexOf(";") - ConnectionString.IndexOf("=") - 1);

			return vFileName;
		}
	}
}
