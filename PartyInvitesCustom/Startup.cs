namespace PartyInvitesCustom {
	using Contracts;
	using Entities;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using PartyInvitesCustom.Orchestrators;
	using RepositoryDataCommon;
	using RepositoryMemory;
	using ReopMySQL;
	using RepoSQLite;
	using System.Configuration;

	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;  
		}

		// This method gets called by the runtime. Use this method to add services 
		// to the container.
		public void ConfigureServices(IServiceCollection services) {
			//Select Which implementation of the Repository to Use....
			//And Select Which implementation of the ADO connector to Use... if needed
			SelelctAndConfigureServices.SelelctRepoService(services, Configuration);
			services.AddTransient<IGuests, Guests>();
			services.AddSingleton(Configuration);
			services.AddMvc();


		}

		// This method gets called by the runtime. Use this method to configure the
		// HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
			}
			else {
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseMvc
			(
				routes => {
					routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
					routes.MapRoute(name: "RsvpForm", template: "Home/{controller=RsvpFormController}/{action=RsvpForm}");
					routes.MapRoute(name: "ListResponses", template: "RsvpForm/{controller=ListResponsesController}/{action=ListResponses}");
					routes.MapRoute(name: "Error", template: "Home/{controller=ErrorController}/{action=Error}");
				});
		}

		public IConfiguration Configuration { get; }   

	}


	public static class SelelctAndConfigureServices {

		//Select Which implementation of the Repository to Use
		public static void SelelctRepoService(IServiceCollection aServices, IConfiguration aConfiguration) { 

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
			}

		}
	}

	//This Class Could be added to DI service as Lazy loader for RepoService
	public interface ISelectRepoService {
		IGuestR SelelctRepository();
	}

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
			}
			return mSlectedDataSource;
		}
	}


}