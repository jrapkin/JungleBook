using JungleBook.Contracts;
using JungleBook.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JungleBook.Data
{
	public class AccommodationRepository : RepositoryBase<Accommodation>, IAccommodationRepository
	{
		public AccommodationRepository(ApplicationDbContext applicationDbContext)
			:base (applicationDbContext)
		{

		}
	}
}
