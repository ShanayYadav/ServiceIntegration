using RestShrapWrapper.Abstraction;
using RestShrapWrapper.Domian;

namespace RestShrapWrapper.Imp
{
	public sealed class AuditingRestClient : IAuditingRestClient
	{
		private IntegrationAuditingContext _context;

		public AuditingRestClient(IntegrationAuditingContext context)
		{
			_context = context;
		}

		public int InsertIntegrationAudit(TIntegrationAudit audit)
		{
			_context.IntegrationAudits.Add(audit);
			return _context.SaveChanges();
		}
	}
}
