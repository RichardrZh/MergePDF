using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MergePDF
{
    public partial class FormMerge : Form
    {
        internal List<PdfFileInfo> pdfList;
        internal MergeOption? MergeOption;

        internal FormMerge(List<PdfFileInfo> pdfs)
        {
            InitializeComponent();

            pdfList = pdfs;
            int ID = 0;
            bool trigger = false;

            string placeholderText = "";
            foreach (PdfFileInfo pdf in pdfList)
            {
                ID++;
                pdf.ID = $"F{ID}";

                if (pdf.NumPages == 1)
                {
                    placeholderText += $"{pdf.ID}(1) ";
                }
                else if (pdf.NumPages == 2)
                {
                    placeholderText += $"{pdf.ID}(1,2) ";
                }
                else if (pdf.NumPages > 2 && trigger == false)
                {
                    placeholderText += $"{pdf.ID}(1,2-{pdf.NumPages}) ";
                    trigger = true;
                }
                else
                {
                    placeholderText += $"{pdf.ID}(1-{pdf.NumPages}) ";
                }
            }

            radioButtonAll.CheckedChanged += RadioButton_CheckedChanged;
            radioButtonSelected.CheckedChanged += RadioButton_CheckedChanged;
            radioButtonAll.Checked = true;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = pdfList;

            textBoxSelectedPages.PlaceholderText = placeholderText;
        }

        private void RadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            textBoxSelectedPages.Enabled = radioButtonSelected.Checked;
        }

        private void MergeCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void MergeNow_Click(object sender, EventArgs e)
        {
            MergeOption option = new MergeOption(pdfList);
            if (radioButtonSelected.Checked)
            {
                if (!option.ValidateInput(textBoxSelectedPages.Text))
                {
                    MessageBox.Show($"Invalid data input - {option.ErrorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                foreach (PdfFileInfo file in option)
                {
                    file.AddAllPages();
                }
            }
            MergeOption = option;
            DialogResult = DialogResult.OK;
        }
    }
}
