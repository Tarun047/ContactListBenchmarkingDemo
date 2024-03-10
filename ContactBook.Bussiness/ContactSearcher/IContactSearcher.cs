using ContactBook.Bussiness.Models;

namespace ContactBook.Bussiness;

public interface IContactSearcher
{
    public IEnumerable<Contact> SearchContactByName(string name);
}