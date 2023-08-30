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
    /// Represents a list of Pdf files (with their selected pages) to be merged.
    /// </summary>
    internal class MergeOption : List<PdfFileInfo>
    {
        /// <summary>
        /// Gets or sets an error message (for invalid data input).
        /// </summary>
        public string? ErrorMessage { get; private set; }

        /// <summary>
        /// A constructor for MergeOption. Initializes the MergeOPtion with a list of <paramref name="pdfFiles">pdf files</paramref>.
        /// </summary>
        /// <param name="pdfFiles">A list of PdfFileInfo objects.</param>
        /// <seealso cref="MergeOption"/>
        /// <seealso cref="PdfFileInfo"/>
        public MergeOption(List<PdfFileInfo> pdfFiles)
        {
            base.AddRange(pdfFiles);
        }

        /// <summary>
        /// Validates if the data input is correct for a range of files and pages.
        /// </summary>
        /// <param name="options">String representing selected files and pages. Files are represented in the following format: F&lt;<see cref="PdfFileInfo.ID"></see>&gt;(<see cref="PdfFileInfo.selectedPages">&lt;selected pages delimited by "," "-" eg. "1,3,5-7"&gt;</see>) , note: &lt; &gt; are used for clarity and are not part of the string.</param>
        /// <returns>Returns true if valid.</returns>
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

        /// <summary>
        /// Validates if the data input is correct for a single page in a file.
        /// </summary>
        /// <param name="pdf">The <see cref="PdfFileInfo">file</see> containing the page.</param>
        /// <param name="page">The page number of the page being validated.</param>
        /// <seealso cref="PdfFileInfo"/>
        /// <returns>Returns true if valid.</returns>
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

        /// <summary>
        /// Merges the pages in this <see cref="MergeOption">MergeOption</see> and saves it to the specified <paramref name="file">file</paramref>.
        /// </summary>
        /// <param name="file">The resulting pdf file containing merged pages. The string is the file path including extension.</param>
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
