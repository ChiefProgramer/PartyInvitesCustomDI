using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PartyInvitesCustom.Orchestrators;

namespace PartyInvitesCustom.Controllers {
	public class ListResponsesController : Controller {
		private readonly IGuests _Guests; //Its a Singleton, so this is just reference to a single instance

		public ListResponsesController(IGuests aGuests) {
			_Guests = 
				aGuests
					?? throw new ArgumentNullException(nameof(aGuests));

		}

		public IActionResult ListResponses() {
			return View(_Guests.GuestList());
		}
	}
}