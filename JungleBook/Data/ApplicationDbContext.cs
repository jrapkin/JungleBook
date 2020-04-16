using System;
using System.Collections.Generic;
using System.Text;
using JungleBook.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JungleBook.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Accommodation> Accommodations { get; set; }
		public DbSet<Activity> Activities { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Day> Days { get; set; }
		public DbSet<Destination> Destinations { get; set; }
		public DbSet<Trip> Trips { get; set; }
		public DbSet<Traveler> Travelers { get; set; }
		public DbSet<UserProfile> UserProfiles { get; set; }
		public DbSet<DayActivity> DayActivities { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<DayActivity>().HasKey(d => new { d.DayId, d.ActivityId });
			modelBuilder.Entity<DayActivity>()
						.HasOne(d => d.Day)
						.WithMany(d => d.DayActivities)
						.HasForeignKey(d => d.DayId);
			modelBuilder.Entity<DayActivity>()
						.HasOne(a => a.Activity)
						.WithMany(a => a.DayActivities)
						.HasForeignKey(a => a.ActivityId);
			modelBuilder.Entity<UserProfile>().HasKey(u => new { u.TravelerId, u.TripId });
			modelBuilder.Entity<UserProfile>()
						.HasOne(u => u.Traveler)
						.WithMany(u => u.UserProfiles)
						.HasForeignKey(u => u.TravelerId);
			modelBuilder.Entity<UserProfile>()
						.HasOne(t => t.Trip)
						.WithMany(t => t.UserProfiles)
						.HasForeignKey(t => t.TripId);
		}
	}
}
