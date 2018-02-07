using BeerProject.Constants;
using BeerProject.Interfaces;
using BeerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace BeerProject.Provider
{
	public class ContextProvider: IContextProvider
	{
		private HttpClient client = new HttpClient();

		public Beers GetBeersAsync(string request, string endpoint)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(API.baseUrl + endpoint);

			
			client.DefaultRequestHeaders.Accept.Add(
			new MediaTypeWithQualityHeaderValue("application/json"));

			var param = API.key + request;
			HttpResponseMessage response = client.GetAsync(param).Result;
			if (response.IsSuccessStatusCode)
			{				
				var dataObjects = response.Content.ReadAsAsync<Beers>().Result;
				return dataObjects;
			}
			return null;
		}

		public BeerResponce GetBeerAsync(string request, string endpoint)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(API.baseUrl + endpoint + request);


			client.DefaultRequestHeaders.Accept.Add(
			new MediaTypeWithQualityHeaderValue("application/json"));

			var param = API.key;
			HttpResponseMessage response = client.GetAsync(param).Result;
			if (response.IsSuccessStatusCode)
			{				
				var dataObjects = response.Content.ReadAsAsync<BeerResponce>().Result;
				return dataObjects;
			}
			return null;
		}

		public Glasses GetGlasswareAsync()
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(API.baseUrl + API.EndPoints.Glassware);


			client.DefaultRequestHeaders.Accept.Add(
			new MediaTypeWithQualityHeaderValue("application/json"));

			
			HttpResponseMessage response = client.GetAsync(API.key).Result;
			if (response.IsSuccessStatusCode)
			{				
				var dataObjects = response.Content.ReadAsAsync<Glasses>().Result;
				return dataObjects;
			}
			return null;
		}
	}
}