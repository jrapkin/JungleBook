using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
	public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
	{
		public void Configure(EntityTypeBuilder<Destination> builder)
		{
			builder.HasKey(e => e.DestinationId);

			builder.HasOne(e => e.TripItinerary)
					   .WithMany(e => e.Destinations)
					   .HasForeignKey(e => e.TripItineraryId)
					   .OnDelete(DeleteBehavior.ClientSetNull);

			builder.OwnsOne(e => e.Address);
		}

	}
}
