using ContactBook.Bussiness.Models;

namespace ContactBook.Bussiness;

public class ListBasedContactSearcher : IContactSearcher
{
    private readonly IReadOnlyList<Contact> _contacts;
    public ListBasedContactSearcher(IReadOnlyList<Contact> allContacts)
    {
        _contacts = allContacts;
    }
    
    public IEnumerable<Contact> SearchContactByName(string name)
    {
        foreach (var contact in _contacts)
        {
            if (contact.Name.StartsWith(name))
            {
                yield return contact;
            }
        }
    }
}