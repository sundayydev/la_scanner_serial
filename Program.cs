using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialScannerApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew;
            using (Mutex mutex = new Mutex(true, "SerialScannerApp_SingleInstance", out createdNew))
            {
                if (!createdNew)
                {
                    MessageBox.Show("Ứng dụng đã được mở. Vui lòng kiểm tra khay hệ thống (tray icon).",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; // Thoát không mở form thứ 2
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
