﻿namespace DotNextRZD.PublicApi.Routes
{
    public class TrainsFromControllerRoutes
    {
        public const string BasePrefix = RailwayStationsControllerRoutes.BasePrefix + 
            "/{station:int}/departures";
        public const string GetAll = "";
        public const string GetById = "{id:int}";
    }
}