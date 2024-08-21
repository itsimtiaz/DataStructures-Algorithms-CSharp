namespace DataStructures_Algorithms_CSharp.DataStructures.Queue;

public class TwoStacksQueue
{
    private Stack<int> stack1, stack2;

    public TwoStacksQueue()
    {
        stack1 = new Stack<int>();
        stack2 = new Stack<int>();
    }

    public void Enqueue(int item)
    {
        stack1.Push(item);
    }

    public int Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        if (!stack2.Any())
        {
            while (stack1.Any())
            {
                stack2.Push(stack1.Pop());
            }
        }

        return stack2.Pop();
    }

    public bool IsEmpty() => !stack1.Any() && !stack2.Any();

}
