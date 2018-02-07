using BeerProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeerProject.Controllers
{
    public class GlassController : ApiController
    {
		private IContextProvider contextProvider;

		public GlassController(IContextProvider contextProvider)
		{
			this.contextProvider = contextProvider;
		}

		public IHttpActionResult GetGlasses()
		{
			try
			{
				var glasses = this.contextProvider.GetGlasswareAsync();
				if (glasses == null)
				{
					return NotFound();
				}
				return Ok(glasses);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
    }

}
