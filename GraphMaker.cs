using System;
using System.IO;
using System.Text;


class GraphMaker
{

    /// <summary>
    /// ReadGraphFile opens a text file containing an adjacency matrix (composed of 0s
    /// and 1s) and loads it into a Graph object.
    /// If the text file is incomplete or malformed, this method may have unpredictable
    /// results.
    /// </summary>
    /// <param name="filename">the file name to open</param>
    /// <returns>a Graph object of the corresponding adjacency matrix</returns>
    public static Graph ReadGraphFile(string filename)
    {
        // set up the Graph to return
        Graph returnGraph = new Graph(0);

        // lazy person way to deal with problems!
        try
        {
            int lineCounter = 0;

            // open the file
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

                if (thisLine.Length < returnGraph.NodeCount)
                {
                    Console.WriteLine("Adjacency matrix file has too few columns.");
                    Console.WriteLine("Assuming missing data contain 0s.");
                }
                // parse the integers of the line
                for (int i = 0; i < thisLine.Length; i++)
                {
                    if (i >= returnGraph.NodeCount)
                    {
                        Console.WriteLine("Adjacency matrix file has too many columns.");
                        Console.WriteLine("Ignoring extra columns.");
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

            if (lineCounter < returnGraph.NodeCount)
            {
                Console.WriteLine("Adjacency file contains insufficient number of lines.");
                Console.WriteLine("Assuming the missing rows of the matrix contain all 0s.");
            }
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

    /// <summary>
    /// GetFilename prompts the user for a filename and returns the
    /// filename entered by the user.
    /// </summary>
    /// <returns>string of the filename netered by the user</returns>
    public static string GetFilename(bool IsInputFile = true)
    {
        if (IsInputFile)
        {
            Console.WriteLine("Please enter the name of the file (with path) of the ");
            Console.WriteLine("adjacency matrix text file: ");
        }
        else
        {
            Console.WriteLine("Please enter the name of the destination file to use.");
        }


        string filename = "";

        while (filename == "")
        {
            filename = Console.ReadLine();

            if (filename == "")
            {
                Console.WriteLine("Please enter a filename!");
            }
        }

        return filename;

    }


    public static void Main(string[] args)
    {

        string inputFile = GetFilename();


        Graph myGraph = ReadGraphFile(inputFile);

        string outputFile = GetFilename(false);

        WriteFile(myGraph.DotOutput(), outputFile);

    }
}