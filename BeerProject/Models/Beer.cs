using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerProject.Models
{
	public class Beer
	{
		public string id { get; set; }
		public string name { get; set; }
		public string nameDisplay { get; set; }
		public string description { get; set; }
		public string abv { get; set; }
		public int glasswareId { get; set; }
		public int srmId { get; set; }
		public int styleId { get; set; }
		public string isOrganic { get; set; }
		public string status { get; set; }
		public string statusDisplay { get; set; }
		public string createDate { get; set; }
		public string updateDate { get; set; }
		public Glass glass { get; set; }
		public Srm srm { get; set; }
		public Style style { get; set; }
	}
}