using System;
using System.Collections;
using System.Data;
using System.Linq;
using Avalonia.Media;
using Csv_Formater.Lib;
namespace Avalonia.TestUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region properties
        public string[] Rows { get; set; }
        public string[] FirstRow { get; set; }
        public DataTable RowsDataTable { get; set; }
        
        #endregion
        
        #region constructor
        public MainWindowViewModel()
        {
            FormatCsv csv = new FormatCsv();
            csv.Lines = FormatCsv.ReadCsvandSplit($"{Environment.CurrentDirectory}/CSVFORMATER/csvsource.txt");
            FirstRow = FormatCsv.ReadCsvandSplit($"{Environment.CurrentDirectory}/CSVFORMATER/csvsource.txt").First().Split('\t');
            RowsDataTable = csv.ToDatatable();
            Rows = StringToArray(csv.Lines);
        }
        #endregion
        
        #region Functions

        public DataView DataView
        {
            get => RowsDataTable.DefaultView;
        }
        
        public string[] StringToArray(IEnumerable lines)
        {

            string[] rows = new string[] { };

            foreach (string line in lines)
            {
                rows = rows.Concat(line.Split('\t')).ToArray();
            }
            return rows;
        }
        #endregion
        
    }
}