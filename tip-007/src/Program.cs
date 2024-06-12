using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;


Console.WriteLine("Tip-007");

Result<FileInfo> fileInfoResult = new FileInfo(@"c:\dummy.file");
if (fileInfoResult.IsSuccessful)
{
    // compiler shall warn you about the followin access as
    // "dereference of possibly null value" if the lines with Member not null are removed
    Console.WriteLine(fileInfoResult.Value.FullName);
}

return;



public class Result<T>
{
    private Result(T result)
    {
        Value = result;
    }

    private Result(string error)
    {
        Error = error;
    }

    // see how compiler behaves when the following lines are or are not present
    [MemberNotNullWhen(false, nameof(Error))]
    [MemberNotNullWhen(true, nameof(Value))]
    [JsonIgnore]
    public bool IsSuccessful => Error is null;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Value { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Error { get; }

    public static implicit operator Result<T>(T result)
    {
        return new Result<T>(result);
    }

    public static implicit operator Result<T>(string error)
    {
        return new Result<T>(error);
    }

    public static Result<T> FromError(string error)
    {
        return new Result<T>(error);
    }

    public static Result<T> FromValue(T value)
    {
        return new Result<T>(value);
    }
}