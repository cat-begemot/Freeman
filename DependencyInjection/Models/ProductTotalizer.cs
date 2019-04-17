using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
	public class ProductTotalizer
	{
		public ProductTotalizer(IRepository repo)
		{
			this.Repository = repo;			
		}

		public IRepository Repository { get; set; }

		public Decimal Total => this.Repository.Products.Sum(product => product.Price);
	}
}
