using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
	public class DayActivityConfiguration : IEntityTypeConfiguration<DayActivity>
	{
		public void Configure(EntityTypeBuilder<DayActivity> builder)
		{
			builder.HasKey(e => new { e.DayId, e.ActivityId })
				   .IsClustered(false);
			builder.HasOne(d => d.Day)
					.WithMany(d => d.DayActivities)
					.HasForeignKey(d => d.DayId);
			builder.HasOne(a => a.Activity)
				   .WithMany(a => a.DayActivities)
				   .HasForeignKey(a => a.ActivityId)
				   .OnDelete(DeleteBehavior.ClientSetNull);
		}
	}
}
