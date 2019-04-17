using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlsAndRoutes.Models;
using Microsoft.AspNetCore.Mvc;

namespace UrlsAndRoutes.Controllers
{
	public class HomeController : Controller
	{
		public ViewResult Index()
		{
			return View("Result", new Result()
			{
				Controller = nameof(HomeController),
				Action = nameof(Index)
			});
		}

		public ViewResult CustomVariable(String id)
		{
			Result r = new Result()
			{
				Controller = nameof(HomeController),
				Action = nameof(CustomVariable)
			};

			r.Data["Id"] = id ?? "<no value>";
			r.Data["Url"] = this.Url.Action("CustomVariable", "Home", new { id = 100 });

			return View("Result", r);
		}
	}
}
