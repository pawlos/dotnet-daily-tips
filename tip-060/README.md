# 060 - async enumerable #

We end the week with the topic of `IAsyncEnumerable` interface. Thanks to it we generate a collection with yield return and consume it with async foreach like we would normally do with non async enumerable.

Code looks nice and we still get all the benefits of asyncs.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1?view=net-8.0

```csharp
public class ProfilesCollection(HttpClient httpClient)
{
    public async IAsyncEnumerable<string> GetValuesAsync()
    {
        foreach (var item in new[] {
            "https://twitter.com/@pawel_lukasik",
            "https://infosec.exchange/@pawel_lukasik",
            "https://www.linkedin.com/in/plukasik/"
        })
        {
            yield return await httpClient.GetStringAsync(item);
        }
    }
}

var httpClient = new HttpClient();
var profileCollection = new ProfilesCollection(httpClient);
await foreach(var item in profilesCollection.GetValuesAsync())
{
    Console.WriteLine(item);
}
```