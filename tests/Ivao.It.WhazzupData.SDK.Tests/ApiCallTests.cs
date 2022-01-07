using System;
using System.Threading.Tasks;
using Ivao.It.WhazzupData.SDK.Models;
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
        await Task.Delay(5001);
        var ivaoData = await ivao.GetAsync();

        Assert.NotNull(ivaoData);
        Assert.NotEmpty(ivaoData.Clients.Pilots);
        Assert.NotEmpty(ivaoData.Clients.Atcs);
    }

    [Fact]
    public async Task TestTooCloseCall()
    {
        await Task.Delay(5001);
        await ivao.GetAsync();
        await Task.Delay(200);
        await Assert.ThrowsAsync<InvalidOperationException>(async () => await ivao.GetAsync());
    }

    [Fact]
    public async Task TestTooCloseCallThanCorrectDelay()
    {
        await Task.Delay(5001);
        await ivao.GetAsync();
        await Task.Delay(200);
        await Assert.ThrowsAsync<InvalidOperationException>(async () => await ivao.GetAsync());

        await Task.Delay(5001);
        await ivao.GetAsync();
    }
}
