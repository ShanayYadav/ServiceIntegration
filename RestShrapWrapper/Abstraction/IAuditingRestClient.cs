using RestShrapWrapper.Domian;

namespace RestShrapWrapper.Abstraction
{
	public interface IAuditingRestClient
	{
		int InsertIntegrationAudit(TIntegrationAudit audit);
	}
}
