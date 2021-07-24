using Microsoft.AspNetCore.Mvc;
using Softplan.Domain.Results;

namespace Softplan.Api1.Controllers
{
    [Route("consulta")]
    public class InterestRateController : SoftplanControllerBase
    {
        [HttpGet("taxajuros")]
        public Result<decimal> Get() => GetResult(0.01m);
    }
}
