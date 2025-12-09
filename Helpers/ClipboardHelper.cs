using System;
using System.Threading;
using System.Windows.Forms;

namespace SerialScannerApp.Helpers
{
    public static class ClipboardHelper
    {
        public static void SetTextThreadSafe(string text)
        {
            // Kiểm tra null hoặc empty
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            Thread thread = new Thread(() =>
            {
                try
                {
                    Clipboard.SetText(text, TextDataFormat.UnicodeText);
                }
                catch
                {
                    Thread.Sleep(50);
                    // Kiểm tra lại trước khi thử lần 2
                    if (!string.IsNullOrEmpty(text))
                    {
                        Clipboard.SetText(text, TextDataFormat.UnicodeText);
                    }
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }
    }
}
