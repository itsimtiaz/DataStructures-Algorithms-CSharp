namespace DataStructures_Algorithms_CSharp.DataStructures.HashTable;

public class HashTableWithProbing
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

    private TableKeyValuePair?[] _table;
    private int count;

    public HashTableWithProbing(int size)
    {
        _table = new TableKeyValuePair[size];
    }

    public void Add(int key, string value)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("The table is full.");
        }

        var tableHashCode = GetTableHashCode(key);

        var tableKeyValuePair = new TableKeyValuePair(key, value);

        if (_table[tableHashCode] is null)
        {
            _table[tableHashCode] = tableKeyValuePair;
            return;
        }

        while (_table[tableHashCode] != null)
        {
            tableHashCode++;

            if (tableHashCode == _table.Length)
            {
                tableHashCode = tableHashCode % _table.Length;
            }
        }

        _table[tableHashCode] = tableKeyValuePair;
        count++;
    }

    public string? Get(int key)
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The table is empty.");
        }

        var tableHashKey = GetTableHashCode(key);

        if (_table[tableHashKey]?.Key == key)
        {
            return _table[tableHashKey]!.Value;
        }

        var nextItem = (tableHashKey + 1) % _table.Length;

        while (nextItem != tableHashKey)
        {
            if (_table[nextItem]?.Key == key)
            {
                return _table[nextItem]!.Value;
            }

            nextItem++;
            if (nextItem == _table.Length)
            {
                nextItem = nextItem % _table.Length;
            }
        }

        throw new InvalidOperationException($"There is no data for the provided key: {key}");
    }

    public void Remove(int key)
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The table is empty.");
        }

        var tableHashKey = GetTableHashCode(key);

        if (_table[tableHashKey]!.Key == key)
        {
            _table[tableHashKey] = null;
            return;
        }

        var nextItem = (tableHashKey + 1) % _table.Length;

        while (nextItem != tableHashKey)
        {
            if (_table[nextItem]?.Key == key)
            {
                _table[nextItem] = null;
            }
            nextItem++;

            if (nextItem == _table.Length)
            {
                nextItem = nextItem % _table.Length;
            }
        }

        throw new InvalidOperationException($"There is no data found for the provided key: {key}.");
    }

    #region Methods

    private bool IsFull() => count == _table.Length;
    private bool IsEmpty() => count == 0;

    private int GetTableHashCode(int key) => Math.Abs(key.GetHashCode()) % _table.Length;

    #endregion

}
