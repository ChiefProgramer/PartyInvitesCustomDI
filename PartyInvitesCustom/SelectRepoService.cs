using Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReopMySQL;
using RepoRFCoreConnectorSQLite;
using RepositoryDataCommon;
using RepositoryEFCore;
using RepositoryMemory;
using RepoSQLite;
using RepoSqlServerCompact;
using xData_Layer_EFCore_SQLite;

namespace PartyInvitesCustom {
	//This Class Could be added to DI service as Lazy loader for RepoService


	public class SelectRepoService : ISelectRepoService {
		private IServiceCollection mServices;
		private IConfiguration mConfiguration;

		private IGuestR mSelelctedRepo;
		private IRepoConnection mSlectedDataSource;
		private IRepoEFCoreConnection mSlectedEFCoreDataSource;



		public SelectRepoService(IServiceCollection aServices, IConfiguration aConfiguration) {
			mServices = aServices;
			mConfiguration = aConfiguration;
		}

		//Select Which implementation of the Repository to Use

		public IGuestR SelelctRepository() {
			return mSelelctedRepo ?? SelectRepo();
		}

		private IGuestR SelectRepo() {

			var vDataSource = mConfiguration.GetSection(Constants.Strings.AppSettings_Repository); // Constants.MyStrings

			switch (vDataSource.Value) {
				case Constants.Strings.ADO_DataCommon:
					mSelelctedRepo = new GuestDataCommon(SelectDataSource());
					mServices.AddSingleton<IGuestR>(mSelelctedRepo);
					break;
				case Constants.Strings.Memory:
					mSelelctedRepo = new GuestRepositoryMemory();
					mServices.AddSingleton<IGuestR>(mSelelctedRepo);
					break;
				case Constants.Strings.EFCore:

					//mSelelctedRepo = new GuestEFCore(SelectEFCoreDATASource());
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

			var vDataSource = mConfiguration.GetSection(Constants.Strings.AppSettings_DataSource);

			switch (vDataSource.Value) {
				case Constants.Strings.SQLite:
					mSlectedDataSource = new SqliteConnection(mConfiguration);
					mServices.AddSingleton<IRepoConnection>(mSlectedDataSource);
					break;
				case Constants.Strings.MySQL:
					mSlectedDataSource = new MySQLConnection(mConfiguration);
					mServices.AddSingleton<IRepoConnection>(mSlectedDataSource);
					break;
				case Constants.Strings.SqlCe:
					mSlectedDataSource = new SqlCeConnection(mConfiguration);
					mServices.AddSingleton<IRepoConnection>(mSlectedDataSource);
					break;
			}
			return mSlectedDataSource;
		}

		//Select Which implementation of the EFCore connector to Use
		private IRepoEFCoreConnection SelectEFCoreDATASource() { 

			var vDataSource = mConfiguration.GetSection(Constants.Strings.AppSettings_DataSource);

			switch (vDataSource.Value) {
				case Constants.Strings.SQLite:
					//mSlectedEFCoreDataSource = new SqliteEFCoreConnection(mConfiguration,);
					mServices.AddSingleton<IRepoEFCoreConnection>(mSlectedEFCoreDataSource);
					break;
				//case Constants.Strings.MySQL:
				//	mSlectedDataSource = new MySQLConnection(mConfiguration);
				//	mServices.AddSingleton<IRepoConnection>(mSlectedDataSource);
				//	break;
				//case Constants.Strings.SqlCe:
				//	mSlectedDataSource = new SqlCeConnection(mConfiguration);
				//	mServices.AddSingleton<IRepoConnection>(mSlectedDataSource);
				//	break;
			}
			return mSlectedEFCoreDataSource;
		}
	}
}
