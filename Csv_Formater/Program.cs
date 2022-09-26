using Csv_Formater.Lib;

//User Input for whitespace
Console.WriteLine("Enter number of whitespace chars. Has to be bigger than 10");
int ws = Convert.ToInt16(Console.ReadLine());
    while (ws == 10)
    {
        Console.WriteLine("Please enter a value greater or equal to 10");
        ws = Convert.ToInt16(Console.ReadLine());
    }

//User Input for file name
Console.WriteLine("Enter file name");
string fileName = Console.ReadLine();

//Output
FormatCsv fc = new FormatCsv($"{Environment.CurrentDirectory}/CSVFORMATER/csvsource.txt",$"{Environment.CurrentDirectory}/CSVFORMATER/{fileName}.csv", ws);

Console.WriteLine("");
// Write to file
FormatCsv.SaveCsv(fc.OutputPath ,fc.Lines);

Console.WriteLine("CSV File created");
//print FormattedLines
foreach (var item in fc.FormattedLines)
{
    Console.WriteLine(item);
}




