using System.Collections.Generic;

namespace UsingViewComponent.Models
{
	public interface ICityRepository
	{
		IEnumerable<City> Cities { get; }
		void AddCity(City newCity);
	}

}
