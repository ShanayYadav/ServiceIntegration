using ZohoIntegration.Domain.Enum;

namespace ZohoIntegration.Domain
{
    public class ZohoConfigurationModel
    {
        public string ConsentUri { get; set; }
        public string BaseUrl { get; set; }
        public string GrantType { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Code { get; set; }
        public string RedirectUri { get; set; }
        public string Scope { get; set; }
        public ZohoClientTypeEnum ClientType { get; set; }
    }
}