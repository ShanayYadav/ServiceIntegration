using ZohoAbstraction;
using Microsoft.Extensions.Options;
using ZohoIntegration.Domain;
using ZohoIntegration.Domain.Enum;

namespace ZohoIntegration.Imp
{
    public class ZohoAppSettingConfiguration : IZohoConfiguration
    {
        ZohoConfiguration _zohoConfiguration;
        public ZohoAppSettingConfiguration(IOptions<ZohoConfiguration> configuration)
        {
            _zohoConfiguration = configuration.Value;
        }

        public ZohoConfigurationModel GetZohoConfiguration(ZohoClientTypeEnum clientType)
        {
            if (clientType == ZohoClientTypeEnum.None)
            {
                throw new ArgumentException("Set ZohoClientTypeEnum before");
            }

            if (_zohoConfiguration == null || _zohoConfiguration.ZohoConfigurationModel == null ||
                _zohoConfiguration.ZohoConfigurationModel.Count == 0)
            {
                throw new Exception("ZohoConfiguration is not defined in application configuration");
            }
            return _zohoConfiguration.ZohoConfigurationModel.First(x => x.ClientType == clientType);
        }
    }
}
