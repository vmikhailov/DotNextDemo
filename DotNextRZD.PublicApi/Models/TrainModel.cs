using System;

namespace DotNextRZD.PublicApi.Models
{
    /// <summary>
    ///     Train information model
    /// </summary>
    public class TrainTripModel
    {
        /// <summary>
        ///     Id of the trip
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Date of the trip
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        ///     Item from the schedule
        /// </summary>
        public TrainScheduleModel Train { get; set; }

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