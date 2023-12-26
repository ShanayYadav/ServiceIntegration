using ZohoIntegration.Domain;
using ZohoIntegration.Domain.Enum;

namespace ZohoAbstraction
{
	public interface IZohoConfiguration
	{
		ZohoConfigurationModel GetZohoConfiguration(ZohoClientTypeEnum clientType);
	}
}