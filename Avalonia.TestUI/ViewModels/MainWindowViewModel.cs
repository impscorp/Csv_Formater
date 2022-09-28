using System;
using System.Collections;
using System.Data;
using System.Linq;
using Csv_Formater.Lib;
namespace Avalonia.TestUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region properties
        public IEnumerable Rows { get; set; }
        public string[] FirstRow { get; set; }
        public DataTable RowsDataTable { get; set; }
        
        #endregion
        
        #region constructor
        public MainWindowViewModel()
        {
            FormatCsv csv = new FormatCsv();

            Rows = csv.Lines;
            FirstRow = csv.Lines.First().Split('\t');
            RowsDataTable = csv.ToDatatable();
        }
        #endregion
        
        #region Functions
        public DataView DataView
        {
            get => RowsDataTable.DefaultView;
        }
        #endregion
        
    }
}