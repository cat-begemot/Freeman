using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiControllers.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace ApiControllers.Controllers
{
	[Route("api/[controller]")]
	public class ReservationController : Controller
	{
		private IRepository repository;

		public ReservationController(IRepository repo)
		{
			this.repository = repo;
		}

		[HttpGet]
		public IEnumerable<Reservation> Get()
		{
			return this.repository.Reservations;
		}

		[HttpGet("{id}")]
		public IActionResult Get([FromRoute] Int32 id)
		{
			Reservation result = this.repository[id];
			if (result == null)
				return this.NotFound();
			else
				return this.Ok(result);
		}

		[HttpPost]
		public Reservation Post([FromBody] Reservation res)
		{
			return this.repository.AddReservation(new Reservation()
			{
				ClientName = res.ClientName,
				Location = res.Location
			});
		}

		[HttpPut]
		public Reservation Put([FromBody] Reservation res)
		{
			return this.repository.UpdateReservation(res);
		}

		[HttpPatch("{id}")]
		public StatusCodeResult Patch([FromRoute] Int32 id, [FromBody] JsonPatchDocument<Reservation> patch)
		{
			Reservation res = Get(id) as Reservation;
			if (res != null)
			{
				patch.ApplyTo(res);
				return this.Ok();
			}
			else
				return this.NotFound();
		}

		[HttpDelete("{id}")]
		public void Delete([FromRoute] Int32 id)
		{
			this.repository.DeleteReservation(id);
		}
	}
}
