using JungleBook.Models;
using System.Collections.Generic;

namespace JungleBook.Contracts
{
	public interface IAddressRepository : IRepositoryBase<Address>
	{
		ICollection<Address> GetAllAddresses();
		void CreateAddress(Address address);
		bool CheckIfAddressExists(Address address);
	}
}
