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

    /// <summary>
    /// It will reverse elements up-to k element.
    /// </summary>
    /// <param name="queue"></param>
    /// <param name="k"></param>
    public void Reverse(CustomQueue queue, int k)
    {

        if (queue.IsEmpty())
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        CustomStack stack = new CustomStack(queue.Count());

        for (int i = 0; i < k; i++)
        {
            stack.Push(queue.Dequeue());
        }

        while (!stack.IsEmpty())
        {
            queue.Enqueue(stack.Pop());
        }

        for (int i = 0; i < queue.Count() - k; i++)
        {
            queue.Enqueue(queue.Dequeue());
        }
    }
}
