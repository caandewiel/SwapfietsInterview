using System;
namespace SwapfietsInterview.Models
{
    public enum LocationStatus
    {
        Active, Inactive
    }

    public class Location
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public LocationStatus LocationStatus { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int ProximitySize { get; set; }
    }
}
