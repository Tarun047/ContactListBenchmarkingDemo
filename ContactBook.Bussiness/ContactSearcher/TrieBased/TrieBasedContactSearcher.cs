using ContactBook.Bussiness.Models;

namespace ContactBook.Bussiness;

public class TrieBasedContactSearcher : IContactSearcher
{
    private readonly Trie<Contact> _trie;
    public TrieBasedContactSearcher(IReadOnlyList<Contact> allContacts)
    {
        _trie = new Trie<Contact>(allContacts);
    }
    
    public IEnumerable<Contact> SearchContactByName(string name)
    {
        return _trie.Search(name);
    }
}