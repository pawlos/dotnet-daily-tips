using System.Runtime.CompilerServices;

var c = new ClassWithPrivateField();

// 1️⃣ will print "."
Console.WriteLine(c);
GetSetPrivateField(c);

// 2️⃣ will print ".."
Console.WriteLine(c);
return;


void GetSetPrivateField(ClassWithPrivateField classWithPrivate)
{
    ref var path = ref UnsafeAccessToPrivateField(classWithPrivate);
    path = "..";
    return;

    // ✅ specify the type of unsafe access and the name of the accessed thing
    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_path")]
    static extern ref string UnsafeAccessToPrivateField(ClassWithPrivateField classWithPrivate);
}

internal class ClassWithPrivateField
{
    private string _path = ".";

    public override string ToString()
    {
        return $"Path: {_path}";
    }
}
