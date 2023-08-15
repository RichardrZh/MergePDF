using iTextSharp.text;
using iTextSharp.text.pdf;
using MergePDF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergePDF
{
    /// <summary>
    /// Pdf files to be merged with selected pages
    /// </summary>
    internal class MergeOption : List<PdfFileInfo>
    {
        /// <summary>
        /// Error message if data input is invalid
        /// </summary>
        public string? ErrorMessage { get; private set; }

        public MergeOption(List<PdfFileInfo> pdfFiles)
        {
            base.AddRange(pdfFiles);
        }

        /// <summary>
        /// validate if the data input is correct
        /// </summary>
        /// <param name="options">select files and pages</param>
        /// <returns>true if valid</returns>
        public bool ValidateInput(string options)
        {
            string[] optionData = options.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            this.Clear();
            for (int i = 0; i < optionData.Length;)
            {
                string fileId = optionData[i].ToUpper();
                if (!fileId.StartsWith('F') || optionData.Length < i + 2)
                {
                    //invalid, no page defined for this ID
                    if (fileId.StartsWith('F'))
                        this.ErrorMessage = $"incorrect file id {fileId}";
                    else
                        this.ErrorMessage = $"incorrect pages for file id {fileId}";
                    return false;
                }
                PdfFileInfo? pdf = this.FirstOrDefault(o => o.ID == fileId);
                if (pdf == null)
                {
                    this.ErrorMessage = $"incorrect file id {fileId}";
                    return false;
                }
                pdf.Clear();
                string[] pages = optionData[i + 1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                List<int> selectedPages = new List<int>();
                foreach (string p in pages)
                {
                    if (p.IndexOf('-') != -1)
                    {
                        string[] range = p.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                        if (range.Length != 2)
                        {
                            this.ErrorMessage = $"incorrect page range ({p}) for file \"{pdf.Name}\"";
                            LogMessage.Log(this.ErrorMessage);
                            return false;
                        }
                        if (!ValidatePage(pdf, range[0]) || !ValidatePage(pdf, range[1]))
                        {
                            LogMessage.Log($"Invalid input {p}: {range[0]},{range[1]}");
                            return false;
                        }
                        pdf.AddPage(range);
                    }
                    else if (!ValidatePage(pdf, p))
                    {
                        return false;
                    }
                    else
                    {
                        pdf.AddPage(p);
                    }
                }
                this.Add(pdf);
                i += 2;
            }
            return true;
        }
        private bool ValidatePage(PdfFileInfo pdf, string page)
        {
            if (int.TryParse(page, out int num))
            {
                if (num < 1 || num > pdf.NumberOfPages)
                {
                    this.ErrorMessage = $"incorrect pages for file \"{pdf.Name}\"";
                    LogMessage.Log(this.ErrorMessage);
                    return false;
                }
            }
            else
            {
                this.ErrorMessage = $"incorrect pages for file \"{pdf.Name}\"";
                LogMessage.Log(this.ErrorMessage);
                return false;
            }
            return true;
        }

        public void Merge(string file)
        {
            LogMessage.Log($"Merging to file\"{file}\".");
            using (var fs = new FileStream(file, FileMode.Create))
            {
                using (var document = new Document())
                {
                    using (var pdfCopy = new PdfCopy(document, fs))
                    {
                        document.Open();
                        foreach (PdfFileInfo pdf in this)
                        {
                            using (var pdfReader = new PdfReader(pdf.Filename))
                            {
                                PdfReader.unethicalreading = true;
                                foreach (var page in pdf.selectedPages)
                                {
                                    pdfCopy.AddPage(pdfCopy.GetImportedPage(pdfReader, page));
                                }
                                PdfReader.unethicalreading = false;
                            }
                        }
                    }
                }
            }
            LogMessage.Log($"Merge complete");
        }
    }
}
