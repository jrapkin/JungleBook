using JungleBook.Contracts;
using JungleBook.Models;

namespace JungleBook.Data
{
	public class AddressRepository : RepositoryBase<Address>, IAddressRepository
	{
		public AddressRepository(ApplicationDbContext applicationDbContext)
			:base (applicationDbContext)
		{
		}
	}
}
