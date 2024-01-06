using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WatsAppIntegration.Abstraction;
using Microsoft.Extensions.Configuration;
using RestShrapWrapper.Config;
using WatsAppIntegration.Config;

namespace ApiIntegrationTestApp
{
    internal class Program
	{
		static void Main(string[] args)
		{
			var builder = Host.CreateApplicationBuilder(args);
			builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("applicationConfig.json");
						
			builder.RestShrapWrapperServicesRegistration();
			builder.FacebookApiServicesRegistration();
			
			var host = builder.Build();

			var watsApp = new WatApiCallTest(host.Services.GetService<IWatsAppMsgApi>());
			watsApp.SendMsg();

		}
	}
}