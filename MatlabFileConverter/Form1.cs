namespace MatlabFileConverter
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.IO;
    using System.Windows.Forms;
    using MatlabFileConverterLibrary;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ConvertButtonClick(object sender, EventArgs e)
        {
            matFileNameTextBox.Enabled = false;
            nameFilterTextBox.Enabled = false;
            selectFileButton.Enabled = false;
            convertButton.Enabled = false;
            transposeCheckBox.Enabled = false;

            string matlabFileName = matFileNameTextBox.Text;
            string valueListFileName = matlabFileName.Replace(".mat", ".val");
            string csvFileName = csvFileNameTextBox.Text;

            string nameFilter = nameFilterTextBox.Text + ";time";
            string[] nameFilters = nameFilter.Split(';');

            bool transpose = transposeCheckBox.Checked;

            ConvertFile(nameFilters, matlabFileName, valueListFileName, csvFileName, transpose);

            transposeCheckBox.Enabled = true;
            matFileNameTextBox.Enabled = true;
            nameFilterTextBox.Enabled = true;
            selectFileButton.Enabled = true;
            convertButton.Enabled = true;
        }

        private void ConvertFile(string[] nameFilters, string matlabFileName, string valueListFileName, string cvsFileName, bool transpose)
        {
            Contract.Requires(!string.IsNullOrEmpty(valueListFileName));

            List<Value> valueList = MatlabFileReader.ReadFile(matlabFileName);
            WriteValueList(valueList, valueListFileName);
            WriteCvsFile(valueList, cvsFileName, nameFilters, transpose);
        }

        private void WriteValueList(List<Value> valueList, string valueListFileName)
        {
            Contract.Requires(!string.IsNullOrEmpty(valueListFileName));

            using (StreamWriter sw = new StreamWriter(valueListFileName))
            {
                foreach (Value value in valueList)
                {
                    Contract.Assume(value != null);
                    sw.WriteLine(value.Name + ": " + value.Description);
                }
            }
        }

        private void WriteCvsFile(List<Value> valueList, string cvsFileName, string[] nameFilters, bool transpose)
        {
            List<Value> actualValueList = new List<Value>(valueList.Count);
            foreach (Value value in valueList)
            {
                foreach (string filter in nameFilters)
                {
                    if (Operators.LikeString(value.Name, filter, CompareMethod.Text))
                    {
                        actualValueList.Add(value);
                        break;
                    }
                }
            }

            WriteCvsFile(cvsFileName, actualValueList, transpose);
        }

        private static void WriteCvsFile(string cvsFileName, List<Value> actualValueList, bool transpose)
        {
            using (StreamWriter sw = new StreamWriter(cvsFileName))
            {
                if (transpose)
                {
                    for (int j = 0; j < actualValueList.Count; j++)
                    {
                        for (int i = -1; i < actualValueList[j].Data.Length; i++)
                        {
                            sw.Write(i == -1 ? actualValueList[j].Name : actualValueList[j].Data[i].ToString(CultureInfo.InvariantCulture));
                            if (i < actualValueList[j].Data.Length - 1)
                            {
                                sw.Write(",");
                            }
                            else
                            {
                                sw.WriteLine();
                            }
                        }
                    }
                }
                else
                {
                    for (int i = -1; i < actualValueList[0].Data.Length; i++)
                    {
                        for (int j = 0; j < actualValueList.Count; j++)
                        {
                            sw.Write(i == -1 ? actualValueList[j].Name : actualValueList[j].Data[i].ToString(CultureInfo.InvariantCulture));
                            if (j < actualValueList.Count - 1)
                            {
                                sw.Write(",");
                            }
                            else
                            {
                                sw.WriteLine();
                            }
                        }
                    }
                }
            }
        }

        private void SelectFileButtonClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                matFileNameTextBox.Text = openFileDialog1.FileName;
                csvFileNameTextBox.Text = openFileDialog1.FileName.Replace(".mat", ".csv");
            }
        }
    }
}
