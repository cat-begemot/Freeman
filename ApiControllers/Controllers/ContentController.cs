using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using ApiControllers.Models;

namespace ApiControllers.Controllers
{
	[Route("api/[controller]")]
	public class ContentController : Controller
	{
		[HttpGet("string")]
		public String GetString()
		{
			return "This is a string response";
		}

		[HttpGet("int")]
		public Int32 GetInt()
		{
			return 5;
		}

		[HttpGet("object")]
		public Reservation GetObject()
		{
			return new Reservation()
			{
				ReservationId = 1,
				ClientName = "Alex",
				Location = "Europe"
			};
		}
	}
}
