namespace DotNextRZD.PublicApi.Routes
{
    public class TrainsToControllerRoutes
    {
        public const string BasePrefix = RailwayStationsControllerRoutes.BasePrefix + "/{station}/arrivals";
        public const string GetAll = "";
        public const string GetById = "{id:int}";
    }
}