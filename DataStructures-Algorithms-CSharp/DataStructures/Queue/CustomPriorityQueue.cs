namespace DataStructures_Algorithms_CSharp.DataStructures.Queue;

public class CustomPriorityQueue
{
    private int[] queue;
    private int count;

    public CustomPriorityQueue(int initialSize)
    {
        queue = new int[initialSize];
    }
}
