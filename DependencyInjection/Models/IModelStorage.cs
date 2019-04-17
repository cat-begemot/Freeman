using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
	public interface IModelStorage
	{
		IEnumerable<Product> Items { get; }
		Product this[String key] { get; set; }

		Boolean ContainsKey(String key);
		void RemoveItem(String key);
	}
}
