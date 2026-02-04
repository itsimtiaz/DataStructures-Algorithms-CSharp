namespace DataStructures_Algorithms_CSharp.Searching;

public class Searching
{

    private readonly int[] _numbers;
    private int count = 0;

    public Searching(int[] numbers)
    {
        _numbers = numbers;
        count = _numbers.Length;
    }

    public int LinearSearch(int target)
    {
        for (int i = 0; i < count; i++)
        {
            if (_numbers[i] == target)
                return i;
        }

        return -1;
    }

    public int BinarySearchRecursive(int target)
    {
        return BinarySearchRecursive(target, 0, count - 1);
    }

    private int BinarySearchRecursive(int target, int start, int end)
    {
        if (start > end)
            return -1;

        int mid = (start + end) / 2;

        if (_numbers[mid] == target)
        {
            return mid;
        }

        if (_numbers[mid] > target)
        {
            return BinarySearchRecursive(target, start, mid - 1);
        }

        return BinarySearchRecursive(target, mid + 1, end);
    }

    public int BinarySearchIterative(int target)
    {
        int start = 0, end = count - 1;

        while (start <= end)
        {
            int mid = (start + end) / 2;

            if (_numbers[mid] == target)
            {
                return mid;
            }

            if (_numbers[mid] > target)
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }

        return -1;
    }

    public int TernarySearch(int target)
    {
        return TernarySearch(target, 0, count - 1);
    }

    private int TernarySearch(int target, int start, int end)
    {
        if (start > end)
            return -1;

        int partition = (end - start) / 3;

        int mid1 = start + partition;
        int mid2 = end - partition;

        if (_numbers[mid1] == target)
            return mid1;

        if (_numbers[mid2] == target)
            return mid2;

        if (target < _numbers[mid1])
            return TernarySearch(target, start, mid1 - 1);

        if (target > _numbers[mid2])
            return TernarySearch(target, mid2 + 1, end);

        return TernarySearch(target, mid1 + 1, mid2 - 1);
    }

    public int JumpSearch(int target)
    {
        int partition = (int)Math.Sqrt(count);

        int start = 0, end = partition;

        while (start < end && _numbers[end - 1] < target)
        {
            start = end;

            end += partition;

            if (end > count)
                end = count;
        }

        for (int i = start; i < end; i++)
        {
            if (_numbers[i] == target)
                return i;
        }

        return -1;
    }

    public int ExponentialSearch(int target)
    {
        int boundary = 1;

        while (boundary < count && _numbers[boundary] < target)
        {
            boundary *= 2;
        }

        int start = 0;
        int end = Math.Min(boundary, count - 1);

        return BinarySearchRecursive(target, start, end);
    }

}
