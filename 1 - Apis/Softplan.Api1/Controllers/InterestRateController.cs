using Microsoft.AspNetCore.Mvc;
using Softplan.Domain.Core.Results;

namespace Softplan.Api1.Controllers
{
    [Route("taxajuros")]
    public class InterestRateController : SoftplanControllerBase
    {
        [HttpGet]
        public Result<decimal> Get() => GetResult(0.01m);
    }
}
