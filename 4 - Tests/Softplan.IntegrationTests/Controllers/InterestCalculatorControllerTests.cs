using Moq;
using Softplan.Domain.Interfaces.Services;
using Softplan.Domain.Params;
using Softplan.Domain.Results;
using Softplan.IntegrationTests._Common;
using Softplan.IntegrationTests._Common.Results;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Softplan.IntegrationTests.Controllers
{
    public class InterestCalculatorControllerTests : TestBase
    {
        public InterestCalculatorControllerTests(SoftplanFixture fixture) : base(fixture, "calculajuros") { }

        public static IEnumerable<object[]> CalculateData()
        {
            yield return new object[] { new FeesParams { Capital = 100, Time = 5, Fee = 0.01m }, 105.10m };
            yield return new object[] { new FeesParams { Capital = 50000, Time = 6, Fee = 0.08m }, 79343.71m };
        }

        [Theory]
        [MemberData(nameof(CalculateData))]
        public async Task ShouldCalculateAsync(FeesParams feesParams, decimal expectedResult)
        {
            var apiMock = GetMock<IApi1Service>();
            apiMock.Setup(a => a.GetFeeAsync()).ReturnsAsync(new Result<decimal>(feesParams.Fee));

            var (response, result) = await Request.GetAsync<ResultTest<decimal>>(Uri, feesParams);

            response.EnsureSuccessStatusCode();
            Assert.Equal(expectedResult, result.Data);
        }
    }
}
