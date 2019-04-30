using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Views.Infrastructure
{
	public class SimpleExpander : IViewLocationExpander
	{
		public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
		{
			foreach(String location in viewLocations)
			{
				yield return location.Replace("Shared", "Common");
			}
			yield return "/Views/Legacy/{1}/{0}/View.cshtml";
		}

		public void PopulateValues(ViewLocationExpanderContext context)
		{
			
		}
	}
}
