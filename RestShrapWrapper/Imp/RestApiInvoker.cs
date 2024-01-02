using RestSharp;
using RestShrapWrapper.Abstraction;

namespace RestShrapWrapper.Imp
{
	public class RestApiInvoker : RestApiInvokerBase, IRestApiInvoker
	{
		public RestApiInvoker(IRequestEvent requestEvent) : base(requestEvent)
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
