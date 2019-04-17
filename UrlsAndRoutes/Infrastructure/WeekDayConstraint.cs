using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace UrlsAndRoutes.Infrastructure
{
	public class WeekDayConstraint : IRouteConstraint
	{
		private static String[] _Days = new[] { "mon", "tue", "wed", "thu", "fri", "sat", "sun" };

		public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
		{
			return _Days.Contains<String>(values[routeKey]?.ToString().ToLowerInvariant());
		}
	}
}
