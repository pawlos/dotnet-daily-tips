# 012 - Problem details #

Good and consistent problem reporting is crucial in any web application. There are numerous ways to do that some better some not so good (yes, it's you `200 OK, {"isError": true}`).

Not sure if you are aware but there's an RFC document that specifies how such object to report errors should look like - [RFC 7807](https://www.rfc-editor.org/rfc/rfc7807). It specifies how the type should be defined so that it has enough information for machines to handle it but also enough for human to understand what happened. It standardized both xml & JSON format for returning such object.

ASP.NET Core has such type defined - [ProblemDetails](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.problemdetails?view=aspnetcore-8.0).

Wolverine has also first class support for Problem Details.


```csharp
public static async Task<object> ToHttpResponse<T>(this Task<Result<T>> result)
{
    var v = await result;
    return v switch
    {
        { Value: not null } => v.Value,
        { Error: not null } => new ProblemDetails
            {
                Type = "https://ostra.paczka/error",
                Title = "Error happened",
                Detail = v.Error,
                Status = 404
            }
    };
}
```