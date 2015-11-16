using System.Threading;
using System.Web.Http;
using DotNextRZD.PublicApi.Handlers;
using DotNextRZD.PublicApi;
using DotNextRZD.PublicApi.Swagger;
using Microsoft.Owin;
using Newtonsoft.Json;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace DotNextRZD.PublicApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            var jsonformatter = config.Formatters.JsonFormatter;
            jsonformatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            jsonformatter.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            var xmlformatter = config.Formatters.XmlFormatter;
            xmlformatter.UseXmlSerializer = true;

            //config.EnableSystemDiagnosticsTracing();

            config.MessageHandlers.Add(new NullJsonHandler());
            config.RegisterSwagger();
            config.EnsureInitialized();
            app.UseWebApi(config);
        }
    }
}

