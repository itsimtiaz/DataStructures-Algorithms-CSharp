namespace DataStructures_Algorithms_CSharp.DataStructures.Trees;

public class CustomBinaryTree
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

    public void Add(int item)
    {
        Node node = new(item);

        if (_root is null)
        {
            _root = node;
            return;
        }

        var currentNode = _root;

        while (true)
        {
            if (item > currentNode.Value)
            {
                if (currentNode.Right is null)
                {
                    currentNode.Right = node;
                    break;
                }

                currentNode = currentNode.Right;
            }
            else
            {
                if (currentNode.Left is null)
                {
                    currentNode.Left = node;
                    break;
                }
                currentNode = currentNode.Left;
            }
        }

    }

    public bool Find(int item)
    {
        if (_root is null)
        {
            throw new InvalidOperationException("The tree is empty.");
        }

        var currentNode = _root;

        while (currentNode != null)
        {
            if (currentNode.Value == item)
            {
                return true;
            }

            if (item > currentNode.Value)
            {
                currentNode = currentNode.Right;
            }
            else
            {
                currentNode = currentNode.Left;
            }
        }

        return false;
    }

    public void PreOrderTraverse() => PreOrderTraverse(_root);

    /// <summary>
    /// Tree will be traversed by Root, Left, Right.
    /// </summary>
    /// <param name="root"></param>
    private void PreOrderTraverse(Node? root)
    {
        if (root is null)
        {
            return;
        }

        Console.Write($"{root.Value}, ");

        PreOrderTraverse(root.Left);
        PreOrderTraverse(root.Right);
    }

    public void InOrderTraverse() => InOrderTraverse(_root);

    /// <summary>
    /// Tree will be traversed by Left, Root, Right
    /// </summary>
    /// <param name="root"></param>
    private void InOrderTraverse(Node? root)
    {
        if (root is null)
        {
            return;
        }

        InOrderTraverse(root.Left);

        Console.Write($"{root.Value}, ");

        InOrderTraverse(root.Right);
    }

    public void PostOrderTraverse() => PostOrderTraverse(_root);

    /// <summary>
    /// Tree will be traversed by Left, Right, Root.
    /// </summary>
    /// <param name="root"></param>
    private void PostOrderTraverse(Node? root)
    {
        if (root is null)
        {
            return;
        }

        PostOrderTraverse(root.Left);
        PostOrderTraverse(root.Right);

        Console.Write($"{root.Value}, ");
    }

    public int GetHeight() => GetHeight(_root);

    private int GetHeight(Node? root)
    {
        if (root is null)
        {
            return -1;
        }
        int leftHeight = GetHeight(root.Left);
        int rightHeight = GetHeight(root.Right);

        return 1 + (leftHeight > rightHeight ? leftHeight : rightHeight);
    }

    public int GetMinimumValue() => GetMinimumValue(_root);

    private int GetMinimumValue(Node? root)
    {
        if (root is null)
        {
            return int.MaxValue;
        }

        return Math.Min(GetMinimumValue(root.Left), GetMinimumValue(root.Right));
    }

    public bool CheckEquality(CustomBinaryTree tree) => CheckEquality(_root, tree._root);

    private bool CheckEquality(Node? root1, Node? root2)
    {
        if (root1 is null && root2 is null)
        {
            return true;
        }

        if (root1 is not null && root2 is not null)
        {
            return root1.Value == root2.Value && CheckEquality(root1.Left, root2.Left) && CheckEquality(root1.Right, root2.Right);
        }

        return false;
    }

    private bool ValidateBinarySearchTree() => ValidateBinarySearchTree(_root, int.MinValue, int.MaxValue);

    private bool ValidateBinarySearchTree(Node? root, int min, int max)
    {
        if (root is null)
        {
            return true;
        }

        return (root.Value >= min && root.Value <= max)
        && ValidateBinarySearchTree(root.Left, min, root.Value)
        && ValidateBinarySearchTree(root.Right, root.Value, max);
    }

    #region Methods

    private bool IsEmpty() => _root is null;

    #endregion

}
