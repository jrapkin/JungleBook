using JungleBook.Contracts;
using JungleBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Data
{
	public class TravelerRepository : RepositoryBase<Traveler>, ITravelerRepository
	{
		public TravelerRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{
		}
		public void CreateTraveler(Traveler traveler) => Create(traveler);
	}
}
