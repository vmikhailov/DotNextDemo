using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using DotNextRZD.PublicApi.Model;
using DotNextRZD.PublicApi.Routes;
using DotNextRZD.PublicApi.Swagger;

namespace DotNextRZD.PublicApi.Controllers
{
    /// <summary>
    ///     RailwayStations controller
    /// </summary>
    /// <remarks>ssss</remarks>
    [RoutePrefix(RailwayStationsControllerRoutes.BasePrefix)]
    [SwaggerDescription("RailwayStations", "Information about all railway stations")]
    public class RailwayStationsController : ApiController
    {
        #region Test Data

        public static RailwayStationModel[] testData =
        {
            new RailwayStationModel {Id = 1, CityId = 77, Name = "Белорусский вокзал"},
            new RailwayStationModel {Id = 2, CityId = 77, Name = "Казанский вокзал"},
            new RailwayStationModel {Id = 3, CityId = 77, Name = "Киевский вокзал"},
            new RailwayStationModel {Id = 4, CityId = 77, Name = "Курский вокзал"},
            new RailwayStationModel {Id = 5, CityId = 77, Name = "Ленинградский вокзал"},
            new RailwayStationModel {Id = 6, CityId = 77, Name = "Павелецкий вокзал"},
            new RailwayStationModel {Id = 7, CityId = 77, Name = "Рижский вокзал"},
            new RailwayStationModel {Id = 8, CityId = 77, Name = "Савёловский вокзал"},
            new RailwayStationModel {Id = 9, CityId = 77, Name = "Ярославский вокзал"},
            new RailwayStationModel {Id = 10, CityId = 78, Name = "Московский вокзал"},
            new RailwayStationModel {Id = 11, CityId = 78, Name = "Финляндский вокзал"},
            new RailwayStationModel {Id = 12, CityId = 78, Name = "Балтийский вокзал"},
            new RailwayStationModel {Id = 13, CityId = 78, Name = "Ладожский вокзал"}
        };

        #endregion


        [HttpGet]
        [Route(RailwayStationsControllerRoutes.GetAll)]
        public RailwayStationModel[] GetAll()
        {
            return testData;
        }


        /// <summary>
        ///     Get all railway stations
        /// </summary>
        /// <returns>all available railway stations</returns>
        /// <remarks>
        ///     This method returns all available railway station without any trains
        /// </remarks>
        //[HttpGet]
        //[Route(RailwayStationsControllerRoutes.GetAll)]
        [EnableQuery()]
        public IQueryable<RailwayStationModel> GetAll11()
        {
            return testData.AsQueryable().Take(100);
        }

        /// <summary>
        ///     Get railway station by Id
        /// </summary>
        /// <param name="id">RailwayStation Id</param>
        /// <returns>Requested railway station</returns>
        /// <response code="200">Success</response>
        /// <response code="404">No railway station found</response>
        [HttpGet]
        [Route(RailwayStationsControllerRoutes.GetById)]
        public RailwayStationModel GetById(int id)
        {
            var station = testData.SingleOrDefault(x => x.Id == id);
            return CreateResponse(station);
        }

        /// <summary>
        ///     Get railway station by internation railway station's code
        /// </summary>
        /// <param name="code">RailwayStation code</param>
        /// <returns>Requested railway station</returns>
        /// <response code="200">Success</response>
        /// <response code="404">No railway station found</response>
        [HttpGet]
        [Route(RailwayStationsControllerRoutes.GetByCode)]
        public RailwayStationModel GetByCode(string code)
        {
            var cmp = StringComparer.CurrentCultureIgnoreCase;
            var station = testData.SingleOrDefault(x => cmp.Compare(x.Code, code) == 0);
            return CreateResponse(station);
        }

        private RailwayStationModel CreateResponse(RailwayStationModel station)
        {
            if (station == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("no railway station found by id")
                });
            }
            return station;
        }

        /// <summary>
        ///     Create an railway station
        /// </summary>
        /// <param name="model">railway station data</param>
        /// <returns>The railway station created and persisted</returns>
        [HttpPost]
        [Route(RailwayStationsControllerRoutes.Create)]
        public RailwayStationModel Create(RailwayStationModel model)
        {
            return model;
        }

        /// <summary>
        ///     Update an railway station
        /// </summary>
        /// <param name="model">railway station data</param>
        /// <returns>The railway station updated</returns>
        [HttpPut]
        [Route(RailwayStationsControllerRoutes.Update)]
        public RailwayStationModel Update(RailwayStationModel model)
        {
            return model;
        }

        /// <summary>
        ///     Delete all railway station
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route(RailwayStationsControllerRoutes.Delete)]
        public void DeleteAll()
        {
        }

        /// <summary>
        ///     Delete an railway station by Id
        /// </summary>
        /// <param name="id">railway station Id</param>
        /// <returns></returns>
        /// <response code="404">if no railway station found</response>
        [HttpDelete]
        [Route(RailwayStationsControllerRoutes.DeleteById)]
        public void DeleteById(int id)
        {
        }

        /// <summary>
        ///     Delete an railway station by railway station's code
        /// </summary>
        /// <param name="code">railway station code</param>
        /// <returns></returns>
        /// <response code="404">if no railway station found</response>
        [HttpDelete]
        [Route(RailwayStationsControllerRoutes.DeleteByCode)]
        public void DeleteByCode(string code)
        {
        }
    }
}