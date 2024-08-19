# 047 - SIMD #

SIMD is an acronym that stand for single-instruction, multiple-data instructions accelerated by the hardware that allow performing the same instruction with a single opcode on multiple data input.

In .NET those instructions are locates in the System.Numerics namespace. Let's start with checking the types that are available at our disposal:

- 👉 `Vector2`, `Vector3`, `Vector4` - can represent accordingly 2,3 or 4 float values.
- 👉 `Matrix3x2`, `Matrix4x4` - can represent matrices 3x2 and 4x4
- 👉 `Plane` - can represent a 3d plane object
- 👉 `Quaternion` - for rotations in 3d space
- 👉 `Vector<T>` - generic type that allows vector of specific type

Docs: 📑 https://learn.microsoft.com/en-us/dotnet/standard/simd

```csharp
using System.Numerics;

// 3d vectors
var v1 = new Vector3(0.1f, 0.2f, 0.3f);
var v2 = new Vector3(1.1f, 2.2f, 3.3f);
var result = v1 + v2;

// plane
var plane = new Plane(0.0f, 1.0f, 0.0f, 10.0f);

// Identity 4x4 matrix
var identity = Matrix4x4.Identity;

// Vector of values of type int
Vector<int> v = new Vector<int>(new[] {1,2,3,4,5,6,7,8});
```