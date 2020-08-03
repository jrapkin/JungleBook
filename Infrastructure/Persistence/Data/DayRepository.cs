using Application.Interfaces;
using Domain.Models;

namespace Infrastructure.Persistence.Data
{
	public class DayRepository : RepositoryBase<Day>, IDayRepository
	{
		public DayRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{

		}
		public void CreateDay(Day day)
		{
			Create(day);
		}
	}
}
