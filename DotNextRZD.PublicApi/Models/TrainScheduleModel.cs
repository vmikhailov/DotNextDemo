using System;

namespace DotNextRZD.PublicApi.Models
{
    /// <summary>
    ///     Train information model
    /// </summary>
    public class TrainScheduleModel
    {
        /// <summary>
        ///     Internal (database) Id of the train
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     External (public) number of the train
        /// </summary>
        public string TrainNumber { get; set; }

        /// <summary>
        ///     Id of railway station from which train is started
        /// </summary>
        public int OriginRailwayStationId { get; set; }

        /// <summary>
        ///     Translated to the current language name of airport from which the train is started
        /// </summary>
        public string OriginRailwayStationName { get; set; }

        /// <summary>
        ///     RailwayStation id of train's destination
        /// </summary>
        public int DestinationRailwayStationId { get; set; }

        /// <summary>
        ///     Translated to the current language name of train's destination airport
        /// </summary>
        public string DestinationRailwayStationName { get; set; }

        /// <summary>
        ///     Scheduled time of arrival
        /// </summary>
        public DateTime ScheduledTime { get; set; }

    }
}