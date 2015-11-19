using System.Web.Http;
using DotNextRZD.PublicApi;
using DotNextRZD.PublicApi.Config;
using DotNextRZD.PublicApi.Swagger;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace DotNextRZD.PublicApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.RegisterWebApi();
            config.RegisterSwagger();

            config.EnsureInitialized();
            app.UseWebApi(config);
        }
    }
}