namespace DataStructures_Algorithms_CSharp.Queue;

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

        MoveStack1ToStack2();

        return stack2.Pop();
    }

    public int Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        MoveStack1ToStack2();

        return stack2.Peek();
    }

    public bool IsEmpty() => !stack1.Any() && !stack2.Any();

    #region Methods

    private void MoveStack1ToStack2()
    {
        if (!stack2.Any())
        {
            while (stack1.Any())
            {
                stack2.Push(stack1.Pop());
            }
        }
    }

    #endregion

}
