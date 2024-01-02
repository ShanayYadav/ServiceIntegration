using RestShrapWrapper.Abstraction;
using RestShrapWrapper.Domian;

namespace RestShrapWrapper.Imp
{
	public class RequestEvent : IRequestEvent
	{
		IAuditingRestClient _restClient;

		public RequestEvent(IAuditingRestClient restClient)
		{
			_restClient = restClient;
		}

		public ValueTask OnBeforeRequest(HttpRequestMessage requestMessage)
		{
			var reqBody = requestMessage.Content.ReadAsStringAsync().Result;
			//TODO : complete the code
			_restClient.InsertIntegrationAudit(new TIntegrationAudit { });
			return new ValueTask();
		}

		public ValueTask OnAfterRequest(HttpResponseMessage requestMessage)
		{
			var resBody = requestMessage.Content.ReadAsStringAsync().Result;
			//TODO : complete the code
			_restClient.InsertIntegrationAudit(new TIntegrationAudit { });
			return new ValueTask();
		}
	}
}
