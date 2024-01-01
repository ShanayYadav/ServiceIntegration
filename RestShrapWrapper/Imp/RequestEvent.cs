namespace RestShrapWrapper.Imp
{
	public class RequestEvent
	{
		AuditingRestClient _restClient;

		public RequestEvent(IntegrationAuditingContext dbcontext)
		{
			_restClient = new AuditingRestClient(dbcontext);
		}

		public ValueTask OnBeforeRequest(HttpRequestMessage requestMessage)
		{
			var reqBody = requestMessage.Content.ReadAsStringAsync().Result;
			return new ValueTask();
		}

		public ValueTask OnAfterRequest(HttpResponseMessage requestMessage)
		{
			var resBody = requestMessage.Content.ReadAsStringAsync().Result;
			return new ValueTask();
		}
	}
}
