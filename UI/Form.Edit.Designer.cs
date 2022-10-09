namespace UI
{
    partial class FormEdit
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.formatCsvBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Whitespace = new System.Windows.Forms.TextBox();
            this.seperatorBox = new System.Windows.Forms.ComboBox();
            this.Save = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.formatCsvBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // formatCsvBindingSource
            // 
            this.formatCsvBindingSource.DataSource = typeof(Csv_Formater.Lib.FormatCsv);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 156);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 41;
            this.dataGridView1.Size = new System.Drawing.Size(1224, 620);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(218, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_Browse);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 39);
            this.textBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1171, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 46);
            this.button2.TabIndex = 3;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Whitespace
            // 
            this.Whitespace.Location = new System.Drawing.Point(374, 12);
            this.Whitespace.Name = "Whitespace";
            this.Whitespace.Size = new System.Drawing.Size(200, 39);
            this.Whitespace.TabIndex = 4;
            this.Whitespace.TextChanged += new System.EventHandler(this.Whitespace_TextChanged);
            // 
            // seperatorBox
            // 
            this.seperatorBox.FormattingEnabled = true;
            this.seperatorBox.Location = new System.Drawing.Point(580, 13);
            this.seperatorBox.Name = "seperatorBox";
            this.seperatorBox.Size = new System.Drawing.Size(242, 40);
            this.seperatorBox.TabIndex = 5;
            this.seperatorBox.SelectedIndexChanged += new System.EventHandler(this.seperatorBox_SelectedIndexChanged);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(984, 12);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(150, 46);
            this.Save.TabIndex = 6;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.button1_Click_save);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(828, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 46);
            this.button3.TabIndex = 7;
            this.button3.Text = "Compare";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 776);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.seperatorBox);
            this.Controls.Add(this.Whitespace);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormEdit";
            this.Text = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.formatCsvBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BindingSource formatCsvBindingSource;
        private DataGridView dataGridView1;
        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private TextBox Whitespace;
        private ComboBox seperatorBox;
        private Button Save;
        private Button button3;
    }
}