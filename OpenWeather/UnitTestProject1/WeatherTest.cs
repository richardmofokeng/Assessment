using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using OpenWeather;
using OpenWeather.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class WeatherTest
    {
        private const string ApiKey = "ed8858ae34c32055f2ed07cdd9a82d01";
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var city = "London";
            var mockResponse = new WeatherResponse
            {
                Coord = new Coordinates { Lat = 51.5074, Lon = -0.1278 }
            };
            var httpMessageHandler = new Mock<HttpMessageHandler>();
            httpMessageHandler
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                   "SendAsync",
                   ItExpr.IsAny<HttpRequestMessage>(),
                   ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(mockResponse))
               });

            var client = new HttpClient(httpMessageHandler.Object);
            var service = new WeatherService(client, ApiKey);             


            var coord =  service.GetCoordinatesAsync(city).GetAwaiter();
 
            var latitudeCoor = coord.GetResult().Lat;
            var longitudeCoor = coord .GetResult().Lon;

            var weather =   service.Get7DayForecastAsync(latitudeCoor, longitudeCoor).GetAwaiter();
            var results = weather.GetResult();
        }
    }
}
