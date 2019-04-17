using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure
{
	public class TimeFilter : IAsyncActionFilter, IAsyncResultFilter
	{
		private ConcurrentQueue<Double> actionTimes=new ConcurrentQueue<Double>();
		private ConcurrentQueue<Double> resultTime = new ConcurrentQueue<Double>();
		private IFilterDiagnostic diagnostics;

		public TimeFilter(IFilterDiagnostic diags)
		{
			this.diagnostics = diags;
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			Stopwatch timer = Stopwatch.StartNew();
			await next();
			timer.Stop();
			this.actionTimes.Enqueue(timer.Elapsed.TotalMilliseconds);
			diagnostics.AddMessage($@"Action time: {timer.Elapsed.TotalMilliseconds} ms. Averrage: {this.actionTimes.Average():F2}");
		}

		public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			Stopwatch timer = Stopwatch.StartNew();
			await next();
			timer.Stop();
			this.resultTime.Enqueue(timer.Elapsed.TotalMilliseconds);
			diagnostics.AddMessage($@"Result time: {timer.Elapsed.Milliseconds} ms. Averrage: {this.resultTime.Average():F2}");
		}
	}
}
