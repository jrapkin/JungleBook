using JungleBook.Contracts;
using JungleBook.Models;
using System.Collections.Generic;
using System.Linq;

namespace JungleBook.Data
{
	public class AddressRepository : RepositoryBase<Address>, IAddressRepository
	{
		public AddressRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{
		}
		public ICollection<Address> GetAllAddresses()
		{
			return FindAll().ToList();
		}
		public void CreateAddress(Address address)
		{
			Create(address);
		}
		public bool CheckIfAddressExists(Address address)
		{
			if (FindByCondition(a => a.AddressId == address.AddressId).Any())
			{
				return true;
			}
			return false;
		}
	}
}
