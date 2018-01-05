namespace PartyInvitesCustom.Controllers
{
	using System;
	using System.Diagnostics;
	using System.Linq;
	using Contracts;
	using Entities;
	using Microsoft.AspNetCore.Mvc;
	using Models;
	//using RepositoryMemory;

	public class HomeController: Controller
	{
		private readonly IPartyInvitesR _Repository;

		public HomeController(IPartyInvitesR aPartyInvitesR)
		{
			_Repository = 
				aPartyInvitesR 
					?? throw new ArgumentNullException(nameof(aPartyInvitesR));
			// Repository now supplied by DI
			//_Repository = new PartyInvitesR();
		}

		[HttpGet]
		public IActionResult Index()
		{
			//			return View();
			int vHour = DateTime.Now.Hour;
			ViewBag.Greeting = (vHour < 12) ? "Good Morning" : "Good Afternoon";
			return View("MyIndex");
		}

		[HttpGet]
		public ViewResult RsvpForm() { return View(); }

		[HttpPost]
		public ViewResult RsvpForm(GuestResponse aGuestResponse)
		{
			if (ModelState.IsValid)
			{
				_Repository.Add(aGuestResponse);
				return View("Thanks", aGuestResponse);
			}
			return View();
		}

		public IActionResult About()
		{
			ViewBag.Message = "Your application description goes here on this page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public IActionResult Error()
		{
			return View
			(
				new ErrorViewModel
				{
					RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
				}
			);
		}

		public IActionResult ListResponses()
		{
			return View(_Repository.GetAll().Where(r => r.WillAttend == true));
		}
	}
}