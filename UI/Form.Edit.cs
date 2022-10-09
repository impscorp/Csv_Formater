using Csv_Formater.Lib;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace UI
{
    public partial class FormEdit : Form
    {
        public FormEdit()
        {
            InitializeComponent();
            seperatorBox.DataSource = FormatCsv._seperatorList;
            seperatorBox.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        FormatCsv _cv = new FormatCsv();

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _cv.ToDatatable();

        }

        private void Form1_BuildCsv(object sender, EventArgs e)
        {
            try
            {
                _cv.Lines = FormatCsv.ReadCsv_and_Split(_cv.Input, _cv.Seperator);
            }
            catch
            {
            }

        }
        private void Form1_FormatCSV(object sender, EventArgs e)
        {
            try
            {
                FormatCsv.tempLines = DatagridviewToEnumerable(dataGridView1);
                //check if whitespace empty
                if (Whitespace.Text == "")
                {
                    //if empty calculate whitespaces
                    _cv.FormattedLines = FormatCsv.UserFormat(_cv.Input, FormatCsv.CalculateWhitespace(FormatCsv.tempLines, _cv.Seperator), _cv.Seperator);
                }
                else
                {
                    //if not empty set whitespace to the value the user entered
                    _cv.FormattedLines = FormatCsv.UserFormat(_cv.Input, Convert.ToInt16(Whitespace.Text), _cv.Seperator);
                }
            }
            catch
            {
            }

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
                _cv.Input = textBox1.Text;
                Form1_BuildCsv(sender, e);
                Form1_Load(sender, e);
            }

        }
        private void button1_Click_save(object sender, EventArgs e)
        {
            //dialog to save file
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                InitialDirectory = @"C:\Users\jonasvogel\Documents",
                Title = "Save CSV Files",

                CheckFileExists = false,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = "txt files (*.txt)|*.txt|Csv files (*.csv)|*.csv|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,

            };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                Form1_FormatCSV(sender, e);
                //ask user if he wants to save the file with the same seperator as the input file
                DialogResult dialogResult = MessageBox.Show("Do you want to save the Formated file?", "Save file", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //save file with the same seperator as the input file
                    FormatCsv.SaveCsv(saveFileDialog1.FileName, _cv.FormattedLines);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //save file with the seperator the user selected
                    FormatCsv.SaveCsv(saveFileDialog1.FileName, FormatCsv.tempLines);
                }
            }

        }
        //datagridview to enumerable with header
        public IEnumerable<string> DatagridviewToEnumerable(DataGridView dgv)
        {
            var lines = new List<string>();
            var header = "";
            foreach (DataGridViewColumn item in dgv.Columns)
            {
                header += item.HeaderText + _cv.Seperator;
            }
            lines.Add(header);
            foreach (DataGridViewRow item in dgv.Rows)
            {
                var line = "";
                foreach (DataGridViewCell cell in item.Cells)
                {
                    line += cell.Value + _cv.Seperator;
                }
                lines.Add(line);
            }
            return lines;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ask user to enter name of new header
            string newHeader = Microsoft.VisualBasic.Interaction.InputBox("Enter new header name", "New Header", "New Header", -1, -1);
            if (newHeader != "")
            {
                dataGridView1.Columns.Add("test", newHeader);
            }

        }
        
        private void seperatorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cv.Seperator = seperatorBox.Text;
        }

        private void Whitespace_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormCompare form2 = new FormCompare();
            form2.Show();
        }
    }
}
