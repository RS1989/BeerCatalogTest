using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerProject.Models
{
	public class Beers
	{
		public int currentPage { get; set; }
		public string numberOfPages { get; set; }
		public int totalResults { get; set; }
		public List<Beer> data { get; set; }
	}
}