using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestShrapWrapper.Abstraction;
using RestShrapWrapper.Domian;
using RestShrapWrapper.Imp;

namespace RestShrapWrapper.Config
{
    public static class RestShrapWarpperServiceConfiguration
    {

        public static void RestShrapWarpperConfiguration(this HostApplicationBuilder? builder)
        {
            if (builder == null)
            {
                return;
            }
            var _configuration = builder.Configuration;
            builder.Services.AddDbContext<IntegrationAuditingContext>(options =>
            {
                if (!options.IsConfigured)
                {
                    options.UseSqlServer(_configuration.GetConnectionString("ConStr"));
                }
            });

            builder.Services.AddTransient<IIntegrationAuditDal, IntegrationAuditDal>();
            builder.Services.AddTransient<IRequestEvent, RequestEvent>();
            builder.Services.AddTransient<IRestApiInvoker, RestApiInvoker>();
        }
    }
}
