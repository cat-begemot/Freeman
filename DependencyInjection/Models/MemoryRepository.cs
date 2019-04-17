using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
	public class MemoryRepository : IRepository
	{
		private IModelStorage storage;
		private String guid = Guid.NewGuid().ToString();

		public MemoryRepository(IModelStorage modelStore)
		{
			this.storage = modelStore;
			new List<Product>()
			{
				new Product(){ Name="Kayak", Price=275M },
				new Product(){ Name="Lifejacket", Price=48.95M },
				new Product(){ Name="Soccer ball", Price=19.50M }
			}.ForEach(product => AddProduct(product));
		}

		public IEnumerable<Product> Products => this.storage.Items;

		public Product this[string name] => storage[name];

		public void AddProduct(Product product)
		{
			this.storage[product.Name] = product;
		}

		public void DeleteProduct(Product product)
		{			
			this.storage.RemoveItem(product.Name);
		}

		public override string ToString()
		{
			return this.guid;
		}
	}
}
