# 031 - Conditional attribute  #

Sometimes there's a need to compile certain part of the code depending of the external factors like target OS or whether it's debug or release build. There is preprocessor directive #if that allows to wrap a part of the code the be conditionally compiled but there are certain disadvantages to using that:

- 📌compiler doesn't check the code that is inside #if directive when the condition is not true. That could lead to discovering an error once the directive changes to true due to other part of the system had changed.

- 📌with #if it's often that the directive would be inside the method at the call site, mixed up with the generic code which makes that harder to read

Conditional attribute can fix those problems. We only need to mark the method that supposed to be conditionally compiled into the code. We do not need to change the call-site and the compiler takes care of that. Also, the compiler still checks the correctness of the code that we have inside that method.

- 🚩Docs for preprocessor directives📑 https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/preprocessor-directives#conditional-compilation

- 🚩Docs for Conditional attribute 📑 https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.conditionalattribute?view=net-8.0

Did you had to use those in your projects? If so please share ♻.
