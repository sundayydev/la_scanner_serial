using Microsoft.Win32;
using System.Windows.Forms;

namespace SerialScannerApp.Helpers
{
    public static class StartupHelper
    {
        public static void SetStartup(string appName, string exePath, bool enable)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            if (enable)
                key.SetValue(appName, $"\"{exePath}\"");
            else
                key.DeleteValue(appName, false);
        }
    }
}
