
namespace LoggingKata
{
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");
            TacoBell tacoBell = new TacoBell();

            double longitude;
            double latitude;

            string[] cells = line.Split(',');

            if (cells.Length < 3 || cells.Length > 4)
            {
                logger.LogError("Length of array is shorter than three.");

                return null;
            }

            string LatitudeAsString = cells[0];           
            string LongitudeAsString = cells[1];
            tacoBell.Name = cells[2];

            logger.LogInfo("Converting longitude to double");
            bool ConvertLongitude = double.TryParse(LongitudeAsString, out longitude);

            logger.LogInfo("Converting latitude to double");
            bool ConvertLatitude = double.TryParse(LatitudeAsString, out latitude);

            if (ConvertLongitude == false || ConvertLatitude == false)
            {
                logger.LogError("latitude or longitude is not a number");
                return null;
            }
            
            Point LongAndLat = new Point(latitude, longitude);
            tacoBell.Location = LongAndLat;
            return tacoBell;
        }

    }
}