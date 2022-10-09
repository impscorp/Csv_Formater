namespace UI
{
    partial class FormCompare
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Load1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Load2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Compare = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 39);
            this.textBox1.TabIndex = 5;
            // 
            // Load1
            // 
            this.Load1.Location = new System.Drawing.Point(227, 15);
            this.Load1.Name = "Load1";
            this.Load1.Size = new System.Drawing.Size(150, 46);
            this.Load1.TabIndex = 4;
            this.Load1.Text = "Load";
            this.Load1.UseVisualStyleBackColor = true;
            this.Load1.Click += new System.EventHandler(this.button1_Click_Browse);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 41;
            this.dataGridView1.Size = new System.Drawing.Size(988, 620);
            this.dataGridView1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1016, 18);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 39);
            this.textBox2.TabIndex = 8;
            // 
            // Load2
            // 
            this.Load2.Location = new System.Drawing.Point(1222, 15);
            this.Load2.Name = "Load2";
            this.Load2.Size = new System.Drawing.Size(150, 46);
            this.Load2.TabIndex = 7;
            this.Load2.Text = "Load";
            this.Load2.UseVisualStyleBackColor = true;
            this.Load2.Click += new System.EventHandler(this.Load2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(1016, 78);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 82;
            this.dataGridView2.RowTemplate.Height = 41;
            this.dataGridView2.Size = new System.Drawing.Size(988, 620);
            this.dataGridView2.TabIndex = 6;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 704);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1992, 164);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // Compare
            // 
            this.Compare.Location = new System.Drawing.Point(1854, 15);
            this.Compare.Name = "Compare";
            this.Compare.Size = new System.Drawing.Size(150, 46);
            this.Compare.TabIndex = 10;
            this.Compare.Text = "Compare";
            this.Compare.UseVisualStyleBackColor = true;
            this.Compare.Click += new System.EventHandler(this.Compare_Click);
            // 
            // FormCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2020, 880);
            this.Controls.Add(this.Compare);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Load2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Load1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormCompare";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Button Load1;
        private DataGridView dataGridView1;
        private TextBox textBox2;
        private Button Load2;
        private DataGridView dataGridView2;
        private RichTextBox richTextBox1;
        private Button Compare;
    }
}