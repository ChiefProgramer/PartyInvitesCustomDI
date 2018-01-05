using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvitesCustom.Models;

namespace PartyInvitesCustom.Controllers {
	public class ErrorController : Controller {

		public IActionResult Error() {
			return View
			(
				new ErrorViewModel {
					RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
				}
			);
		}
	}
}