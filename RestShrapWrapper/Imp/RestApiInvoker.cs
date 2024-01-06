using Microsoft.Extensions.Options;
using RestSharp;
using RestShrapWrapper.Abstraction;
using RestShrapWrapper.Config;

namespace RestShrapWrapper.Imp
{
	public class RestApiInvoker : RestApiInvokerBase, IRestApiInvoker
	{
		public RestApiInvoker(IRequestEvent requestEvent, IOptions<RestShrapConfig> restSharpConfig)
			: base(requestEvent, restSharpConfig)
		{

		}

		public TReturn Get<TReturn>(string url) where TReturn : class, new()
		{
			var result = Get<TReturn>(url, null);
			return result;
		}

		public TReturn Get<TReturn>(string url, Dictionary<string, string> headers) where TReturn : class, new()
		{
			TReturn result = new TReturn();
			return result;
		}

		public TReturn Post<TSource, TReturn>(string url, TSource source) where TReturn : class, new()
		{
			TReturn result = new TReturn();
			return result;
		}

		public TReturn Post<TSource, TReturn>(string url, TSource source, Dictionary<string, string> headers) where TReturn : class, new()
		{
			return RestApiCall<TSource, TReturn>(url, source, headers, Method.Post);
		}

	}
}
