using Generator.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Processor.Model.Entity;
namespace Processor.Infrastructure
{
	/// <summary>
	/// Датаконтекст
	/// </summary>
	public class DataContext:DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new IncidentConfiguration());
		}
		public DbSet<IncidentEntity> Incident { get; set; }
		public DbSet<EventEntity> Events { get; set; }
	}
}
