using Contracts;
using Entities;
using PartyInvitesCustom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvitesCustom.Orchestrators
{
	public class Guests : IGuests {

		private readonly IGuestR _Repository; //Its a Singleton, so this is just reference to a single instance

		public Guests(IGuestR aGuestR) {
			_Repository =
				aGuestR
					?? throw new ArgumentNullException(nameof(aGuestR));
		}

		public void Add(GuestResponse aGuestResponse) {
			IGuest vGuest = new Guest();
			vGuest.Name = aGuestResponse.Name;
			vGuest.Email = aGuestResponse.Email;
			vGuest.Phone = aGuestResponse.Phone;
			vGuest.WillAttend = aGuestResponse.WillAttend;

			_Repository.Add(vGuest);

		}

		public List<AttendingGuest> GuestList() {
			List<AttendingGuest> atGuestList = new List<AttendingGuest>();

			var guestList = _Repository.GetAll().Where(r => r.WillAttend == true);
			foreach (var guest in guestList) {
				AttendingGuest atGuest = new AttendingGuest();
				atGuest.Name = guest.Name;
				atGuest.Email= guest.Email;
				atGuest.Phone = guest.Phone;

				atGuestList.Add(atGuest);
			}

			return(atGuestList);
		}


		//

	}
}
