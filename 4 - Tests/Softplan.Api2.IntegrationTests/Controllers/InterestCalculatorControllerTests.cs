using Moq;
using Softplan.Domain.Interfaces.Services;
using Softplan.Domain.Results;
using Softplan.IntegrationTests._Common;
using Softplan.IntegrationTests._Common.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Softplan.IntegrationTests.Controllers
{
    public class InterestCalculatorControllerTests : TestBase
    {
        public InterestCalculatorControllerTests(SoftplanFixture fixture) : base(fixture, "calculadora") { }

        public static IEnumerable<object[]> CalculateData()
        {
            yield return new object[] { new { valorinicial = 100, meses = 5 }, 0.01m, 105.10m };
            yield return new object[] { new { valorinicial = 50000, meses = 6 }, 0.08m, 79343.71m };
        }

        [Theory]
        [MemberData(nameof(CalculateData))]
        public async Task ShouldCalculateAsync(object feeParams, decimal fee, decimal expectedResult)
        {
            var apiMock = GetMock<IApi1Service>();
            apiMock.Setup(a => a.GetFeeAsync()).ReturnsAsync(new Result<decimal>(fee));

            var (response, result) = await Request.GetAsync<ResultTest<decimal>>(new Uri($"{Uri}/calculajuros"), feeParams);

            response.EnsureSuccessStatusCode();
            Assert.Equal(expectedResult, result.Data);
        }
    }
}
