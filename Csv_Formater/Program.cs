using System.IO.Compression;
using Csv_Formater.Lib;

#region Constructor
FormatCsv fc = new FormatCsv();
#endregion

#region Functions
void BuildCsv(string fileName, int ws, string seperator)
{
    fc.Input = $"{Environment.CurrentDirectory}/CSVFORMATER/csvsource.txt";
    fc.Output = $"{Environment.CurrentDirectory}/CSVFORMATER/{fileName}.csv";
    fc.Lines = FormatCsv.ReadCsv_and_Split(fc.Input, seperator);
    fc.FormattedLines = FormatCsv.UserFormat(fc.Input, ws);
}
#endregion

//User Input for whitespace
Console.WriteLine("Enter number of whitespace chars. Has to be bigger than 10");
int ws = Convert.ToInt16(Console.ReadLine());
    while (ws == 10)
    {
        Console.WriteLine("Please enter a value greater or equal to 10");
        ws = Convert.ToInt16(Console.ReadLine());
    }
//User Input for seperator
Console.WriteLine("Enter seperator");
string seperator = Console.ReadLine();
    while (seperator == "")
    {
        Console.WriteLine("Please enter a seperator like ',' '\t' or ';'");
        seperator = Console.ReadLine();
    }

//User Input for file name
Console.WriteLine("Enter file name");
string fileName = Console.ReadLine();
if (fileName != null) BuildCsv(fileName, ws, seperator);

//Output
Console.WriteLine("");
// Write to file
FormatCsv.SaveCsv(fc.Output ,fc.Lines);

Console.WriteLine("CSV File created");
//print FormattedLines
foreach (var item in fc.FormattedLines)
{
    Console.WriteLine(item);
}




