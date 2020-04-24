using JungleBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Contracts
{
	public interface IHikingProject
	{
		Task<HikingResult> SearchForHikingSpots(string latitude, string longitude);
		Task<CampingResult> Search(string latitude, string longitude);
	}
}
