using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using DotNextRZD.PublicApi.Models;
using DotNextRZD.PublicApi.Routes;
using DotNextRZD.PublicApi.Swagger;

namespace DotNextRZD.PublicApi.Controllers
{
    /// <summary>
    ///     Trains infromation controller
    /// </summary>
    [RoutePrefix(TrainsControllerRoutes.BasePrefix)]
    [SwaggerControllerDescription("Information about all trains")]
    public class TrainsController : ApiController
    {
        /// <summary>
        ///     Retreive all trains infromation
        /// </summary>
        /// <returns>
        ///     Train infomormation model
        /// </returns>
        [HttpGet]
        [Route(TrainsControllerRoutes.GetAll)]
        [EnableQuery]
        public IQueryable<TrainScheduleModel> GetAll()
        {
            return testData.AsQueryable();
        }

        /// <summary>
        ///     Retreive a particular trains infromation
        /// </summary>
        /// <param name="id">train id</param>
        /// <returns>Train infomormation model</returns>
        [HttpGet]
        [Route(TrainsControllerRoutes.GetById)]
        public TrainScheduleModel GetById(int id)
        {
            var train = testData.SingleOrDefault(x => x.Id == id);
            if (train == null)
            {
                throw ErrorResponse.CreateException(HttpStatusCode.NotFound, "no train found by id");
            }
            return train;
        }

        #region Test Data

        internal static TrainScheduleModel[] testData;

        static TrainsController()
        {
            var r = new Random();
            var cnt = r.Next(1000) + 1000;
            var flcnt = RailwayStationsController.testData.Count();

            var trains = new List<TrainScheduleModel>();

            var i = 0;
            while (i < cnt)
            {
                var f1 = RailwayStationsController.testData[r.Next(flcnt)];
                var f2 = RailwayStationsController.testData[r.Next(flcnt)];
                if (f1 == f2) continue;
                trains.Add(new TrainScheduleModel
                {
                    Id = i + 1, 
                    OriginRailwayStationId = f1.Id, 
                    OriginRailwayStationName = f1.Name,
                    DestinationRailwayStationId = f2.Id,
                    DestinationRailwayStationName = f2.Name});
                i++;
            }
            testData = trains.ToArray();
        }

        #endregion
    }
}