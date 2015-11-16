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
    [RoutePrefix(TrainsFromControllerRoutes.BasePrefix)]
    [SwaggerControllerDescription("RailwayStations", null)]
    public class TrainsFromController : TrainsController
    {
        private static IQueryable<TrainModel> GetTrains(int code)
        {
            var cmp = StringComparer.CurrentCultureIgnoreCase;
            var filtered = testData.AsQueryable().Where(x => cmp.Compare(x.OriginRailwayStationId, code) == 0);
            return filtered;
        }

        /// <summary>
        ///     Retreive all trains departuring from the railway station specified
        /// </summary>
        /// <param name="station">railway station id</param>
        /// <returns>
        ///     Train infomormation model
        /// </returns>
        [HttpGet]
        [Route(TrainsFromControllerRoutes.GetAll)]
        [EnableQuery]
        public Task<IQueryable<TrainModel>> GetAll(int station)
        {
            return Task.FromResult(GetTrains(station));
        }

        /// <summary>
        ///     Retreive a particular train departuring from the railway station specified
        /// </summary>
        /// <param name="station">railway station id</param>
        /// <param name="id">train id</param>
        /// <returns>
        ///     Train infomormation model
        /// </returns>
        [HttpGet]
        [Route(TrainsFromControllerRoutes.GetById)]
        public Task<TrainModel> GetById(int station, int id)
        {
            return Task.FromResult(GetTrains(station).SingleOrDefault(x => x.Id == id));
        }
    }
}