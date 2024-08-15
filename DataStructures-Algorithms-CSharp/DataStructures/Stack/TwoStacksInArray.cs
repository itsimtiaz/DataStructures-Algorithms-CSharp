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

    #region Methods

    private bool IsFull() => stack2Counter - 1 == stack1Counter;

    #endregion
}
