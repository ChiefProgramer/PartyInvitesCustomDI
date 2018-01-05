namespace PartyInvitesCustom.Controllers {
	using System;
	using Microsoft.AspNetCore.Mvc;

	//using RepositoryMemory;

	public class HomeController : Controller {
		
		[HttpGet]
		public IActionResult Index() {
			//			return View();
			int vHour = DateTime.Now.Hour;
			ViewBag.Greeting = (vHour < 12) ? "Good Morning" : "Good Afternoon";
			return View("MyIndex");
		}
	}
}