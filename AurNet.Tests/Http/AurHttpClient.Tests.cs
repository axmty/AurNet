using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AurNet.Http;
using Moq;
using Xunit;

namespace AurNet.Tests.Http
{
    public class AurHttpClientTests
    {
        [Fact]
        public async Task SearchAsync_ReturnsSuccessApiResponseObject_WhenApiCallSucceeds()
        {
            var expectedApiResponse = $@"
            {{
                ""version"":5,
                ""type"":""search"",
                ""resultcount"":3,
                ""results"":[],
            }}";
            var aurClient = new AurHttpClient(MockIHttpClientFactoryWithRawResponse(expectedApiResponse));

            var responseWrapper = await aurClient.SearchAsync("", SearchField.NameDesc);

            Assert.True(responseWrapper.IsSuccess);
            Assert.Equal(3, responseWrapper.SuccessResponse.ResultCount);
        }

        [Fact]
        public async Task SearchAsync_ReturnsFunctionalErrorResponseObject_WhenApiResponseContainsErrorMessage()
        {
            var expectedErrorMessage = "Incorrect by field specified.";
            var expectedApiResponse = $@"
            {{
                ""version"":5,
                ""type"":""error"",
                ""resultcount"":0,
                ""results"":[],
                ""error"":""{expectedErrorMessage}""
            }}";
            var aurClient = new AurHttpClient(MockIHttpClientFactoryWithRawResponse(expectedApiResponse));

            var responseWrapper = await aurClient.SearchAsync("", SearchField.NameDesc);

            Assert.True(responseWrapper.IsError);
            Assert.True(responseWrapper.ErrorResponse.IsFunctional);
            Assert.Equal(expectedErrorMessage, responseWrapper.ErrorResponse.FunctionalErrorMessage);
        }

        [Fact]
        public async Task SearchAsync_ReturnsTechnicalErrorResponseObject_WhenExceptionIsRaisedWhenCallingApi()
        {
            var raisedException = new HttpRequestException();
            var aurClient = new AurHttpClient(MockIHttpClientFactoryWithExceptionRaised(raisedException));

            var responseWrapper = await aurClient.SearchAsync("", SearchField.NameDesc);

            Assert.True(responseWrapper.IsError);
            Assert.True(responseWrapper.ErrorResponse.IsTechnical);
            Assert.Equal(raisedException, responseWrapper.ErrorResponse.TechnicalException);
        }

        private static IHttpClientFactory MockIHttpClientFactoryWithRawResponse(string rawResponse)
        {
            var mockHandler = new MockDelegatingHandler(() => new HttpResponseMessage
            {
                Content = new StringContent(rawResponse)
            });

            return MockIHttpClientFactoryWithDelegatingHandler(mockHandler);
        }

        private static IHttpClientFactory MockIHttpClientFactoryWithExceptionRaised(Exception exception)
        {
            var mockHandler = new MockDelegatingHandler(() => throw exception);

            return MockIHttpClientFactoryWithDelegatingHandler(mockHandler);
        }

        private static IHttpClientFactory MockIHttpClientFactoryWithDelegatingHandler(MockDelegatingHandler handler)
        {
            var mockClient = new HttpClient(handler);
            var mockFactory = new Mock<IHttpClientFactory>();
            mockFactory.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(mockClient);

            return mockFactory.Object;
        }

        public class MockDelegatingHandler : DelegatingHandler
        {
            private readonly Func<HttpResponseMessage> _handler;

            public MockDelegatingHandler(Func<HttpResponseMessage> handler)
            {
                _handler = handler;
            }

            protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                return Task.FromResult(_handler());
            }
        }
    }
}