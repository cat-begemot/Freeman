using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using ControllersAndActions.Infrastructure;

namespace ControllersAndActions.Controllers
{
	public class HomeController : Controller
	{
		public ObjectResult Index()
		{
			return this.Ok(new[]
			{
				"Alice",
				"Bob",
				"Joe"
			});
		}

		[HttpPost]
		public RedirectToActionResult ReceiveForm(String name, String city)
		{
			this.TempData["name"] = name;
			this.TempData["city"] = city;
			return this.RedirectToAction(nameof(Data));
		}

		public ViewResult Data()
		{
			//return new CustomHtmlResult() { Content = $"{name} lives in {city} (Used {this.Request.Method})" };
			var name = this.TempData["name"] as String;
			var city = this.TempData["city"] as String;
			return View("Result", $"{name} lives in {city} (Used {this.Request?.Method})");
		}
	}
}
