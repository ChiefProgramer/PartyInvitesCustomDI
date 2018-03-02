using Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReopMySQL;
using RepositoryDataCommon;
using RepositoryMemory;
using RepoSQLite;
using RepoSqlServerCompact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvitesCustom
{
	public static class SelelctAndConfigureServices {

		//Select Which implementation of the Repository to Use
		public static void SelectRepoService(IServiceCollection aServices, IConfiguration aConfiguration) {

			var vDataSource = aConfiguration.GetSection("AppSettings:Repository");

			switch (vDataSource.Value) {
				case "ADO-DataCommon":
					ConfigureRepoService(aServices, aConfiguration);
					aServices.AddSingleton<IGuestR, GuestDataCommon>();
					break;
				case "Memory":
					aServices.AddSingleton<IGuestR, GuestRepositoryMemory>();
					break;
			}
		}

		//This no longer needs to be public as it is only call if needed by SelectRepoService
		private static void ConfigureRepoService(IServiceCollection aServices, IConfiguration aConfiguration) {

			var vDataSource = aConfiguration.GetSection("AppSettings:DataSource");

			switch (vDataSource.Value) {
				case "SQLite":
					aServices.AddSingleton<IRepoConnection, SqliteConnection>();
					break;
				case "MySQL":
					aServices.AddSingleton<IRepoConnection, MySQLConnection>();
					break;
				case "SqlCe":
					aServices.AddSingleton<IRepoConnection, SqlCeConnection>();
					break;
			}

		}
	}
}
