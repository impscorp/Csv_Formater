namespace Csv_Formater.Lib;

public class FormatCsv
{
    #region properties
    public IEnumerable<string> FormattedLines { get; }
    
    public IEnumerable<string> Lines { get; }
    public string OutputPath { get; }

    #endregion
    
    #region Constructor
    public FormatCsv(string inPath, string outPath, int ws)
    {
        Lines = BuildCSV(inPath);
        FormattedLines = UserFormat(inPath, ws);
        OutputPath = outPath;
    }
    #endregion
    #region Functions
    public static IEnumerable<string> UserFormat(string inputPath, int whitespace = 10)
    {
        var formattedLines = BuildCSV(inputPath);
 
        return formattedLines.Select(line => line.Split('\t')
                .Select(text => text.Length < whitespace ? text.PadRight(whitespace) : text)
                .Aggregate((text1, text2) => text1 + "\t" + text2));
    }

    private static IEnumerable<string> BuildCSV(string inputPath)
    {
        //read csv file
        var lines = File.ReadAllLines(inputPath);

        //format csv file
        var formattedLines =
            lines.Select(line => line.Replace(",", "\t"))
                .Select(line => line.Replace(";", "\t"))
                .Select(line => line.Replace("\r", ""))
                .Select(line => line.Replace("\n", ""));
        return formattedLines;
    }

    public static void SaveCsv(string outputpath, IEnumerable<string> Lines)
    {
        //write csv file
        File.WriteAllLines(outputpath, Lines);
    }
    
    //public static void Collums_AmountandNames(string amount, string names);

    //public static void Records_AmountandNames(string amount, string names);
    #endregion
}   
