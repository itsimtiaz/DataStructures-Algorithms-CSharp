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

        var element = Head;
        Head = Head!.Next;

        element!.Next = null;
        _count--;
        return element.Item;
    }

    public int Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        return Head!.Item;
    }

    public bool IsEmpty() => Head == null;

    public int Size() => _count;

    public int[] ToArray()
    {

        var list = new int[_count];

        if (!IsEmpty())
        {
            int i = 0;
            var current = Head;

            while (current != null)
            {
                list[i++] = current.Item;
            }

        }

        return list;
    }
}
