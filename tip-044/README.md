# 044 - UnsafeAccessorAttribute #

Trimming doesn't work well with code that is dynamically access types, functions or members. That's why reflection doesn't work well with trimming. With reflection it's difficult (or even impossible) to predict what code will finally be called.
To mitigate that, few new things have been added. One is Source generators, another `UnsafeAccessorAttribute`.

With that last one we can specify that we want to access a field or a method that previously was being access via reflection. With that attribute we can get, at least limited, functionality known from reflection and still be able to determine what code shall and what shall not be put into the final assembly.

Docs:
📑 https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.unsafeaccessorattribute?view=net-8.0
