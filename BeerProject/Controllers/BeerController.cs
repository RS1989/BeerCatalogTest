using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BeerProject.Interfaces;
using BeerProject.Models;

namespace BeerProject.Controllers
{
	public class BeerController : ApiController
	{
		private IBeerProvider beerProvider;

		public BeerController(IBeerProvider beerProvider)
		{
			this.beerProvider = beerProvider;
		}

		[HttpPost]
		public IHttpActionResult GetBeers(Request request)
		{
			try
			{
				var beers = this.beerProvider.GetBeers(request);
				if (beers == null)
				{
					return NotFound();
				}
				return Ok(beers);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		[HttpPost]
		public IHttpActionResult SearchBeers(Request request)
		{
			try
			{
				var beers = this.beerProvider.SearchBeers(request);
				if (beers == null)
				{
					return NotFound();
				}
				return Ok(beers);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		[HttpGet]
		public IHttpActionResult GetBeer(string id)
		{
			try
			{
				var beer = this.beerProvider.GetBeer(id);
				if (beer == null)
				{
					return NotFound();
				}
				return Ok(beer);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
	}
}
