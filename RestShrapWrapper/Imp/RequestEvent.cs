using RestShrapWrapper.Abstraction;
using RestShrapWrapper.Domian;
using RestShrapWrapper.Enums;
using RestShrapWrapper.Utility;

namespace RestShrapWrapper.Imp
{
	public class RequestEvent : IRequestEvent
	{
		IIntegrationAuditDal _restClient;

		public RequestEvent(IIntegrationAuditDal restClient)
		{
			_restClient = restClient;
		}

		public ValueTask OnBeforeRequest(HttpRequestMessage requestMessage)
		{
			try
			{
				AuditRequestRecordAsync(requestMessage);
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
				AuditResponseRecordAsync(responseMessage);
			}
			catch (Exception ex)
			{

			}
			return new ValueTask();
		}


		private int AuditRequestRecord(HttpRequestMessage requestMessage)
		{
			try
			{
				var auiditEntry = AuditRequestRecordMapper(requestMessage);
				//TODO : complete the code
				return _restClient.InsertIntegrationAudit(auiditEntry);

			}
			catch (Exception ex)
			{

			}
			return 0;
		}

		private async Task<int> AuditRequestRecordAsync(HttpRequestMessage requestMessage)
		{
			int result = 0;
			try
			{
				var auiditEntry = AuditRequestRecordMapper(requestMessage);
				//TODO : complete the code
				result = await _restClient.InsertIntegrationAuditAysnc(auiditEntry);
			}
			catch (Exception ex)
			{

			}
			return result;
		}

		private TIntegrationAudit AuditRequestRecordMapper(HttpRequestMessage requestMessage)
		{
			var reqBody = requestMessage.Content.ReadAsStringAsync().Result;
			reqBody = reqBody.Replace("\r\n", "")?.Replace("\u0022", "");
			var header = "{" + requestMessage.Headers.GetHeaders() + "}";
			var traceId = requestMessage.Headers.GetTraceIdHedaerValue();
			return new TIntegrationAudit
			{
				ApiType = (int)requestMessage.Headers.GetApiTypeHeader(),
				CreatedDate = DateTime.Now,
				HttpStatus = 0,
				RecordType = (int)RecordType.Request,
				Content = $"Url :{requestMessage.RequestUri}, Method: {requestMessage.Method} Headers: {header}, body: {reqBody}",
				TraceId = traceId
			};
		}

		private int AuditResponseRecord(HttpResponseMessage responseMessage)
		{
			try
			{
				var auiditEntry = AuditResponseRecordMapper(responseMessage);
				//TODO : complete the code
				return _restClient.InsertIntegrationAudit(auiditEntry);

			}
			catch (Exception ex)
			{

			}
			return 0;
		}

		private async Task<int> AuditResponseRecordAsync(HttpResponseMessage responseMessage)
		{
			int result = 0;
			try
			{
				var auiditEntry = AuditResponseRecordMapper(responseMessage);
				//TODO : complete the code
				result = await _restClient.InsertIntegrationAuditAysnc(auiditEntry);
			}
			catch (Exception ex)
			{

			}
			return result;
		}

		private TIntegrationAudit AuditResponseRecordMapper(HttpResponseMessage responseMessage)
		{
			var resBody = responseMessage.Content.ReadAsStringAsync().Result;
			var header = responseMessage.Headers.GetHeaders();
			var traceId = responseMessage.RequestMessage.Headers.GetTraceIdHedaerValue();
			return new TIntegrationAudit
			{
				ApiType = (int)responseMessage.RequestMessage.Headers.GetApiTypeHeader(),
				CreatedDate = DateTime.Now,
				HttpStatus = (int)responseMessage.StatusCode,
				RecordType = (int)RecordType.Response,
				Content = $"Headers: {header}, body: {resBody}",
				TraceId = traceId
			};
		}

	}
}
