using JungleBook.Contracts;
using JungleBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Data
{
	public class DayActivityRepository : RepositoryBase<DayActivity>, IDayActivityRepository
	{
		public DayActivityRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{
		}
		public List<DayActivity> GetActivitiesByDay(List<Destination> destinations)
		{
			List<DayActivity> filteredActivities = new List<DayActivity>();
			foreach (var destination in destinations)
			{
				foreach( var day in destination.Days)
				{
					filteredActivities.FindAll(d => d.DayId == day.DayId);
				}
			}
			return filteredActivities;
		}
		public void CreateDayActivity(DayActivity dayActivity)
		{
			Create(dayActivity);
		}
	}
}
