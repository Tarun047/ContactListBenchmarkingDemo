using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ContactBook.Benchmark.DataGen;
using ContactBook.Bussiness;
using ContactBook.Bussiness.HashBased;
using ContactBook.Bussiness.Models;
using ContactBook.Bussiness.RegexBased;

namespace ContactBook.Benchmark.Comparision;


[MemoryDiagnoser(false)]
[Orderer(SummaryOrderPolicy.Method)]
[RankColumn]
public class ContactSearcherComparisionBenchmark : ContactBookDataGenBase
{
    [Benchmark]
    public void ListContactSearcher()
    {
        IContactSearcher contactSearcher = new ListBasedContactSearcher(Contacts);
        BenchmarkCore(contactSearcher);
    }

    [Benchmark]
    public void TrieContactSearcher()
    {
        IContactSearcher contactSearcher = new TrieBasedContactSearcher(Contacts);
        BenchmarkCore(contactSearcher);
    }

    [Benchmark]
    public void RegexBasedContactSearcher()
    {
        IContactSearcher contactSearcher = new RegexBasedContactSearcher(Contacts);
        BenchmarkCore(contactSearcher);
    }

    [Benchmark]
    public void HashBasedContactSearcher()
    {
        IContactSearcher contactSearcher = new HashBasedContactSearcher(Contacts);
        BenchmarkCore(contactSearcher);
    }

    private void BenchmarkCore(IContactSearcher contactSearcher)
    {
        var matchedContacts = new List<Contact>();
        foreach (var name in NamesToSearch)
        {
            matchedContacts.AddRange(contactSearcher.SearchContactByName(name));
        }
    }
}