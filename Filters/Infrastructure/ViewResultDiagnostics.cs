using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure
{
	public class ViewResultDiagnostics : IActionFilter
	{
		private IFilterDiagnostic diagnostics;

		public ViewResultDiagnostics(IFilterDiagnostic diags)
		{
			this.diagnostics = diags;
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
			ViewResult vr;
			if((vr=context.Result as ViewResult) != null)
			{
				this.diagnostics.AddMessage($"View name: {vr.ViewName}");
				this.diagnostics.AddMessage($"Model type: {vr.ViewData.Model.GetType().Name}");				
			}
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			
		}
	}
}
