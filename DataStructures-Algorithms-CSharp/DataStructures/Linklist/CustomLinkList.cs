namespace DataStructures_Algorithms_CSharp.DataStructures.Linklist;

public class CustomLinkList
{
    class Node(int item)
    {
        public int Item { get; } = item;
        public Node? Next { get; set; }
    }

    Node? Head, Tail;
    int offset;

    public void AddFirst(int item)
    {
        Node node = new(item);

        if (IsEmpty())
        {
            Head = Tail = node;
        }
        else
        {
            node.Next = Head;
            Head = node;
        }

        offset++;
    }

    public void AddLast(int item)
    {
        Node node = new(item);

        if (IsEmpty())
        {
            Head = Tail = node;
        }
        else
        {
            Tail!.Next = node;
            Tail = node;
        }

        offset++;
    }

    public void RemoveFirst()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The list is empty.");
        }

        if (Head == Tail)
        {
            Head = Tail = null;
        }
        else
        {
            var nextNode = Head!.Next;
            Head!.Next = null;
            Head = nextNode;
        }

        offset--;
    }

    public void RemoveLast()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The list is empty.");
        }
        else
        {
            var current = Head;

            while (current!.Next != Tail)
            {
                current = current!.Next;
            }

            current.Next = null;
            Tail = current;
        }

        offset--;
    }

    public int IndexOf(int item)
    {
        var current = Head;

        int j = 0;
        while (current != null)
        {
            if (current.Item == item)
            {
                return j;
            }

            j++;
        }
        return -1;
    }

    public bool Contains(int item) => IndexOf(item) >= 0;

    public int Size() => offset;

    public void Reverse()
    {
        if (IsEmpty() || Size() == 1)
        {
            return;
        }

        Node? current = Head, next = null, previous = null;

        while (current != null)
        {
            next = current.Next;

            current.Next = previous;

            previous = current;
            current = next;
        }

        // Resetting Head and Tail
        Tail = Head;
        Head = previous;
    }

    public int FindKthNodeFromEnd(int index)
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("This list is empty.");
        }

        var current = Head;
        for (int i = 0; i < index; i++)
        {
            current = current!.Next;

            if (current is null)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        var kthNode = Head;
        while (current != null)
        {
            current = current.Next;
            kthNode = kthNode!.Next;
        }

        return kthNode!.Item;
    }

    public int[] FindMiddle()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("This list is empty.");
        }

        Node? fast = Head, slow = Head;

        while (fast != null && fast.Next != null)
        {
            fast = fast.Next?.Next;
            slow = slow?.Next;
        }

        if (fast == Tail)
        {
            return new[] { slow!.Item };
        }
        else
        {
            return new[] { slow!.Item, slow.Next!.Item };
        }
    }

    public bool HasLoop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("This list is empty.");
        }

        Node? fast = Head, slow = Head;

        while (fast != null)
        {
            fast = fast.Next?.Next;
            slow = slow?.Next;

            if (fast == slow)
            {
                return true;
            }
        }

        return false;
    }

    #region Methods

    private bool IsEmpty() => Head is null;

    #endregion
}
