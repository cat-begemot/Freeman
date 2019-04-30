using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsingViewComponent.Models;

namespace UsingViewComponent.Components
{
	public class PocoViewComponent
	{
		private ICityRepository cityRepository;

		public PocoViewComponent(ICityRepository cityRepo)
		{
			this.cityRepository = cityRepo;
		}

		public String Invoke()
		{
			return $"{this.cityRepository.Cities.Count()} cities, " +
				$"{this.cityRepository.Cities.Sum(c => c.Population)} people";
		}
	}
}
