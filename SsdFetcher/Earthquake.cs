using System;

namespace SsdFetcher
{
    public class Earthquake
    {
        public int OrigID { get; set; }
        public DateTime Date { get; set; }
        public double Latitude { get; set; } 
        public double Longitude { get; set; } 
        public double Class { get; set; } 
        public double Magnitude { get; set; } 
        public double Depth { get; set; }

        public Earthquake(int origId, DateTime date, double latitude, double longitude, double @class, double magnitude, double depth)
        {
            OrigID = origId;
            Date = date;
            Latitude = latitude;
            Longitude = longitude;
            Class = @class;
            Magnitude = magnitude;
            Depth = depth;
        }

        public Earthquake()
        {
        }

        public override string ToString()
        {
            return $"ID: {OrigID}\nDate: {Date}\nLat {Latitude}\nLon {Longitude}\nClass {Class}\nMs {Magnitude}\nDepth {Depth}\n";
        }
    }
}