using Entities;
using PartyInvitesCustom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvitesCustom.Adapters
{
	public class GuestAdaptor {

		public Guest Adapt(GuestResponse aGuestResponse) {

			Guest vGuest = new Guest();
			vGuest.Name = aGuestResponse.Name;
			vGuest.Email = aGuestResponse.Email;
			vGuest.Phone = aGuestResponse.Phone;
			vGuest.WillAttend = aGuestResponse.WillAttend;

			return vGuest;
		}


		public AttendingGuest Adapt(Guest aGuest) {

			AttendingGuest vAttGuest = new AttendingGuest();
			vAttGuest.Name = aGuest.Name;
			vAttGuest.Email = aGuest.Email;
			vAttGuest.Phone = aGuest.Phone;

			return vAttGuest;
		}




	}
}
