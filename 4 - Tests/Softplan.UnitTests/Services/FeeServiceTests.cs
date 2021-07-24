using Softplan.Domain.Params;
using Softplan.Services.Services;
using Softplan.UnitTests._Common;
using System.Collections.Generic;
using Xunit;

namespace Softplan.UnitTests.Services
{
    public class FeeServiceTests : TestBase
    {
        public FeeServiceTests(SoftplanFixture _) : base(_) { }

        public static IEnumerable<object[]> CalculateData()
        {
            yield return new object[] { new FeeDto { Capital = 100, Time = 5, Fee = 0.01m }, 105.10m };
            yield return new object[] { new FeeDto { Capital = 100, Time = 5, Fee = 0.08m }, 146.93m };
            yield return new object[] { new FeeDto { Capital = 100, Time = 12, Fee = 0.01m }, 112.68m };
            yield return new object[] { new FeeDto { Capital = 50000, Time = 6, Fee = 0.01m }, 53076.00m };
            yield return new object[] { new FeeDto { Capital = 50000, Time = 6, Fee = 0.08m }, 79343.71m };
            yield return new object[] { new FeeDto { Capital = 50000, Time = 12, Fee = 0.01m }, 56341.25m };
        }

        [Theory]
        [MemberData(nameof(CalculateData))]
        public void ShouldCalculate(FeeDto feeDto, decimal expectedResult)
        {
            var service = new FeeService();

            var result = service.Calculate(feeDto);

            Assert.Equal(expectedResult, result, 2);
        }
    }
}
