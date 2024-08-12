using System;

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

        if (Head is null)
        {
            Head = Tail = node;
        }
        else
        {
            node.Next = Head;
            Head = node;
        }
    }
}
