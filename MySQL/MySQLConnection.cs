﻿using System;
using System.Data;
using System.Data.SqlClient;
using Contracts;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ReopMySQL
{ 
    public class MySQLConnection : IRepoConnection {
		string m_Database;
		string m_ConnectionString;

		//###	Properties-

		public string ConnectionString {
			get { return m_ConnectionString; }
			set { m_ConnectionString = value; }
		}

		public string DatabaseName {
			get { return m_Database; }
			set { m_Database = value; }
		}


		//Returns connection string with Database name
		private string ConnectionStringWithDBname {
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

		public MySQLConnection(IConfiguration aConfiguration) {

			var vConnectionString = aConfiguration.GetSection("ConnectionStrings:MySQLConnection");
			ConnectionString = vConnectionString.Value;
		}


		//####	Methods

		//Takes connection string returns MySQLConnection
		public IDbConnection Connection(string aConnectionString) {
			ConnectionString = aConnectionString;

			return (Connection());
		}


		//Returns Open IDbconnection
		public IDbConnection Connection() {
			//This is where we provide a MySql implementation of System.Data.IDbConnection
			var vConnection = new MySqlConnection { ConnectionString = ConnectionStringWithDBname };
			vConnection.Open();

			return (vConnection);
		}
	}
}
