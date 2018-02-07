using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerProject.Models
{
	public class Glasses
	{
		public string message { get; set; }
		public string status { get; set; }
		public List<Glass> data { get; set; }
	}
}