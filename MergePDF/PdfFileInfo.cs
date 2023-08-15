using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergePDF
{
    internal class PdfFileInfo
    {
        public static readonly string pdfFilter = "PDF Files|*.pdf";
        public string? ID { get; set; }
        public string Filename { get; }
        public string Name { get; }
        public int NumberOfPages { get; }
        
        /// <summary>
        /// list holding selecte pages to be merged
        /// </summary>
        public List<int> selectedPages = new List<int>();

        public PdfFileInfo(string fileName)
        {
            Filename = fileName;
            Name = Path.GetFileName(fileName);

            using (var pdf = new PdfReader(fileName))
            {
                NumberOfPages = pdf.NumberOfPages;
            }
        }

        public void Clear()
        {
            selectedPages.Clear();
        }

        /// <summary>
        /// Merge all pages in the file
        /// </summary>
        public void AddAllPages()
        {
            for (int i = 1; i <= this.NumberOfPages; i++)
                selectedPages.Add(i);
        }
        /// <summary>
        /// Add selected page range
        /// </summary>
        /// <param name="range"></param>
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
        /// Add a page
        /// </summary>
        /// <param name="page"></param>
        public void AddPage(string page)
        {
            if (int.TryParse(page, out int p1))
            {
                selectedPages.Add(p1);
            }
        }
    }
}
