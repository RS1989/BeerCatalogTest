using BeerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerProject.Interfaces
{
	public interface IBeerProvider
	{
		Beers GetBeers(Request request);
		Beers SearchBeers(Request request);
		Beer GetBeer(string id);
	}
}