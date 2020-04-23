using JungleBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Contracts
{
	public interface IAddressRepository : IRepositoryBase<Address>
	{
		ICollection<Address> GetAllAddresses();
		void CreateAddress(Address address);
		bool CheckIfAddressExists(Address address);
	}
}
