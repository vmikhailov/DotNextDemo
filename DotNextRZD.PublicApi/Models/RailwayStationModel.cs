using System;
using System.Collections.Generic;

namespace DotNextRZD.PublicApi.Models
{
    public class RailwayStationModel
    {
        /// <summary>
        ///     Internal id of railway station in the database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Public (extenal) code of railway station
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///     Translated to current language name of railway station
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Translated to current language name of railway station's city
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        ///     Latitude of railway station
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        ///     Longitude of railway station
        /// </summary>
        public decimal Longitude { get; set; }

        public List<StationService> Services { get; set;} 
    }

    public class StationService
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
    }
}