using Microsoft.Extensions.Options;
using RestSharp;
using RestShrapWrapper.Abstraction;
using RestShrapWrapper.Config;
using RestShrapWrapper.JsonPolicy;
using RestShrapWrapper.Utility;
using System.Text.Json;
using RestShrapWrapper.Config;

namespace RestShrapWrapper.Imp
{
	public abstract class RestApiInvokerBase
	{
		IRequestEvent _requestEvent;
		RestShrapConfig _restSharpConfig;
		public RestApiInvokerBase(IRequestEvent requestEvent, IOptions<RestShrapConfig> restSharpConfig)
		{
			_requestEvent = requestEvent;
			_restSharpConfig = restSharpConfig.Value;
		}

		protected internal TReturn RestApiCall<TSource, TReturn>(string url, TSource source, Dictionary<string, string> headers, Method method) where TReturn : class, new()
		{
			TReturn result = new TReturn();
			var baseUrl = string.IsNullOrWhiteSpace(url) ? string.Empty : url;
			try
			{
				var options = new RestClientOptions()
				{
					MaxTimeout = -1
				};
				var client = new RestClient(options);
				var request = new RestRequest(url, method);
				if (_restSharpConfig != null && _restSharpConfig.EnableIntegrationAudit)
				{
					request.OnBeforeRequest += _requestEvent.OnBeforeRequest;
					request.OnAfterRequest += _requestEvent.OnAfterRequest;
				}
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
