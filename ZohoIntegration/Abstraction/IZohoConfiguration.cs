using ZohoIntegration.Domain.Config;
using ZohoIntegration.Domain.Enum;

namespace ZohoAbstraction
{
    public interface IZohoConfiguration
	{
		ZohoApi GetZohoConfiguration(ZohoClientTypeEnum clientType);
	}
}