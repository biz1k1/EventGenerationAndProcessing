using Generator.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Processor.Model.Entity;

namespace Processor.Infrastructure
{
	/// <summary>
	/// Класс для конфигурации БД таблиц
	/// </summary>
	public class IncidentConfiguration : IEntityTypeConfiguration<IncidentEntity>
	{
		public void Configure(EntityTypeBuilder<IncidentEntity> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();
		}

	
	}public class EventConfiguration : IEntityTypeConfiguration<EventEntity>
	{
		public void Configure(EntityTypeBuilder<EventEntity> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();
			builder
				.HasMany(x => x.Incident)
				.WithMany(x => x.Events);
		}

	}
}
