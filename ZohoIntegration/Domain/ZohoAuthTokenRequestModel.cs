namespace ZohoIntegration.Domain
{
    public class ZohoAuthTokenRequestModel
    {
        public string ConsentUri { get; set; }
        public string baseUrl { get; set; }
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string code { get; set; }
        public string redirect_uri { get; set; }
    }
}