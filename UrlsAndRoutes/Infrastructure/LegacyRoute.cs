using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Text;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.DependencyInjection;


namespace UrlsAndRoutes.Infrastructure
{
	public class LegacyRoute : IRouter
	{
		private String[] urls;
		private IRouter mvcRoute;

		public LegacyRoute(IServiceProvider services, params string[] targetUrls)
		{
			this.urls = targetUrls;
			mvcRoute = services.GetRequiredService<MvcRouteHandler>();
		}

		public VirtualPathData GetVirtualPath(VirtualPathContext context)
		{
			if(context.Values.ContainsKey("legacyUrl"))
			{
				String url = context.Values["legacyUrl"] as String;
				if(urls.Contains(url))
				{
					return new VirtualPathData(this, url);
				}
			}

			return null;
		}

		public async Task RouteAsync(RouteContext context)
		{
			String requestedUrl = context.HttpContext.Request.Path.Value.TrimEnd('/');
			if(urls.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase))
			{
				context.RouteData.Values["controller"] = "Legacy";
				context.RouteData.Values["action"] = "GetLegacyUrl";
				context.RouteData.Values["legacyUrl"] = requestedUrl;

				await this.mvcRoute.RouteAsync(context);
			}
		}
	}
}
