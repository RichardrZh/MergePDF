using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergePDF
{
    /// <summary>
    /// A representation of a file. Contains certain file metadata.
    /// </summary>
    internal class PdfFileInfo
    {
        /// <summary>
        /// A filter that only accepts pdf files.
        /// </summary>
        public static readonly string pdfFilter = "PDF Files|*.pdf";

        /// <summary>
        /// Gets or sets the unique ID of the file. 
        /// </summary>
        public string? ID { get; set; }

        /// <summary>
        /// Gets the absolute path of the file (including filename and extension).
        /// </summary>
        public string Filename { get; }

        /// <summary>
        /// Gets the filename (including extension) of the file.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the number of pages in the file.
        /// </summary>
        public int NumberOfPages { get; }
        
        /// <summary>
        /// A list holding the selected pages to be merged.
        /// </summary>
        public List<int> selectedPages = new List<int>();

        /// <summary>
        /// The constructor for PdfFileInfo.
        /// </summary>
        /// <param name="fileName">The absolute path (including filename and extension) of the file.</param>
        /// <seealso cref="PdfFileInfo"/>
        public PdfFileInfo(string fileName)
        {
            Filename = fileName;
            Name = Path.GetFileName(fileName);

            using (var pdf = new PdfReader(fileName))
            {
                NumberOfPages = pdf.NumberOfPages;
            }
        }

        /// <summary>
        /// Clears all list members from <see cref="selectedPages">selectedPages</see>.
        /// </summary>
        public void Clear()
        {
            selectedPages.Clear();
        }

        /// <summary>
        /// Selects all pages in the file.
        /// </summary>
        /// <seealso cref="selectedPages"/>
        public void AddAllPages()
        {
            for (int i = 1; i <= this.NumberOfPages; i++)
                selectedPages.Add(i);
        }
        /// <summary>
        /// Adds the selected page range to <see cref="selectedPages">selectedPages</see>.
        /// </summary>
        /// <param name="range">A string array of length 2, containing two numbers (in string form) in ascending order specifing a range of selected pages.</param>
        public void AddPage(string[] range)
        {
            if ((range.Length == 2) &&
                int.TryParse(range[0], out int p1) &&
                int.TryParse(range[1], out int p2))
            {
                if (p1 > p2)
                {
                    LogMessage.Log($"Invalid input {p1} is greater than {p2}");
                }
                for (int i = p1; i <= p2; i++) 
                {
                    selectedPages.Add(i);
                }
            }
        }
        /// <summary>
        /// Adds a page to <see cref="selectedPages">selectedPages</see>.
        /// </summary>
        /// <param name="page">A string represeting the number of the page to be added.</param>
        public void AddPage(string page)
        {
            if (int.TryParse(page, out int p1))
            {
                selectedPages.Add(p1);
            }
        }
    }
}
