using Microsoft.Extensions.Options;
using RestSharp;
using Softplan.Domain.Enums;
using Softplan.Domain.Interfaces.Services;
using Softplan.Domain.Results;
using Softplan.Services.Settings;
using System;
using System.Threading.Tasks;

namespace Softplan.Services.Services
{
    public class Api1Service : IApi1Service
    {
        private readonly RestClient _client;

        public Api1Service(IOptions<Api1Settings> settings)
        {
            if (settings.Value == null) throw new InvalidOperationException($"Please configure {nameof(Api1Settings)}");

            _client = new RestClient(settings.Value.BaseUrl);
        }

        public async Task<Result<decimal>> GetFeeAsync()
        {
            var request = new RestRequest("consulta/taxajuros", Method.GET);
            var result = await _client.ExecuteAsync<Result<decimal>>(request);
            return result.Data ?? new Result<decimal>(Status.Error, "Error on send request to Api1");
        }
    }
}
