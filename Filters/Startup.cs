using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Filters.Infrastructure;

namespace Filters
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<IFilterDiagnostic, DefaultFilterDiagnostics>();
			services.AddScoped<TimeFilter>();
			services.AddScoped<ViewResultDiagnostics>();
			services.AddScoped<DiagnosticsFilter>();

			services.AddMvc().AddMvcOptions(options =>
			{
				options.Filters.AddService(typeof(ViewResultDiagnostics));
				options.Filters.AddService(typeof(DiagnosticsFilter));
			});
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseStatusCodePages();
			app.UseDeveloperExceptionPage();
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
