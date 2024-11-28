namespace DataStructures_Algorithms_CSharp.DataStructures.Trees;

public class CustomHeap
{
    private readonly int[] _heap;
    private int _offset;
    public CustomHeap(int size)
    {
        _heap = new int[size];
    }

    public void Add(int item)
    {
        if (IsFull())
        {
            throw new InvalidOperationException();
        }

        var index = _offset;

        _heap[_offset++] = item;

        var parentIndex = GetParentIndex(index);

        while (index > 0 && _heap[index] > _heap[parentIndex])
        {
            SwapValues(index, parentIndex);

            index = parentIndex;
            parentIndex = GetParentIndex(index);
        }

    }


    #region Methods

    private bool IsFull() => _offset == _heap.Length;

    private bool IsEmpty() => _offset == 0;

    private void SwapValues(int index1, int index2)
    {
        var swapValue = _heap[index1];
        _heap[index1] = _heap[index2];
        _heap[index2] = swapValue;
    }

    private int GetParentIndex(int index) => (index / 2) - 1;

    #endregion

}
