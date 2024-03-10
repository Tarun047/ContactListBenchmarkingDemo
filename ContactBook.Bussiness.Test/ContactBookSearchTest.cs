using ContactBook.Bussiness.HashBased;
using ContactBook.Bussiness.Models;
using ContactBook.Bussiness.RegexBased;

namespace ContactBook.Bussiness.Test;

public class ContactBookSearchTest
{
    public static IEnumerable<TestCaseData> ContactSearchers()
    {
        return new[]
        {
            new TestCaseData(new ListBasedContactSearcher(Contacts))
            {
                TestName = "List Based Search"
            },
            new TestCaseData(new RegexBasedContactSearcher(Contacts))
            {
                TestName = "Regex Based Search"
            },
            new TestCaseData(new TrieBasedContactSearcher(Contacts))
            {
                TestName = "Trie Based Search"
            },
            new TestCaseData(new HashBasedContactSearcher(Contacts))
            {
                TestName = "Hash Based Search"
            }
        };
    }

    [TestCaseSource(nameof(ContactSearchers))]
    public void TestSearch(IContactSearcher contactSearcher)
    {
        var prefixes = new[] { "Ta", "ZZ", "S" };

        foreach (var prefix in prefixes)
        {
            var expectedMatches = Contacts.Where(contact => contact.Name.StartsWith(prefix)).ToArray();
            var matches = contactSearcher.SearchContactByName(prefix).ToArray();
            Assert.That(matches, Has.Length.EqualTo(expectedMatches.Length));
            CollectionAssert.AreEquivalent(expectedMatches.Select(match => match.Name),
                matches.Select(match => match.Name));
        }
    }

    #region Test Data
    private static readonly List<Contact> Contacts = new Contact[]
    {
        new()
        {
            Name = "Tarun",
            Email = "testmail@test.com",
            PhoneNumber = "123456"
        },
        new()
        {
            Name = "Tron",
            Email = "testmail@test.com",
            PhoneNumber = "123456"
        },
        new()
        {
            Name = "SuperTarun",
            Email = "testmail@test.com",
            PhoneNumber = "123456"
        },
        new()
        {
            Name = "TarunCanCodeWell",
            Email = "testmail@test.com",
            PhoneNumber = "123456"
        },
        new()
        {
            Name = "Taller",
            Email = "testmail@test.com",
            PhoneNumber = "123456"
        },
        new()
        {
            Name = "Smaller",
            Email = "testmail@test.com",
            PhoneNumber = "123456"
        },
        new()
        {
            Name = "Tap",
            Email = "testmail@test.com",
            PhoneNumber = "123456"
        }
    }.ToList();

    #endregion
}