using Application.Interfaces;
using Domain.Models;

namespace Infrastructure.Persistence.Data
{
	public class AccommodationRepository : RepositoryBase<Accommodation>, IAccommodationRepository
	{
		public AccommodationRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{

		}
	}
}
