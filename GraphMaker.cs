using System;
using System.IO;


class GraphMaker
{
    const string SourceFolder = "./files/";
    const string DestinationFolder = "./files/";

    public static void WriteFile(string dotData, string filename = "output.dot")
    {
        string finalFilename = DestinationFolder + filename;

        using (StreamWriter outputFile = new StreamWriter(finalFilename))
        {
            outputFile.Write(dotData);
        }
    }


    public static void Main(string[] args)
    {

        int[,] starterGraph = {
            { 0, 0, 1 },
            { 1, 0, 1 },
            { 1, 1, 0 }
            };

        Graph myGraph = new Graph(starterGraph);

        Console.WriteLine(myGraph.DotOutput());
        WriteFile(myGraph.DotOutput());

    }
}