using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
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

		public Task<int> CountAsync() {
			return Task.Run(() => {

			int vRecordCount;
			IDbConnection DataConn = mDataConnector.Connection();
			IDbCommand DBcmd = DataConn.CreateCommand();

			DBcmd.CommandText = "SELECT COUNT(*) From Guests";

			vRecordCount = int.Parse(DBcmd.ExecuteScalar().ToString());

			DataConn.Close();
			return vRecordCount;
			});
		}

		public void Add(Guest aGuest) {
			Task.Run(() => {
				ExecuteNonQuery("insert into Guests (name, email, phone, WillAttend) values(" + aGuest.ToString() + ");");
			});
		}


		public void Update(Guest aGuest) {
			Task.Run(() => {
				throw new NotImplementedException();
			});
		}

		public void Delete(int aGuestId) {
			Task.Run(() => {
				ExecuteNonQuery("DELETE FROM Guests WHERE id =" + aGuestId);
			});
		}

		public Task<Guest> GetAsync(int aGuestId) {
			return Task.Run(() => {

				//Use SQL to get data; Set poperties on Guest object
				IDbConnection DataConn = mDataConnector.Connection();//Gets open connection to Database
				var vReader = GetReader(DataConn, "SELECT * From Guests WHERE id = aGuestId"); //Execute SQL returns IDataReader

				//if there is nothing to read; return null
				Guest aGuest = null;

				if (vReader.Read()) {
					aGuest = new Guest();
					aGuest = MapReaderToGuest(vReader, aGuest); //Set poperties on Guest object
				}

				DataConn.Close();
				return aGuest;
			});
		}

		public Task<List<Guest>> GetAllAsync() {
			return Task.Run(() => {

				List<Guest> aGuestList = new List<Guest>();
				IDbConnection DataConn = mDataConnector.Connection();//Gets open connection to Database

				var vReader = GetReader(DataConn, "SELECT * From Guests"); //Execute SQL returns IDataReader

				while (vReader.Read()) {
					Guest aGuest = new Guest();

					aGuest = MapReaderToGuest(vReader, aGuest); //Set poperties on Guest object
					aGuestList.Add(aGuest);
				}

				DataConn.Close();
				return aGuestList;
			});
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
		private Guest MapReaderToGuest(IDataReader aReader,Guest aGuest) {

			aGuest.Id = aReader.GetInt32(0);
			aGuest.Name = aReader.GetString(1);
			aGuest.Email = aReader.GetString(2);
			aGuest.Phone = aReader.GetString(3);
			aGuest.WillAttend = aReader.GetBoolean(4);

			return aGuest;
		}


	}
}