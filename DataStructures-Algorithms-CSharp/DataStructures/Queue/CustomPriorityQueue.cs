namespace DataStructures_Algorithms_CSharp.DataStructures.Queue;

public class CustomPriorityQueue
{
    private int[] queue;
    private int count, front;

    public CustomPriorityQueue(int initialSize)
    {
        queue = new int[initialSize];
    }

    public void Enqueue(int item)
    {
        if (IsFull())
        {
            Resize();
        }

        int j = count - 1;

        while (queue[j] > item && j >= 0)
        {
            queue[j + 1] = queue[j];
            j--;
        }

        queue[j + 1] = item;
        count++;
    }

    public int Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var item = queue[front];
        queue[front++] = default;
        front = (front + 1) % queue.Length;
        count--;
        return item;
    }

    #region Methods

    private bool IsEmpty() => count == 0;

    private bool IsFull() => count == queue.Length;

    private void Resize()
    {
        var tempData = new int[count * 2];

        for (int i = 0; i < count; i++)
        {
            tempData[i] = queue[i];
        }

        queue = tempData;
    }

    #endregion
}
