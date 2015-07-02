namespace MatlabFileConverter
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.matFileNameTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.convertButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nameFilterTextBox = new System.Windows.Forms.TextBox();
            this.transposeCheckBox = new System.Windows.Forms.CheckBox();
            this.csvFileNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // matFileNameTextBox
            // 
            this.matFileNameTextBox.Location = new System.Drawing.Point(15, 25);
            this.matFileNameTextBox.Name = "matFileNameTextBox";
            this.matFileNameTextBox.Size = new System.Drawing.Size(574, 20);
            this.matFileNameTextBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.matFileNameTextBox, "Provide the path to the input Matlab file.");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Matlab-File|*.mat";
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(595, 23);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(24, 23);
            this.selectFileButton.TabIndex = 1;
            this.selectFileButton.Text = "...";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.SelectFileButtonClick);
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(12, 90);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(75, 23);
            this.convertButton.TabIndex = 2;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.ConvertButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "value name filter:";
            // 
            // nameFilterTextBox
            // 
            this.nameFilterTextBox.Location = new System.Drawing.Point(186, 92);
            this.nameFilterTextBox.Name = "nameFilterTextBox";
            this.nameFilterTextBox.Size = new System.Drawing.Size(403, 20);
            this.nameFilterTextBox.TabIndex = 4;
            this.nameFilterTextBox.Text = "*";
            this.toolTip1.SetToolTip(this.nameFilterTextBox, "Provide a semicolon (\';\') separated list of value names to be included in the out" +
        "put. The wildcard characters \'*\' and \'?\' can be used inside the names.");
            // 
            // transposeCheckBox
            // 
            this.transposeCheckBox.AutoSize = true;
            this.transposeCheckBox.Location = new System.Drawing.Point(96, 118);
            this.transposeCheckBox.Name = "transposeCheckBox";
            this.transposeCheckBox.Size = new System.Drawing.Size(105, 17);
            this.transposeCheckBox.TabIndex = 5;
            this.transposeCheckBox.Text = "transpose output";
            this.transposeCheckBox.UseVisualStyleBackColor = true;
            // 
            // csvFileNameTextBox
            // 
            this.csvFileNameTextBox.Location = new System.Drawing.Point(15, 64);
            this.csvFileNameTextBox.Name = "csvFileNameTextBox";
            this.csvFileNameTextBox.Size = new System.Drawing.Size(574, 20);
            this.csvFileNameTextBox.TabIndex = 6;
            this.toolTip1.SetToolTip(this.csvFileNameTextBox, "Provide the path to the output CSV file.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Path to matlab file:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Path to CSV file (output):";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 143);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.csvFileNameTextBox);
            this.Controls.Add(this.transposeCheckBox);
            this.Controls.Add(this.nameFilterTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.matFileNameTextBox);
            this.Name = "Form1";
            this.Text = "MatlabFileConverter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox matFileNameTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameFilterTextBox;
        private System.Windows.Forms.CheckBox transposeCheckBox;
        private System.Windows.Forms.TextBox csvFileNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

