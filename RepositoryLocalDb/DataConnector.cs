using Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace RepositoryDataCommon { 


	public class DataConnector {
		private IReopConnection ReopConnection;

		public DataConnector(IReopConnection aReopConnection) {
			ReopConnection = aReopConnection;
		}

		public string ConnectionString {
			get { return ReopConnection.ConnectionString; }
		}

		public string DbConnectionString { 
			get {
				string dbName = "";
				if (ReopConnection.DatabaseName != "") dbName = "; database =" + ReopConnection.DatabaseName;

				return ReopConnection.ConnectionString + dbName; }
		}

		public string DatabaseName {
			get { return ReopConnection.DatabaseName; }
		}

		public IDbConnection Connection() {
			var vConnection = ReopConnection.Connection(DbConnectionString);

			return (vConnection);
		}

		public IDataAdapter DataAdapter() { //Not sure about this
			return ReopConnection.DataAdapter();
		}

		public IDbConnection Connection(string aConnectionString) {

			var vConnection = ReopConnection.Connection(aConnectionString);

			return (vConnection);
		}


	}


}
