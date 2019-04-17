using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlsAndRoutes.Models;
using Microsoft.AspNetCore.Mvc;

namespace UrlsAndRoutes.Controllers
{
	public class CustomerController : Controller
	{
		[Route("[controller]/MyAction")]
		public ViewResult Index()
		{
			return View("Result", new Result()
			{
				Controller = nameof(CustomerController),
				Action = nameof(Index)
			});
		}

		public ViewResult List(String id)
		{
			Result r = new Result()
			{
				Controller = nameof(CustomerController),
				Action = nameof(List)
			};

			r.Data["Id"] = id ?? "<no value>";

			return View("Result", r);
		}
	}
}
