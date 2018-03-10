namespace RepositoryMemory {
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Contracts;
	using Entities;

	public class GuestRepositoryMemory : IGuestR {

		private static readonly List<Guest> _Storage =
			new List<Guest>();

		public Task<int> CountAsync() {
			return Task.Run(() => {
				int vResult = _Storage.Count;
			return vResult;
			});
		}

		public void Add(Guest aPartyInvite) {
			_Storage.Add(aPartyInvite);
		}

		public void Update(Guest aPartyInvite) {
			throw new NotImplementedException();
		}

		public void Delete(int aGuesResponseId) {
			throw new NotImplementedException();
		}

		public Task<Guest> GetAsync(int aPartyInviteId) {
				throw new NotImplementedException();
		}

		public Task<List<Guest>> GetAllAsync() {
			return Task.Run(() => {
				return _Storage;
			});
		}

		public void StartUp(IRepoConnection aReopConnection) {
			
		}

		public void StartUp(IRepoConnection aReopConnection, Guest aGuest) {
			throw new NotImplementedException();
		}
	}
}