
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
        public int Height { get; set; }
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

        root.Height = GetHeight(root);

        if (IsLeftHeavy(root))
        {
            Console.WriteLine("The tree is left heavy.");
        }

        if (IsRightHeavy(root))
        {
            Console.WriteLine("The tree is right heavy.");
        }

        return root;
    }

    #region Methods

    private int GetHeight(Node? node) => 1 + Math.Max(node?.Left?.Height ?? -1, node?.Right?.Height ?? -1);

    private int GetBalanceFactor(Node node) => GetHeight(node.Left) - GetHeight(node.Right);

    private bool IsLeftHeavy(Node node) => GetBalanceFactor(node) > 0;
    private bool IsRightHeavy(Node node) => GetBalanceFactor(node) < 0;

    #endregion
}
