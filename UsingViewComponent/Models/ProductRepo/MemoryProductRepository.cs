using System.Collections.Generic;

namespace UsingViewComponent.Models
{
	public class MemoryProductRepository : IProductRepository
	{
		private List<Product> products => new List<Product>()
		{
			new Product(){Name="Kayak", Price=275M},
			new Product(){Name="Lifejacket", Price=48.95M},
			new Product(){Name="Soccer ball", Price=19.5M}
		};

		public IEnumerable<Product> Products => this.products;

		public void AddProduct(Product newProduct)
		{
			this.products.Add(newProduct);
		}
	}
}
