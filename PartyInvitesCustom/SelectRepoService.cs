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
	//This Class Could be added to DI service as Lazy loader for RepoService


	public class SelectRepoService : ISelectRepoService {
		private IServiceCollection mServices;
		private IConfiguration mConfiguration;

		private IGuestR mSelelctedRepo;
		private IRepoConnection mSlectedDataSource;



		public SelectRepoService(IServiceCollection aServices, IConfiguration aConfiguration) {
			mServices = aServices;
			mConfiguration = aConfiguration;
		}

		//Select Which implementation of the Repository to Use

		public IGuestR SelelctRepository() {
			return mSelelctedRepo ?? SelectRepo();
		}

		private IGuestR SelectRepo() {

			var vDataSource = mConfiguration.GetSection("AppSettings:Repository");

			switch (vDataSource.Value) {
				case "ADO-DataCommon":
					mSelelctedRepo = new GuestDataCommon(SelectDataSource());
					mServices.AddSingleton<IGuestR>(mSelelctedRepo);
					break;
				case "Memory":
					mSelelctedRepo = new GuestRepositoryMemory();
					mServices.AddSingleton<IGuestR>(mSelelctedRepo);
					break;
			}
			return mSelelctedRepo;

		}

		//This no longer needs to be public as it is only call if needed by SelectRepo
		private IRepoConnection SelectDataSource() {
			return mSlectedDataSource ?? SelectDATASource();
		}

		//Select Which implementation of the ADO connector to Use
		private IRepoConnection SelectDATASource() {

			var vDataSource = mConfiguration.GetSection("AppSettings:DataSource");

			switch (vDataSource.Value) {
				case "SQLite":
					mSlectedDataSource = new SqliteConnection(mConfiguration);
					mServices.AddSingleton<IRepoConnection>(mSlectedDataSource);
					break;
				case "MySQL":
					mSlectedDataSource = new MySQLConnection(mConfiguration);
					mServices.AddSingleton<IRepoConnection>(mSlectedDataSource);
					break;
				case "SqlCe":
					mSlectedDataSource = new SqlCeConnection(mConfiguration);
					mServices.AddSingleton<IRepoConnection>(mSlectedDataSource);
					break;
			}
			return mSlectedDataSource;
		}
	}
}
