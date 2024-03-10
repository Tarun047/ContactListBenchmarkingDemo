using System.Collections;

namespace ContactBook.Bussiness;

public interface IIndexable
{
    public string IndexKey { get; }
}

class TrieNode<TNode> where TNode : IIndexable
{
    public List<TNode> Values { get; } = new();
    public Dictionary<char, TrieNode<TNode>> Children { get; } = new();
}

public class Trie<TNode> where TNode : IIndexable
{
    private readonly TrieNode<TNode> _root = new();
    
    public Trie(IEnumerable<TNode> data)
    {
        InitializeTrie(data);
    }

    private void InitializeTrie(IEnumerable<TNode> data)
    {
        foreach (var node in data)
        {
            Insert(node);
        }
    }

    void Insert(TNode node)
    {
        var root = _root;
        foreach (var prefix in node.IndexKey)
        {
            root.Children.TryAdd(prefix,new TrieNode<TNode>());
            root = root.Children[prefix];
            root.Values.Add(node);
        }
    }

    public IEnumerable<TNode> Search(string key)
    {
        var root = _root;
        foreach (var prefix in key)
        {
            if (root.Children.TryGetValue(prefix, out var child))
            {
                root = child;
            }
            else
            {
                return Enumerable.Empty<TNode>();
            }
        }
        
        return root.Values;
    }
}