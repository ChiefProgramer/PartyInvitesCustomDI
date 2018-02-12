// All we need on this one is a collection of people who rsvp'd.  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
namespace PartyInvitesCustom.Models
{
    public class ListResponsesViewModel
    {
        //all we need for this view is a list of guests who have said Rsvp'd yes
        public ICollection<GuestResponseYes> Attendees { get; set; }

        //constructors

        public ListResponsesViewModel(){}

        public ListResponsesViewModel(ICollection<GuestResponse> GuestResponsesYes)
        {
            foreach(GuestResponse g in GuestResponsesYes)
            {
                this.Attendees.Add(new GuestResponseYes(g));
            }
        }

        public ListResponsesViewModel(ICollection<GuestResponseYes> GuestResponsesYes)
        {
            this.Attendees = new List<GuestResponseYes>();

            foreach(GuestResponseYes g in GuestResponsesYes)
            {
                this.Attendees.Add(g);
            }           
        }
        
    }

    
}
