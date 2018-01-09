namespace RepositoryMemory {
	using System;
	using System.Collections.Generic;
	using Contracts;
	using Entities;

	public class GuestR : IGuestR {

		private static readonly List<IGuest> _Storage =
			new List<IGuest>();

		public int Count() {
			int vResult = _Storage.Count;
			return vResult;
		}

		public void Add(IGuest aPartyInvite) {
			_Storage.Add(aPartyInvite);
		}

		public void Update(IGuest aPartyInvite) {
			throw new NotImplementedException();
		}

		public void Delete(int aGuesResponseId) {
			throw new NotImplementedException();
		}

		public IGuest Get(int aPartyInviteId) {
			throw new NotImplementedException();
		}

		public List<IGuest> GetAll() { return _Storage; }

		public void StartUp(IReopConnection aReopConnection) {
			
		}
	}
}