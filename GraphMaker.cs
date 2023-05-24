using System;
using System.IO;

class GraphMaker
{


    public static void Main(string[] args)
    {

        int[,] starterGraph = {
            { 0, 0, 1 },
            { 0, 0, 1 },
            { 1, 1, 0 }
            };

        Graph myGraph = new Graph(starterGraph);
        Console.WriteLine(myGraph.DotOutput());


    }
}