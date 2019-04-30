using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers
{
	public class HomeController : Controller
	{
		public ViewResult Index()
		{
			return this.View(viewName: "MyView", model: new string[] { "Apple", "Orange", "Pear" });
		}

		public ViewResult List() => this.View();
	}
}
