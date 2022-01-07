# IVAO IT Whazzup v2 .NET SDK
Project made with ❤️ by IVAO Italy division.

![Discord](https://img.shields.io/discord/426318927220441089)

.NET SDK to read data from the new IVAO Whazzup JSON format.
Taking advantage of the newest and fastest .NET technologies like:
* [System.Text.Json](https://docs.microsoft.com/en-us/dotnet/api/system.text.json?view=net-6.0)
* [Microsoft.Extensions.Http](https://docs.microsoft.com/en-us/dotnet/core/extensions/http-client)

And the ready for the .NET (ex Core) DI Container.

## Example Usage
Configure your Service Collection
```csharp
services.AddIvaoWhazzupHttpClient();
```

Inject the client class
```csharp
public MyClass
{
    public MyClass(IIvaoData ivao)
    {
        this.ivao = ivao;
    }
}
```

Call the Whazzup API
```csharp
public async Task ReadIvaoData()
{
    var ivaoData = await ivao.GetAsync();
    ...
}
```

## Be careful!

To be respectful to the IVAO prescriptions about this API, read carefully [what IVAO DevOps says in the usage rules](https://wiki.ivao.aero/en/home/devops/api/whazuup/how-to-retrieve-v2).

Remember that this library throttles calls from the same instance on a 30 seconds minimum basis. You can configure the library to expand that throttling interval (maybe 1 minute can be good for the majority of the apps) but **you can't configure something smaller than 30 seconds**.

