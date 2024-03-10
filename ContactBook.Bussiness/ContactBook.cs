using ContactBook.Bussiness.Models;
using ContactBook.Bussiness.RegexBased;

namespace ContactBook.Bussiness;

public class ContactBook
{
    private readonly RegexBasedContactSearcher _contactSearcher;
    public ContactBook(IReadOnlyList<Contact> allContacts)
    {
        _contactSearcher = new(allContacts);
    }

    public IEnumerable<Contact> SearchByName(string name) => _contactSearcher.SearchContactByName(name);
}