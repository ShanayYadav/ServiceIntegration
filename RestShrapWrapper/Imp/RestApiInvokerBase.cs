using RestSharp;
using RestShrapWrapper.Abstraction;
using RestShrapWrapper.JsonPolicy;
using RestShrapWrapper.Utility;
using System.Text.Json;

namespace RestShrapWrapper.Imp
{
	public abstract class RestApiInvokerBase
	{
		IRequestEvent _requestEvent;
		public RestApiInvokerBase(IRequestEvent requestEvent)
		{
			_requestEvent = requestEvent;
		}

		protected internal TReturn RestApiCall<TSource, TReturn>(string url, TSource source, Dictionary<string, string> headers, Method method) where TReturn : class, new()
		{
			TReturn result = new TReturn();
			var baseUrl = string.IsNullOrWhiteSpace(url) ? string.Empty : url;
			try
			{
				var options = new RestClientOptions("")
				{
					MaxTimeout = -1
				};
				var client = new RestClient(options);
				var request = new RestRequest(url, method);
				request.OnBeforeRequest += _requestEvent.OnBeforeRequest;
				request.OnAfterRequest += _requestEvent.OnAfterRequest;
				request.AddHeaders(headers);
				var serializeOptions = new JsonSerializerOptions
				{
					PropertyNamingPolicy = new LowerCaseJsonNamingPolicy(),
					WriteIndented = true
				};
				if (method != Method.Get)
				{
					var reqStringBody = JsonSerializer.Serialize(source, serializeOptions);
					request.AddStringBody(reqStringBody, DataFormat.Json);
				}
				var response = client.Execute<TReturn>(request);
				var rs = JsonSerializer.Serialize(response);
				return response.Data;
			}
			catch (Exception ex)
			{

			}
			finally
			{

			}

			return result;
		}
	}
}
