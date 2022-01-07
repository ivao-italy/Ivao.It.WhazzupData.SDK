using System;
using System.Threading.Tasks;
using Xunit;

namespace Ivao.It.WhazzupData.SDK.Tests;

public class ApiCallTests
{
    private readonly IIvaoData ivao;

    public ApiCallTests(IIvaoData ivao)
    {
        this.ivao = ivao;
    }

    [Fact]
    public async Task TestCall()
    {
        var ivaoData = await ivao.GetAsync();

        Assert.NotNull(ivaoData);
        Assert.NotEmpty(ivaoData.Clients.Pilots);
        Assert.NotEmpty(ivaoData.Clients.Atcs);
    }

    [Fact]
    public async Task TestTooCloseCall()
    {
        await ivao.GetAsync();
        await Task.Delay(200);
        await Assert.ThrowsAsync<InvalidOperationException>(async () => await ivao.GetAsync());
    }

    [Fact]
    public async Task TestTooCloseCallThanCorrectDelay()
    {
        await ivao.GetAsync();
        await Task.Delay(200);
        await Assert.ThrowsAsync<InvalidOperationException>(async () => await ivao.GetAsync());

        await Task.Delay(5001);        
        await ivao.GetAsync();
    }
}
