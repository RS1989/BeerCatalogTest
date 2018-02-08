using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerProject.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerProject.Interfaces;
using BeerProject.Models; 
using BeerProject.Provider;
using System.Web.Http;
using System.Web.Http.Results;

namespace BeerProjectTest.Controllers
{
	[TestClass]
	public class BeerControllerTest
	{
		[TestMethod]		
		public void GetReturnsErrorMessage()
		{
			var id = string.Empty;

			var mockBeerProvide = new Moq.Mock<IBeerProvider>();

			var controller = new BeerController(mockBeerProvide.Object);

			IHttpActionResult actionResult = controller.GetBeer(id);

			Assert.IsNotNull(actionResult);
			Assert.IsInstanceOfType(actionResult , typeof(NotFoundResult));			
		}

		[TestMethod]
		[DataRow("xbn6X9")]
		[DataRow("jFLgkw")]
		[DataRow("4UcPMq")]
		public void GetBeerReturnResult(string id)
		{
			var mockBeerModel = new Beer();

			var mockBeerProvide = new Moq.Mock<IBeerProvider>();

			var controller = new BeerController(mockBeerProvide.Object);
			mockBeerProvide.Setup(x => x.GetBeer(id)).Returns(mockBeerModel);
			//Act
			IHttpActionResult actionResult = controller.GetBeer(id);

			//Assert
			Assert.IsNotNull(actionResult);
			Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<Beer>));
		}


		[TestMethod]
		public void GetSearchErrorMessage()
		{
			var mockRequestModel = new Request();

			var mockBeerProvide = new Moq.Mock<IBeerProvider>();

			var controller = new BeerController(mockBeerProvide.Object);

			IHttpActionResult actionResult = controller.SearchBeers(mockRequestModel);

			Assert.IsNotNull(actionResult);
			Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
		}

		[TestMethod]
		[DataRow("Abbaye")]
		[DataRow("Flute")]
		[DataRow("Bavik")]
		public void GetSearchReturnResult(string queryRequest)
		{
			var mockRequestModel = new Request {
				query = queryRequest
			};

			var mockBeersModel = new Beers();

			var mockBeerProvide = new Moq.Mock<IBeerProvider>();
			mockBeerProvide.Setup(x => x.SearchBeers(mockRequestModel)).Returns(mockBeersModel);
			var controller = new BeerController(mockBeerProvide.Object);

			//Act
			IHttpActionResult actionResult = controller.SearchBeers(mockRequestModel);

			//Assert
			Assert.IsNotNull(actionResult);
			Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<Beers>));
		}

		

		[TestMethod]		
		public void GetBeersReturnResult()
		{
			var mockRequestModel = new Request();

			var mockBeersModel = new Beers();

			var mockBeerProvide = new Moq.Mock<IBeerProvider>();
			mockBeerProvide.Setup(x => x.GetBeers(mockRequestModel)).Returns(mockBeersModel);
			var controller = new BeerController(mockBeerProvide.Object);

			//Act
			IHttpActionResult actionResult = controller.GetBeers(mockRequestModel);

			//Assert
			Assert.IsNotNull(actionResult);
			Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<Beers>));
		}
	}
}
