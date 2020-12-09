using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Weather.Core.Entities;
using Weather.Core.Repositories;
using Weather.Core.Services;

namespace Weather.Tests
{
    [TestClass]
    public class WeatherTests
    {
        [TestMethod]
        public void AddAverges_ValidCounting()
        {
            var weatherService = new WeatherService(null);
            var details = new WeatherDetails
            {
                Temperature = 10,
                WindSpeed = 5,
            };

            weatherService.AddWeatherTotals(details);
            var averages = weatherService.GetWeatherAverages();
            var expectedTempAvg = details.Temperature;
            var expectedWindAvg = details.WindSpeed;

            Assert.AreEqual(expectedTempAvg, averages.Data.Temperature);
            Assert.AreEqual(expectedWindAvg, averages.Data.WindSpeed);

            weatherService.AddWeatherTotals(details);
            averages = weatherService.GetWeatherAverages();

            Assert.AreEqual(expectedTempAvg, averages.Data.Temperature);
            Assert.AreEqual(expectedWindAvg, averages.Data.WindSpeed);

            var additionalDetails = new WeatherDetails
            {
                Temperature = 5,
                WindSpeed = 10,
            };

            weatherService.AddWeatherTotals(additionalDetails);
            averages = weatherService.GetWeatherAverages();
            expectedTempAvg = ((details.Temperature * 2) + additionalDetails.Temperature) / 3;
            expectedWindAvg = ((details.WindSpeed * 2) + additionalDetails.WindSpeed) / 3;

            Assert.AreEqual(expectedTempAvg, averages.Data.Temperature);
            Assert.AreEqual(expectedWindAvg, averages.Data.WindSpeed);
        }

        [TestMethod]
        public void ResetAverages_ValidReset()
        {
            var weatherService = new WeatherService(null);
            var details = new WeatherDetails
            {
                Temperature = 10,
                WindSpeed = 5,
            };

            weatherService.AddWeatherTotals(details);
            weatherService.ResetAverages();

            var averages = weatherService.GetWeatherAverages();

            Assert.AreNotEqual(details.Temperature, averages.Data.Temperature);
            Assert.AreNotEqual(details.WindSpeed, averages.Data.WindSpeed);
            Assert.AreEqual(0, averages.Data.WindSpeed);
            Assert.AreEqual(0, averages.Data.WindSpeed);
        }

        [TestMethod]
        public void GetWeather_ValidCall()
        {
            var mock = new Mock<IWeatherRepository>();
            var args = new WeatherArgs { Latitude = 38.123, Longitude = -78.543 };

            mock.Setup(x => x.GetWeather(args)).Returns(GetSampleWeatherDetails());

            var weatherService = new WeatherService(mock.Object);
            var weather = weatherService.GetWeatherDetails(args);

            var expected = GetSampleWeatherDetails();
            Assert.AreEqual(expected.Temperature, weather.Data.Temperature);
            Assert.AreEqual(expected.WindSpeed, weather.Data.WindSpeed);
            Assert.AreEqual(expected.Latitude, weather.Data.Latitude);
            Assert.AreEqual(expected.Longitude, weather.Data.Longitude);

            var averages = weatherService.GetWeatherAverages();
            Assert.AreEqual(expected.Temperature, averages.Data.Temperature);
            Assert.AreEqual(expected.WindSpeed, averages.Data.WindSpeed);
        }

        [TestMethod]
        public void GetWeather_FailedCall()
        {
            var mock = new Mock<IWeatherRepository>();
            var args = new WeatherArgs { Latitude = 38.123, Longitude = -78.543 };

            mock.Setup(x => x.GetWeather(args)).Returns(GetSampleWeatherDetails());

            var weatherService = new WeatherService(mock.Object);
            var details = weatherService.GetWeatherDetails(null);
            Assert.AreEqual(false, details.Success);

            args.Latitude = 0;
            details = weatherService.GetWeatherDetails(args);
            Assert.AreEqual(false, details.Success);

            args.Latitude = 1;
            args.Longitude = 0;
            details = weatherService.GetWeatherDetails(args);
            Assert.AreEqual(false, details.Success);
        }

        private WeatherDetails GetSampleWeatherDetails()
        {
            return new WeatherDetails
            {
                Latitude = 38.123,
                Longitude = -78.543,
                Temperature = 10,
                WindSpeed = 5,
            };
        }

        /*[TestMethod]
        public void GetUserByUserName()
        {

            var client = MockRestClient<WeatherDetails>(HttpStatusCode.OK, "JSON");
            var weatherRepository = new WeatherRepository(client);

            var weather = weatherRepository.GetWeather(new WeatherArgs { Latitude = 38.123, Longitude = -78.543 });

            Assert.AreEqual("10", weather.Temperature);
        }

        public static IRestClient MockRestClient<T>(HttpStatusCode httpStatusCode, string json)
            where T : new() {
            var data = JsonConvert.DeserializeObject<T>(json);
            var response = new Mock<IRestResponse<T>>();
            response.Setup(_ => _.StatusCode).Returns(httpStatusCode);
            response.Setup(_ => _.Data).Returns(data);

            var mockIRestClient = new Mock<IRestClient>();
            mockIRestClient
              .Setup(x => x.Execute<T>(It.IsAny<IRestRequest>()))
              .Returns(response.Object);
            return mockIRestClient.Object;
        }*/
    }
}
