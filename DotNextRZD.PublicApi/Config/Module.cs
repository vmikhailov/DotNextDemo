using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using DotNextRZD.PublicApi.Handlers;
using DotNextRZD.PublicApi.Model;
using Newtonsoft.Json;

namespace DotNextRZD.PublicApi.Config
{
    public static class Module
    {
        public static void RegisterWebApi(this HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.ConfigureFormatters();
            //config.ConfigureOData();
            //config.EnableSystemDiagnosticsTracing();
        }

        public static void ConfigureFormatters(this HttpConfiguration config)
        {
            var jsonformatter = config.Formatters.JsonFormatter;
            jsonformatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            jsonformatter.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
            var xmlformatter = config.Formatters.XmlFormatter;
            xmlformatter.UseXmlSerializer = true;

            config.MessageHandlers.Add(new NullJsonHandler());
        }

        public static void ConfigureOData(this HttpConfiguration config)
        {
            config.AddODataQueryFilter();

            var builder = new ODataConventionModelBuilder {ContainerName = "DotNextDataContext"};
            builder.EntitySet<TrainModel>("Trains");
            builder.EntitySet<CityModel>("Cities");
            builder.EntitySet<RailwayStationModel>("RailwayStations");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
}