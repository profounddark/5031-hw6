using System;
using System.IO;
using System.Text;


class GraphMaker
{

    public static Graph ReadGraphFile(string filename)
    {
        // set up the Graph to return
        Graph returnGraph = new Graph(0);

        try
        {
            int lineCounter = 0;

            StreamReader graphFile = new StreamReader(filename);
            // read the first line of the file

            string graphLine = graphFile.ReadLine();

            while (graphLine != null)
            {
                // split by tabs
                string[] thisLine = graphLine.Split("\t");

                // I weirdly hate this part
                if (returnGraph.IsNull())
                {
                    returnGraph = new Graph(thisLine.Length);
                }

                // parse the integers of the line
                for (int i = 0; i < thisLine.Length; i++)
                {
                    if (i >= returnGraph.NodeCount)
                    {
                        throw new Exception("Too many edges in source file!");
                    }

                    if (Convert.ToInt32(thisLine[i]) == 1)
                    {
                        returnGraph.AddEdge(lineCounter, i);
                    }
                }

                lineCounter++;
                graphLine = graphFile.ReadLine();
            }
            graphFile.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("oops! you broke it!");
            Console.WriteLine("Exception: " + e.Message);
            returnGraph = new Graph(0);
        }

        return returnGraph;
    }

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


        Graph myGraph = ReadGraphFile("./files/adj3.txt");

        WriteFile(myGraph.DotOutput());

    }
}