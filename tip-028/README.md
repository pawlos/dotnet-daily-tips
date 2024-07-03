# 028 - Local function placement  #

Local functions are an alternative to lambdas. They were introduced to avoid allocating but also as an alternative to member function so that they are only called from a close proximity of the function that they are declared in. Though they are not the new thing. I'm not using them as often as I was thinking I would when they were introduced.

I think it might be due to the default placement that is proposed to them when refactoring.

The proposed places are:
- 🚩 At the beginning of the function,
- 🚩 After the extracted code
- 🚩 Before the return
- 🚩 At the end of the function

The default is, "At the end of the function", which will, introduce code after the last return. I'm not sure if I'm ok with that. To be honest I think none of the locations suits me 🤷‍♂️

Read more about local function📑: [Local functions (C# Programming Guide)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions)
So if you use them what is the placement of the local function? And please share pros & cons.