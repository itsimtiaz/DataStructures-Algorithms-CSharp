
namespace DataStructures_Algorithms_CSharp.DataStructures.Trees;

public class AvlTree
{
    class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
    }

    private Node? _root;

    public void Add(int value)
    {
        _root = Add(_root, value);
    }

    private Node? Add(Node? root, int value)
    {
        if (root is null)
        {
            return new Node(value);
        }

        if (root.Value > value)
        {
            root.Left = Add(root.Left, value);
        }
        else
        {
            root.Right = Add(root.Right, value);
        }

        return root;
    }
}
