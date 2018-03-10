using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Contracts;

namespace xData_Layer_EFCore_SQLite {
	

	public class PartyInvitesContext_SQLite : PartyInvitesContext {
		IRepoEFCoreConnection mRepoEFCoreConnection;


		public PartyInvitesContext_SQLite(IRepoEFCoreConnection RepoEFCoreConnection)  {
			mRepoEFCoreConnection = RepoEFCoreConnection;



		}


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlite(mRepoEFCoreConnection.ConnectionString);

		}



	}
}
