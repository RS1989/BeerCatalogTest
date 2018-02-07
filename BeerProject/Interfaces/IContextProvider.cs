using BeerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerProject.Interfaces
{
	public interface IContextProvider
	{
		Beers GetBeersAsync(string request, string endpoint);
		Glasses GetGlasswareAsync();
		BeerResponce GetBeerAsync(string request, string endpoint);
	}
}
