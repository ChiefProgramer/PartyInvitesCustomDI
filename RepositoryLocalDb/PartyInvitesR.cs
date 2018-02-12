namespace RepositoryLocalDb
{
	using System;
	using System.Collections.Generic;
	using Contracts;
	using Entities;

	public class PartyInvitesR: IPartyInvitesR
	{
		public int Count()
		{
			throw new NotImplementedException();

		}

		public void Add(GuestResponse aGuestResponse)
		{
			throw new NotImplementedException();
		}

		public void Update(GuestResponse aGuestResponse)
		{
			throw new NotImplementedException();
		}

		public void Delete(int aGuesResponseId)
		{
			throw new NotImplementedException();
		}

		public GuestResponse Get(int aGuestResponseId)
		{
			throw new NotImplementedException();
		}

		public List<GuestResponse> GetAll() { throw new NotImplementedException(); }

        public List<GuestResponseYes> GetAllGuestResponseYes()
        {
            throw new NotImplementedException();
        }
    }
}