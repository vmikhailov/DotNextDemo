using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using DotNextRZD.PublicApi.Models;
using DotNextRZD.PublicApi.Routes;
using DotNextRZD.PublicApi.Swagger;

namespace DotNextRZD.PublicApi.Controllers
{
    [RoutePrefix(TrainsFromControllerRoutes.BasePrefix)]
    [SwaggerControllerDescription("RailwayStations", null)]
    public class TrainsFromController : TrainsController
    {
        private IQueryable<TrainTripModel> GetTrains(int code)
        {
            var cmp = StringComparer.CurrentCultureIgnoreCase;
            int i = 1;
            var l = new List<TrainTripModel>();
            foreach (var t in testData.AsQueryable().Where(x => cmp.Compare(x.OriginRailwayStationId, code) == 0))
            {
                l.Add(new TrainTripModel() { Id = i++, Train = t });
            }
            return l.AsQueryable();
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
        public IQueryable<TrainTripModel> GetAll(int station)
        {
            return GetTrains(station);
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
        public TrainTripModel GetById(int station, int id)
        {
            var train = GetAll(station).SingleOrDefault(x => x.Id == id);
            if (train == null)
            {
                throw ErrorResponse.CreateException(HttpStatusCode.NotFound, "no train found by id");
            }
            return train;
        }
    }
}