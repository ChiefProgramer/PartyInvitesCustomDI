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
			IDbConnection DataConn = mDataConnector.Connection();
			IDbCommand DBcmd = DataConn.CreateCommand();

			//try {
			DBcmd.CommandText = "";
			DBcmd.ExecuteNonQuery();
			//} catch { }

			DataConn.Close();
		}

		public void Update(IGuest aGuestResponse) {
			throw new NotImplementedException();
		}

		public void Delete(int aGuesResponseId) {
			throw new NotImplementedException();
		}

		public IGuest Get(int aGuestResponseId) {
			throw new NotImplementedException();
		}

		public List<IGuest> GetAll() { throw new NotImplementedException(); }


	}
}