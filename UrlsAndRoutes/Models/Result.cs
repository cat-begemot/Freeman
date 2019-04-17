using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlsAndRoutes.Models
{
	public class Result
	{
		public String Controller { get; set; }
		public String Action { get; set; }
		public IDictionary<String, Object> Data { get; } = new Dictionary<String, Object>();
	}
}
