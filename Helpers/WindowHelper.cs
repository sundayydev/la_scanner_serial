using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SerialScannerApp.Helpers
{
    public static class WindowHelper
    {
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool IsZoomed(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        private const int SW_RESTORE = 9;
        private const int SW_SHOW = 5;

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        /// <summary>
        /// Lấy danh sách tất cả các cửa sổ đang mở
        /// </summary>
        public static List<WindowInfo> GetAllWindows()
        {
            List<WindowInfo> windows = new List<WindowInfo>();
            EnumWindows((hWnd, lParam) =>
            {
                if (IsWindowVisible(hWnd))
                {
                    int length = GetWindowTextLength(hWnd);
                    if (length > 0)
                    {
                        StringBuilder sb = new StringBuilder(length + 1);
                        GetWindowText(hWnd, sb, sb.Capacity);
                        string title = sb.ToString();

                        if (!string.IsNullOrWhiteSpace(title))
                        {
                            GetWindowThreadProcessId(hWnd, out uint processId);
                            Process process = null;
                            try
                            {
                                process = Process.GetProcessById((int)processId);
                            }
                            catch { }

                            windows.Add(new WindowInfo
                            {
                                Handle = hWnd,
                                Title = title,
                                ProcessName = process?.ProcessName ?? "Unknown",
                                ProcessId = (int)processId
                            });
                        }
                    }
                }
                return true;
            }, IntPtr.Zero);

            return windows.OrderBy(w => w.Title).ToList();
        }

        /// <summary>
        /// Focus vào cửa sổ theo handle
        /// </summary>
        public static bool FocusWindow(IntPtr hWnd)
        {
            if (hWnd == IntPtr.Zero) return false;

            try
            {
                // Nếu cửa sổ đang minimize, restore nó
                if (IsIconic(hWnd))
                {
                    ShowWindow(hWnd, SW_RESTORE);
                }
                else
                {
                    ShowWindow(hWnd, SW_SHOW);
                }

                // Focus vào cửa sổ
                SetForegroundWindow(hWnd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Focus vào cửa sổ theo title (tìm cửa sổ đầu tiên có title chứa chuỗi)
        /// </summary>
        public static bool FocusWindowByTitle(string windowTitle)
        {
            if (string.IsNullOrWhiteSpace(windowTitle)) return false;

            var windows = GetAllWindows();
            var targetWindow = windows.FirstOrDefault(w => 
                w.Title.IndexOf(windowTitle, StringComparison.OrdinalIgnoreCase) >= 0);

            if (targetWindow != null)
            {
                return FocusWindow(targetWindow.Handle);
            }

            return false;
        }

        /// <summary>
        /// Lấy cửa sổ đang active
        /// </summary>
        public static WindowInfo GetActiveWindow()
        {
            IntPtr hWnd = GetForegroundWindow();
            if (hWnd == IntPtr.Zero) return null;

            int length = GetWindowTextLength(hWnd);
            if (length > 0)
            {
                StringBuilder sb = new StringBuilder(length + 1);
                GetWindowText(hWnd, sb, sb.Capacity);
                string title = sb.ToString();

                GetWindowThreadProcessId(hWnd, out uint processId);
                Process process = null;
                try
                {
                    process = Process.GetProcessById((int)processId);
                }
                catch { }

                return new WindowInfo
                {
                    Handle = hWnd,
                    Title = title,
                    ProcessName = process?.ProcessName ?? "Unknown",
                    ProcessId = (int)processId
                };
            }

            return null;
        }
    }

    public class WindowInfo
    {
        public IntPtr Handle { get; set; }
        public string Title { get; set; }
        public string ProcessName { get; set; }
        public int ProcessId { get; set; }

        public override string ToString()
        {
            return $"{Title} ({ProcessName})";
        }
    }
}

