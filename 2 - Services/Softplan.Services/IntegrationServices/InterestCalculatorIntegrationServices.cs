using Softplan.Domain.Interfaces.Services;
using Softplan.Domain.Params;
using Softplan.Domain.Results;
using Softplan.Services.Models.Params;
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

        public async Task<Result<decimal>> CalculateFeeAsync(FeeParams feesParams)
        {
            var feeResult = await _api1Service.GetFeeAsync();
            if (!feeResult.Success) return feeResult;

            var feeDto = new FeeDto { 
                Time = feesParams.Time,
                Capital = feesParams.Capital,
                Fee = feeResult.Data
            };
            var result = _feeService.Calculate(feeDto);
            return new Result<decimal>(result);
        }
    }
}
