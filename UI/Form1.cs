using Csv_Formater.Lib;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            FormatCsv _cv = new FormatCsv(textBox1.Text, $"{Environment.CurrentDirectory}/CSVFORMATER/test.csv", 10);

            var dt = new DataTable();
            //add collums for every header in the csv
            foreach (var item in _cv.FirstRow)
            {
                dt.Columns.Add(item);
            }
            //add rows for the datatable         
            foreach (var item in _cv.Lines)
            {
                //exclude first row in line
                if (item != _cv.Lines.First())
                {
                    dt.Rows.Add(item.Split("\t"));
                }

            }
            dataGridView1.DataSource = dt;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                MessageBox.Show(file);
            }
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void button1_Click_Browse(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse CSV Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = "txt files (*.txt)|*.txt|Csv files (*.csv)|*.csv|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                Form1_Load(sender, e);
            }

        }
        private void button1_Click_save(object sender, EventArgs e)
        {
            //save csv
            FormatCsv _cv = new FormatCsv(textBox1.Text, $"{Environment.CurrentDirectory}/CSVFORMATER/test.csv", 10);

            FormatCsv.SaveCsv(_cv.OutputPath, _cv.FormattedLines);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
