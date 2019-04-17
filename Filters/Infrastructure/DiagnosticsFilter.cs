using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure
{
	public class DiagnosticsFilter : IAsyncResultFilter
	{
		private IFilterDiagnostic diagnostics;

		public DiagnosticsFilter(IFilterDiagnostic diags)
		{
			this.diagnostics = diags;
		}

		public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			await next();
			foreach(String message in this.diagnostics?.Messages)
			{
				Byte[] bytes = Encoding.ASCII.GetBytes($"<div>{message}</div>");
				await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
			}
		}
	}
}
