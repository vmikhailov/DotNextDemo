using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using DotNextRZD.PublicApi.Model;
using DotNextRZD.PublicApi.Routes;
using DotNextRZD.PublicApi.Swagger;

namespace DotNextRZD.PublicApi.Controllers
{
    [RoutePrefix(TrainsToControllerRoutes.BasePrefix)]
    [SwaggerDescription("RailwayStations", null)]
    public class TrainsToController : TrainsController
    {
        private IQueryable<TrainModel> GetTrains(int code)
        {
            var cmp = StringComparer.CurrentCultureIgnoreCase;
            var filtered = testData.AsQueryable().Where(x => cmp.Compare(x.DestinationRailwayStationId, code) == 0);
            return filtered;
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
        public IQueryable<TrainModel> GetAll(int station)
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
        public TrainModel GetById(int station, int id)
        {
            return GetTrains(station).SingleOrDefault(x => x.Id == id);
        }
    }
}