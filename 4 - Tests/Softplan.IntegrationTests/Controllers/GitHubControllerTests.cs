using Softplan.IntegrationTests._Common;
using Softplan.IntegrationTests._Common.Results;
using System.Threading.Tasks;
using Xunit;

namespace Softplan.IntegrationTests.Controllers
{
    public class GitHubControllerTests : TestBase
    {
        public GitHubControllerTests(SoftplanFixture fixture) : base(fixture, "showmethecode") { }

        [Fact]
        public async Task ShouldReturnRepositoryUrlAsync()
        {
            var (response, result) = await Request.GetAsync<ResultTest<string>>(Uri);

            response.EnsureSuccessStatusCode();
            Assert.Equal("https://github.com/paulobusch/softplan-test", result.Data);
        }
    }
}
