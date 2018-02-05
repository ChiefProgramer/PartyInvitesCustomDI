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
			//Select Which implementation of the Repository to Use
			SelelctRepoService vSelelctRepoService = new SelelctRepoService(services, Configuration);
			//Select Which implementation of the ADO connector to Use... if needed
			ConfigureRepoService vConfigRepoService = new ConfigureRepoService(services, Configuration);
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

	public class SelelctRepoService { 

		public SelelctRepoService(IServiceCollection aServices, IConfiguration aConfiguration) {
			SelelctRepository(aServices, aConfiguration);
		}

		//Select Which implementation of the Repository to Use
		private void SelelctRepository(IServiceCollection aServices, IConfiguration aConfiguration) { 

			var vDataSource = aConfiguration.GetSection("AppSettings:Repository");

			switch (vDataSource.Value) {
				case "ADO-DataCommon":
					aServices.AddSingleton<IGuestR, GuestDataCommon>();
					break;
				case "Memory":
					aServices.AddSingleton<IGuestR, GuestRepositoryMemory>();
					break;
			}


		}
	}

	public class ConfigureRepoService {

		public ConfigureRepoService(IServiceCollection aServices, IConfiguration aConfiguration) {
			SelelctDataSource(aServices, aConfiguration);
		}

		//Select Which implementation of the ADO connector to Use
		private void SelelctDataSource(IServiceCollection aServices, IConfiguration aConfiguration) {

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

}