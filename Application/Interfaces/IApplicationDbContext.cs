using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
	public interface IApplicationDbContext
	{
		DbSet<Accommodation> Accommodations { get; set; }
		DbSet<Activity> Activities { get; set; }
		DbSet<Day> Days { get; set; }
		DbSet<Destination> Destinations { get; set; }
		DbSet<Trip> Trips { get; set; }
		DbSet<TripItinerary> TripItineraries { get; set; }
		DbSet<Traveler> Travelers { get; set; }
		DbSet<TravelerTrip> TravelerTrips { get; set; }
		DbSet<DayActivity> DayActivities { get; set; }
	}
}
