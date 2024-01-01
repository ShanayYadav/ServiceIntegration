using Microsoft.EntityFrameworkCore;
using RestShrapWrapper.Domian;

namespace RestShrapWrapper
{
	public class IntegrationAuditingContext : DbContext
	{
		public IntegrationAuditingContext(DbContextOptions options)
			: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(IntegrationAuditingContext).Assembly);
		}

		public DbSet<TIntegrationAudit> IntegrationAudits { get; set; }
	}
}
