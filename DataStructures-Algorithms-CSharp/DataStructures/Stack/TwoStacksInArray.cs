using System;

namespace DataStructures_Algorithms_CSharp.DataStructures.Stack;

public class TwoStacksInArray
{
    private int[] stack;
    private int stack1Counter, stack2Counter;

    public TwoStacksInArray(int size)
    {
        stack = new int[size];
        stack1Counter = -1;
        stack2Counter = size;
    }

    public void PushInStack1(int item)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("The stack is full.");
        }

        stack[++stack1Counter] = item;
    }

    public void PushInStack2(int item)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("The stack is full.");
        }

        stack[--stack2Counter] = item;
    }

    public int PopFromStack1()
    {
        if (IsStack1Empty())
        {
            throw new InvalidOperationException("The stack is empty.");
        }

        return stack[stack1Counter--];
    }


    public int PopFromStack2()
    {
        if (IsStack2Empty())
        {
            throw new InvalidOperationException("The stack is empty.");
        }

        return stack[stack1Counter++];
    }

    public bool IsStack1Empty() => stack1Counter == -1;

    public bool IsStack2Empty() => stack2Counter == stack.Length;

    #region Methods

    private bool IsFull() => stack2Counter - 1 == stack1Counter;

    #endregion
}
