using Softplan.IntegrationTests._Common;
using Softplan.IntegrationTests._Common.Results;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Softplan.IntegrationTests.Controllers
{
    public class GitHubControllerTests : TestBase
    {
        public GitHubControllerTests(SoftplanFixture fixture) : base(fixture, "github") { }

        [Fact]
        public async Task ShouldReturnRepositoryUrlAsync()
        {
            var (response, result) = await Request.GetAsync<ResultTest<string>>(new Uri($"{Uri}/showmethecode"));

            response.EnsureSuccessStatusCode();
            Assert.Equal("https://github.com/paulobusch/softplan-test", result.Data);
        }
    }
}
