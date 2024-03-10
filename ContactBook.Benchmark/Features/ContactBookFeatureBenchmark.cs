using BenchmarkDotNet.Attributes;
using ContactBook.Benchmark.DataGen;
using ContactBook.Bussiness.Models;

namespace ContactBook.Benchmark.Features;

[MemoryDiagnoser(false)]
[JsonExporterAttribute.Full]
public class ContactBookFeatureBenchmark : ContactBookDataGenBase
{
    [Benchmark]
    public void BenchmarkSearch()
    {
        var contactSearcher = new Bussiness.ContactBook(Contacts);
        var matchedContacts = new List<Contact>();
        foreach (var name in NamesToSearch)
        {
            matchedContacts.AddRange(contactSearcher.SearchByName(name));
        }
    }
}