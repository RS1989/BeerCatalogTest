using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerProject.Interfaces;
using BeerProject.Models;
using BeerProject.Provider;
using System.Web.Http;
using System.Web.Http.Results;

namespace BeerProjectTest.Providers
{
	[TestClass]
	public class ContextProviderTest
	{
		[TestMethod]
		[DataRow("&styleId=1", "beers/")]
		[DataRow("&q=292&type=beer", "search/")]
		public void GetBeersAsyncReturnResult(string request, string endpoint)
		{			
			var provider = new ContextProvider();

			Beers beers = provider.GetBeersAsync(request,endpoint);

			Assert.IsNotNull(beers);
			Assert.IsTrue(beers.data.Count > 0, "beera.data should be greater than 0");
		}

		[TestMethod]
		[DataRow("", "beers/")]
		[DataRow("", "search/")]
		public void GetBeersAsyncReturnError(string request, string endpoint)
		{
			var provider = new ContextProvider();

			Beers beers = provider.GetBeersAsync(request, endpoint);

			Assert.IsNull(beers);
		}

		[TestMethod]
		[DataRow("xbn6X9", "beer/")]
		[DataRow("jFLgkw", "beer/")]
		public void GetBeerAsyncReturnResult(string request, string endpoint)
		{
			var provider = new ContextProvider();

			BeerResponce responce = provider.GetBeerAsync(request, endpoint);

			Assert.IsNotNull(responce);
		}

		[TestMethod]
		[DataRow("-1", "beers/")]
		[DataRow("-2", "search/")]
		public void GetBeerAsyncReturnError(string request, string endpoint)
		{
			var provider = new ContextProvider();

			BeerResponce responce = provider.GetBeerAsync(request, endpoint);

			Assert.IsNull(responce);
		}
	}
}
