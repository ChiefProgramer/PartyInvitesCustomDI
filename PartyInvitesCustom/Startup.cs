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



	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services 
		// to the container.
		public void ConfigureServices(IServiceCollection services) {
			services.AddSingleton<IGuestR, StartGuestDataCommon>();
			services.AddSingleton<IGuests, Guests>();
			services.AddSingleton<IGuest, Guest>();
			services.AddSingleton<IReopConnection, SqliteConnection>();
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
}