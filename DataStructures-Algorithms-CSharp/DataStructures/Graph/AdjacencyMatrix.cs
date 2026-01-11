namespace DataStructures_Algorithms_CSharp.DataStructures.Graph;

public class AdjacencyMatrix
{
    private readonly int[,] _table;

    private readonly List<string> _nodes;

    public AdjacencyMatrix(int size)
    {
        _table = new int[size, size];
        _nodes = new();
    }


    public void Add(string label)
    {
        if (_nodes.Contains(label))
            return;

        _nodes.Add(label);
    }

    public void AddEdge(string from, string to)
    {
        var fromIndex = _nodes.IndexOf(from);
        var toIndex = _nodes.IndexOf(to);
        if (fromIndex < 0 || toIndex < 0)
            throw new InvalidOperationException();

        _table[fromIndex, toIndex] = 1;
    }

    public void RemoveEdge(string from, string to)
    {
        var fromIndex = _nodes.IndexOf(from);
        var toIndex = _nodes.IndexOf(to);
        if (fromIndex < 0 || toIndex < 0)
            throw new InvalidOperationException();

        _table[fromIndex, toIndex] = 0;
    }

    public void Print()
    {
        Console.Write("\t");
        foreach (var item in _nodes)
        {
            Console.Write($"{item}\t");
        }

        Console.WriteLine($"");

        for (int i = 0; i < _table.GetLength(0); i++)
        {
            Console.Write($"{_nodes[i]}\t");
            for (int j = 0; j < _table.GetLength(1); j++)
            {
                Console.Write($"{_table[i, j]}\t");
            }
            Console.WriteLine($"");
        }
    }

}
