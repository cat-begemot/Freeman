using System;
using System.Collections.Generic;

namespace UsingViewComponent.Models
{
	public interface IProductRepository
	{
		IEnumerable<Product> Products { get; }
		void AddProduct(Product newProduct);
	}
}
