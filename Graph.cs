using System;
using System.Text;

class Graph
{

    private const int CharacterShiftOffset = 65;


    // how to store graph structure?
    private int _nodeCount = 0;

    /// <summary>
    /// GraphArray is the array that stores the underlying graph structure.
    /// 
    /// </summary> 
    private int[,] _graphArray;


    /// <summary>
    /// Constructor to create a graph of a certain number of nodes
    /// in which no nodes are connected.
    /// </summary>
    /// <param name="NumbNodes"></param>
    public Graph(int NumbNodes = 0)
    {
        // set node counts
        _nodeCount = NumbNodes;

        // init array
        _graphArray = new int[_nodeCount, _nodeCount];


    }

    public Graph(int[,] StarterGraph)
    {
        if (StarterGraph.GetLength(0) == StarterGraph.GetLength(1))
        {
            _nodeCount = StarterGraph.GetLength(0);
            _graphArray = StarterGraph;
        }
        else
        {
            _nodeCount = 0;
            _graphArray = new int[0, 0];
        }
    }

    /// <summary>
    /// AddEdge adds an edge from a Source Node to a Destination
    /// Node on the Graph.
    /// </summary>
    /// <param name="SourceNode">The startintg node</param>
    /// <param name="DestNode">The ending node</param>
    /// <returns>true if node was successfully added, false
    /// otherwise</returns>
    public bool AddEdge(int SourceNode, int DestNode)
    {
        // nodes out of range
        if ((SourceNode >= _nodeCount) || (DestNode >= _nodeCount))
        {
            return false;
        }
        else
        {
            _graphArray[SourceNode, DestNode] = 1;
            return true;
        }
    }

    public bool DeleteEdge(int SourceNode, int DestNode)
    {
        // nodes out of range
        if ((SourceNode >= _nodeCount) || (DestNode >= _nodeCount))
        {
            return false;
        }
        else
        {
            _graphArray[SourceNode, DestNode] = 0;
            return true;
        }
    }

    /// <summary>
    /// IsDigraph determines if the encapsulated graph is a 
    /// directional graph or not.
    /// </summary>
    /// <returns>true if a directional graph.</returns>
    public bool IsDigraph()
    {
        for (int i = 0; i < _nodeCount; i++)
        {
            for (int j = i + 1; j < _nodeCount; j++)
            {
                if (_graphArray[i, j] != _graphArray[j, i])
                {
                    return true;
                }
            }
        }

        return false;
    }

    private string _dotDigraphOutput()
    {
        StringBuilder outputString = new StringBuilder();

        outputString.AppendLine("digraph {");
        for (int i = 0; i < _nodeCount; i++)
        {
            for (int j = 0; j < _nodeCount; j++)
            {
                if (_graphArray[i, j] == 1)
                {
                    outputString.Append(Convert.ToChar(i + CharacterShiftOffset));
                    outputString.Append(" -> ");
                    outputString.Append(Convert.ToChar(j + CharacterShiftOffset));
                    outputString.AppendLine();
                }
            }
        }
        outputString.AppendLine("}");

        return outputString.ToString();

    }

    private string _dotGraphOutput()
    {
        StringBuilder outputString = new StringBuilder();

        outputString.AppendLine("graph {");
        for (int i = 0; i < _nodeCount; i++)
        {
            for (int j = i; j < _nodeCount; j++)
            {
                if (_graphArray[i, j] == 1)
                {
                    outputString.Append(Convert.ToChar(i + CharacterShiftOffset));
                    outputString.Append(" -- ");
                    outputString.Append(Convert.ToChar(j + CharacterShiftOffset));
                    outputString.AppendLine();
                }
            }
        }
        outputString.AppendLine("}");

        return outputString.ToString();

    }

    public string DotOutput()
    {
        if (IsDigraph())
        {
            return _dotDigraphOutput();
        }
        else
        {
            return _dotGraphOutput();
        }
    }
}