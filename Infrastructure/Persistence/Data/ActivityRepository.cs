using Application.Interfaces;
using Domain.Models;

namespace Infrastructure.Persistence.Data
{
	public class ActivityRepository : RepositoryBase<Activity>, IActivityRepository
	{
		public ActivityRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{

		}
	}
}
