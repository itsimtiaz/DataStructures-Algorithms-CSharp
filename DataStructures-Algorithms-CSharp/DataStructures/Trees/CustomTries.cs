

using System.Collections.ObjectModel;

namespace DataStructures_Algorithms_CSharp.DataStructures.Trees;

public class CustomTries
{
    class Node(char ch)
    {
        public char Item { get; set; } = ch;
        public bool IsEndOfWorld { get; set; }

        public IDictionary<char, Node> Children { get; set; } = new Dictionary<char, Node>();

        public bool Exists(char item) => Children.ContainsKey(item);

        public void Add(char item) => Children.Add(item, new Node(item));

        public Node Get(char item) => Children[item];

        public void MarkWordComplete() => IsEndOfWorld = true;

        public IEnumerable<Node> GetChildren() => Children.Values;

        public void Remove(char item) => Children.Remove(item);

        public bool IsEmpty() => !Children.Any();

    }

    private Node _root = new(' ');

    public void Add(string input)
    {
        var current = _root;

        foreach (var ch in input)
        {
            if (!current.Exists(ch))
            {
                current.Add(ch);
            }

            current = current.Get(ch);
        }

        current.MarkWordComplete();
    }

    public bool Contains(string input)
    {
        var current = _root;

        foreach (var item in input)
        {
            if (!current.Exists(item))
            {
                return false;
            }

            current = current.Get(item);
        }

        return current.IsEndOfWorld;
    }

    public void Traverse()
    {
        Traverse(_root);
    }

    private void Traverse(Node root)
    {
        // We can only do it by Pre-Order or Post-Order.
        Console.WriteLine(root.Item);

        foreach (var node in root.GetChildren())
        {
            Traverse(node);
        }
    }

    public void Remove(string input)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(input);

        Remove(_root, input, 0);
    }

    private void Remove(Node? root, string input, int index)
    {
        if (root is null) return;

        if (index == input.Length)
        {
            root.IsEndOfWorld = false;
            return;
        }

        var currentCh = input[index];
        var node = root.Get(currentCh);
        Remove(node, input, index + 1);

        if (!root.IsEndOfWorld && root.IsEmpty())
        {
            root.Remove(currentCh);
        }
    }

    public IEnumerable<string> AutoComplete(string input)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(input);

        var current = _root;
        foreach (var item in input)
        {
            current = current?.Get(item);
        }

        ICollection<string> words = new Collection<string>();

        AutoComplete(current, words, input);

        return words;
    }

    private void AutoComplete(Node? current, ICollection<string> words, string input)
    {
        if (current is null) return;

        if (current.IsEndOfWorld)
        {
            words.Add(input);
        }

        foreach (var node in current.GetChildren())
        {
            AutoComplete(node, words, input + node.Item);
        }
    }

    public bool ContainsRecursive(string input)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(input);

        return ContainsRecursive(_root, input, 0);
    }

    private bool ContainsRecursive(Node? node, string input, int index)
    {
        if (node is null)
            return false;

        if (index == input.Length)
            return node.IsEndOfWorld;

        var currentChar = input[index];

        var currentNode = node.Get(currentChar);

        return ContainsRecursive(currentNode, input, index + 1);
    }

    public int CountWords() => CountWords(_root);

    private int CountWords(Node? node)
    {
        if (node is null)
        {
            return 0;
        }

        if (node.IsEndOfWorld)
        {
            return 1;
        }

        int result = 0;
        foreach (var child in node.GetChildren())
        {
            result += CountWords(child);
        }

        return result;
    }
}
