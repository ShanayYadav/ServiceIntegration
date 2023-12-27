using ZohoIntegration.Domain;

namespace ZohoAbstraction
{
    public interface IZohoClient
    {
        string ZohoOpenConnectUrl(ZohoOpenConnectRequestModel model);
        ZohoAuthTokenResponseModel GenerateZohoAuthToken(ZohoAuthTokenRequestModel zohoAuthTokenRequestModel);
    }
}
