
using System.Text.RegularExpressions;
using ContactBook.Bussiness.Models;

namespace ContactBook.Bussiness.RegexBased;

public class RegexBasedContactSearcher : IContactSearcher
{
    private readonly IReadOnlyList<Contact> _contacts;
    public RegexBasedContactSearcher(IReadOnlyList<Contact> contacts)
    {
        _contacts = contacts;
    }

    public IEnumerable<Contact> SearchContactByName(string name)
    {
        var regex = new Regex($"^{name}", RegexOptions.Compiled, TimeSpan.FromMinutes(1));
        return _contacts.Where(contact => regex.IsMatch(contact.Name));
    }
}