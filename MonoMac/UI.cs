using Csv_Formater.Lib;
//macos UI
using AppKit;
using Foundation;

//common UI
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Csv_Formater
{
    public partial class Form1 
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //macos
            NSApplication.Init();
            //windows
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(255, 255, 255);
            this.ForeColor = Color.FromArgb(0, 0, 0);
            this.Size = new Size(400, 100);
            this.Text = "Csv_Formater";
            this.Font = new Font("Arial", 10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.label1 = new Label();
            this.label1.Text = "Drag and Drop your csv file here";
            this.label1.Location = new Point(5, 5);
            this.label1.Size = new Size(400, 100);
            this.label1.Font = new Font("Arial", 10);
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(this.label1);
            this.AllowDrop = true;
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy
            }
        }
    }
}