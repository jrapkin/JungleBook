using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Models.ViewModels
{
	public class MapViewModel
	{
		Trip Trips { get; set; }
		public List<Destination> VisitedDestinations { get; set; }
		public List<Destination> FutureDestinations { get; set; }
		
	}
}
