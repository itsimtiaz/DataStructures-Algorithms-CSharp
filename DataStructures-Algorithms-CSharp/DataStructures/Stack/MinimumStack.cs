namespace DataStructures_Algorithms_CSharp.DataStructures.Stack;

public class MinimumStack
{
    private CustomStack stack, minimumStack;

    public MinimumStack(int size)
    {
        stack = new CustomStack(size);
        minimumStack = new CustomStack(size);
    }

    public void Push(int item)
    {
        stack.Push(item);

        if (minimumStack.IsEmpty() || minimumStack.Peek() > item)
        {
            minimumStack.Push(item);
        }
    }

    public int Pop()
    {
        var popElement = stack.Pop();

        if (popElement == minimumStack.Peek())
        {
            minimumStack.Pop();
        }

        return popElement;
    }

    public int Peek() => stack.Peek();
}
