using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using DependencyInjection.Controllers;
using DependencyInjection.Models;
using DependencyInjection.Infrastructure;

namespace DependencyInjectionTests
{
  public class DITests
  {
		[Fact]
		public void ControllerTest()
		{
			var data = new[]
			{
				new Product() {Name="Test", Price=100}
			};

			var mock = new Mock<IRepository>();
			mock.SetupGet(m => m.Products).Returns(data);

			HomeController controller = new HomeController(mock.Object, null);

			ViewResult result = controller.Index();

			Assert.Equal(data, result.ViewData.Model);
		}
  }
}
