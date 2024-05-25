using Microsoft.Extensions.Hosting;
using Wolverine;

Console.WriteLine("Tip-004");

Host.CreateDefaultBuilder()
    .UseWolverine(options =>
    {
        Console.WriteLine(options.DescribeHandlerMatch(typeof(ParcelByIdHendler)));
    }).Build();



public class ParcelByIdHendler(ParcelStore parcelsStore) // typo in Handler
{
    public Result<ParcelDetailsResult> Handle(ParcelByIdQuery query)
    {
        // handle
        return new Result<ParcelDetailsResult>();
    }
}

// Mocks
public record ParcelByIdQuery;

public class Result<T>;

public record ParcelDetailsResult;

public class ParcelStore;


