using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;
using DependencyInjection.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Controllers
{
	public class HomeController : Controller
	{
		/*
		private IRepository repository;

		public HomeController(
			IRepository repo)
		{
			this.repository = repo;			
		}
		*/

		public ViewResult Index([FromServices] ProductTotalizer totalizer)
		{
			IRepository repository = this.HttpContext.RequestServices.GetService<IRepository>();

			if (repository != null)
			{
				this.ViewBag.HomeController = repository.ToString();
				this.ViewBag.Totalizer = totalizer.Repository.ToString();
				this.ViewBag.Description = "Hello everybody!";
				return this.View(repository.Products);
			}
			else
				return this.View();
		}
	}
}
