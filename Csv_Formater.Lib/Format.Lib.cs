using System.Data;

namespace Csv_Formater.Lib;

public class FormatCsv
{
    #region properties
    public IEnumerable<string> FormattedLines { get; set; }
    public string Output { get; set; }
    public string Input { get; set; }
    private static string _Seperator { get; set; }
    public IEnumerable<string> _Lines { get; set; }
    public static IEnumerable<string> _tempLines { get; set; }

    #endregion
    
    #region Constructor
    public FormatCsv()
    {
    }
    #endregion
    #region Functions
    public static IEnumerable<string> UserFormat(string inputPath, int whitespace = 10)
    { 
        var formattedLines = ReadCsv_and_Split(inputPath, _Seperator );
 
        return formattedLines.Select(line => line.Split(_Seperator)
                .Select(text => text.Length < whitespace ? text.PadRight(whitespace) : text)
                .Aggregate((text1, text2) => text1 + " " + text2));
    }

    public static IEnumerable<string> ReadCsv_and_Split(string inputPath, string seperator = "\t")
    {
        _Seperator = seperator;
        //read csv file
        _tempLines = File.ReadAllLines(inputPath);

        //format csv file
        var splitLines =
            _tempLines.Select(line => line.Replace(",", _Seperator))
                .Select(line => line.Replace(";", _Seperator))
                .Select(line => line.Replace("\r", ""))
                .Select(line => line.Replace("\n", ""));
        return splitLines;
    }

    public static void SaveCsv(string outputpath, IEnumerable<string> lines)
    {
        File.WriteAllLines(outputpath, lines);
    }
    
    public static IEnumerable<string> AddCollum(IEnumerable<string> lines, string collumName)
    {
        var newLines = lines.Select(line => collumName + _Seperator + line);
        return newLines;
    }

   public DataTable ToDatatable()
    {
        var dt = new DataTable();
        //add collums for every header in the csv
        foreach (var item in _Lines.First().Split(_Seperator))
        {
            dt.Columns.Add(item);
        }
        //add rows for the datatable         
        foreach (var item in _Lines)
        {
            //exclude first row in line
            if (item != _Lines.First())
            {
                dt.Rows.Add(item.Split(_Seperator));
            }
        }

        return dt;
    }
   
    public static IEnumerable<string> CompareCsv(string inputPath1, string inputPath2)
    {
        var lines1 = ReadCsv_and_Split(inputPath1);
        var lines2 = ReadCsv_and_Split(inputPath2);

        var diff = lines1.Except(lines2);
        return diff;
    }

    public static IEnumerable<int> GetIndexLinesInQuotes()
    {
        var indexLinesInQuotes = _tempLines.Select((line, index) => new { line, index })
            .Where(x => x.line.Contains("\""))
            .Select(x => x.index);
        return indexLinesInQuotes;
    }
    
    #endregion
}   
