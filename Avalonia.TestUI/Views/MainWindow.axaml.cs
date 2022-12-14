using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.TestUI.ViewModels;
using ReactiveUI;

namespace Avalonia.TestUI.Views
{
    public partial class MainWindow : Window
    {
        #region constuctor
        public MainWindow()
        {
            Activated += MainWindow_Activated;
            
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();  
#endif

        }
        #endregion
        
        #region event handlers
        private void MainWindow_Activated(object sender, System.EventArgs e)
        {
            var grid = this.FindControl<DataGrid>("DataGrid");
            var vm = (MainWindowViewModel)DataContext;

            var cols = vm.DataView.Table.Columns;
            grid.Columns.Clear();
            for (var i = 0; i < cols.Count; i++)
            {
                grid.Columns.Add(new DataGridTextColumn
                {
                    Header = cols[i].ColumnName, 
                    Binding = new Binding($"vm.Rows[{i}]")
                });
            }
        }
        private void Button_Click(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        private void Open_Click(object? sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Save_Click(object? sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}