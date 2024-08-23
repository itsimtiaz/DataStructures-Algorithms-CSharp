using System;

namespace DataStructures_Algorithms_CSharp.DataStructures.HashTable;

public class CustomHashTable
{
    class TableKeyValuePair
    {
        public TableKeyValuePair(int key, string value)
        {
            Key = key;
            Value = value;
        }
        public int Key { get; private set; }
        public string Value { get; private set; } = null!;
    }



}
