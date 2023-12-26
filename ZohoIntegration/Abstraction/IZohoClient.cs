using ZohoIntegration.Domain;

namespace ZohoAbstraction
{
    public interface IZohoClient
    {
        string ZohoOpenConnectUrl(ZohoConsentRequestModel model);
        ZohoAuthTokenResponseModel GenerateZohoAuthToken(ZohoAuthTokenRequestModel zohoAuthTokenRequestModel);
    }
}
