namespace DataStructures_Algorithms_CSharp.HashTable;

public class NonRepeatedChar
{
    private readonly IDictionary<char, int> dictionary;

    public NonRepeatedChar()
    {
        dictionary = new Dictionary<char, int>();
    }

    public char GetFirstNonRepeatedChar(string input)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(nameof(input));

        ClearDictionaryIfRequired();

        for (int i = 0; i < input.Length; i++)
        {
            var key = input[i];

            var count = dictionary.TryGetValue(key, out var result) ? result + 1 : 1;

            dictionary[key] = count;
        }

        foreach (KeyValuePair<char, int> item in dictionary)
        {
            if (item.Value == 1)
            {
                return item.Key;
            }
        }

        return char.MinValue;
    }

    #region Methods

    private void ClearDictionaryIfRequired()
    {
        if (dictionary.Any())
        {
            dictionary.Clear();
        }
    }

    #endregion

}
