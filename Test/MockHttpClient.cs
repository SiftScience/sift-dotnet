using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;

namespace Test
{
    public class MockHttpClient
    {
        public static HttpClient GetMockClient()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Returns((HttpRequestMessage request, CancellationToken cancellationToken) => GetMockResponse(request, cancellationToken));
            return new HttpClient(mockHttpMessageHandler.Object);
        }

        static Task<HttpResponseMessage> GetMockResponse(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri.LocalPath == "/expectedPath")
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                response.Content = new StringContent(GetAuthJson(), Encoding.UTF8, "application/json");
                return Task.FromResult(response);
            }
            throw new NotImplementedException();
        }

        static string GetAuthJson()
        {
            return "{ \"isAuthenticated\": true }";
        }
    }
}