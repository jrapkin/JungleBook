using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Identity;

namespace Infrastructure.Persistence.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Accommodation> Accommodations { get; set; }
		public DbSet<Activity> Activities { get; set; }
		public DbSet<Day> Days { get; set; }
		public DbSet<Destination> Destinations { get; set; }
		public DbSet<Trip> Trips { get; set; }
		public DbSet<TripItinerary> TripItineraries { get; set; }
		public DbSet<Traveler> Travelers { get; set; }
		public DbSet<TravelerTrip> TravelerTrips { get; set; }
		public DbSet<DayActivity> DayActivities { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		}
	}
}
