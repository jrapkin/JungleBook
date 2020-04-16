using JungleBook.Contracts;
using JungleBook.Models;

namespace JungleBook.Data
{
	public class TripRepository : RepositoryBase<Trip>, ITripRepository
	{
		public TripRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{
		}
	}
}
