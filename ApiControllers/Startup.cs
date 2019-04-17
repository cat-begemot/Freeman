using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ApiControllers.Models;

namespace ApiControllers
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<MemoryRepository>();
			services.AddSingleton<IRepository>(provider =>
			{
				return provider.GetRequiredService<MemoryRepository>();
			});
			services.AddMvc().AddXmlDataContractSerializerFormatters();
		}

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
					defaults: new { controller = "Home", action = "Index" });
			});
		}
	}
}
