using Microsoft.EntityFrameworkCore;

namespace RestShrapWrapper.Domian
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
