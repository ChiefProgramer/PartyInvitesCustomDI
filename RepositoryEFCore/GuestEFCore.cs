using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RepositoryEFCore
{
    public class GuestEFCore : IGuestR {
		private PartyInvitesContext mEFCoreContext;

		public GuestEFCore(PartyInvitesContext aEFCoreContext) {
			mEFCoreContext = aEFCoreContext;
		}


		//####	Methods
		public void Add(Guest aGuest) {
			mEFCoreContext.Guests.Add(aGuest);
			SaveChangesAsync();
		}


		public async Task<int> CountAsync() {
			var vGuestList = await mEFCoreContext.Guests.ToListAsync();

			return vGuestList.Count;
		}

		public async void Delete(int aGuestId) {
			var Guest = await mEFCoreContext.Guests.FirstOrDefaultAsync(g => g.Id == aGuestId);
			mEFCoreContext.Guests.Remove(Guest);
			SaveChangesAsync();
		}

		public async Task<Guest> GetAsync(int aGuestId) {
			return await mEFCoreContext.Guests.FirstOrDefaultAsync(g => g.Id == aGuestId);
		}

		public async Task<List<Guest>> GetAllAsync() {
			return await mEFCoreContext.Guests.ToListAsync();

		}

		public void Update(Guest aGuest) {
			mEFCoreContext.Guests.Update(aGuest);
			SaveChangesAsync();
		}

		private void SaveChangesAsync() {
			mEFCoreContext.SaveChangesAsync();

		}


	}

}
