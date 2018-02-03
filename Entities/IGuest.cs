using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
  public interface IGuest {//could call this IPartyGuest

		int Id { get; set; }
		string Name { get; set; }
		string Email { get; set; }
		string Phone { get; set; }
		bool? WillAttend { get; set; }
	}
}
