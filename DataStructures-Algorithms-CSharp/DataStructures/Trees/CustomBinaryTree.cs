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

}
