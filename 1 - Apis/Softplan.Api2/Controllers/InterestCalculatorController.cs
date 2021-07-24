using Microsoft.AspNetCore.Mvc;
using Softplan.Domain.Results;
using Softplan.Services.IntegrationServices;
using Softplan.Services.Models.Params;
using System.Threading.Tasks;

namespace Softplan.Api2.Controllers
{
    [Route("calculadora")]
    public class InterestCalculatorController : SoftplanControllerBase
    {
        private readonly InterestCalculatorIntegrationServices _interestCalculatorIntegrationServices;

        public InterestCalculatorController(InterestCalculatorIntegrationServices interestCalculatorIntegrationServices)
        {
            _interestCalculatorIntegrationServices = interestCalculatorIntegrationServices;
        }

        [HttpGet("calculajuros")]
        public async Task<Result<decimal>> GetAsync([FromQuery] FeeParams feesParams) 
            => GetResult(await _interestCalculatorIntegrationServices.CalculateFeeAsync(feesParams));
    }
}
