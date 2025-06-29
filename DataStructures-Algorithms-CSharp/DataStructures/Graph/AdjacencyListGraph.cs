namespace DataStructures_Algorithms_CSharp.DataStructures.Graph;

public class AdjacencyListGraph
{
    record Node(string Label);

    Dictionary<string, Node> _nodes = new();
    Dictionary<Node, List<Node>> _edges = new();

    public void Add(string label)
    {
        if (_nodes.ContainsKey(label))
            return;

        Node node = new(label);
        _nodes.Add(label, node);
        _edges.Add(node, new List<Node>());
    }

    public void Remove(string label)
    {
        if (!_nodes.TryGetValue(label, out var node))
            return;

        foreach (var edge in _edges.Values)
        {
            if (edge.Contains(node))
            {
                edge.Remove(node);
            }
        }

        _edges.Remove(node);
        _nodes.Remove(label);
    }

    public void AddEdge(string from, string to)
    {
        if (!_nodes.TryGetValue(from, out var fromNode) || !_nodes.TryGetValue(to, out var toNode))
            throw new InvalidOperationException();

        if (!_edges[fromNode].Contains(toNode))
            _edges[fromNode].Add(toNode);
    }

    public void RemoveEdge(string from, string to)
    {
        if (!_nodes.TryGetValue(from, out var fromNode) || !_nodes.TryGetValue(to, out var toNode))
            throw new InvalidOperationException();

        if (_edges[fromNode].Contains(toNode))
            _edges[fromNode].Remove(toNode);
    }

    public void Print()
    {
        foreach (var node in _edges)
        {
            Console.WriteLine($"{node.Key} is connected with {string.Join(", ", node.Value.Select(_ => _.Label))}");
        }
    }

    public void Traverse(string label)
    {
        if (!_nodes.TryGetValue(label, out var node))
            return;

        HashSet<Node> visited = new();
        Traverse(node, visited);
    }

    private void Traverse(Node node, HashSet<Node> visited)
    {
        Console.WriteLine($"Node: {node.Label}");
        visited.Add(node);

        foreach (var edge in _edges[node])
        {
            if (!visited.Contains(edge))
            {
                Traverse(edge, visited);
            }
        }
    }

    public void TraverseIterative(string label)
    {
        if (!_nodes.TryGetValue(label, out var node))
            return;

        HashSet<Node> visited = new();
        Stack<Node> stack = new();

        stack.Push(node);

        while (stack.Any())
        {
            var popItem = stack.Pop();
            Console.WriteLine($"Node: {popItem.Label}");

            visited.Add(popItem);

            foreach (var edge in _edges[popItem])
            {
                if (!visited.Contains(edge))
                {
                    stack.Push(edge);
                }
            }
        }
    }

    public void BreadthFirstTraverse(string label)
    {
        if (!_nodes.TryGetValue(label, out var node))
            return;

        HashSet<Node> visited = new();
        Queue<Node> queue = new();

        queue.Enqueue(node);

        while (queue.Any())
        {
            var popItem = queue.Dequeue();
            Console.WriteLine($"Node: {popItem.Label}");

            visited.Add(popItem);

            foreach (var edge in _edges[popItem])
            {
                if (!visited.Contains(edge))
                {
                    queue.Enqueue(edge);
                }
            }
        }
    }

    public IEnumerable<string> TopologicalSort()
    {
        HashSet<Node> visited = new();
        Stack<Node> stack = new();

        foreach (var node in _nodes.Values)
        {
            TopologicalSort(node, visited, stack);
        }

        List<string> path = new();
        while (stack.Any())
        {
            path.Add(stack.Pop().Label);
        }

        return path;
    }

    private void TopologicalSort(Node node, HashSet<Node> visited, Stack<Node> stack)
    {
        visited.Add(node);

        foreach (var edge in _edges[node])
        {
            if (!visited.Contains(edge))
                TopologicalSort(edge, visited, stack);
        }

        stack.Push(node);
    }
}
