using Softplan.Domain.Params;

namespace Softplan.Domain.Interfaces.Services
{
    public interface IFeeService
    {
        public decimal Calculate(FeeDto feeDto);
    }
}
