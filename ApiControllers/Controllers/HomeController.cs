using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiControllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiControllers.Controllers
{
	public class HomeController : Controller
	{
		private IRepository repository;

		public HomeController(IRepository repo)
		{
			this.repository = repo;
		}

		public ViewResult Index()
		{
			return this.View(repository.Reservations);
		}

		[HttpPost]
		public IActionResult AddReservation(Reservation reservation)
		{
			repository.AddReservation(reservation);
			return RedirectToAction("Index");
		}
	}
}
