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
    /// <summary>
    /// The form for merging pdf files.
    /// </summary>
    internal partial class FormMerge : Form
    {
        /// <summary>
        /// A list of <see cref="PdfFileInfo">pdf files</see>.
        /// </summary>
        internal List<PdfFileInfo> pdfList;

        /// <summary>
        /// A <see cref="MergeOption">MergeOption</see> representing the list of pdf files/pages to be merged.
        /// </summary>
        internal MergeOption? MergeOption;

        /// <summary>
        /// The constructor for <see cref="FormMerge"/>.
        /// </summary>
        /// <param name="pdfs">A list of <see cref="PdfFileInfo">pdf files</see>.</param>
        public FormMerge(List<PdfFileInfo> pdfs)
        {
            InitializeComponent();

            // update fields
            pdfList = pdfs;
            int ID = 0;
            bool trigger = false;

            // get placeholder text
            string placeholderText = "";
            foreach (PdfFileInfo pdf in pdfList)
            {
                ID++;
                pdf.ID = $"F{ID}";

                if (pdf.NumberOfPages == 1)
                {
                    placeholderText += $"{pdf.ID}(1) ";
                }
                else if (pdf.NumberOfPages == 2)
                {
                    placeholderText += $"{pdf.ID}(1,2) ";
                }
                else if (pdf.NumberOfPages > 2 && trigger == false)
                {
                    placeholderText += $"{pdf.ID}(1,2-{pdf.NumberOfPages}) ";
                    trigger = true;
                }
                else
                {
                    placeholderText += $"{pdf.ID}(1-{pdf.NumberOfPages}) ";
                }
            }

            // initialize component values
            radioButtonAll.CheckedChanged += RadioButton_CheckedChanged;
            radioButtonSelected.CheckedChanged += RadioButton_CheckedChanged;
            radioButtonAll.Checked = true;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = pdfList;

            textBoxSelectedPages.PlaceholderText = placeholderText;
            textBoxSelectedPages.Text = placeholderText;
        }

        /// <summary>
        /// Enables/Disables advanced page selection, from RadioButton user input. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            textBoxSelectedPages.Enabled = radioButtonSelected.Checked;
        }

        /// <summary>
        /// Closes the <see cref="FormMerge"/> form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MergeCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Merges the selected files/pages and closes the <see cref="FormMerge"/> form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
