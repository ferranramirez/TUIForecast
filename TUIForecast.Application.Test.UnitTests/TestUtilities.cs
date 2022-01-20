using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TUIForecast.Application.Test.UnitTests
{
    public class TestUtilities
    {
        protected static HttpClient MockHttpClient_KO()
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.NoContent
               })
               .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object);
            return httpClient;
        }

        protected static HttpClient MockHttpClient_OK(string content)
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(content),
               })
               .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object);
            return httpClient;
        }
    }
}