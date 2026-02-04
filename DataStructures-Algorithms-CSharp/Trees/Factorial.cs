namespace DataStructures_Algorithms_CSharp.Trees;

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

    public int GetFactorialByLoop(int value)
    {
        int result = 1;

        for (int i = value; i > 0; i--)
        {
            result *= i;
        }

        return result;
    }
}
