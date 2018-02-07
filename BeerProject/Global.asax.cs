using BeerProject.Interfaces;
using BeerProject.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.Lifetime;

namespace BeerProject
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{		
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			var container = new UnityContainer();
			container.RegisterType<IContextProvider, ContextProvider>(new HierarchicalLifetimeManager());
			container.RegisterType<IBeerProvider, BeerProvider>(new HierarchicalLifetimeManager());
			GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);

		}
	}
}
