using Microsoft.AspNetCore.Mvc;
using Softplan.Domain.Results;

namespace Softplan.Api2.Controllers
{
    [Route("github")]
    public class GitHubController : SoftplanControllerBase
    {
        [HttpGet("showmethecode")]
        public Result<string> Get() => GetResult("https://github.com/paulobusch/softplan-test");
    }
}
