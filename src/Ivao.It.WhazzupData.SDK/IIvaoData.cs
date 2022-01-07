using System.Threading;
using System.Threading.Tasks;
using Ivao.It.WhazzupData.SDK.Models;

namespace Ivao.It.WhazzupData.SDK
{
    /// <summary>
    /// Wrapper for the IVAO API Whazzup v2
    /// </summary>
    public interface IIvaoData
    {
        /// <summary>
        /// Calls IVAO Whazzup API
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<Root> GetAsync();

        /// <summary>
        /// Calls IVAO Whazzup API
        /// </summary>
        /// <returns></returns>
        Task<Root> GetAsync(CancellationToken cancellationToken);
    }
}
