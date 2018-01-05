namespace Contracts
{
	using System.Collections.Generic;
	using Entities;

	public interface IPartyInvitesR
	{
		int Count();
		void Add(GuestResponse aGuestResponse);
		void Update(GuestResponse aGuestResponse);
		void Delete(int aGuesResponseId);
		GuestResponse Get(int aGuestResponseId);
		List<GuestResponse> GetAll();

	}
}