using Softplan.Domain.Interfaces.Services;
using Softplan.Domain.Params;
using System;

namespace Softplan.Services.Fees
{
    public class FeeService : IFeeService
    {
        public decimal Calculate(FeesParams feesParams)
        {
            var fee = Convert.ToDouble(feesParams.Fee);
            var totalFees = Math.Pow(fee + 1, Convert.ToDouble(feesParams.Time));
            var result = Convert.ToDecimal(Convert.ToDouble(feesParams.Capital) * totalFees);
            return decimal.Round(result, 2, MidpointRounding.ToZero);
        }
    }
}
