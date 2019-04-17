using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.Routing;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
	public class Startup
	{		
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.Configure<RouteOptions>(options =>
			{
				options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint));
				options.LowercaseUrls = true;
				options.AppendTrailingSlash = true;
			});
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseDeveloperExceptionPage();
			app.UseStatusCodePages();

			app.UseStaticFiles();

			app.UseMiddleware<PageNotFoundCatcher>();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "areas",
					template: "{area:exists}/{controller=Home}/{action=Index}"
				);

				routes.Routes.Add(new LegacyRoute(
					app.ApplicationServices,
					"/articles/Windows_3.1_Overview.html",
					"/old/.NET_1.0_Class_Library"));

				routes.MapRoute(
					name: "default",
					template: "{controller}/{action}/{id?}",
					defaults: new { controller = "Home", action = "Index" });

				routes.MapRoute(
					name: "out",
					template: "outbound/{controller}/{action}",
					defaults: new { controller = "Home", action = "Index" });
			});

				/*
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action}/{id?}",
					defaults: new { controller = "Home", action = "Index" },
					constraints: new {id = new CompositeRouteConstraint(new IRouteConstraint[]
					{
						new AlphaRouteConstraint(),
						new WeekDayConstraint()
					})}
				);
				*/
		}
	}
}
