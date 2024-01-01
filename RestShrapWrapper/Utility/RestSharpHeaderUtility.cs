using RestSharp;

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

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }
            return request;
        }
    }
}
