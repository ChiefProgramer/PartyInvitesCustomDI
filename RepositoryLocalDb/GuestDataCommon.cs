using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Contracts;
using Entities;



namespace RepositoryDataCommon {

	public class StartGuestDataCommon : IGuestR {
		DbCreator mDbCreator;
		DataConnector mDataConnector;

		public void StartUp(IReopConnection aReopConnection) {
			mDataConnector = new DataConnector(aReopConnection);
			mDbCreator = new DbCreator(mDataConnector);

			try { mDbCreator.CreateDB(); }
			catch { }

			mDbCreator.CreateTables();
		}

		public int Count() {
			throw new NotImplementedException();

		}

		public void Add(IGuest aGuestResponse) {
			ExecuteNonQuery("insert into Guests (name, email, phone, WillAttend) values(" + aGuestResponse.ToString() + ");");
		}

		public void Update(IGuest aGuestResponse) {
			throw new NotImplementedException();
		}

		public void Delete(int aGuestResponseId) {
			ExecuteNonQuery("DELETE FROM Guests WHERE id =" + aGuestResponseId);
		}

		public IGuest Get(int aGuestResponseId) {
			throw new NotImplementedException();
		}

		public List<IGuest> GetAll() { throw new NotImplementedException(); }

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