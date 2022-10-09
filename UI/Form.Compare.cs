using Csv_Formater.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormCompare : Form
    {
        public FormCompare()
        {
            InitializeComponent();
            
        }
       
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
        
        FormatCsv _cv = new FormatCsv();

        private void Form1_Load(object sender, EventArgs e,int table)
        {

            if (table == 1)
            {
                dataGridView1.DataSource = _cv.ToDatatable();
            }
            else
            {
                dataGridView2.DataSource = _cv.ToDatatable();
            }
        }

        private void Form1_BuildCsv(object sender, EventArgs e)
        {
            try
            {
                _cv.Seperator = FormatCsv._seperatorList[0];
                _cv.Lines = FormatCsv.ReadCsv_and_Split(_cv.Input, _cv.Seperator);
            }
            catch
            {
            }

        }
        private void button1_Click_Browse(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                _cv.Input = textBox1.Text;
                Form1_BuildCsv(sender, e);
                Form1_Load(sender, e, 1);
            }

        }

        private void Compare_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = FormatCsv.CompareCsv(textBox1.Text, textBox2.Text);
        }

        private void Load2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
                _cv.Input = textBox2.Text;
                Form1_BuildCsv(sender, e);
                Form1_Load(sender, e, 2);
            }
        }
    }
}
