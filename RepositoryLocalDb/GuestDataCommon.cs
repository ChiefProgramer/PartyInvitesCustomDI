using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Contracts;
using Entities;



namespace RepositoryDataCommon {

	public class GuestDataCommon : IGuestR {
		private DbCreator mDbCreator;
		private DataConnector mDataConnector;

		public GuestDataCommon(IRepoConnection aRepoConnection) {
			mDataConnector = new DataConnector(aRepoConnection); 
			mDbCreator = new DbCreator(mDataConnector);

			StartUp();
		}

		//this creates DB and add tables... if needed
		public void StartUp() {

			try { mDbCreator.CreateDB(); }
			catch { } //if this fails its becasue we did not need to do this 

			mDbCreator.CreateTables();
		}



		public int Count() {
			throw new NotImplementedException();

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

			var vReader = GetReader("SELECT * From Guests WHERE id = aGuestId"); //Execute SQL returns IDataReader

			IGuest aGuest = new Guest();

			if (vReader.Read()) {

				aGuest = MapReaderToGuest(vReader, aGuest); //Set poperties on Guest object
			}

			return aGuest;
		}

		public List<IGuest> GetAll() {
			List<IGuest> aGuestList = new List<IGuest>();

			var vReader = GetReader("SELECT * From Guests"); //Execute SQL returns IDataReader

			while (vReader.Read()) {
				IGuest aGuest = new Guest(); // Get a new copy of Guest object

				aGuest = MapReaderToGuest(vReader, aGuest);

				aGuestList.Add(aGuest);
			}

			return aGuestList;

		}


		//Execute SQL returns IDataReader
		private IDataReader GetReader(string aSQLstring) {

			List<IGuest> aGuestList = new List<IGuest>();
			IDbConnection DataConn = mDataConnector.Connection(); //Gets open connection to Database
			IDbCommand DBcmd = DataConn.CreateCommand();

			DBcmd.CommandText = "aSQLstring";
			var vReader = DBcmd.ExecuteReader();

			return vReader;
		}

		//Execute SQL returns ture if sucessful;
		private bool ExecuteNonQuery(string aCommandText) {
			IDbConnection DataConn = mDataConnector.Connection(); //Gets open connection to Database
			IDbCommand DBcmd = DataConn.CreateCommand();

			try {
			DBcmd.CommandText = aCommandText;
			DBcmd.ExecuteNonQuery();
			} catch {
				DataConn.Close();
				return false;
			}
		
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