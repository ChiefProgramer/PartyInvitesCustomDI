using Contracts;
using Entities;
using PartyInvitesCustom.Adapters;
using PartyInvitesCustom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvitesCustom.Orchestrators
{
	public class Guests : IGuests {

		private readonly IGuestR _Repository; //Its a Singleton, so this is just reference to a single instance

		public Guests(IGuestR aGuestR, IReopConnection aReopConnection) {
			_Repository =
				aGuestR
					?? throw new ArgumentNullException(nameof(aGuestR));

			_Repository.StartUp(aReopConnection);
		}

		public void Add(GuestResponse aGuestResponse) {
			GuestAdaptor vGuestAd = new GuestAdaptor();

			_Repository.Add(vGuestAd.Adapt(aGuestResponse));
		}

		public List<AttendingGuest> GuestList() {
			List<AttendingGuest> atGuestList = new List<AttendingGuest>();

			var guestList = _Repository.GetAll().Where(r => r.WillAttend == true);

			foreach (var guest in guestList) {
				GuestAdaptor vGuestAd = new GuestAdaptor();

				atGuestList.Add(vGuestAd.Adapt(guest));
			}

			return(atGuestList);
		}
	}
}
