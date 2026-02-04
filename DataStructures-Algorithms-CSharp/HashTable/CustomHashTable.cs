namespace DataStructures_Algorithms_CSharp.HashTable;

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

    public void Remove(int key)
    {
        var tableIndex = GetTableHashCode(key);

        if (_table[tableIndex] is null)
        {
            return;
        }

        foreach (var item in _table[tableIndex])
        {
            if (item.Key == key)
            {
                _table[tableIndex].Remove(item);
                return;
            }
        }

        throw new InvalidOperationException($"The provided key: {key} doesn't exist in the table");
    }

    public string? Get(int key)
    {
        var tableIndex = GetTableHashCode(key);

        if (_table[tableIndex] is null)
        {
            return null;
        }

        foreach (var item in _table[tableIndex])
        {
            if (item.Key == key)
            {
                return item.Value;
            }
        }

        throw new InvalidOperationException($"The provided key: {key} doesn't exist in the table");
    }

    #region Methods

    private int GetTableHashCode(int key) => Math.Abs(key.GetHashCode()) % _table.Length;

    #endregion

}
