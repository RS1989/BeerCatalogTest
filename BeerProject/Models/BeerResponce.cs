﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerProject.Models
{
	public class BeerResponce
	{
		public string message { get; set; }
		public Beer data { get; set; }
		public string status { get; set; }
	}
}