namespace DataStructures_Algorithms_CSharp.DataStructures.Stack;

public class CustomStack
{
    private int[] stack;
    private int offset;

    public CustomStack(int size)
    {
        stack = new int[size];
    }

    public void Push(int item)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("The stack is full and cannot accept more items.");
        }

        stack[offset++] = item;
    }

    public int Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("This stack is empty.");
        }

        return stack[--offset];
    }

    #region Methods

    bool IsEmpty() => offset == 0;

    bool IsFull() => offset == stack.Length;

    #endregion
}
