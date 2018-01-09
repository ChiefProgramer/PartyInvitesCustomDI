using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;


namespace RepositoryDataCommon {

   public class DbCreator {

		DataConnector mDataConnector;

		public DbCreator(DataConnector aDataConnector) {
			mDataConnector = aDataConnector;

		}

		public bool CreateDB() {
			IDbConnection vDataConn = mDataConnector.Connection(mDataConnector.ConnectionString);
			IDbCommand vDBcmd = vDataConn.CreateCommand();

			vDataConn.Open();
			vDBcmd.CommandText = "CREATE DATABASE IF NOT EXISTS `"+ mDataConnector.DatabaseName + "`;";
			vDBcmd.ExecuteNonQuery();
			vDataConn.Close();

			return true;
		}

		public bool CreateTables() {
			IDbConnection vDataConn = mDataConnector.Connection();
			IDbCommand vDBcmd = vDataConn.CreateCommand();

			vDataConn.Open();
			vDBcmd.CommandText = "CREATE TABLE IF NOT EXISTS `Guests`(`id` INT AUTO_INCREMENT, `name` TEXT, `email` TEXT, `phone` TEXT, `WillAttend` TEXT, PRIMARY KEY(id))";
			vDBcmd.ExecuteNonQuery();
			vDataConn.Close();

			return true;
		}

	}
}
