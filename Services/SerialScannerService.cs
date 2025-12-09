using SerialScannerApp.Helpers;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace SerialScannerApp.Services
{
    public class SerialScannerService
    {
        private readonly SerialPort port = new SerialPort();
        private readonly List<byte> buffer = new List<byte>();
        private readonly object bufferLock = new object();
        private System.Timers.Timer dataTimer;

        public bool SendEnterAfterScan { get; set; } = true;
        public bool FocusWindowEnabled { get; set; } = false;
        public string TargetWindowTitle { get; set; } = string.Empty;
        public bool CustomParsingEnabled { get; set; } = false;
        public string CustomDelimiter { get; set; } = "|";
        public int CustomFieldIndex { get; set; } = 0;
        public int ReadSpeedMs { get; set; } = 80;
        public bool IsConnected => port.IsOpen;

        public event Action<string> DataReceived;
        public event Action<string> StatusChanged;

        public void Connect(string portName, int baudRate = 115200, int dataBits = 8, 
            StopBits stopBits = StopBits.One, Parity parity = Parity.None, Handshake handshake = Handshake.None)
        {
            if (port.IsOpen) return;

            port.PortName = portName;
            port.BaudRate = baudRate;
            port.Parity = parity;
            port.StopBits = stopBits;
            port.DataBits = dataBits;
            port.Handshake = handshake;
            port.DataReceived += Port_DataReceived;
            port.Open();

            StatusChanged?.Invoke($"Đã kết nối {portName} ({baudRate}, {dataBits}, {stopBits}, {parity}, {handshake})");
        }

        public void Disconnect()
        {
            if (port.IsOpen)
            {
                port.DataReceived -= Port_DataReceived;
                port.Close();
                StatusChanged?.Invoke("Đã ngắt kết nối");
            }
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int bytesToRead = port.BytesToRead;
                if (bytesToRead <= 0) return;

                byte[] temp = new byte[bytesToRead];
                port.Read(temp, 0, bytesToRead);

                lock (bufferLock)
                {
                    buffer.AddRange(temp);
                }

                if (dataTimer == null)
                {
                    dataTimer = new System.Timers.Timer(ReadSpeedMs);
                    dataTimer.Elapsed += (s, ev) => ProcessBufferedData();
                    dataTimer.AutoReset = false;
                }
                else
                {
                    // Cập nhật interval nếu đã thay đổi
                    if (dataTimer.Interval != ReadSpeedMs)
                    {
                        dataTimer.Interval = ReadSpeedMs;
                    }
                }

                dataTimer.Stop();
                dataTimer.Start();
            }
            catch (Exception ex)
            {
                StatusChanged?.Invoke($"Lỗi đọc dữ liệu: {ex.Message}");
            }
        }

        private void ProcessBufferedData()
        {
            byte[] fullData;
            lock (bufferLock)
            {
                if (buffer.Count == 0) return;
                fullData = buffer.ToArray();
                buffer.Clear();
            }

            string decoded = EncodingHelper.DecodeDataSafe(fullData)
                .Replace("\0", "")
                .Replace("\t", "")
                .TrimEnd(' ', '\t', '\r', '\n');

            if (string.IsNullOrWhiteSpace(decoded)) return;

            // Áp dụng custom parsing nếu được bật
            if (CustomParsingEnabled && !string.IsNullOrEmpty(CustomDelimiter))
            {
                try
                {
                    string[] parts = decoded.Split(new string[] { CustomDelimiter }, StringSplitOptions.None);
                    if (parts.Length > CustomFieldIndex && CustomFieldIndex >= 0)
                    {
                        decoded = parts[CustomFieldIndex].Trim();
                    }
                    else
                    {
                        // Nếu index không hợp lệ, giữ nguyên chuỗi gốc
                    }
                }
                catch
                {
                    // Nếu có lỗi, giữ nguyên chuỗi gốc
                }
            }

            ThreadPool.QueueUserWorkItem(_ =>
            {
                // Focus vào cửa sổ target nếu được bật
                if (FocusWindowEnabled && !string.IsNullOrWhiteSpace(TargetWindowTitle))
                {
                    Thread.Sleep(50); // Đợi một chút để đảm bảo
                    WindowHelper.FocusWindowByTitle(TargetWindowTitle);
                    Thread.Sleep(100); // Đợi cửa sổ được focus
                }

                ClipboardHelper.SetTextThreadSafe(decoded);
                SendKeys.SendWait("^v");

                bool hasEnter = decoded.EndsWith("\r") || decoded.EndsWith("\n");
                if (SendEnterAfterScan && !hasEnter)
                {
                    SendKeys.SendWait("{ENTER}");
                }
            });

            DataReceived?.Invoke(decoded);
        }
    }
}
