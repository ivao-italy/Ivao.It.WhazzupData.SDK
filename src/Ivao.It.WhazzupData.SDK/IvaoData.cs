using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Ivao.It.WhazzupData.SDK.Models;
using Microsoft.Extensions.Options;

namespace Ivao.It.WhazzupData.SDK
{
    /// <inheritdoc/>
    public sealed class IvaoData : IIvaoData
    {
        private readonly IvaoDataOptions _ivaoOptions;
        private readonly IHttpClientFactory _httpClientFactory;
        private DateTime? _lastCall;

        /// <summary>
        /// Contructs the IVAO API Wrapper
        /// </summary>
        /// <param name="ivaoOptions"></param>
        /// <param name="httpClientFactory"></param>
        public IvaoData(IOptions<IvaoDataOptions> ivaoOptions, IHttpClientFactory httpClientFactory)
        {
            _ivaoOptions = ivaoOptions != null ? ivaoOptions.Value : new IvaoDataOptions();
            _ivaoOptions.Validate();

            _httpClientFactory = httpClientFactory;
        }


        /// <inheritdoc/>
        public async Task<Root> GetAsync(CancellationToken cancellationToken)
        {
            ValidateLastCall();

            //API Call
            using (var client = _httpClientFactory.CreateClient(_ivaoOptions.WhazzupHttpClientName))
            {
                var response = await client.GetAsync(string.Empty, cancellationToken);
                return await DeserializeDataOnSuccessAsync(response);
            }
        }

        /// <inheritdoc/>
        public async Task<Root> GetAsync()
        {
            ValidateLastCall();


            //API Call
            using (var client = _httpClientFactory.CreateClient(_ivaoOptions.WhazzupHttpClientName))
            {
                var response = await client.GetAsync(string.Empty);
                return await DeserializeDataOnSuccessAsync(response);
            }
        }

        /// <summary>
        /// Throttling implementation (<see cref="IvaoData"/> injected as singleton)
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        private void ValidateLastCall()
        {
            if (_lastCall != null)
            {
                if (DateTime.Now - _lastCall.Value < _ivaoOptions.ReadEvery)
                {
                    throw new InvalidOperationException($"API Calls not allwed with intervals shorter than {_ivaoOptions.ReadEvery.TotalSeconds}sec");
                }
            }
        }

        /// <summary>
        /// Handling API result
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private async Task<Root> DeserializeDataOnSuccessAsync(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var root = JsonSerializer.Deserialize<Root>(await response.Content.ReadAsStringAsync());
            _lastCall = DateTime.Now;
            return root;
        }
    }
}
