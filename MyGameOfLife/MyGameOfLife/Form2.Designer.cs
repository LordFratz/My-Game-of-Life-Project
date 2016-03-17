namespace MyGameOfLife
{
    partial class Form2
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.MillisecondsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RowsUpDown = new System.Windows.Forms.NumericUpDown();
            this.ColumnsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BackgroundButton = new System.Windows.Forms.Button();
            this.GridButton = new System.Windows.Forms.Button();
            this.CellsButton = new System.Windows.Forms.Button();
            this.TorodialRadioButton = new System.Windows.Forms.RadioButton();
            this.FiniteRadioButton = new System.Windows.Forms.RadioButton();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SkipUpDown = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MillisecondsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsUpDown)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SkipUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Location = new System.Drawing.Point(13, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(464, 199);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.MillisecondsUpDown);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(456, 170);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Milliseconds";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ColumnsUpDown);
            this.tabPage2.Controls.Add(this.RowsUpDown);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(456, 170);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Size";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.CellsButton);
            this.tabPage3.Controls.Add(this.GridButton);
            this.tabPage3.Controls.Add(this.BackgroundButton);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(456, 170);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Color";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.FiniteRadioButton);
            this.tabPage4.Controls.Add(this.TorodialRadioButton);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(456, 170);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Boundry";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // MillisecondsUpDown
            // 
            this.MillisecondsUpDown.Location = new System.Drawing.Point(175, 74);
            this.MillisecondsUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.MillisecondsUpDown.Name = "MillisecondsUpDown";
            this.MillisecondsUpDown.Size = new System.Drawing.Size(176, 22);
            this.MillisecondsUpDown.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Milliseconds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Rows";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Columns";
            // 
            // RowsUpDown
            // 
            this.RowsUpDown.Location = new System.Drawing.Point(189, 52);
            this.RowsUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RowsUpDown.Name = "RowsUpDown";
            this.RowsUpDown.Size = new System.Drawing.Size(166, 22);
            this.RowsUpDown.TabIndex = 2;
            // 
            // ColumnsUpDown
            // 
            this.ColumnsUpDown.Location = new System.Drawing.Point(189, 96);
            this.ColumnsUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ColumnsUpDown.Name = "ColumnsUpDown";
            this.ColumnsUpDown.Size = new System.Drawing.Size(166, 22);
            this.ColumnsUpDown.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Background";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Grid";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Cells";
            // 
            // BackgroundButton
            // 
            this.BackgroundButton.BackColor = System.Drawing.Color.Black;
            this.BackgroundButton.Location = new System.Drawing.Point(180, 30);
            this.BackgroundButton.Name = "BackgroundButton";
            this.BackgroundButton.Size = new System.Drawing.Size(238, 23);
            this.BackgroundButton.TabIndex = 3;
            this.BackgroundButton.UseVisualStyleBackColor = false;
            this.BackgroundButton.Click += new System.EventHandler(this.BackgroundButton_Click);
            // 
            // GridButton
            // 
            this.GridButton.BackColor = System.Drawing.Color.Black;
            this.GridButton.Location = new System.Drawing.Point(180, 74);
            this.GridButton.Name = "GridButton";
            this.GridButton.Size = new System.Drawing.Size(238, 23);
            this.GridButton.TabIndex = 4;
            this.GridButton.UseVisualStyleBackColor = false;
            this.GridButton.Click += new System.EventHandler(this.GridButton_Click);
            // 
            // CellsButton
            // 
            this.CellsButton.BackColor = System.Drawing.Color.Black;
            this.CellsButton.Location = new System.Drawing.Point(180, 117);
            this.CellsButton.Name = "CellsButton";
            this.CellsButton.Size = new System.Drawing.Size(238, 23);
            this.CellsButton.TabIndex = 5;
            this.CellsButton.UseVisualStyleBackColor = false;
            this.CellsButton.Click += new System.EventHandler(this.CellsButton_Click);
            // 
            // TorodialRadioButton
            // 
            this.TorodialRadioButton.AutoSize = true;
            this.TorodialRadioButton.Location = new System.Drawing.Point(43, 38);
            this.TorodialRadioButton.Name = "TorodialRadioButton";
            this.TorodialRadioButton.Size = new System.Drawing.Size(81, 21);
            this.TorodialRadioButton.TabIndex = 2;
            this.TorodialRadioButton.TabStop = true;
            this.TorodialRadioButton.Text = "Torodial";
            this.TorodialRadioButton.UseVisualStyleBackColor = true;
            // 
            // FiniteRadioButton
            // 
            this.FiniteRadioButton.AutoSize = true;
            this.FiniteRadioButton.Location = new System.Drawing.Point(43, 101);
            this.FiniteRadioButton.Name = "FiniteRadioButton";
            this.FiniteRadioButton.Size = new System.Drawing.Size(63, 21);
            this.FiniteRadioButton.TabIndex = 3;
            this.FiniteRadioButton.TabStop = true;
            this.FiniteRadioButton.Text = "Finite";
            this.FiniteRadioButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(316, 218);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 26);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(398, 218);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 26);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.comboBox1);
            this.tabPage5.Controls.Add(this.SkipUpDown);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(456, 170);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Highlight";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Skip Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Lines Highlighted";
            // 
            // SkipUpDown
            // 
            this.SkipUpDown.Location = new System.Drawing.Point(207, 38);
            this.SkipUpDown.Name = "SkipUpDown";
            this.SkipUpDown.Size = new System.Drawing.Size(177, 22);
            this.SkipUpDown.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "On",
            "Off"});
            this.comboBox1.Location = new System.Drawing.Point(207, 103);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 3;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 254);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.tabControl);
            this.Name = "Form2";
            this.Text = "Form2";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MillisecondsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsUpDown)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SkipUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown MillisecondsUpDown;
        private System.Windows.Forms.NumericUpDown ColumnsUpDown;
        private System.Windows.Forms.NumericUpDown RowsUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CellsButton;
        private System.Windows.Forms.Button GridButton;
        private System.Windows.Forms.Button BackgroundButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton FiniteRadioButton;
        private System.Windows.Forms.RadioButton TorodialRadioButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown SkipUpDown;
    }
}