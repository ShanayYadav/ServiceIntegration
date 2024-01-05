using RestShrapWrapper.Abstraction;
using RestShrapWrapper.Domian;
using RestShrapWrapper.Utility;
using System.Text.Json;

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
			try
			{
				var reqBody = JsonSerializer.Serialize(requestMessage.Content.ReadAsStringAsync().Result);
				reqBody.Replace("\r\n", "");
				reqBody.Replace("\u0022", "");
				var header = requestMessage.Headers.GetHeaders();
				var traceId = requestMessage.Headers.GetValues("traceid").FirstOrDefault();
				var auiditEntry = new TIntegrationAudit
				{
					ApiType = 1,
					CreatedDate = DateTime.Now,
					HttpStatus = 0,
					RecordType = 1,
					Content = $"Url :{requestMessage.RequestUri}, Method: {requestMessage.Method} Headers: {header}, body: {reqBody}",
					TraceId = traceId
				};
				//TODO : complete the code
				_restClient.InsertIntegrationAudit(auiditEntry);
				return new ValueTask();
			}
			catch (Exception ex)
			{

			}
			return new ValueTask();
		}

		public ValueTask OnAfterRequest(HttpResponseMessage responseMessage)
		{
			try
			{
				var resBody = responseMessage.Content.ReadAsStringAsync().Result;
				var header = responseMessage.Headers.GetHeaders();
				var traceId = responseMessage.RequestMessage.Headers.GetValues("traceid").FirstOrDefault();
				//TODO : complete the code
				_restClient.InsertIntegrationAudit(new TIntegrationAudit
				{
					ApiType = 1,
					CreatedDate = DateTime.Now,
					HttpStatus = (int)responseMessage.StatusCode,
					RecordType = 2,
					Content = $"Headers: {header}, body: {resBody}",
					TraceId = traceId
				});

			}
			catch (Exception ex)
			{

			}
			return new ValueTask();
		}
	}
}
