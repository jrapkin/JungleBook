using JungleBook.Contracts;
using JungleBook.Models;
using System.Collections.Generic;

namespace JungleBook.Data
{
	public class DestinationRepository : RepositoryBase<Destination>, IDestinationRepository
	{
		public DestinationRepository(ApplicationDbContext applicationDbContext)
			:base(applicationDbContext)
		{	
		}
		public void CreateDestination (Destination destination)
		{
			Create(destination);
		}
	}
}
