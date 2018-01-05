using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using PartyInvitesCustom.Models;
using PartyInvitesCustom.Orchestrators;

namespace PartyInvitesCustom.Controllers {

	public class RsvpFormController : Controller {
		private readonly IGuests _Guests; //Its a Singleton, so this is just reference to a single instance

		public RsvpFormController(IGuests aGuest) {
			_Guests =
				aGuest
					?? throw new ArgumentNullException(nameof(aGuest));
		}

		[HttpGet]
		public ViewResult RsvpForm() { return View(); }

		[HttpPost]
		public ViewResult RsvpForm(GuestResponse aGuestResponse) {
			if (ModelState.IsValid) {
				_Guests.Add(aGuestResponse);
				return View("Thanks", aGuestResponse);
			}
			return View();
		}
	}
}