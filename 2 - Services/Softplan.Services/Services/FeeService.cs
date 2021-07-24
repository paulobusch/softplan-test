using Softplan.Domain.Interfaces.Services;
using Softplan.Domain.Params;
using System;

namespace Softplan.Services.Services
{
    public class FeeService : IFeeService
    {
        public decimal Calculate(FeeDto feeDto)
        {
            var fee = Convert.ToDouble(feeDto.Fee);
            var totalFees = Math.Pow(fee + 1, Convert.ToDouble(feeDto.Time));
            var result = Convert.ToDecimal(Convert.ToDouble(feeDto.Capital) * totalFees);
            return decimal.Round(result, 2, MidpointRounding.ToZero);
        }
    }
}
