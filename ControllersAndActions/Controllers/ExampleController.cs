using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ControllersAndActions.Controllers
{
	public class ExampleController : Controller
	{
		public StatusCodeResult Code()
		{
			return this.NotFound();
		}

		public VirtualFileResult Index()
		{
			return this.File("/lib/twitter-bootstrap/css/bootstrap.css", "text/css");
		}

		public ViewResult Result()
		{
			return this.View((Object)"Hello world!");
		}

		public RedirectResult Redirect()
		{
			return this.RedirectPermanent("/Example/Index");
		}

		public RedirectToRouteResult RedirectToRoute()
		{
			return RedirectToRoute(new
			{
				controller = "Example",
				action = "Index",
				id = "MyId"
			});
		}
	}
}
