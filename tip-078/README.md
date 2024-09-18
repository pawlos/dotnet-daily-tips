# 078 - Verify #

Verify is a snapshot testing tool that allows for simplifying assertions of complex data models.

Sometimes, at the end of our tests, to correctly assert the state, we would like to use multiple assertions. However, that is usually considered a bad practice (setting aside the debate on whether multiple assertions are okay) because if the test fails, we would like to have a clear indication of which assertion triggered the failure. Also, setting up and maintaining multiple assertions can be cumbersome.

Verify allows us to replace all the assertions with a snapshot generation that will later be compared with new versions, detecting discrepancies.

This all works based on two files - `<test_name>.received.<ext>` and `<test_name>.verified.<ext>`. The latter is our snapshot that we will be comparing against; its format represents the current state.

Have you had a chance to use Verify or other snapshot testing libraries?

Docs 📑: https://github.com/VerifyTests/Verify

```csharp
[Fact]
public Task Test()
{
    var person = ClassBeingTested.FindPerson();
    return Verify(person);
}

public static class ClassBeingTested
{
    public static Person FindPerson() =>
        new()
        {
            Id = new("ebced679-45d3-4653-8791-3d969c4a986c"),
            Title = Title.Mr,
            GivenNames = "Johnny",
            FamilyName = "Smith",
            Spouse = "Jilly",
            Children =
            [
                "Sam",
                "Mary"
            ],
            Address = new()
            {
                Street = "4 Puddle Lane",
                Country = "USA"
            },
        };
}
```