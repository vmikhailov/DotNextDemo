using System;

namespace DotNextRZD.PublicApi.Model
{
    /// <summary>
    ///     Train information model
    /// </summary>
    public class TrainModel
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

        /// <summary>
        ///     Actual time of arrival
        /// </summary>
        public DateTime CurrentTime { get; set; }

        /// <summary>
        ///     External code of train status
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        ///     Status of train
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        ///     True if status is updated
        /// </summary>
        public bool UpdatedStatus { get; set; }

        /// <summary>
        ///     true if train is delayed
        /// </summary>
        public bool? IsDelayed { get; set; }
    }
}