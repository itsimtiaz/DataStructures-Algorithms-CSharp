namespace DataStructures_Algorithms_CSharp.HashTable;

public class PairsInData
{

    public int FindPairsWithGivenDifference(int[] data, int difference)
    {
        HashSet<int> dictionary = new HashSet<int>();

        foreach (var item in data)
        {
            dictionary.Add(item);
        }

        var count = 0;
        foreach (var item in dictionary)
        {
            if (dictionary.Contains(difference + item))
            {
                count++;
            }

            if (dictionary.Contains(difference - item))
            {
                count++;
            }

            dictionary.Remove(item);
        }

        return count;
    }

}
