using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Contracts;
using Entities;



namespace RepositoryDataCommon {

	public class GuestDataCommon : IGuestR {
		DbCreator mDbCreator;
		DataConnector mDataConnector;
		IGuest mGuest; //No DI needed in this project; We can use a sigle DI provided by Core 

		public void StartUp(IReopConnection aReopConnection, IGuest aGuest) {
			mDataConnector = new DataConnector(aReopConnection);
			mDbCreator = new DbCreator(mDataConnector);
			mGuest = aGuest; 

			try { mDbCreator.CreateDB(); }
			catch { }

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
			IGuest aGuest = mGuest.ShallowCopy(); // Get a new copy of Guest object

			//Use SQL to get data; Set poperties on Guest object

			return aGuest;
		}

		public List<IGuest> GetAll() {
			List<IGuest> aGuestList = new List<IGuest>();

			//Do some loop with SOL


			IGuest aGuest = mGuest.ShallowCopy(); // Get a new copy of Guest object


			//Finish Loop

			return aGuestList;

		}

		private bool ExecuteNonQuery(string aCommandText) {
			IDbConnection DataConn = mDataConnector.Connection();
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


	}
}