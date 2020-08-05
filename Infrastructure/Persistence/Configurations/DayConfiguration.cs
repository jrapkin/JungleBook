using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
	public class DayConfiguration : IEntityTypeConfiguration<Day>
	{
		public void Configure(EntityTypeBuilder<Day> builder)
		{
			builder.HasKey(e => e.DayId);

			builder.HasOne(e => e.TripItinerary)
				   .WithMany(e => e.Days)
				   .HasForeignKey(e => e.TripItineraryId)
				   .OnDelete(DeleteBehavior.ClientSetNull);
		}
	}
}
