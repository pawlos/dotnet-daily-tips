using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;


Console.WriteLine("Tip-001");
Console.WriteLine($"Existing file: {ResolvePathExplicit(@".\README.md").Value.Name}");
Console.WriteLine($"Non-existing file: {ResolvePathImplicit(@".\tip001.dll").Error}");

return;

static Result<FileInfo> ResolvePathExplicit(string path)
{
    return !File.Exists(path) ? Result<FileInfo>.FromError($"File '{path}' does not exists.") :
                                Result<FileInfo>.FromValue(new FileInfo(path));

}

static Result<FileInfo> ResolvePathImplicit(string path)
    {
        return !File.Exists(path) ? $"File '{path}' does not exists." : new FileInfo(path);
    }



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