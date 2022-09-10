using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Moq.Contrib.HttpClient;
using Newtonsoft.Json.Linq;
using Xunit;

namespace golf1052.SlackAPI.Tests
{
    public class SlackCoreTests
    {
        private readonly SlackCore slackApi;
        private readonly Mock<HttpMessageHandler> httpMessageHandler;
        private readonly Dictionary<string, SemaphoreSlim> urlRateLimits;

        public SlackCoreTests()
        {
            httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            urlRateLimits = new Dictionary<string, SemaphoreSlim>();
            slackApi = new SlackCore(string.Empty, httpMessageHandler.CreateClient(), urlRateLimits);
        }

        [Fact]
        public async Task DoSlackCall()
        {
            Uri uri = new Uri("https://example.com/users.list");
            httpMessageHandler.SetupRequestSequence(uri)
                .ReturnsResponse((System.Net.HttpStatusCode)429, response =>
                {
                    response.Headers.RetryAfter = new System.Net.Http.Headers.RetryConditionHeaderValue(TimeSpan.FromSeconds(5));
                })
                .ReturnsResponse(System.Net.HttpStatusCode.OK, response =>
                {
                    JObject o = new JObject();
                    o["ok"] = true;
                    response.Content = new StringContent(o.ToString(Newtonsoft.Json.Formatting.None));
                })
                .ReturnsResponse(System.Net.HttpStatusCode.OK, response =>
                 {
                     JObject o = new JObject();
                     o["ok"] = true;
                     response.Content = new StringContent(o.ToString(Newtonsoft.Json.Formatting.None));
                 });
            Task t1 = slackApi.DoSlackCall(uri);
            Task t2 = slackApi.DoSlackCall(uri);
            await Task.WhenAll(t2, t1);
        }
    }
}
