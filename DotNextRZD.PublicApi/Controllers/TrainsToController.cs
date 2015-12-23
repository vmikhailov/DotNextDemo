using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using DotNextRZD.PublicApi.Models;
using DotNextRZD.PublicApi.Routes;
using DotNextRZD.PublicApi.Swagger;

namespace DotNextRZD.PublicApi.Controllers
{
    [RoutePrefix(TrainsToControllerRoutes.BasePrefix)]
    [SwaggerControllerDescription("RailwayStations", null)]
    public class TrainsToController : TrainsController
    {
        private IQueryable<TrainTripModel> GetTrains(int code)
        {
            var cmp = StringComparer.CurrentCultureIgnoreCase;
            int i = 1;
            var l = new List<TrainTripModel>();
            foreach (var t in testData.AsQueryable().Where(x => cmp.Compare(x.DestinationRailwayStationId, code) == 0))
            {
                l.Add(new TrainTripModel() {Id = i++, Train = t});
            }
            return l.AsQueryable();
        }

        /// <summary>
        ///     Retreive all trains arriving to the station specified
        /// </summary>
        /// <param name="station">station code</param>
        /// <returns>
        ///     Train infomormation model
        /// </returns>
        [HttpGet]
        [Route(TrainsToControllerRoutes.GetAll)]
        [EnableQuery]
        public IQueryable<TrainTripModel> GetAll(int station)
        {
            return GetTrains(station);
        }

        /// <summary>
        ///     Retreive a particular train arriving to the station specified
        /// </summary>
        /// <param name="station">station code</param>
        /// <param name="id">train id</param>
        /// <returns>
        ///     Train infomormation model
        /// </returns>
        [HttpGet]
        [Route(TrainsToControllerRoutes.GetById)]
        public TrainTripModel GetById(int station, int id)
        {
            return GetTrains(station).SingleOrDefault(x => x.Id == id);
        }
    }
}