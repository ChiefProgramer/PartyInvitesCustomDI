using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Contracts;
using Entities;



namespace RepositoryDataCommon {

	public class GuestDataCommon : IGuestR {
		private IRepoConnection mDataConnector;

		public GuestDataCommon(IRepoConnection aRepoConnection) {
			mDataConnector = aRepoConnection; 

			SetupDataBase();
		}

		//this creates DB and add tables... if needed
		private void SetupDataBase() {
			DbCreator mDbCreator = new DbCreator(mDataConnector);

			//if this fails its becasue we did not need to do this 
			mDbCreator.CreateDB();  
			mDbCreator.CreateTables();
		}

		public int Count() {
			int vRecordCount;
			IDbConnection DataConn = mDataConnector.Connection();
			IDbCommand DBcmd = DataConn.CreateCommand();

			DBcmd.CommandText = "SELECT COUNT(*) From Guests";

			vRecordCount = int.Parse(DBcmd.ExecuteScalar().ToString());

			DataConn.Close();
			return vRecordCount;
		}

		public void Add(IGuest aGuest) {
			ExecuteNonQuery("insert into Guests (name, email, phone, WillAttend) values(" + aGuest.ToString() + ");");
		}

		public void Update(IGuest aGuest) {
			throw new NotImplementedException();
		}

		public void Delete(int aGuestId) {
			ExecuteNonQuery("DELETE FROM Guests WHERE id =" + aGuestId);
		}

		public IGuest Get(int aGuestId) {
			//Use SQL to get data; Set poperties on Guest object
			IDbConnection DataConn = mDataConnector.Connection();//Gets open connection to Database
			var vReader = GetReader(DataConn, "SELECT * From Guests WHERE id = aGuestId"); //Execute SQL returns IDataReader

			//if there is nothing to read; return null
			IGuest aGuest = null; 

			if (vReader.Read()) {
				aGuest = new Guest();
				aGuest = MapReaderToGuest(vReader, aGuest); //Set poperties on Guest object
			}

			DataConn.Close();
			return aGuest;
		}

		public List<IGuest> GetAll() {
			List<IGuest> aGuestList = new List<IGuest>();
			IDbConnection DataConn = mDataConnector.Connection();//Gets open connection to Database

			var vReader = GetReader(DataConn, "SELECT * From Guests"); //Execute SQL returns IDataReader

			while (vReader.Read()) {
				IGuest aGuest = new Guest(); 

				aGuest = MapReaderToGuest(vReader, aGuest); //Set poperties on Guest object
				aGuestList.Add(aGuest);
			}

			DataConn.Close();
			return aGuestList;
		}


		//Execute SQL returns IDataReader
		private IDataReader GetReader(IDbConnection DataConn, string aCommandText) {
			IDbCommand DBcmd = DataConn.CreateCommand();

			DBcmd.CommandText = aCommandText;
			var vReader = DBcmd.ExecuteReader();

			DBcmd.Dispose();

			return vReader;
		}

		//Execute SQL returns true if sucessful;
		private bool ExecuteNonQuery(string aCommandText) {
			IDbConnection DataConn = mDataConnector.Connection(); //Gets open connection to Database
			IDbCommand DBcmd = DataConn.CreateCommand();

			try {
			DBcmd.CommandText = aCommandText;
			DBcmd.ExecuteNonQuery();
			} catch {
				DBcmd.Dispose();
				DataConn.Close();
				return false;
			}

			DBcmd.Dispose();
			DataConn.Close();
			return true;
		}

		//Sets poperties on Guest object
		private IGuest MapReaderToGuest(IDataReader aReader,IGuest aGuest) {

			aGuest.Name = aReader.GetString(1);
			aGuest.Email = aReader.GetString(2);
			aGuest.Phone = aReader.GetString(3);
			string vWillAttend = aReader.GetString(4);
			if (vWillAttend.ToLower() == "true") {
				aGuest.WillAttend = true;
			}
			else {
				aGuest.WillAttend = false;
			}

			return aGuest;
		}


	}
}