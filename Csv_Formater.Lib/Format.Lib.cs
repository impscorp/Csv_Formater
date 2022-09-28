using System.Data;

namespace Csv_Formater.Lib;

public class FormatCsv
{
    #region properties
    public IEnumerable<string> FormattedLines { get; set; }
    public string Output { get; set; }
    public string Input { get; set; }

    public IEnumerable<string> Lines { get; set; }
    public IEnumerable<string> NewLines { get; set; }
    public IEnumerable<string> FirstRow { get; }


    #endregion
    
    #region Constructor
    public FormatCsv()
    {
    }
    #endregion
    #region Functions
    public static IEnumerable<string> UserFormat(string inputPath, int whitespace = 10)
    {
        var formattedLines = ReadCsvandSplit(inputPath);
 
        return formattedLines.Select(line => line.Split('\t')
                .Select(text => text.Length < whitespace ? text.PadRight(whitespace) : text)
                .Aggregate((text1, text2) => text1 + "\t" + text2));
    }

    public static IEnumerable<string> ReadCsvandSplit(string inputPath)
    {
        //read csv file
        var lines = File.ReadAllLines(inputPath);

        //format csv file
        var splitLines =
            lines.Select(line => line.Replace(",", "\t"))
                .Select(line => line.Replace(";", "\t"))
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
        var newLines = lines.Select(line => collumName + "\t" + line);
        return newLines;
    }

   public DataTable ToDatatable()
    {
        var dt = new DataTable();
        //add collums for every header in the csv
        foreach (var item in FirstRow)
        {
            dt.Columns.Add(item);
        }
        //add rows for the datatable         
        foreach (var item in Lines)
        {
            //exclude first row in line
            if (item != Lines.First())
            {
                dt.Rows.Add(item.Split("\t"));
            }
        }

        return dt;
    }

    
    
    //public static void Collums_AmountandNames(string amount, string names);

    //public static void Records_AmountandNames(string amount, string names);
    #endregion
}   
