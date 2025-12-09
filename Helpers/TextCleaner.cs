using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SerialScannerApp.Helpers
{
    public static class TextCleaner
    {
        public static string Clean(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;

            return text
                .Replace("\0", "")
                .Replace("\t", "")
                .TrimEnd(' ', '\t', '\r', '\n');
        }
    }
}
