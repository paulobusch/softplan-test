using Softplan.Domain.Results;
using System.Threading.Tasks;

namespace Softplan.Domain.Interfaces.Services
{
    public interface IApi1Service
    {
        Task<Result<decimal>> GetFeeAsync();
    }
}
