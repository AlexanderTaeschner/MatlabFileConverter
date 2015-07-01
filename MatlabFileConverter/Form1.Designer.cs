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
            this.matFileNameTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.convertButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nameFilterTextBox = new System.Windows.Forms.TextBox();
            this.transposeCheckBox = new System.Windows.Forms.CheckBox();
            this.csvFileNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // matFileNameTextBox
            // 
            this.matFileNameTextBox.Location = new System.Drawing.Point(12, 12);
            this.matFileNameTextBox.Name = "matFileNameTextBox";
            this.matFileNameTextBox.Size = new System.Drawing.Size(583, 20);
            this.matFileNameTextBox.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Matlab-File|*.mat";
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(601, 10);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(24, 23);
            this.selectFileButton.TabIndex = 1;
            this.selectFileButton.Text = "...";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.SelectFileButtonClick);
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(12, 64);
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
            this.label1.Location = new System.Drawing.Point(93, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "value name filter:";
            // 
            // nameFilterTextBox
            // 
            this.nameFilterTextBox.Location = new System.Drawing.Point(186, 66);
            this.nameFilterTextBox.Name = "nameFilterTextBox";
            this.nameFilterTextBox.Size = new System.Drawing.Size(409, 20);
            this.nameFilterTextBox.TabIndex = 4;
            this.nameFilterTextBox.Text = "*";
            // 
            // transposeCheckBox
            // 
            this.transposeCheckBox.AutoSize = true;
            this.transposeCheckBox.Location = new System.Drawing.Point(96, 92);
            this.transposeCheckBox.Name = "transposeCheckBox";
            this.transposeCheckBox.Size = new System.Drawing.Size(105, 17);
            this.transposeCheckBox.TabIndex = 5;
            this.transposeCheckBox.Text = "transpose output";
            this.transposeCheckBox.UseVisualStyleBackColor = true;
            // 
            // csvFileNameTextBox
            // 
            this.csvFileNameTextBox.Location = new System.Drawing.Point(12, 38);
            this.csvFileNameTextBox.Name = "csvFileNameTextBox";
            this.csvFileNameTextBox.Size = new System.Drawing.Size(583, 20);
            this.csvFileNameTextBox.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 114);
            this.Controls.Add(this.csvFileNameTextBox);
            this.Controls.Add(this.transposeCheckBox);
            this.Controls.Add(this.nameFilterTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.matFileNameTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

