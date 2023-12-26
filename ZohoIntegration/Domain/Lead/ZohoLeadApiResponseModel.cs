using ZohoIntegration.Domain.Shared;

namespace ZohoIntegration.Domain.Lead
{
    public class ZohoLeadApiResponseModel
    {
        public string Code { get; set; }
        public ResponseDetails Details { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}
