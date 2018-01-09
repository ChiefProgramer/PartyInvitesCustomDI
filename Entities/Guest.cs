﻿namespace Entities
{

	public class Guest : IGuest { //could call this PartyGuest

		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public bool? WillAttend { get; set; }

		public override string ToString() {

			return "('" + Name + "','" + Email + "','" + Phone + "','" + WillAttend +  "');
		}

	}
}