using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Filters.Infrastructure;

namespace Filters.Controllers
{
	[Profile]
	public class HomeController : Controller
	{
		public IActionResult Index(Int32? id)
		{
			return this.View("Message");
		}
		
		public IActionResult SecondAction()
		{
			return this.View("Message", "This is the SecondAction action on the Home controller");
		}

		public ViewResult GenerateException(Int32? id)
		{
			if (id == null)
				throw new ArgumentOutOfRangeException(nameof(id));
			else if (id > 10)
				throw new IndexOutOfRangeException(nameof(id));
			else
				return this.View("Message", $"The value is {id}");
		}
	}
}
