using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsingViewComponent.Models;
namespace UsingViewComponent.Components
{
	public class CitySummary : ViewComponent
	{
		private ICityRepository cityRepository;

		public CitySummary(ICityRepository cityRepo)
		{
			this.cityRepository = cityRepo;
		}

		public IViewComponentResult Invoke()
		{
			return this.View(new CityViewModel()
			{
				Cities = this.cityRepository.Cities.Count(),
				Population = this.cityRepository.Cities.Sum(city => city.Population)
			});
		}
	}
}
