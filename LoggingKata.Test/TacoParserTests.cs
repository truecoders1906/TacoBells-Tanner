using System;
using Xunit;
using LoggingKata;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // Arrange


            // Act


            // Assert
        }

        [Theory]
        [InlineData("34.996237,-85.291147,Taco Bell Chattanooga", "Taco Bell Chattanooga", 34.996237, -85.291147)]
        [InlineData("32.555148,-84.946447,Taco Bell Columbus", "Taco Bell Columbus", 32.555148, -84.946447)]

        public void ShouldParse(string str, string TestName, double TestLatitude, double TestLongitude)
        {
            // Arrange
            TacoParser TacoParse = new TacoParser();
            Point TacoBellLocation = new Point(TestLatitude, TestLongitude);

            // Act
            ITrackable actual = TacoParse.Parse(str);

            // Assert
            Assert.Equal(TestName, actual.Name);
            Assert.Equal(TacoBellLocation.Latitude, actual.Location.Latitude);
            Assert.Equal(TacoBellLocation.Longitude, actual.Location.Longitude);
        }

        [Theory]
        [InlineData("")]
        [InlineData("It's, Taco, Tuesdaaaaaay")]
        [InlineData("34.9962, NoLongitude ,Taco Bell Chattanooga")]
        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse

            // Arrange
            TacoParser FailParse = new TacoParser();

            // Act
            ITrackable actual = FailParse.Parse(str);

            // Assert
            Assert.Null(actual);
        }
    }
}
