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

}
