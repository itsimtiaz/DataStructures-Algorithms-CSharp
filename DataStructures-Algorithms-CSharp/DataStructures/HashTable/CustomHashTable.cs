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
        public int Key { get; set; }
        public string Value { get; set; } = null!;
    }

    private LinkedList<TableKeyValuePair>[] _table;

    public CustomHashTable(int size)
    {
        _table = new LinkedList<TableKeyValuePair>[size];
    }

    public void Add(int key, string value)
    {
        var tableIndex = GetTableHashCode(key);

        if (_table[tableIndex] is null)
        {
            _table[tableIndex] = new LinkedList<TableKeyValuePair>();
        }

        // If item is already exist then we just need to update the value. 
        foreach (var item in _table[tableIndex])
        {
            if (item.Key == key)
            {
                item.Value = value;
                return;
            }
        }

        _table[tableIndex].AddLast(new TableKeyValuePair(key, value));
    }

    #region Methods

    private int GetTableHashCode(int key) => key.GetHashCode() % _table.Length;

    #endregion

}