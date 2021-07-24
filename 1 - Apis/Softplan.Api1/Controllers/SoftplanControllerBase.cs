using Microsoft.AspNetCore.Mvc;
using Softplan.Domain.Core.Results;

namespace Softplan.Api1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class SoftplanControllerBase : ControllerBase
    {
        protected Result GetResult(Result result)
        {
            Response.StatusCode = (int)result.Status;
            return result;
        }

        protected Result<T> GetResult<T>(Result<T> result)
        {
            Response.StatusCode = (int)result.Status;
            return result;
        }

        protected Result<T> GetResult<T>(T data)
        {
            return new Result<T>(data);
        }
    }
}
