using System;

namespace DataStructures_Algorithms_CSharp.DataStructures.Heap;

public class CustomHeap
{
    private readonly int[] _heap;
    private int count;

    public CustomHeap(int size)
    {
        _heap = new int[size];
    }

    public void Add(int item)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("The heap is full.");
        }

        var index = count++;
        var parentIndex = GetParentIndex(index);

        _heap[index] = item;

        while (index > 0 && _heap[index] > _heap[parentIndex])
        {
            Swap(index, parentIndex);

            index = parentIndex;
            parentIndex = GetParentIndex(parentIndex);
        }
    }

    #region Methods

    private bool IsFull() => count == _heap.Length;

    private bool IsEmpty() => count == 0;

    private int GetParentIndex(int index) => (index - 1) / 2;

    private void Swap(int index1, int index2)
    {
        var temp = _heap[index1];
        _heap[index1] = _heap[index2];
        _heap[index2] = temp;
    }

    #endregion

}
