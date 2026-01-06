

using System.Collections.ObjectModel;
using System.Text;

namespace DataStructures_Algorithms_CSharp.DataStructures.Trees;

public class CustomTries
{
    class Node(char ch)
    {
        public char Item { get; set; } = ch;
        public bool IsEndOfWord { get; set; }

        public IDictionary<char, Node> Children { get; set; } = new Dictionary<char, Node>();

        public bool Exists(char item) => Children.ContainsKey(item);

        public void Add(char item) => Children.Add(item, new Node(item));

        public Node Get(char item) => Children[item];

        public void MarkWordComplete() => IsEndOfWord = true;

        public IEnumerable<Node> GetChildren() => Children.Values;

        public void Remove(char item) => Children.Remove(item);

        public bool IsEmpty() => !Children.Any();

        public int ChildrenCount() => Children.Count();

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

        return current.IsEndOfWord;
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

    private bool Remove(Node? root, string input, int index)
    {
        if (root is null) return;

        if (index == input.Length)
        {
            if (root.IsEndOfWord)
                root.IsEndOfWord = false;
            return root.Children.Count() == 0;
        }

        if (!root.Exists(input[index]))
            return false;

        var node = root.Get(input[index]);

        var shouldRemove = Remove(node, input, index + 1);

        if (shouldRemove)
            root.Remove(input[index]);

        return !root.IsEndOfWord && root.IsEmpty();
    }

    public IEnumerable<string> AutoComplete(string input)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(input);

        ICollection<string> words = new Collection<string>();
        
        var current = _root;
        foreach (var item in input)
        {
            if(!current.Exists(item))
                return words;
            
            current = current.Get(item);
        }
        
        AutoComplete(current, words, input);

        return words;
    }

    private void AutoComplete(Node? current, ICollection<string> words, string input)
    {
        if (current is null) return;

        if (current.IsEndOfWord)
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
       if (!root.Exists(input[index]))
           return false;
        
        var node = root.Get(input[index]);

        if (index == input.Length)
            return node.IsEndOfWord;

        return ContainsRecursive(node, input, index + 1);
    }

    public int CountWords() => CountWords(_root);

    private int CountWords(Node root)
    {
        int result = 0;
        if (root.IsEndOfWord)
            result++;

        foreach (var child in node.GetChildren())
        {
            result += CountWords(child);
        }

        return result;
    }

    public string GetLongestPrefix(IEnumerable<string> words)
    {
        int shortestWord = int.MaxValue;

        var tri = new CustomTries();

        foreach (var word in words)
        {
            tri.Add(word);

            shortestWord = shortestWord > word.Length ? word.Length : shortestWord;
        }

        var longestPrefix = new StringBuilder(shortestWord);

        var current = tri._root;

        while (current.ChildrenCount() == 1)
        {
            current = current.GetChildren().FirstOrDefault();

            if (current is null) break;

            longestPrefix.Append(current.Item);
        }

        return longestPrefix.ToString();
    }

}
