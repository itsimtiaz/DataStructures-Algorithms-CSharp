namespace DataStructures_Algorithms_CSharp.Array;

public class DynamicArray
{
    int[] _array;
    int offset;

    public DynamicArray(int initialSize = 10)
    {
        _array = new int[initialSize];
    }

    public void Insert(int item)
    {
        if (IsFull())
        {
            Resize();
        }

        _array[offset++] = item;
    }

    public void InsertAt(int item, int index)
    {
        if (IsFull())
        {
            Resize();
        }

        for (int i = offset; i >= index; i--)
        {
            _array[i] = _array[i - 1];
        }

        _array[index] = item;
        offset++;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= offset)
        {
            throw new IndexOutOfRangeException("Index is out of bounds.");
        }

        for (int i = index; i < offset; i++)
        {
            _array[i] = _array[i + 1];
        }

        offset--;
    }

    public void Reverse()
    {
        var temporaryArray = new int[offset];

        int j = 0;
        for (int i = offset - 1; i >= 0; i--)
        {
            temporaryArray[j++] = _array[i];
        }

        _array = temporaryArray;
    }

    public int IndexOf(int item)
    {
        for (int i = 0; i < offset; i++)
        {
            if (_array[i] == item)
            {
                return i;
            }
        }

        return -1;
    }

    public bool Contains(int item) => IndexOf(item) >= 0;

    public DynamicArray Intersect(DynamicArray array)
    {
        var intersection = new DynamicArray(offset);

        for (int i = 0; i < offset; i++)
        {
            if (array.Contains(_array[i]))
            {
                intersection.Insert(_array[i]);
            }
        }

        return intersection;
    }

    public int Max()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The array is empty.");
        }

        int max = 0;

        for (int i = 0; i < offset; i++)
        {
            if (_array[i] > max)
            {
                max = _array[i];
            }
        }

        return max;
    }

    public int Min()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The array is empty.");
        }

        int min = 0;

        for (int i = 0; i < offset; i++)
        {
            if (_array[i] < min)
            {
                min = _array[i];
            }
        }

        return min;
    }

    #region Methods

    bool IsEmpty() => offset == 0;

    bool IsFull() => offset == _array.Length;

    void Resize()
    {
        var temporaryResizedArray = new int[offset * 2];

        for (int i = 0; i < offset; i++)
        {
            temporaryResizedArray[i] = _array[i];
        }

        _array = temporaryResizedArray;
    }

    #endregion
}
