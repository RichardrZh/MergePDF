using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergePDF
{
    internal class LogMessage
    {
        static bool bDebug = true;

        /// <summary>
        /// Debug Log message 
        /// </summary>
        /// <param name="message"></param>
        public static void Log(string message)
        {
            if (bDebug)
                System.Diagnostics.Debug.WriteLine($"{DateTime.Now.ToString("yyyy-MM-ss HH:mm:ss.fff")} Debug: {message}");
        }
    }
}
