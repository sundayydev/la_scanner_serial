using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

namespace SerialScannerApp.Helpers
{
    public static class ComPortHelper
    {
        /// <summary>
        /// Lấy thông tin mô tả của COM port từ Registry
        /// </summary>
        public static string GetPortDescription(string portName)
        {
            try
            {
                // Tìm trong tất cả các device classes
                using (RegistryKey deviceMap = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DEVICEMAP\SERIALCOMM"))
                {
                    if (deviceMap != null)
                    {
                        foreach (string valueName in deviceMap.GetValueNames())
                        {
                            string port = deviceMap.GetValue(valueName)?.ToString();
                            if (port == portName)
                            {
                                // Tìm friendly name từ device path
                                string devicePath = valueName;
                                string[] pathParts = devicePath.Split('\\');
                                
                                if (pathParts.Length > 0)
                                {
                                    // Tìm trong Enum
                                    string searchPath = @"SYSTEM\CurrentControlSet\Enum";
                                    string friendlyName = SearchFriendlyName(searchPath, portName);
                                    if (!string.IsNullOrEmpty(friendlyName))
                                    {
                                        return friendlyName;
                                    }
                                }
                            }
                        }
                    }
                }

                // Tìm trong USB devices
                string usbFriendlyName = SearchUsbDevice(portName);
                if (!string.IsNullOrEmpty(usbFriendlyName))
                {
                    return usbFriendlyName;
                }
            }
            catch { }

            return string.Empty;
        }

        private static string SearchFriendlyName(string basePath, string portName, int depth = 0)
        {
            // Giới hạn độ sâu đệ quy để tránh SecurityException
            if (depth > 3) return string.Empty;

            try
            {
                using (RegistryKey baseKey = Registry.LocalMachine.OpenSubKey(basePath))
                {
                    if (baseKey != null)
                    {
                        string[] subKeyNames = null;
                        try
                        {
                            subKeyNames = baseKey.GetSubKeyNames();
                        }
                        catch (System.Security.SecurityException)
                        {
                            return string.Empty;
                        }

                        if (subKeyNames != null)
                        {
                            foreach (string subKeyName in subKeyNames)
                            {
                                try
                                {
                                    using (RegistryKey subKey = baseKey.OpenSubKey(subKeyName, false)) // Read-only
                                    {
                                        if (subKey != null)
                                        {
                                            // Kiểm tra Device Parameters
                                            try
                                            {
                                                using (RegistryKey deviceParams = subKey.OpenSubKey("Device Parameters", false))
                                                {
                                                    if (deviceParams != null)
                                                    {
                                                        string port = deviceParams.GetValue("PortName")?.ToString();
                                                        if (port == portName)
                                                        {
                                                            string friendlyName = subKey.GetValue("FriendlyName")?.ToString();
                                                            if (string.IsNullOrEmpty(friendlyName))
                                                            {
                                                                friendlyName = subKey.GetValue("DeviceDesc")?.ToString();
                                                            }
                                                            return friendlyName ?? string.Empty;
                                                        }
                                                    }
                                                }
                                            }
                                            catch (System.Security.SecurityException) { }

                                            // Đệ quy tìm trong subkeys (chỉ nếu depth < 3)
                                            if (depth < 3)
                                            {
                                                string result = SearchFriendlyName(basePath + "\\" + subKeyName, portName, depth + 1);
                                                if (!string.IsNullOrEmpty(result))
                                                {
                                                    return result;
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (System.Security.SecurityException) { }
                                catch { }
                            }
                        }
                    }
                }
            }
            catch (System.Security.SecurityException)
            {
                return string.Empty;
            }
            catch { }

            return string.Empty;
        }

        private static string SearchUsbDevice(string portName)
        {
            try
            {
                using (RegistryKey usbKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\USB", false))
                {
                    if (usbKey != null)
                    {
                        string[] vendorIds = null;
                        try
                        {
                            vendorIds = usbKey.GetSubKeyNames();
                        }
                        catch (System.Security.SecurityException)
                        {
                            return string.Empty;
                        }

                        if (vendorIds != null)
                        {
                            foreach (string vendorId in vendorIds)
                            {
                                try
                                {
                                    using (RegistryKey vendorKey = usbKey.OpenSubKey(vendorId, false))
                                    {
                                        if (vendorKey != null)
                                        {
                                            string[] productIds = null;
                                            try
                                            {
                                                productIds = vendorKey.GetSubKeyNames();
                                            }
                                            catch (System.Security.SecurityException) { continue; }

                                            if (productIds != null)
                                            {
                                                foreach (string productId in productIds)
                                                {
                                                    try
                                                    {
                                                        using (RegistryKey productKey = vendorKey.OpenSubKey(productId, false))
                                                        {
                                                            if (productKey != null)
                                                            {
                                                                string[] instanceIds = null;
                                                                try
                                                                {
                                                                    instanceIds = productKey.GetSubKeyNames();
                                                                }
                                                                catch (System.Security.SecurityException) { continue; }

                                                                if (instanceIds != null)
                                                                {
                                                                    foreach (string instanceId in instanceIds)
                                                                    {
                                                                        try
                                                                        {
                                                                            using (RegistryKey instanceKey = productKey.OpenSubKey(instanceId, false))
                                                                            {
                                                                                if (instanceKey != null)
                                                                                {
                                                                                    try
                                                                                    {
                                                                                        using (RegistryKey deviceParams = instanceKey.OpenSubKey("Device Parameters", false))
                                                                                        {
                                                                                            if (deviceParams != null)
                                                                                            {
                                                                                                string port = deviceParams.GetValue("PortName")?.ToString();
                                                                                                if (port == portName)
                                                                                                {
                                                                                                    string friendlyName = instanceKey.GetValue("FriendlyName")?.ToString();
                                                                                                    if (string.IsNullOrEmpty(friendlyName))
                                                                                                    {
                                                                                                        friendlyName = instanceKey.GetValue("DeviceDesc")?.ToString();
                                                                                                    }
                                                                                                    return friendlyName ?? string.Empty;
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    catch (System.Security.SecurityException) { }
                                                                                }
                                                                            }
                                                                        }
                                                                        catch (System.Security.SecurityException) { }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    catch (System.Security.SecurityException) { }
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (System.Security.SecurityException) { }
                            }
                        }
                    }
                }
            }
            catch (System.Security.SecurityException)
            {
                return string.Empty;
            }
            catch { }

            return string.Empty;
        }

        /// <summary>
        /// Lấy danh sách COM port với description
        /// </summary>
        public static List<ComPortInfo> GetComPortsWithDescription()
        {
            List<ComPortInfo> ports = new List<ComPortInfo>();
            
            try
            {
                string[] portNames = SerialPort.GetPortNames().Distinct().OrderBy(p => p).ToArray();
                
                foreach (string portName in portNames)
                {
                    string description = GetPortDescription(portName);
                    bool isScanner = !string.IsNullOrEmpty(description) && 
                                    (description.IndexOf("Barcode", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                     description.IndexOf("Scanner", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                     description.IndexOf("Quét", StringComparison.OrdinalIgnoreCase) >= 0);

                    ports.Add(new ComPortInfo
                    {
                        PortName = portName,
                        Description = description,
                        IsScanner = isScanner
                    });
                }
            }
            catch { }

            return ports;
        }

        /// <summary>
        /// Tìm COM port của Barcode Scanner
        /// </summary>
        public static string FindScannerPort()
        {
            var ports = GetComPortsWithDescription();
            var scannerPort = ports.FirstOrDefault(p => p.IsScanner);
            return scannerPort?.PortName ?? string.Empty;
        }
    }

    public class ComPortInfo
    {
        public string PortName { get; set; }
        public string Description { get; set; }
        public bool IsScanner { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Description))
            {
                return $"{Description} ({PortName})";
            }
            return PortName;
        }
    }
}

