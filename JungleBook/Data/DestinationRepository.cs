using JungleBook.Contracts;
using JungleBook.Models;

namespace JungleBook.Data
{
	public class DestinationRepository : RepositoryBase<Destination>, IDestinationRepository
	{
		public DestinationRepository(ApplicationDbContext applicationDbContext)
			:base(applicationDbContext)
		{
		}
	}
}
