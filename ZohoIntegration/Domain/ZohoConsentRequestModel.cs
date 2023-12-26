namespace ZohoIntegration.Domain
{
    public class ZohoConsentRequestModel
    {
        public string ConsentUri { get; set; }
        public string ClientId { get; set; }
        public string RedirectUrl { get; set; }
        public string BaseUrl { get; set; }
        public string Scope { get; set; }
    }
}