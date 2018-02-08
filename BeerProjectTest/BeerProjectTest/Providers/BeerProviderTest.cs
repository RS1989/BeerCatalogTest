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
	public class BeerProviderTest
	{
		[TestMethod]
		[DataRow("&styleId=1", "beers/")]
		public void GetBeersReturnResult(string param, string endpoint)
		{
			var mockRequestModel = new Request();

			var mockBeersModel = new Beers();
			
			var mockContextProvide = new Moq.Mock<IContextProvider>();
			mockContextProvide.Setup(m => m.GetBeersAsync(param, endpoint)).Returns(mockBeersModel);
			var provider = new BeerProvider(mockContextProvide.Object);

			Beers beers = provider.GetBeers(mockRequestModel);

			Assert.IsNotNull(beers, $"beer {provider}" );
		}

		[TestMethod]
		[DataRow("Mug")]
		[DataRow("292 ")]
		[DataRow("Traditional ")]
		public void SearchBeersReturnResult(string queryRequest)
		{
			var mockRequestModel = new Request {
				query = queryRequest
			};

			var mockBeersModel = new Beers();

			var mockContextProvide = new Moq.Mock<IContextProvider>();
			mockContextProvide.Setup(x => x.GetBeersAsync($"&q={queryRequest}&type=beer", "search/")).Returns(mockBeersModel);
			var provider = new BeerProvider(mockContextProvide.Object);

			Beers beers = provider.SearchBeers(mockRequestModel);

			Assert.IsNotNull(beers);
		}


		[TestMethod]
		[DataRow("-1")]
		public void SearchBeersReturnError(string request)
		{
			var mockRequestModel = new Request();

			var mockBeersModel = new Beers();

			var mockContextProvide = new Moq.Mock<IContextProvider>();
			mockContextProvide.Setup(x => x.GetBeersAsync($"&q={request}&type=beer", "search/")).Returns(mockBeersModel);

			var provider = new BeerProvider(mockContextProvide.Object);

			Beers beers = provider.SearchBeers(mockRequestModel);

			Assert.IsNull(beers);
		}


		[TestMethod]
		[DataRow("xbn6X9")]
		[DataRow("jFLgkw")]
		[DataRow("4UcPMq")]
		public void GetBeerReturnResult(string id)
		{	

			var mockBeerModel = new Beer();
			var mockBeerResponce = new BeerResponce();
			var mockContextProvide = new Moq.Mock<IContextProvider>();

			mockContextProvide.Setup(x => x.GetBeerAsync(id, "beer/")).Returns(mockBeerResponce);

			var provider = new BeerProvider(mockContextProvide.Object);

			Beer beer = provider.GetBeer(id);

			Assert.IsNotNull(beer);			
		}


		[TestMethod]
		[DataRow("-1")]
		public void GetBeerReturnError(string id)
		{
			var mockBeerModel = new Beer();

			var mockContextProvide = new Moq.Mock<IContextProvider>();
			var mockBeerResponce = new BeerResponce();
			var provider = new BeerProvider(mockContextProvide.Object);
			mockContextProvide.Setup(x => x.GetBeerAsync(id, "beer/")).Returns(mockBeerResponce);
			Beer beer = provider.GetBeer(id);

			Assert.IsNull(beer);
		}

	}
}
