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

    public HashTableWithProbing(int size)
    {
        _table = new TableKeyValuePair[size];
    }

    public void Add(int key, string value)
    {

    }

}
