using System.Data;

namespace Csv_Formater.Lib;

public class FormatCsv
{
    #region properties
    public IEnumerable<string> FormattedLines { get; set; }
    public IEnumerable<string> Lines { get; set; }
    public static IEnumerable<string> tempLines { get; set; }
    public string Output { get; set; }
    public string Input { get; set; }
    public string Seperator { get; set; }

    public static string tempSeperator;

    public static List<string> _seperatorList = new List<string> { "\t", ";", ",", ":", "|", " " };
#endregion

#region Constructor
public FormatCsv()
    {
    }
    #endregion

    #region Functions
    /// <summary>
    /// Formats the lines 
    /// </summary>
    /// <param name="inputPath"></param>
    /// <param name="whitespace"></param>
    /// <param name="seperator"></param>
    /// <returns></returns>
    public static IEnumerable<string> UserFormat(string inputPath, int whitespace, string seperator = "\t")
    {
        var formattedLines = tempLines; //ReadCsv_and_Split(inputPath, seperator);
        if (whitespace == 0)
        {
            whitespace = CalculateWhitespace(tempLines, seperator);
        }
        return formattedLines.Select(line => line.Split(seperator)
                .Select(text => text.Length < whitespace ? text.PadRight(whitespace) : text)
                .Aggregate((text1, text2) => text1 + seperator + text2));
    }
    /// <summary>
    /// Reads the Csv or text file and splits it into lines. if debug is enabled it generates a random csv file
    /// </summary>
    /// <param name="inputPath"></param>
    /// <param name="seperator"></param>
    /// <returns></returns>
    public static IEnumerable<string> ReadCsv_and_Split(string inputPath, string seperator = "\t")
    {
        //read csv file
        tempLines = File.ReadAllLines(inputPath);
        tempSeperator = seperator;
#if DEBUG
        //tempLines = GenerateTestCsv(2);
#endif
        //format csv file

        var splitLines = 
            tempLines.Select(line => line.Replace(AutoDetectSeperator(inputPath), seperator));

        return splitLines.Select(line => line.TrimEnd(seperator.ToCharArray()));
        //return splitLines;
    }
    /// <summary>
    /// Reads the csv file and returns the seperator that is used
    /// </summary>
    /// <param name="inputPath">the Csv file</param>
    /// <returns></returns>
    public static string AutoDetectSeperator(string inputPath)
    {
        var lines = File.ReadAllLines(inputPath);
        var seperator = "";
        var seperatorCount = 0;
        var seperatorList = _seperatorList;
        foreach (var line in lines)
        {
            foreach (var s in seperatorList)
            {
                if (line.Contains(s))
                {
                    seperatorCount++;
                    seperator = s;
                }
            }
        }

        return seperator;
    }
    //parse csv enclosed between quotes
    public static IEnumerable<string> ParseCsv(string inputPath)
    {
        var lines = tempLines;
        var seperator = AutoDetectSeperator(inputPath);
        var parsedLines = new List<string>();
        foreach (var line in lines)
        {
            var parsedLine = "";
            var quoteCount = 0;
            var quote = false;
            foreach (var c in line)
            {
                if (c == '"')
                {
                    quoteCount++;
                    if (quoteCount % 2 == 0)
                    {
                        quote = false;
                    }
                    else
                    {
                        quote = true;
                    }
                }
                if (c == seperator[0] && !quote)
                {
                    parsedLine += seperator;
                }
                else
                {
                    parsedLine += c;
                }
            }
            parsedLines.Add(parsedLine);
        }
        return parsedLines;
    }

    /// <summary>
    /// Saves the Csv file to the given path
    /// </summary>
    /// <param name="outputpath"></param>
    /// <param name="lines"></param>
    public static void SaveCsv(string outputpath, IEnumerable<string> lines)
    {
        File.WriteAllLines(outputpath, lines);
    }
    /// <summary>
    /// Calculates the whitespace for the csv file
    /// </summary>
    /// <param name="lines">The CSV file</param>
    /// <returns>the number of whitespace chars </returns>
    public static int CalculateWhitespace(IEnumerable<string> lines, string seperator)
    {
        var whitespace = 0;
        foreach (var line in lines)
        {
            var temp = line.Split(seperator).Max(text => text.Length);
            if (temp > whitespace)
            {
                whitespace = temp;
            }
        }
        return whitespace;
    }
    /// <summary>
    /// Converts the csv file to a datatable
    /// </summary>
    /// <returns></returns>
    public DataTable ToDatatable()
    {
        var dt = new DataTable();
        //add collums for every header in the csv
        foreach (var item in Lines.First().Split(Seperator))
        {
            dt.Columns.Add(item);
        }
        //add rows for the datatable         
        foreach (var item in Lines)
        {
            //exclude first row in line
            if (item != Lines.First())
            {
                dt.Rows.Add(item.Split(Seperator));
            }
        }

        return dt;
    }
    public static string CompareCsv(string inputPath1, string inputPath2)
    {
        var List1 = ReadCsv_and_Split(inputPath1);
        var List2 = ReadCsv_and_Split(inputPath2);
        var smallerList = List1.Count() < List2.Count() ? List1 : List2;

        var result = "";
        for (int i = 0; i < smallerList.Count(); i++)
        {
            if (List1.ElementAt(i) != List2.ElementAt(i))
            {
                result += "Line " + i + " is different" + Environment.NewLine;
                result += "Csv 1: " + List1.ElementAt(i) + Environment.NewLine;
                result += "Csv 2: " + List2.ElementAt(i) + Environment.NewLine;
            }
        }
        return result;
    }

    /// <summary>
    /// Generates a CSV file with the given number of lines
    /// </summary>
    /// <param name="lines"></param>
    /// <returns>List with the values </returns>
    public static IEnumerable<string> GenerateTestCsv(int lines)
    {
        var random = new Random();
        var testLines = new List<string>();
        var line = "";
        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                line += random.Next(0, 100) + "\t";
            }
            testLines.Add(line);
            line = "";
        }
        return testLines;
    }



    #endregion
}
