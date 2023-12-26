namespace ZohoIntegration.Domain
{
    public class ZohoAuthTokenResponseModel
    {
        public string code { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string api_domain { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string scope { get; set; }
    }
}
