using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WatsAppIntegration.Abstraction;
using WatsAppIntegration.Imp;
using Microsoft.Extensions.Configuration;
using WatsAppIntegration.Domain.Config;
using RestShrapWrapper.Config;

namespace ApiIntegrationTestApp
{
    internal class Program
	{
		static void Main(string[] args)
		{
			var builder = Host.CreateApplicationBuilder(args);
			builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("applicationConfig.json");
			var _configuration = builder.Configuration;
			builder.RegisterServices();
			builder.Services.AddTransient<IWatsAppMsgApi, WatsAppMsgApi>();
			builder.Services.Configure<FaceBookGraphApiConfig>(_configuration.GetSection("FaceBookGraphApi"));
			var host = builder.Build();

			var watsApp = new WatApiCallTest(host.Services.GetService<IWatsAppMsgApi>());
			watsApp.SendMsg();

		}
	}
}