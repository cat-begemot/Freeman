using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Infrastructure
{
	public interface IFilterDiagnostic
	{
		IEnumerable<String> Messages { get; }
		void AddMessage(String message);
	}

	public class DefaultFilterDiagnostics : IFilterDiagnostic
	{
		private List<String> messages = new List<string>();

		public IEnumerable<string> Messages => this.messages;

		public void AddMessage(string message)
		{
			this.messages.Add(message);
		}
	}
}
