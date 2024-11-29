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

    public int Remove()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException();
        }

        var index = 0;

        var itemToBeRemoved = _heap[index];

        _heap[index] = _heap[--_offset];

        var largestChild = GetLargestChildIndex(index);

        while (largestChild != index && _heap[index] < _heap[largestChild])
        {
            SwapValues(index, largestChild);
            index = largestChild;
            largestChild = GetLargestChildIndex(index);
        }

        return itemToBeRemoved;
    }

    public IEnumerable<int> GetDataByDescendingOrder()
    {
        for (int i = 0; i < _offset; i++)
        {
            yield return Remove();
        }
    }

    public IEnumerable<int> GetDataByAscendingOrder()
    {
        int[] data = new int[_offset];
        for (int i = _offset - 1; i >= 0; i--)
        {
            data[i] = Remove();
        }

        return data;
    }

    public void Heapify(int[] data)
    {
        if (data.Length == 0)
        {
            throw new InvalidOperationException();
        }

        for (int i = 0; i < data.Length; i++)
        {
            Heapify(i, data);
        }
    }

    private void Heapify(int index, int[] data)
    {
        if (index >= data.Length)
        {
            return;
        }

        var largestChild = GetLargestChildIndex(index);

        if (largestChild >= data.Length || data[index] > data[largestChild])
        {
            return;
        }

        SwapValues(index, largestChild, data);

        Heapify(largestChild, data);
    }

    public int GetKthLargestItem(int kth)
    {
        if (kth < 0 || kth >= _offset)
        {
            throw new ArgumentOutOfRangeException();
        }

        for (int i = 0; i < kth; i++)
        {
            Remove();
        }

        return GetFirstItem();
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


    private void SwapValues(int index1, int index2, int[] data)
    {
        var swapValue = data[index1];
        data[index1] = data[index2];
        data[index2] = swapValue;
    }


    private int GetParentIndex(int index) => (index - 1) / 2;

    private int GetLeftIndex(int index) => (index * 2) + 1;

    private int GetRightIndex(int index) => index * 2 + 2;

    private int GetLargestChildIndex(int index)
    {
        var leftIndex = GetLeftIndex(index);
        var rightIndex = GetRightIndex(index);

        if (leftIndex >= _offset)
        {
            return index;
        }

        if (rightIndex >= _offset)
        {
            return leftIndex;
        }

        return _heap[leftIndex] > _heap[rightIndex] ? leftIndex : rightIndex;
    }

    private int GetFirstItem() => _heap[0];

    #endregion

}
