using System;
using Microsoft.Extensions.Options;
using Xunit;

namespace Ivao.It.WhazzupData.SDK.Tests;

public class DataOptionsValidations
{
    [Fact]
    public void TestOk()
    {
        var opt = new IvaoDataOptions();

        var ivaoData = new IvaoData(Options.Create(opt), null);
    }

    [Fact]
    public void TestKo_Timespan()
    {
        var opt = new IvaoDataOptions
        {
            ReadEvery = TimeSpan.FromSeconds(1),
        };

        Assert.Throws<ArgumentException>(() => new IvaoData(Options.Create(opt), null));
    }

    [Fact]
    public void TestKo_WhazzupUrl()
    {
        var opt = new IvaoDataOptions
        {
            WhazzupUrl = null
        };

        Assert.Throws<NullReferenceException>(() => new IvaoData(Options.Create(opt), null));
    }
}
