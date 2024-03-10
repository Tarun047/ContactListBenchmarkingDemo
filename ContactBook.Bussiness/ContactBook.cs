using ContactBook.Bussiness.Models;

namespace ContactBook.Bussiness;

public class ContactBook
{
    private readonly TrieBasedContactSearcher _contactSearcher;
    public ContactBook(IReadOnlyList<Contact> allContacts)
    {
        _contactSearcher = new(allContacts);
    }

    public IEnumerable<Contact> SearchByName(string name) => _contactSearcher.SearchContactByName(name);
}