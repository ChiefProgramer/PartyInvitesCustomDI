using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace RepositoryMySql
{
   public static class DbCreator
    {

		public static bool CreateDB() {
			MySqlConnection vDataConn = DataConnector.Connection(DataConnector.ConnectionString);
			MySqlCommand vDBcmd = vDataConn.CreateCommand();

			vDataConn.Open();
			vDBcmd.CommandText = "CREATE DATABASE IF NOT EXISTS `"+ DataConnector.DatabaseName + "`;";
			vDBcmd.ExecuteNonQuery();
			vDataConn.Close();

			return true;
		}

		public static bool CreateTables() {
			MySqlConnection vDataConn = DataConnector.Connection();
			MySqlCommand vDBcmd = vDataConn.CreateCommand();

			vDataConn.Open();
			vDBcmd.CommandText = "CREATE TABLE IF NOT EXISTS `Guests`(`id` INT AUTO_INCREMENT, `name` TEXT, `email` TEXT, `phone` TEXT, `WillAttend` TEXT, PRIMARY KEY(id))";
			vDBcmd.ExecuteNonQuery();
			vDataConn.Close();

			return true;
		}

	}
}
