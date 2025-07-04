using System.Text;

namespace DataStructures_Algorithms_CSharp.DataStructures.StringUtils;

public class StringUtils
{
    public static int CountVowels(string input)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(input);

        HashSet<char> vowels = new() { 'a', 'i', 'e', 'o', 'u' };
        int result = 0;
        foreach (var item in input)
        {
            if (vowels.Contains(char.ToLowerInvariant(item)))
                result++;
        }

        return result;
    }

    public static string ReverseByStack(string input)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(input);

        Stack<char> stack = new();
        foreach (var item in input)
        {
            stack.Push(item);
        }

        StringBuilder result = new();

        while (stack.Any())
        {
            result.Append(stack.Pop());
        }

        return result.ToString();
    }

    public static string ReverseByIterative(string input)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(input);

        StringBuilder result = new();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            result.Append(input[i]);
        }

        return result.ToString();
    }

    public static string ReverseSentence(string input)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(input);

        var inputArray = input.Split(' ');

        StringBuilder result = new();

        for (int i = inputArray.Length - 1; i >= 0; i--)
        {
            result.Append(inputArray[i]);
            if (i > 0)
                result.Append(" ");
        }

        return result.ToString();
    }

    public static bool IsRotated(string original, string input)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(original);

        ArgumentException.ThrowIfNullOrWhiteSpace(input);

        return original.Length == input.Length && (original + original).Contains(input);
    }

    public static string RemoveDuplicate(string input)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(input);

        HashSet<char> duplicates = new();

        StringBuilder result = new();

        foreach (var item in input)
        {
            if (duplicates.Contains(item))
                continue;

            duplicates.Add(item);
            result.Append(item);
        }

        return result.ToString();
    }

    public static char MostRepeatedCharWithDictionary(string input)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(input);

        Dictionary<char, int> table = new();

        foreach (var item in input)
        {
            if (table.ContainsKey(item))
            {
                table[item]++;
            }
            else
            {
                table.Add(item, 1);
            }
        }

        char mostRepeatedChar = table.FirstOrDefault().Key;

        foreach (var item in table)
        {
            if (table[mostRepeatedChar] < item.Value)
                mostRepeatedChar = item.Key;
        }

        return mostRepeatedChar;
    }

    public static char MostRepeatedCharWithArray(string input)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(input);

        int[] inputArray = new int[256];

        foreach (var item in input)
        {
            inputArray[item]++;
        }

        int mostRepeatedChar = 0;

        for (int i = 0; i < inputArray.Length; i++)
        {
            if (inputArray[mostRepeatedChar] < inputArray[i])
                mostRepeatedChar = i;
        }

        return (char)mostRepeatedChar;
    }

    public static string CapitalizeSentence(string input)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(input);

        var words = input.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].Substring(0, 1).ToUpper() +
                    words[i].Substring(1);
        }

        return string.Join(' ', words);
    }

    public static bool AreAnagrams(string input1, string input2)
    {
        var firstInputCharArray = input1.ToCharArray();
        var secondInputCharArray = input2.ToCharArray();

        System.Array.Sort(firstInputCharArray);
        System.Array.Sort(secondInputCharArray);

        return firstInputCharArray.Length == secondInputCharArray.Length &&
                firstInputCharArray.SequenceEqual(secondInputCharArray);
    }

    public static bool AreAnagramsUsingHistogramming(string input1, string input2)
    {
        int[] inputArray = new int[256];

        for (int i = 0; i < input1.Length; i++)
        {
            inputArray[i]++;
        }

        for (int i = 0; i < input2.Length; i++)
        {
            if (inputArray[i] < 1)
                return false;

            inputArray[i]--;
        }

        return true;
    }

    public static bool AreAnagramsUsingHistogrammingByDictionary(string input1, string input2)
    {
        Dictionary<char, int> table = new();

        foreach (var item in input1)
        {
            if (table.ContainsKey(item))
                table[item]++;
            else
                table.Add(item, 1);
        }

        foreach (var item in input2)
        {
            if (!table.ContainsKey(item) || table[item] < 1)
                return false;

            table[item]--;
        }

        return true;
    }

    public static bool IsPalindrome(string input)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(input);

        StringBuilder reverseString = new();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            reverseString.Append(input[i]);
        }

        return input.Equals(reverseString.ToString());
    }

    public static bool IsPalindromeByLeftRightIndex(string input)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(input);

        int left = 0, right = input.Length - 1;

        while (left < right)
        {
            if (input[left++] != input[right--])
                return false;
        }

        return true;
    }

}
