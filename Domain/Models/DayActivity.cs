using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
	public class DayActivity
	{

		public string ActivityType { get; set; }
		public int? ActivityId { get; set; }
		public int DayId { get; set; }
		public Day Day { get; set; }
		public Activity Activity { get; set; }
	}
}
