namespace DataStructures_Algorithms_CSharp.Heap;

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

    public int Remove()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The heap is empty.");
        }

        var index = 0;
        var root = _heap[index];
        _heap[index] = _heap[--count];

        while (index <= count && !IsValidParent(index))
        {
            int largestChild = 0;

            if (!HasRightChild(index))
            {
                largestChild = LeftIndex(index);
            }
            else
            {
                largestChild = _heap[LeftIndex(index)] > _heap[RightIndex(index)] ? LeftIndex(index) : RightIndex(index);
            }

            Swap(index, largestChild);
            index = largestChild;
        }

        return root;
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

    private int LeftIndex(int index) => 2 * index + 1;

    private int RightIndex(int index) => 2 * index + 2;

    private bool IsValidParent(int index)
    {
        if (index == count)
        {
            return true;
        }

        var isValid = _heap[index] > _heap[LeftIndex(index)];

        if (RightIndex(index) <= count)
        {
            isValid &= _heap[index] > _heap[RightIndex(index)];
        }

        return isValid;
    }

    private bool HasLeftChild(int index) => LeftIndex(index) <= count;

    private bool HasRightChild(int index) => RightIndex(index) <= count;

    #endregion

}
