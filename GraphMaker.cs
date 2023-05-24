using System;
using System.IO;


class GraphMaker
{

    /// <summary>
    /// WriteFile writes the outputs the string data containing the
    /// dot file data into a file with name filename.
    /// </summary>
    /// <param name="dotData">string containing dot file data</param>
    /// <param name="filename">the filename to write</param>
    /// <returns></returns>
    public static bool WriteFile(string dotData, string filename = "output.dot")
    {

        bool success = true;

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
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
            { 0, 1, 1 },
            { 1, 0, 1 },
            { 1, 1, 0 }
            };

        Graph myGraph = new Graph(starterGraph);

        WriteFile(myGraph.DotOutput());

    }
}