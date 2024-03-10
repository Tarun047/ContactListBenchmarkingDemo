using ContactBook.Bussiness.Models;

namespace ContactBook.Bussiness.HashBased;

public class HashBasedContactSearcher : IContactSearcher
{
    private readonly IReadOnlyList<Contact> _contacts;
    private readonly Dictionary<ReadOnlyMemory<char>, List<Contact>> _hasher;

    public HashBasedContactSearcher(IReadOnlyList<Contact> contacts)
    {
        _contacts = contacts;
        _hasher = new Dictionary<ReadOnlyMemory<char>, List<Contact>>(new ReadOnlyCharMemoryComparer());
        PopulateContactHash();
    }

    private void PopulateContactHash()
    {
        foreach (var contact in _contacts)
        {
            for(int i=0; i < contact.IndexKey.Length; i++)
            {
                var key = contact.IndexKey.AsMemory(0, i+1);
                _hasher.TryAdd(key, new List<Contact>());
                _hasher[key].Add(contact);
            }
        }
    }
    
    public IEnumerable<Contact> SearchContactByName(string name)
    {
        return _hasher.TryGetValue(name.AsMemory(), out var matches) ? matches : Enumerable.Empty<Contact>();
    }
}