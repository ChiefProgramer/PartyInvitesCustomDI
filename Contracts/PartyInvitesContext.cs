using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Contracts
{
	public abstract class PartyInvitesContext : DbContext, IPartyInvitesContext {

		public DbSet<Guest> Guests { get; set; }

		 
	}
}
