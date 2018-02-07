using BeerProject.Constants;
using BeerProject.Interfaces;
using BeerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerProject.Provider
{
	public class BeerProvider: IBeerProvider
	{
		private IContextProvider contextProvider;

		public BeerProvider(IContextProvider contextProvider)
		{
			this.contextProvider = contextProvider;
		}

		public Beers GetBeers(Request request)
		{
			var param = BuildParam(request);
			param = param + "&styleId=1";
			var beers = contextProvider.GetBeersAsync(param, API.EndPoints.AllBeers);
			return beers;
		}

		public Beers SearchBeers(Request request)
		{
			var filters = BuildParam(request);
			var param = $"&q={request.query}&type=beer{filters}";
			var beers = contextProvider.GetBeersAsync(param, API.EndPoints.SearchBeers);
			return beers;
		}

		public Beer GetBeer(string id)
		{
			var param = $"{id}";
			var beer = contextProvider.GetBeerAsync(param, API.EndPoints.GetBeer)?.data;
			return beer;
		}

		private string BuildParam(Request request)
		{
			var result = string.Empty;
			if (!string.IsNullOrWhiteSpace(request.page))
			{
				result = $"&p={request.page}";
			}
			if (!string.IsNullOrWhiteSpace(request.withBreweries))
			{
				result = result + $"&withBreweries={request.withBreweries}";
			}
			if (!string.IsNullOrWhiteSpace(request.withBreweries))
			{
				result = result + $"&withSocialAccounts={request.withSocialAccounts}";
			}
			if (!string.IsNullOrWhiteSpace(request.withBreweries))
			{
				result = result + $"&withIngredients={request.withIngredients}";
			}
			if (!string.IsNullOrWhiteSpace(request.withLocations))
			{
				result = result + $"&withLocations={request.withLocations}";
			}
			if (!string.IsNullOrWhiteSpace(request.order))
			{
				result = result + $"&order={request.order}";
			}
			if (!string.IsNullOrWhiteSpace(request.sort))
			{
				result = result + $"&sort={request.sort}";
			}
			return result;
		}
	}
}