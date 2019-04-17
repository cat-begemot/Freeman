using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
	public class DictionaryStorage : IModelStorage
	{
		private Dictionary<String, Product> items = new Dictionary<string, Product>();

		public Product this[string key]
		{
			get { return this.items[key]; }
			set { this.items[key] = value; }
		}

		public IEnumerable<Product> Items => this.items.Values;

		public bool ContainsKey(string key)
		{
			return this.items.ContainsKey(key);
		}

		public void RemoveItem(string key)
		{
			this.items.Remove(key);
		}
	}
}
