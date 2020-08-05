using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
	public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
	{
		public void Configure(EntityTypeBuilder<Activity> builder)
		{
			builder.HasKey(e => e.ActivityId);

			builder.Property(e => e.Name)
				   .HasColumnName("Name");

			builder.Property(e => e.Description)
				   .HasColumnName("Description");

			builder.OwnsOne(e => e.Address);

		}
	}
}
