namespace DotNextRZD.PublicApi.Model
{
    public class CityModel
    {
        /// <summary>
        ///     Id of the city
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Translated to current language name of airport
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Latitude of airport
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        ///     Longitude of airport
        /// </summary>
        public decimal Longitude { get; set; }
    }
}