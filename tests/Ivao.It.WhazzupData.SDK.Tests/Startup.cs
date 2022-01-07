using System;
using Microsoft.Extensions.DependencyInjection;

namespace Ivao.It.WhazzupData.SDK.Tests;

internal class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddIvaoWhazzupHttpClient(new IvaoDataOptions { WhazzupUrl = "http://localhost/whazzup/whazzup.json", ReadEvery = TimeSpan.FromSeconds(5) });

        services.AddTransient<IIvaoData, IvaoData>();
    }
}
