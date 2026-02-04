namespace DataStructures_Algorithms_CSharp.Queue;

public class CustomQueue
{
    private int[] queue;
    private int front, rear, count;

    public CustomQueue(int size)
    {
        queue = new int[size];
    }

    public void Enqueue(int item)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("The queue is full.");
        }

        queue[rear] = item;
        count++;

        rear = (rear + 1) % queue.Length;
    }

    public int Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("This queue is empty.");
        }

        var item = queue[front];
        queue[front] = default;
        count--;
        front = (front + 1) % queue.Length;
        return item;
    }

    public int Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("This queue is empty.");
        }

        return queue[front];
    }

    public bool IsEmpty() => count == 0;

    public int Count() => count;

    #region Methods

    private bool IsFull() => count == queue.Length;

    #endregion
}
