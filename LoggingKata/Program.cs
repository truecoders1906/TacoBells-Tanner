using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable TacoBell1 = null;
            ITrackable TacoBell2 = null;
            double LargestDistance = 0;

            foreach (ITrackable Restuarant in locations)
            {                
                GeoCoordinate locA = new GeoCoordinate(Restuarant.Location.Latitude, Restuarant.Location.Longitude);
                foreach (ITrackable TacoRestuarant in locations)
                {
                    GeoCoordinate locB = new GeoCoordinate(TacoRestuarant.Location.Latitude, TacoRestuarant.Location.Longitude);
                    double DistanceBetweenResturants = locA.GetDistanceTo(locB);

                    if (DistanceBetweenResturants > LargestDistance)
                    {
                        TacoBell1 = Restuarant;
                        TacoBell2 = TacoRestuarant;
                        LargestDistance = DistanceBetweenResturants;
                    }
                }

            }
            Console.WriteLine(TacoBell1.Name);
            Console.WriteLine(TacoBell2.Name);
            Console.WriteLine(LargestDistance);
        }
    }

}