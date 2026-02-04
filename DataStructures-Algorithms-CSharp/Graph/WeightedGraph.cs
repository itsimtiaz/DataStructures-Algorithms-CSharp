namespace DataStructures_Algorithms_CSharp.Graph;

public class WeightedGraph
{
    class Node(string label)
    {
        public string Label { get; } = label;

        List<Edge> edges = new();

        public void AddEdge(Node to, int weight) => edges.Add(new(this, to, weight));

        public IEnumerable<Edge> Edges => edges;
    }

    class DistanceComparer : IComparer<int>
    {
        public int Compare(int x, int y) => x.CompareTo(y);
    }

    record Edge(Node From, Node To, int Weight);

    readonly Dictionary<string, Node> _nodes = new();

    public void Add(string label)
    {
        if (_nodes.ContainsKey(label))
            return;

        _nodes.Add(label, new Node(label));
    }

    public void AddEdge(string from, string to, int weight)
    {
        if (!_nodes.TryGetValue(from, out var fromNode) || !_nodes.TryGetValue(to, out var toNode))
            throw new InvalidOperationException();

        fromNode.AddEdge(toNode, weight);
        toNode.AddEdge(fromNode, weight);
    }

    public void Print()
    {
        foreach (var node in _nodes.Values)
        {
            Console.WriteLine($"{node.Label} is connected with {string.Join(", ", node.Edges.Select(_ => _.To.Label))}");
        }
    }

    public string GetShortestPath(string from, string to)
    {
        if (!_nodes.TryGetValue(from, out var fromNode) || !_nodes.TryGetValue(to, out var toNode))
            throw new InvalidOperationException();

        Dictionary<Node, int> nodeDistances = new();
        Dictionary<Node, Node> previousNodes = new();

        foreach (var node in _nodes.Values)
        {
            nodeDistances.Add(node, int.MaxValue);
        }

        nodeDistances[fromNode] = 0;

        PriorityQueue<Node, int> queue = new(comparer: new DistanceComparer());
        queue.Enqueue(fromNode, 0);

        HashSet<Node> visited = new();

        while (queue.Count > 0)
        {
            var popItem = queue.Dequeue();
            visited.Add(popItem);

            foreach (var edge in popItem.Edges)
            {
                if (visited.Contains(edge.To))
                    continue;

                var newDistance = nodeDistances[popItem] + edge.Weight;

                if (newDistance < nodeDistances[edge.To])
                {
                    nodeDistances[edge.To] = newDistance;
                    previousNodes[edge.To] = popItem;
                    queue.Enqueue(edge.To, newDistance);
                }
            }
        }

        Stack<Node> stack = new();
        var previousNode = toNode;

        while (previousNode != null)
        {
            stack.Push(previousNode);
            previousNodes.TryGetValue(previousNode, out previousNode);
        }

        List<string> path = new();

        while (stack.Any())
        {
            path.Add(stack.Pop().Label);
        }

        return string.Join(" -> ", path);
    }

    public WeightedGraph GetMinimumSpinningTree()
    {
        var graph = new WeightedGraph();

        if (!_nodes.Any())
            return graph;

        var firstNode = _nodes.FirstOrDefault().Value;

        HashSet<Node> visited = new();
        PriorityQueue<Edge, int> queue = new();

        foreach (var edge in firstNode.Edges)
        {
            queue.Enqueue(edge, edge.Weight);
        }

        visited.Add(firstNode);

        graph.Add(firstNode.Label);

        while (queue.Count > 0)
        {
            var popEdge = queue.Dequeue();
            
            graph.Add(popEdge.To.Label);
            graph.AddEdge(popEdge.From.Label, popEdge.To.Label, popEdge.Weight);

            visited.Add(popEdge.To);

            foreach (var edge in popEdge.To.Edges)
            {
                if (visited.Contains(edge.To))
                    continue;

                queue.Enqueue(edge, edge.Weight);
            }
        }

        return graph;
    }

    public bool HasCycle()
    {
        HashSet<Node> visited = new();

        foreach (var node in _nodes.Values)
        {
            if (visited.Contains(node))
                continue;

            if (HasCycle(node, null, visited))
                return true;
        }

        return false;
    }

    private bool HasCycle(Node node, Node? parent, HashSet<Node> visited)
    {
        visited.Add(node);

        foreach (var edge in node.Edges)
        {
            if (edge.To == parent)
                continue;

            if (visited.Contains(edge.To) || HasCycle(edge.To, node, visited))
                return true;
        }

        return false;
    }
}
