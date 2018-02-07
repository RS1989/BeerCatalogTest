using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerProject.Models
{
	public class Request
	{
		public string page { get; set; }
		public string query { get; set; }
		public string withBreweries { get; set; }
		public string withSocialAccounts { get; set; }
		public string withIngredients { get; set; }
		public string withLocations { get; set; }
		public string order { get; set; }
		public string sort { get; set; }
	}
}