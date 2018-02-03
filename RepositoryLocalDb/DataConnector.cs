using Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace RepositoryDataCommon { 


	public class DataConnector {
		private IRepoConnection RepoConnection;

		public DataConnector(IRepoConnection aRepoConnection) {
			RepoConnection = aRepoConnection;
		}

		//Returns connection string
		public string ConnectionString {
			get { return RepoConnection.ConnectionString; }
		}

		//Returns connection string with Database name
		public string DbConnectionString { 
			get {
				string dbName = "";
				if (RepoConnection.DatabaseName != "") dbName = "; database =" + RepoConnection.DatabaseName;

				return RepoConnection.ConnectionString + dbName; }
		}

		//Returns Database name
		public string DatabaseName {
			get { return RepoConnection.DatabaseName; }
		}

		//Returns Open IDbconnection
		public IDbConnection Connection() {
			var vConnection = RepoConnection.Connection(DbConnectionString);
			vConnection.Open();

			return (vConnection);
		}

		//Take connection string returns IDbconnection 
		public IDbConnection Connection(string aConnectionString) {

			var vConnection = RepoConnection.Connection(aConnectionString);

			return (vConnection);
		}
	}
}
