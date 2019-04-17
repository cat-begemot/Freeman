using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using Filters.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Filters.Infrastructure
{
	public class ProfileAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			((HomeController)context.Controller).ViewData.Model = context.ActionArguments;
			

		}

		public override void OnActionExecuted(ActionExecutedContext context)
		{
			context.HttpContext.Response.StatusCode = StatusCodes.Status207MultiStatus;
		}

		/*
		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			Stopwatch timer = Stopwatch.StartNew();
			await next();
			timer.Stop();
			String result = $"<div>Elapsed time: {timer.Elapsed.TotalMilliseconds} ms</div>";
			Byte[] bytes = Encoding.ASCII.GetBytes(result);
			await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
		}*/
	}
}
