using System;
using DataStructures_Algorithms_CSharp.DataStructures.Stack;

namespace DataStructures_Algorithms_CSharp.DataStructures.Queue;

public class QueueReverser
{
    public void Reverse(CustomQueue queue)
    {
        if (queue.IsEmpty())
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        CustomStack stack = new CustomStack(queue.Count());

        while (!queue.IsEmpty())
        {
            stack.Push(queue.Dequeue());
        }

        while (!stack.IsEmpty())
        {
            queue.Enqueue(stack.Pop());
        }
    }
}
