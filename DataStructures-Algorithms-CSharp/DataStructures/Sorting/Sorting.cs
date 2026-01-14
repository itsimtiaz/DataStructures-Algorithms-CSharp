namespace DataStructures_Algorithms_CSharp.DataStructures.Sorting;

public class Sorting
{

    private readonly int[] _numbers;
    int count = 0;

    public Sorting(int[] numbers)
    {
        _numbers = numbers;
        count = _numbers.Length;
    }

    public void BubbleSort()
    {
        bool valuesSwapped = false;

        for (int i = 0; i < count; i++)
        {
            valuesSwapped = false;

            for (int j = 1; j < count - i; j++)
            {
                if (_numbers[j - 1] > _numbers[j])
                {
                    SwapValues(j - 1, j);
                    valuesSwapped = true;
                }
            }

            if (!valuesSwapped)
                break;
        }
    }

    public void SelectionSort()
    {
        for (int i = 0; i < count; i++)
        {
            var minIndex = i;

            for (int j = i + 1; j < count; j++)
            {
                if (_numbers[j] < _numbers[minIndex])
                {
                    minIndex = j;
                }
            }

            SwapValues(i, minIndex);
        }
    }

    public void InsertionSort()
    {
        for (int i = 0; i < count; i++)
        {
            var current = _numbers[i];

            int j = i - 1;

            while (j >= 0 && _numbers[j] > current)
            {
                _numbers[j + 1] = _numbers[j];
                j--;
            }

            _numbers[j + 1] = current;
        }
    }

    public void MergeSort() => MergeSort(_numbers);

    private void MergeSort(int[] numbers)
    {
        if (numbers.Length <= 1)
            return;

        int mid = numbers.Length / 2;

        int[] leftArray = new int[mid];
        for (int i = 0; i < mid; i++)
        {
            leftArray[i] = numbers[i];
        }

        int[] rightArray = new int[numbers.Length - mid];

        for (int i = mid; i < numbers.Length; i++)
        {
            rightArray[i - mid] = numbers[i];
        }

        MergeSort(leftArray);
        MergeSort(rightArray);

        Merge(leftArray, rightArray, numbers);
    }

    private void Merge(int[] leftArray, int[] rightArray, int[] original)
    {
        int leftIndex = 0, rightIndex = 0, index = 0;

        while (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
        {
            if (leftArray[leftIndex] <= rightArray[rightIndex])
            {
                original[index++] = leftArray[leftIndex++];
            }
            else
            {
                original[index++] = rightArray[rightIndex++];
            }
        }

        while (leftIndex < leftArray.Length)
        {
            original[index++] = leftArray[leftIndex++];
        }

        while (rightIndex < rightArray.Length)
        {
            original[index++] = rightArray[rightIndex++];
        }
    }

    public void QuickSort() => QuickSort(0, count - 1);

    private void QuickSort(int start, int end)
    {
        if (start >= end)
            return;

        int pivot = _numbers[end];
        int boundary = start - 1;

        for (int i = start; i < end; i++)
        {
            if (_numbers[i] < pivot)
            {
                SwapValues(++boundary, i);
            }
        }

        SwapValues(++boundary, end);

        QuickSort(start, boundary - 1);
        QuickSort(boundary + 1, end);
    }

    public void CountSort(int maxValue)
    {
        int[] countArray = new int[maxValue + 1];

        foreach (var number in _numbers)
        {
            countArray[number]++;
        }
        int k = 0;
        for (int i = 0; i < countArray.Length; i++)
        {
            for (int j = 0; j < countArray[i]; j++)
            {
                _numbers[k++] = i;
            }
        }

    }

    public void BucketSort(int bucketSize)
    {
        List<int>[] buckets = new List<int>[bucketSize];

        for (int i = 0; i < bucketSize; i++)
        {
            buckets[i] = new List<int>();
        }

        foreach (var number in _numbers)
        {
            var bucketIndex = number / bucketSize;
            buckets[bucketIndex].Add(number);
        }

        int index = 0;
        foreach (var bucket in buckets)
        {
            bucket.Sort();

            foreach (var number in bucket)
            {
                _numbers[index++] = number;
            }
        }

    }

    #region Methods

    private void SwapValues(int index1, int index2)
    {
        if (index1.Equals(index2))
            return;

        var temp = _numbers[index1];
        _numbers[index1] = _numbers[index2];
        _numbers[index2] = temp;
    }

    #endregion

}
