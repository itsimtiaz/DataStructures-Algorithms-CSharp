namespace DataStructures_Algorithms_CSharp.DataStructures.Trees;

public class Factorial
{
    public int GetFactorialByRecursion(int value)
    {
        if (value == 0)
        {
            return 1;
        }

        return value * (value - 1);
    }
}
