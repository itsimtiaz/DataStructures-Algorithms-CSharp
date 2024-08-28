using System.Reflection.Metadata.Ecma335;

namespace DataStructures_Algorithms_CSharp.DataStructures.HashTable;

public class MostRepeatedChar
{
    IDictionary<char, int> dictionary;

    public MostRepeatedChar()
    {
        dictionary = new Dictionary<char, int>();
    }
    public char GetMostRepeatedChar(string input)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(input);

        ClearDictionaryIfRequired();

        for (int i = 0; i < input.Length; i++)
        {
            var dictionaryKey = input[i];

            int count = dictionary.ContainsKey(dictionaryKey) ? dictionary[dictionaryKey] + 1 : 1;

            dictionary[dictionaryKey] = count;
        }

        char mostRepeatedChar = GetFirstKeyFromDictionary();

        foreach (KeyValuePair<char, int> item in dictionary)
        {
            if (item.Value > dictionary[mostRepeatedChar])
            {
                mostRepeatedChar = item.Key;
            }
        }

        return mostRepeatedChar;
    }


    #region Methods

    private void ClearDictionaryIfRequired()
    {
        if (dictionary.Any())
        {
            dictionary.Clear();
        }
    }

    private char GetFirstKeyFromDictionary() => dictionary.Keys.First();

    #endregion
}
