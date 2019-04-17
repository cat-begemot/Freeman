using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControllers.Models
{
	public class Reservation
	{
		public Int32 ReservationId { get; set; }
		public String ClientName { get; set; }
		public String Location { get; set; }
	}
}
