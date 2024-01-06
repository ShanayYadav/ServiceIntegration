using RestSharp;
using RestShrapWrapper.Enums;
using System.Net.Http.Headers;
using System.Text;

namespace RestShrapWrapper.Utility
{
	public static class RestSharpHeaderUtility
	{
		public const string TRACE_ID_Header_KEY = "traceid";
		public static RestRequest AddHeaders(this RestRequest request, Dictionary<string, string> headers)
		{
			if (request == null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			request.AddHeader("Content-Type", "application/json");
			request.AddHeader(TRACE_ID_Header_KEY, Guid.NewGuid());
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
			var strBuilder = new StringBuilder(string.Empty);
			var enumerator = headers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				var current = enumerator.Current;
				strBuilder.Append($"{current.Key}:{current.Value.FirstOrDefault()}");
				strBuilder.Append(',');
			}
			var reqHeaders = strBuilder.ToString();
			return reqHeaders.Substring(0, reqHeaders.Length - 1);
		}

		public static string GetTraceIdHedaerValue(this HttpHeaders headers)
		{
			return headers?.GetValues(TRACE_ID_Header_KEY).FirstOrDefault();
		}

		public static ApiType GetApiTypeHeader(this HttpHeaders headers)
		{
			var header = headers?.GetValues(HeaderConstant.API_TYPE).FirstOrDefault();
			if (Enum.TryParse(header, true, out ApiType apiType))
			{
				return apiType;
			}
			return ApiType.None;
		}
	}
}
