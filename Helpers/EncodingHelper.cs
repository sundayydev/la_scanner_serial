using System;
using System.Linq;
using System.Text;

namespace SerialScannerApp.Helpers
{
    public static class EncodingHelper
    {
        public static string DecodeDataSafe(byte[] fullData)
        {
            try
            {
                // Nếu có BOM UTF-8
                if (fullData.Length >= 3 &&
                    fullData[0] == 0xEF && fullData[1] == 0xBB && fullData[2] == 0xBF)
                    return Encoding.UTF8.GetString(fullData, 3, fullData.Length - 3);

                string utf8Decoded = Encoding.UTF8.GetString(fullData);

                // Nếu không ra tiếng Việt -> fallback Windows-1258
                if (!utf8Decoded.Any(c => c >= 0x300 && c <= 0x1EF9))
                {
                    Encoding win1258 = Encoding.GetEncoding(1258);
                    return win1258.GetString(fullData);
                }

                return utf8Decoded;
            }
            catch
            {
                return Encoding.Default.GetString(fullData);
            }
        }
    }
}
