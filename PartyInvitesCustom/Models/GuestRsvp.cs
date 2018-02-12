// This is supposed to represent the people who said they would 
// attend the party. GuestResponse.cs's where will attend = true

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvitesCustom.Models
{
    public class GuestRsvp
    {
        public GuestRsvp(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
       
    }
}
