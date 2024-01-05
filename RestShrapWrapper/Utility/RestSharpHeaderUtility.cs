using RestSharp;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace RestShrapWrapper.Utility
{
	public static class RestSharpHeaderUtility
	{
		public static RestRequest AddHeaders(this RestRequest request, Dictionary<string, string> headers)
		{
			if (request == null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("traceid", Guid.NewGuid());
			if (headers != null)
			{
				foreach (var header in headers)
				{
					request.AddHeader(header.Key, header.Value);
				}
			}
			return request;
		}

		public static string GetHeaders(this HttpHeaders headers)
		{
			var reqHeaders = string.Empty;
			var enumerator = headers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				var current = enumerator.Current;
				reqHeaders += $"{current.Key}:{current.Value.FirstOrDefault()}, ";
			}
			return reqHeaders.Substring(0, reqHeaders.Length - 3);
		}

	}
}
