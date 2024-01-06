using RestShrapWrapper.Abstraction;
using RestShrapWrapper.Domian;

namespace RestShrapWrapper.Imp
{
    public sealed class IntegrationAuditDal : IIntegrationAuditDal
	{
		private IntegrationAuditingContext _context;

		public IntegrationAuditDal(IntegrationAuditingContext context)
		{
			_context = context;
		}

		public int InsertIntegrationAudit(TIntegrationAudit audit)
		{
			_context.IntegrationAudits.Add(audit);
			return _context.SaveChanges();
		}

		public async Task<int> InsertIntegrationAuditAysnc(TIntegrationAudit audit)
		{
			_context.IntegrationAudits.Add(audit);
			return await _context.SaveChangesAsync();
		}
	}
}
