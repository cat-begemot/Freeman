using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace UrlsAndRoutes.Infrastructure
{
	public class PageNotFoundCatcher
	{
		private RequestDelegate nextRequest;

		public PageNotFoundCatcher(
			RequestDelegate next)
		{
			this.nextRequest = next;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			await this.nextRequest.Invoke(httpContext);
			
			if (httpContext.Request.Path.ToString().ToLower().StartsWith("/home/customvariable"))
			{
				if(httpContext.Response.StatusCode==404)
				{
					await httpContext.Response.WriteAsync("Variable must be a day of the week in 3 letters format. For example: 'sun' for Sunday",
						Encoding.UTF8);
				}
			}			
		}
	}
}
