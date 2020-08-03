using Domain.Models;
using System.Collections.Generic;

namespace Application.Interfaces
{
	public interface IDayActivityRepository : IRepositoryBase<DayActivity>
	{
		List<DayActivity> GetActivitiesByDay(List<Destination> destinations);
		void CreateDayActivity(DayActivity dayActivity);
	}

}
