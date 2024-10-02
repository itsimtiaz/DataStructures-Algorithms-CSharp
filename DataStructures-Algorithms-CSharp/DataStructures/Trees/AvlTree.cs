
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
            if (GetBalanceFactor(root.Left!) < 0)
            {
                RotateLeft(root.Left!);
            }

            return RotateRight(root);
        }
        else if (IsRightHeavy(root))
        {
            if (GetBalanceFactor(root.Right!) > 0)
            {
                RotateRight(root.Right!);
            }

            return RotateLeft(root);
        }

        return root;
    }

    public bool IsBalance() => IsBalance(_root);

    private bool IsBalance(Node? root)
    {
        if (root is null)
        {
            return true;
        }

        return root.Height >= -1 && root.Height <= 1 && IsBalance(root.Left) && IsBalance(root.Right);
    }

    public bool IsPerfectWithFormula()
    {
        var treeHeight = GetTreeHeight(_root);
        return IsPerfectWithFormula(_root, treeHeight);
    }

    private bool IsPerfectWithFormula(Node? root, int treeHeight)
    {
        return GetTreeSize(root) == Math.Pow(2, GetTreeHeight(_root) + 1) - 1;
    }

    #region Methods

    private int GetNodeHeight(Node? node) => node?.Height ?? -1;

    private int GetHeight(Node? node) => 1 + Math.Max(GetNodeHeight(node?.Left), GetNodeHeight(node?.Right));

    private int GetBalanceFactor(Node node) => GetNodeHeight(node.Left) - GetNodeHeight(node.Right);

    private bool IsLeftHeavy(Node node) => GetBalanceFactor(node) > 1;

    private bool IsRightHeavy(Node node) => GetBalanceFactor(node) < -1;

    private Node RotateLeft(Node node)
    {
        var newNode = node.Right;
        node.Right = newNode!.Left;
        newNode!.Left = node;
        return newNode;
    }

    private Node RotateRight(Node node)
    {
        var newNode = node.Left;
        node.Left = newNode!.Right;
        newNode!.Right = node;
        return newNode;
    }

    private int GetTreeHeight(Node? node)
    {
        if (node is null)
        {
            return -1;
        }

        return 1 + Math.Max(GetTreeHeight(node.Left), GetTreeHeight(node.Right));
    }

    private int GetTreeSize(Node? node)
    {
        if (node is null)
        {
            return 0;
        }

        return GetTreeSize(node.Left) + 1 + GetTreeSize(node.Right);
    }

    #endregion
}
