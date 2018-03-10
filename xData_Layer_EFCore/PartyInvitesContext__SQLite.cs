using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Contracts;

namespace xData_Layer_EFCore_SQLite {
	

	public class PartyInvitesContext__SQLite : DbContext {

		//public PartyInvitesContext__SQLite(DbContextOptions<PartyInvitesContext__SQLite> options) : base(options) {
		//}

		public DbSet<Guest> Guests { get; set; }

	}
}
