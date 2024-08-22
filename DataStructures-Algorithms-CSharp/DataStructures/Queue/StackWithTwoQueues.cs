namespace DataStructures_Algorithms_CSharp.DataStructures.Queue;

public class StackWithTwoQueues
{
    Queue<int> queue1, queue2;
    private int top;
    public StackWithTwoQueues()
    {
        queue1 = new Queue<int>();
        queue2 = new Queue<int>();
    }

    public void Push(int item)
    {
        top = item;
        queue1.Enqueue(top);
    }

    public int Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        while (queue1.Count() > 1)
        {
            top = queue1.Dequeue();
            queue2.Enqueue(top);
        }

        var temp = queue2;
        queue2 = queue1;
        queue1 = temp;

        return queue2.Dequeue();
    }

    public int Peek() => top;

    public bool IsEmpty() => !queue1.Any();
}
