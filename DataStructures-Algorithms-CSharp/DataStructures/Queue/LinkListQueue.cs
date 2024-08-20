namespace DataStructures_Algorithms_CSharp.DataStructures.Queue;

public class LinkListQueue
{
    class Node
    {
        public Node(int node)
        {
            Item = node;
        }
        public int Item { get; private set; }
        public Node? Next { get; set; }
    }

    private Node? Head, Tail;
    private int _count;

    public void Enqueue(int item)
    {
        var node = new Node(item);

        if (IsEmpty())
        {
            Head = Tail = node;
        }
        else
        {
            Tail!.Next = node;
            Tail = node;
        }

        _count++;
    }

    public int Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The queue is empty.");
        }
    }

    public bool IsEmpty() => Head == null;
}
