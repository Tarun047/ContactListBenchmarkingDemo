# ContactListBenchmarkingDemo

1. This repo consists of a simple Dotnet Application created to demonstrate how to benchmark using [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)
2. We explore various approaches to solve the problem of prefix search among a given list of strings.
3. Read the supporting medium article [here](https://codezen.medium.com/buckle-up-for-benchmarkdotnet-def73302abed?source=friends_link&sk=0a54bf5c2849d3ad3fbc44732e479876)

# How do I run this
1. Clone the repo
2. Make sure you have dotnet SDK installed from [here](https://dotnet.microsoft.com/en-us/download)
3. Run `dotnet run -c Release --project ContactBook.Benchmark --filter ContactBook.Benchmark.Comparision*` from the root of the repo.
4. Wait for the magic to work!
