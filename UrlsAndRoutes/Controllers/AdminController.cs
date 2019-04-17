using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlsAndRoutes.Models;
using Microsoft.AspNetCore.Mvc;

namespace UrlsAndRoutes.Controllers
{
	public class AdminController : Controller
	{
		public ViewResult Index()
		{
			return View("Result", new Result()
			{
				Controller = nameof(AdminController),
				Action = nameof(Index)
			});
		}
	}
}
