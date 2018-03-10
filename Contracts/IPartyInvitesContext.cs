using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
   public interface IPartyInvitesContext {

		DbSet<Guest> Guests { get; set; }
	}
}
