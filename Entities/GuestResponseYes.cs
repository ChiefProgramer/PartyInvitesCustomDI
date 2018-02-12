using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class GuestResponseYes
    {
        // properties
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        //constructors
        public GuestResponseYes() { }
        public GuestResponseYes(GuestResponse aGuestResponse)
        {
            this.Name = aGuestResponse.Name;
            this.Phone = aGuestResponse.Phone;
            this.Email = aGuestResponse.Email;
        }
    }
}
