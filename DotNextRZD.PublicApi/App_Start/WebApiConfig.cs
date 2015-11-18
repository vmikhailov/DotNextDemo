using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using DotNextRZD.PublicApi.Model;

namespace WebApiService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.AddODataQueryFilter();

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.ContainerName = "DotNextDataContext";
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
