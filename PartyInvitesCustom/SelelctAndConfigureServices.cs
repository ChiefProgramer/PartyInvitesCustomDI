using Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReopMySQL;
using RepoEFCoreConnectorSqlServerCompact;
using RepoRFCoreConnectorSQLite;
using RepositoryDataCommon;
using RepositoryEFCore;
using RepositoryMemory;
using RepoSQLite;
using RepoSqlServerCompact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xData_Layer_EFCore_SQLite;
using xData_Layer_EFCore_SqlServerCompact;

namespace PartyInvitesCustom
{
	public static class SelelctAndConfigureServices {

		//Select Which implementation of the Repository to Use
		public static void SelectRepoService(IServiceCollection aServices, IConfiguration aConfiguration) {

			var vDataSource = aConfiguration.GetSection("AppSettings:Repository");

			switch (vDataSource.Value) {
				case Constants.Strings.ADO_DataCommon:
					ConfigureRepoService(aServices, aConfiguration);
					aServices.AddSingleton<IGuestR, GuestDataCommon>();
					break;
				case Constants.Strings.Memory:
					aServices.AddSingleton<IGuestR, GuestRepositoryMemory>();
					break;
				case Constants.Strings.EFCore:
					ConfigureEFCoreRepoService(aServices, aConfiguration);
					aServices.AddSingleton<IGuestR, GuestEFCore>();
					break;
			}
		}

		//This no longer needs to be public as it is only call if needed by SelectRepoService
		private static void ConfigureRepoService(IServiceCollection aServices, IConfiguration aConfiguration) {

			var vDataSource = aConfiguration.GetSection("AppSettings:DataSource");

			switch (vDataSource.Value) {
				case Constants.Strings.SQLite:
					aServices.AddSingleton<IRepoConnection, SqliteConnection>();
					break;
				case Constants.Strings.MySQL:
					aServices.AddSingleton<IRepoConnection, MySQLConnection>();
					break;
				case Constants.Strings.SqlCe:
					aServices.AddSingleton<IRepoConnection, SqlCeConnection>();
					break;
			}

		}

		private static void ConfigureEFCoreRepoService(IServiceCollection aServices, IConfiguration aConfiguration) {

			var vDataSource = aConfiguration.GetSection("AppSettings:DataSource");

			switch (vDataSource.Value) {
				case Constants.Strings.SQLite:
					//aServices.AddDbContext<PartyInvitesContext__SQLite>();
					//aServices.AddSingleton<PartyInvitesContext__SQLite>();

					//aServices.AddEntityFrameworkSqlite().AddDbContext<PartyInvitesContext_SQLite>();

					//aServices.AddDbContext<PartyInvitesContext_SQLite>();
					aServices.AddSingleton <IRepoEFCoreConnection, SqliteEFCoreConnection> ();
					aServices.AddSingleton<PartyInvitesContext, PartyInvitesContext_SQLite>();

					break;
				case Constants.Strings.MySQL:

					break;
				case Constants.Strings.SqlCe:
					aServices.AddSingleton<IRepoEFCoreConnection, SqlCEEFCoreConnection>();
					aServices.AddSingleton<PartyInvitesContext, PartyInvitesContext_SqlCE>();
					break;
			}

		}
	}
}
