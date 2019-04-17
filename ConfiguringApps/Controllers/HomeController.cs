using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConfiguringApps.Infrastructure;
using Microsoft.Extensions.Logging;


namespace ConfiguringApps.Controllers
{
	public class HomeController : Controller
	{
		private UptimeService uptimeService;
		private ILogger<HomeController> logger;

		public HomeController(
			UptimeService uptime,
			ILogger<HomeController> log)
		{
			uptimeService = uptime;
			logger = log;
		}

		public ViewResult Index(Boolean throwException=false)
		{
			logger.LogDebug($"Handled {this.Request.Path} at uptime {uptimeService.Uptime} ms");

			if (throwException)
				throw new System.NullReferenceException();

			return this.View(new Dictionary<String, String>()
				{
					["Message"] = "This is the Index action",
					["Uptime"] = $"{uptimeService.Uptime} ms"
				}
			);
		}

		public ViewResult Error()
		{
			return View(nameof(Index), new Dictionary<String, String>()
			{
				["Message"]="This is the Error action"
			});
		}
	}
}
