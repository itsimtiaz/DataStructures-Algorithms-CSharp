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

    private TableKeyValuePair[] _table;
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
    }

    #region Methods

    private bool IsFull() => count == _table.Length;

    private int GetTableHashCode(int key) => Math.Abs(key.GetHashCode()) % _table.Length;

    #endregion

}
