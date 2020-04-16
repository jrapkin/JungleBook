using JungleBook.Contracts;
using JungleBook.Models;


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
