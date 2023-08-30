using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergePDF
{
    internal class LogMessage
    {
        /// <summary>
        /// A boolean representing a debug mode. When true, debug utilities such as error logging are enabled.
        /// </summary>
        static bool bDebug = true;

        /// <summary>
        /// Logs a debug message.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        public static void Log(string message)
        {
            if (bDebug)
                System.Diagnostics.Debug.WriteLine($"{DateTime.Now.ToString("yyyy-MM-ss HH:mm:ss.fff")} Debug: {message}");
        }
    }
}
