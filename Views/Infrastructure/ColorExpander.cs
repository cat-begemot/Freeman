using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Views.Infrastructure
{
	public class ColorExpander : IViewLocationExpander
	{
		private static Dictionary<String, String> Colors =
			new Dictionary<string, string>() { ["red"] = "Red", ["green"] = "Green", ["blue"] = "Blue" };

		public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
		{
			String color;
			context.Values.TryGetValue("color", out color);
			foreach(String location in viewLocations)
			{
				if (!String.IsNullOrEmpty(color))
				{
					yield return location.Replace("{0}", color);
				}
				else
					yield return location;
			}
		}

		public void PopulateValues(ViewLocationExpanderContext context)
		{
			var routeValues = context.ActionContext.RouteData.Values;
			String color;

			if(routeValues.ContainsKey("id") && Colors.TryGetValue((routeValues["id"] as String), out color)
				&& !string.IsNullOrEmpty(color))
			{
				context.Values["color"] = color;
			}
		}
	}
}
