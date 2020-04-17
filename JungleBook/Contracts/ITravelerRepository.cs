using JungleBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Contracts
{
	public interface ITravelerRepository : IRepositoryBase<Traveler>
	{
		void CreateTraveler(Traveler traveler);
	}
}
