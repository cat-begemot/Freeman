using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControllers.Models
{
	public interface IRepository
	{
		Reservation this[Int32 id] { get; }
		IEnumerable<Reservation> Reservations { get; }
		Reservation AddReservation(Reservation reservation);
		Reservation UpdateReservation(Reservation reservation);
		void DeleteReservation(Int32 id);
	}
}
