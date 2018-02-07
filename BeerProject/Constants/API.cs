using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerProject.Constants
{
	public static class API
	{
		public static string baseUrl = @"http://api.brewerydb.com/v2/";
		public static string key = @"?key=";
		public static class EndPoints
		{
			public static string AllBeers = @"beers/";

			public static string SearchBeers = @"search/";

			public static string Glassware = @"glassware/";

			public static string GetBeer = @"beer/";
		}
	}
}