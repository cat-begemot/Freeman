﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ConfiguringApps.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace ConfiguringApps
{
	public class Startup
	{
		public Startup(IConfiguration config)
		{
			Configuration = config;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<UptimeService>();

			services.AddMvc().AddMvcOptions(options =>
			{
				options.RespectBrowserAcceptHeader = true;
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			Console.WriteLine($"ContentRootPath: {env.ContentRootPath}");
			Console.WriteLine($"WebRootPath: {env.WebRootPath}");
			Console.WriteLine((Configuration.GetSection("ShortCircuitMiddleware")?.GetValue<Boolean>("EnableBrowserShortCircuit")).Value);

			if((Configuration.GetSection("ShortCircuitMiddleware")?.GetValue<Boolean>("EnableBrowserShortCircuit")).Value)
			{
				app.UseMiddleware<ErrorMiddleware>();
				app.UseMiddleware<BrowserTypeMiddleware>();
				app.UseMiddleware<ShortCircuitMiddleware>();
			}

			if (env.IsDevelopment())
			{
				/*				
				app.UseMiddleware<ContentMiddleware>();
				*/

				app.UseDeveloperExceptionPage();
				app.UseStatusCodePages();
				
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
