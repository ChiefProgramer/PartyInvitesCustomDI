	using System;
	using System.Collections.Generic;
	using Contracts;
	using Entities;
	using MySql.Data.MySqlClient;


namespace RepositoryMySql {

	public class GuestMySql : IGuestR {

		public GuestMySql() {
			DbCreator.CreateDB();
			DbCreator.CreateTables();
		}

		public int Count() {
			throw new NotImplementedException();
			  
		}

		public void Add(IGuest aGuestResponse) {
			throw new NotImplementedException();
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