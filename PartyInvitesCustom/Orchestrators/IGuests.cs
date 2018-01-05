using PartyInvitesCustom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvitesCustom.Orchestrators
{
   public interface IGuests
    {
		void Add(GuestResponse aGuestResponse);

		List<AttendingGuest> GuestList();
	}
}
