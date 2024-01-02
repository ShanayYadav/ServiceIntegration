using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WatsAppIntegration.Abstraction;
using WatsAppIntegration.Imp;
using RestShrapWrapper.Abstraction;
using RestShrapWrapper.Imp;
using RestShrapWrapper;
using Microsoft.EntityFrameworkCore;

namespace ApiIntegrationTestApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var builder = Host.CreateApplicationBuilder(args);

			builder.Services.AddDbContext<IntegrationAuditingContext>(options =>
			{
				if (!options.IsConfigured)
				{
					options.UseSqlServer("Data Source=DESKTOP-ST9KBFM;initial catalog=IClapDatabase;User Id='DESKTOP-ST9KBFM\\Gaurav'; Trusted_Connection=true; TrustServerCertificate=true");
				}
			});

			builder.Services.AddTransient<IAuditingRestClient, AuditingRestClient>();
			builder.Services.AddTransient<IRequestEvent, RequestEvent>();
			builder.Services.AddTransient<IRestApiInvoker, RestApiInvoker>();
			builder.Services.AddTransient<IWatsAppMsgApi, WatsAppMsgApi>();
			var host = builder.Build();

			var watsApp = new WatApiCallTest(host.Services.GetService<IWatsAppMsgApi>());
			watsApp.SendMsg();

		}
	}
}