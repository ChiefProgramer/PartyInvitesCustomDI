using Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace xData_Layer_EFCore_SqlServerCompact
{
    public class PartyInvitesContext_SqlCE : PartyInvitesContext {
		IRepoEFCoreConnection mRepoEFCoreConnection;


		public PartyInvitesContext_SqlCE(IRepoEFCoreConnection RepoEFCoreConnection) {
			mRepoEFCoreConnection = RepoEFCoreConnection;



		}


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlCe(mRepoEFCoreConnection.ConnectionString);

		}
    
    }
}
