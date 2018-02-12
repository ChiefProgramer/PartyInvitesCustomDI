namespace PartyInvitesCustom.Controllers
{
	using System;
	using System.Diagnostics;
	using System.Linq;
	using Contracts;
	using Entities;
	using Microsoft.AspNetCore.Mvc;
	using Models;
    using System.Collections.Generic;

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
			int vHour = DateTime.Now.Hour;
			ViewBag.Greeting = (vHour < 12) ? "Good Morning" : "Good Afternoon";
			return View("MyIndex");
		}

		[HttpGet]
		public ViewResult RsvpForm() { return View(); }

        //no need for a view model, it won't reduce memory usage right since the method
        //has already stored the whole aGuestResponse object?
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
            // view model constructor, list of guestreponseyes constructor, repo call to get a list of guestresponseyes
             return View(
                 new ListResponsesViewModel(
                     new List<GuestResponseYes>(
                         _Repository.GetAllGuestResponseYes()
                         )
                     )
                 );

            //return View(_Repository.GetAllGuestResponseYes());
            //return View(new ListResponsesViewModel(_Repository.GetAllGuestResponseYes()));
        }
	}
}