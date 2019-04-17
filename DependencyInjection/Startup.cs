using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using DependencyInjection.Infrastructure;
using DependencyInjection.Models;

namespace DependencyInjection
{
	public class Startup
	{
		private readonly IHostingEnvironment env;

		public Startup(IHostingEnvironment hostEnv)
		{
			this.env = hostEnv;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			//TypeBroker.SetRepositoryType<AlternateRepository>();
			//services.AddTransient<IRepository, MemoryRepository>();
			services.AddSingleton<IRepository>(provider =>
			{
				if (this.env.IsDevelopment())
					return provider.GetService<MemoryRepository>();
				else
					return new AlternateRepository();
			});
			services.AddSingleton<MemoryRepository>();

			services.AddTransient<IModelStorage, DictionaryStorage>();
			services.AddTransient<ProductTotalizer>();
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseDeveloperExceptionPage();
			app.UseStatusCodePages();
			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action}/{id?}",
					defaults: new {controller="Home", action="Index"}
					);
			});
		}
	}
}
