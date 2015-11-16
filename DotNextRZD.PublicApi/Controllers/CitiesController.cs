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
    ///     Cities controller
    /// </summary>
    /// <remarks>ssss</remarks>
    [RoutePrefix(CitiesControllerRoutes.BasePrefix)]
    [SwaggerControllerDescription("Cities", "All cities in our country")]
    public class CitiesController : ApiController
    {
        #region Test Data

        public static CityModel[] testData =
        {
            new CityModel {Id = 77, Name = "Москва"},
            new CityModel {Id = 78, Name = "Санкт-Петербруг"},
            new CityModel {Id = 51, Name = "Мурманская область"},
            new CityModel {Id = 36, Name = "Воронежская область"}
        };

        #endregion

        /// <summary>
        ///     Get all cities information
        /// </summary>
        /// <returns>all available cities</returns>
        /// <remarks>
        ///     This method returns all available cities
        /// </remarks>
        [HttpGet]
        [Route(CitiesControllerRoutes.GetAll)]
        [EnableQuery]
        public IQueryable<CityModel> GetAll()
        {
            return testData.AsQueryable();
        }

        /// <summary>
        ///     Get cities by Id
        /// </summary>
        /// <param name="id">City Id</param>
        /// <returns>Requested city</returns>
        /// <response code="200">Success</response>
        /// <response code="404">No city information found</response>
        [HttpGet]
        [Route(CitiesControllerRoutes.GetById)]
        public CityModel GetById(int id)
        {
            var city = testData.SingleOrDefault(x => x.Id == id);
            if (city == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("no city found by id")
                });
            }
            return city;
        }

        /// <summary>
        ///     Create a city information
        /// </summary>
        /// <param name="model">city data</param>
        /// <returns>The city information created and persisted</returns>
        [HttpPost]
        [Route(CitiesControllerRoutes.Create)]
        public CityModel Create(CityModel model)
        {
            return model;
        }

        /// <summary>
        ///     Update a city information
        /// </summary>
        /// <param name="model">city data</param>
        /// <returns>The city information updated</returns>
        [HttpPut]
        [Route(CitiesControllerRoutes.Update)]
        public CityModel Update(CityModel model)
        {
            return model;
        }

        /// <summary>
        ///     Delete all cities information
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route(CitiesControllerRoutes.Delete)]
        public void DeleteAll()
        {
        }

        /// <summary>
        ///     Delete an city information
        /// </summary>
        /// <param name="id">city Id</param>
        /// <returns></returns>
        /// <response code="404">if no city found</response>
        [HttpDelete]
        [Route(RailwayStationsControllerRoutes.DeleteById)]
        public void DeleteById(int id)
        {
        }
    }
}