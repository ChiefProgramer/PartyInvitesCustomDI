using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;


namespace RepositoryDataCommon {

   public class DbCreator {

		private DataConnector mDataConnector;

		public DbCreator(DataConnector aDataConnector) {
			mDataConnector = aDataConnector;

		}

		//Creates Database if needed
		public bool CreateDB() {
			IDbConnection vDataConn = mDataConnector.Connection(mDataConnector.ConnectionString);
			IDbCommand vDBcmd = vDataConn.CreateCommand();

			vDataConn.Open();
			vDBcmd.CommandText = "CREATE DATABASE IF NOT EXISTS `" + mDataConnector.DatabaseName + "`;";
			vDBcmd.ExecuteNonQuery();
			vDBcmd.Dispose();
			vDataConn.Close();

			return true;
		}
		//Creates Tables if needed
		public bool CreateTables() {
			IDbConnection vDataConn = mDataConnector.Connection();
			IDbCommand vDBcmd = vDataConn.CreateCommand();

			vDataConn.Open();
			vDBcmd.CommandText = "CREATE TABLE IF NOT EXISTS `Guests`(`id` INT AUTO_INCREMENT, `name` TEXT, `email` TEXT, `phone` TEXT, `WillAttend` TEXT, PRIMARY KEY(id))";
			vDBcmd.ExecuteNonQuery();
			vDBcmd.Dispose();
			vDataConn.Close();

			return true;
		}

	}
}
