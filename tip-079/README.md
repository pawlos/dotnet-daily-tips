# 079 - Verify - DontScrub* #

Let's revisit the example from yesterday. If we were in compare mode (already generated received file) and someone were to modify the GUID, running such a test would not result in a broken one.

By default, Verify has some types scrubbed, so changes there won't affect the comparison. GUIDs and DateTimes are among such types, and if we would like them to be included in the comparison, we would need to tell Verify not to scrub them. Thankfully, there is an option to do that using the static `VerifierSettings` class and calling either `DontScrubGuids()` or `DontScrubDateTimes()`.

Docs 📑: https://github.com/VerifyTests/Verify


```csharp
[Fact]
public Task Test()
{
    // 👇 Add this to include GUIDs in comparison
    VerifierSettings.DontScrubGuids();
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