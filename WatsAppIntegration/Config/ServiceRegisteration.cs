using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WatsAppIntegration.Abstraction;
using WatsAppIntegration.Imp;

namespace WatsAppIntegration.Config
{
	public static class ServiceRegisteration
	{

		public static void FacebookApiServicesRegistration(this HostApplicationBuilder? builder)
		{
			if (builder == null)
			{
				return;
			}
			var _configuration = builder.Configuration;

			builder.Services.AddTransient<IWatsAppMsgApi, WatsAppMsgApi>();
			builder.Services.Configure<FaceBookGraphApiConfig>(_configuration.GetSection("FaceBookGraphApi"));

		}
	}
}
