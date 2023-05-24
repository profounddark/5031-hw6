using System;
using System.IO;


class GraphMaker
{
    const string DestinationFolder = "./files-test/";

    public static bool WriteFile(string dotData, string filename = "output.dot")
    {

        bool success = true;

        string finalFilename = DestinationFolder + filename;

        try
        {
            using (StreamWriter outputFile = new StreamWriter(finalFilename))
            {
                outputFile.Write(dotData);
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("There has been an IOException in the attempt");
            Console.WriteLine("to write your DOT file. More information is available");
            Console.WriteLine("in this entirely unhelpful exception message:");
            Console.WriteLine(ex);
            success = false;
        }

        return success;

    }


    public static void Main(string[] args)
    {

        int[,] starterGraph = {
            { 0, 0, 1 },
            { 1, 0, 1 },
            { 1, 1, 0 }
            };

        Graph myGraph = new Graph(starterGraph);

        WriteFile(myGraph.DotOutput());

    }
}