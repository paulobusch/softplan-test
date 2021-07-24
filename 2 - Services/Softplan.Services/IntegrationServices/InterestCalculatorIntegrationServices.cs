using Softplan.Domain.Interfaces.Services;
using Softplan.Domain.Params;
using Softplan.Domain.Results;
using System.Threading.Tasks;

namespace Softplan.Services.IntegrationServices
{
    public class InterestCalculatorIntegrationServices
    {
        private readonly IFeeService _feeService;
        private readonly IApi1Service _api1Service;

        public InterestCalculatorIntegrationServices(
            IFeeService feeService,
            IApi1Service api1Service
        )
        {
            _feeService = feeService;
            _api1Service = api1Service;
        }

        public async Task<Result<decimal>> CalculateFeeAsync(FeesParams feesParams)
        {
            var feeResult = await _api1Service.GetFeeAsync();
            if (!feeResult.Success) return feeResult;

            feesParams.Fee = feeResult.Data;
            var result = _feeService.Calculate(feesParams);
            return new Result<decimal>(result);
        }
    }
}
