# 001 - Result\<T\> #


Having a `Result<T>` class one can creating it explicitly by calling a method from that class (or ctor) or, by using an operator, implicitly that will hide the object creation. Which one do you prefer?

Using explicit type information:

```csharp
static Result<FileInfo> ResolvePathExplicit(string path)
{
    return !File.Exists(path) ? Result<FileInfo>.FromError("File does not exists.") :
                                Result<FileInfo>.FromValue(new FileInfo(path));

}
```
or by using implicit conversion operator
```csharp
static Result<FileInfo> ResolvePathImplicit(string path)
{
    return !File.Exists(path) ? "File does not exists." : new FileInfo(path);
}
```