using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerProject.Models
{
	public class Paging
	{
		public int CurrentPage { get; set; }
		public int Take  { get; set; }
		public int Skip { get; set; } 
	}
}