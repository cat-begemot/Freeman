using System;
using Xunit;
using ControllersAndActions.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ControllersAndActionsTests
{
	public class ActionTests
	{
		[Fact]
		public void Redirection()
		{
			ExampleController controller = new ExampleController();

			var result = controller.Redirect();

			Assert.Equal("/Example/Index", result.Url);
			Assert.True(result.Permanent);
		}

		[Fact]
		public void RedirectToRoute()
		{
			ExampleController controller = new ExampleController();
			var result=controller.RedirectToRoute();
			
			Assert.False(result.Permanent);
			Assert.Equal("Example", result.RouteValues["controller"]);
			Assert.Equal("Index", result.RouteValues["action"]);
			Assert.Equal("MyId", result.RouteValues["id"]);
		}

		[Fact]
		public void JsonActionMethod()
		{
			HomeController controller = new HomeController();
			IActionResult result = controller.Index();

			Assert.Equal(new[] { "Alice", "Bob", "Joe" }, ((ObjectResult)result).Value);
		}

		[Fact]
		public void NotFoundActionMethod()
		{
			ExampleController controller = new ExampleController();
			StatusCodeResult result = controller.Code();

			Assert.Equal(404, result.StatusCode);
		}
	}
}
