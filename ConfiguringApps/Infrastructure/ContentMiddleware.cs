using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace ConfiguringApps.Infrastructure
{
	public class ContentMiddleware
	{
		private RequestDelegate nextDelegate;
		private UptimeService uptimeService;

		public ContentMiddleware(
			RequestDelegate next,
			UptimeService uptime)
		{
			nextDelegate = next;
			uptimeService = uptime;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
			{
				await httpContext.Response.WriteAsync($"This is from the content middleware. Uptime: {uptimeService.Uptime} ms", Encoding.UTF8);
			}
			else
				await nextDelegate.Invoke(httpContext);
		}
	}
}
