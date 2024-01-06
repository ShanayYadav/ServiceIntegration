using RestShrapWrapper.Domian;

namespace RestShrapWrapper.Abstraction
{
	public interface IIntegrationAuditDal
	{
		int InsertIntegrationAudit(TIntegrationAudit audit);
		Task<int> InsertIntegrationAuditAysnc(TIntegrationAudit audit);
	}
}
