using BenchmarkDotNet.Attributes;
using Bogus;
using ContactBook.Bussiness.Models;

namespace ContactBook.Benchmark.DataGen;

public abstract class ContactBookDataGenBase
{
    [Params(1_000, 5_000, 10_000)]
    public int Size { get; set; }

    private readonly Faker<Contact> _faker = new Faker<Contact>()
        .UseSeed(42)
        .RuleFor(contact => contact.Name, faker => faker.Person.FullName)
        .RuleFor(contact => contact.Email, faker => faker.Person.Email)
        .RuleFor(contact => contact.PhoneNumber, faker => faker.Person.Phone);
    
    protected List<string> NamesToSearch;
    protected List<Contact> Contacts;

    
    [GlobalSetup]
    public void Setup()
    {
        Contacts = _faker.Generate(Size);
        NamesToSearch = Enumerable.Range(0, Size).Where(idx => idx % 4 == 0).Select(idx => Contacts[idx].Name).ToList();
        Randomizer.Seed = new Random(7337);
        var faker = new Faker();
        foreach (var contact in Contacts)
        {
            contact.Name = $"{faker.PickRandom(NamesToSearch)} {contact.Name}";
        }
    }
}