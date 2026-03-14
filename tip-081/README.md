# 081 - ArchUnitNet #

Last week, a few posts were about Verify and how snapshot testing can simplify complex scenarios. Today, another testing library.

ArchUnitNET allows us to write tests that assert our architecture in unit tests, checking if everything, as we orchestrated, is correct while we build our application.

We can prepare our tests in 3 simple steps. 1️⃣ We create the architecture rule using fluent syntax, creating an expression that describes the dependencies between layers or types. Then, in 2️⃣, we need the actual assemblies and types that will be validated against the rule. 3️⃣ Finally, we do the actual validation. That's it.

Docs 📑: https://github.com/TNG/ArchUnitNET

```csharp
[Fact]
public void DomainLayerShouldNotHaveAnyDependencies()
{
    // 1️⃣ build the rule using fluent syntax
    IArchRule rule = Type()
        .That()
        .ResideInAssembly(typeof(ShipmentBasicInfo).Assembly)
        .Should()
        .NotDependOnAnyTypesThat()
        .ResideInAssembly(typeof(MarkerHandler).Assembly)
        .AndShould()
        .NotDependOnAnyTypesThat()
        .ResideInAssembly(typeof(Result<>).Assembly)
        .WithoutRequiringPositiveResults();

    // 2️⃣ build the architecture that contains our types, and relations between them
    var architecture = new ArchLoader().LoadAssemblies(
            System.Reflection.Assembly.Load("Ostra.Paczka.Domain"),
            System.Reflection.Assembly.Load("Ostra.Paczka.Application"),
            System.Reflection.Assembly.Load("Ostra.Paczka.SharedKernel")
        )
        .Build();

    // 3️⃣ assert the condition
    rule.Check(architecture);
}
```
