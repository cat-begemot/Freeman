using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsingViewComponent.Models;

namespace UsingViewComponent.Controllers
{
	public class HomeController : Controller
	{
		private IProductRepository productRepository;

		public HomeController(IProductRepository productRepo)
		{
			this.productRepository = productRepo;
		}

		[HttpGet]
		public ViewResult Index()
		{
			return this.View(this.productRepository.Products);
		}

		[HttpGet]
		public ViewResult Create()
		{
			return this.View();
		}

		[HttpPost]
		public IActionResult Create(Product newProduct)
		{
			this.productRepository.AddProduct(newProduct);
			return this.RedirectToAction("Index");
		}
	}
}
