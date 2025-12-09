using Microsoft.Win32;
using SerialScannerApp.Helpers;
using SerialScannerApp.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialScannerApp
{
    public partial class Form1 : Form
    {
        private readonly SerialScannerService scanner = new SerialScannerService();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;

            ckbStartUpWindow.Checked = Properties.Settings.Default.StartUpWindow;
            ckbEnter.Checked = Properties.Settings.Default.SendEnterAfterScan;
            scanner.SendEnterAfterScan = ckbEnter.Checked;

            // Load focus window settings
            ckbFocusWindow.Checked = Properties.Settings.Default.FocusWindowEnabled;
            scanner.FocusWindowEnabled = ckbFocusWindow.Checked;
            scanner.TargetWindowTitle = Properties.Settings.Default.TargetWindowTitle;
            UpdateSelectedWindowLabel();

            scanner.StatusChanged += msg => Invoke(new Action(() => lblStatus.Text = msg));
            scanner.DataReceived += data => Console.WriteLine($"[SCANNED]: {data}");

            InitializeComPortSettings();
            LoadPorts();
            LoadAutoConnectSettings();
            
            // Enable/disable select window button based on checkbox
            btnSelectWindow.Enabled = ckbFocusWindow.Checked;

            string[] args = Environment.GetCommandLineArgs();
            if (args.Contains("-minimized"))
            {
                // Chế độ chạy ngầm
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false; // Không hiện trên thanh taskbar
                notifyIcon1.Visible = true; // Hiện icon ở tray

                // Dùng BeginInvoke để đảm bảo lệnh Hide được chạy sau khi Form đã load xong giao diện
                this.BeginInvoke(new Action(() =>
                {
                    this.Hide();
                }));
            }   
        }

        // ==============================================
        // 1️⃣ NẠP DANH SÁCH COM
        // ==============================================
        private void LoadPorts()
        {
            cbPorts.Items.Clear();
            string[] ports = SerialPort.GetPortNames()
                                       .Distinct()
                                       .OrderBy(p => p)
                                       .ToArray();

            if (ports.Length > 0)
            {
                cbPorts.Items.AddRange(ports);
                cbPorts.SelectedIndex = 0;
                lblStatus.Text = "Chọn cổng COM và nhấn Kết nối.";
            }
            else
            {
                lblStatus.Text = "Không tìm thấy cổng COM.";
            }
        }

        private void ReloadPorts()
        {
            try
            {
                string currentSelection = cbPorts.SelectedItem?.ToString();
                cbPorts.Items.Clear();

                string[] ports = SerialPort.GetPortNames()
                                           .Distinct()
                                           .OrderBy(p => p)
                                           .ToArray();

                if (ports.Length > 0)
                {
                    cbPorts.Items.AddRange(ports);
                    if (!string.IsNullOrEmpty(currentSelection) && ports.Contains(currentSelection))
                        cbPorts.SelectedItem = currentSelection;
                    else
                        cbPorts.SelectedIndex = 0;

                    lblStatus.Text = "Danh sách cổng đã được cập nhật.";
                }
                else
                {
                    lblStatus.Text = "Không tìm thấy cổng COM nào.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi khi tải lại cổng: " + ex.Message;
            }
        }

        private void btnReloadPort_Click(object sender, EventArgs e)
        {
            ReloadPorts();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipTitle = "Ứng dụng đang chạy nền";
            notifyIcon1.BalloonTipText = "Nhấn đúp để mở lại cửa sổ.";
            notifyIcon1.ShowBalloonTip(800);
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (scanner != null && scanner.IsConnected)
                {
                    scanner.Disconnect();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi ngắt kết nối cổng COM: " + ex.Message);
            }

            this.Close();
        }

        private void ckbStartUpWindow_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StartUpWindow = ckbStartUpWindow.Checked;
            Properties.Settings.Default.Save();
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

                if (ckbStartUpWindow.Checked)
                {
                    string runCommand = $"\"{Application.ExecutablePath}\" -minimized";

                    // Set giá trị vào Registry
                    key.SetValue(Application.ProductName, runCommand);
                }
                else
                {
                    key.DeleteValue(Application.ProductName, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi Registry: " + ex.Message);
            }
        }

        private void ckbEnter_CheckedChanged(object sender, EventArgs e)
        {
            scanner.SendEnterAfterScan = ckbEnter.Checked;
            Properties.Settings.Default.SendEnterAfterScan = ckbEnter.Checked;
            Properties.Settings.Default.Save();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbPorts.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn cổng COM.");
                    return;
                }

                // Lấy các thông số cấu hình từ UI
                int baudRate = (int)cbBaudRate.SelectedItem;
                int dataBits = (int)cbDataBits.SelectedItem;
                StopBits stopBits = (StopBits)cbStopBits.SelectedItem;
                Parity parity = (Parity)cbParity.SelectedItem;
                Handshake handshake = (Handshake)cbHandshake.SelectedItem;

                scanner.Connect(cbPorts.SelectedItem.ToString(), baudRate, dataBits, stopBits, parity, handshake);
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                cbPorts.Enabled = false;
                SetConnectionState(true);
            }
            catch (Exception ex)
            {
                SetConnectionState(false);
                MessageBox.Show($"Lỗi kết nối : {ex.Message}");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            scanner.Disconnect();
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            cbPorts.Enabled = true;
            SetConnectionState(false);
        }

        // ==============================================
        // 5️⃣ TỰ ĐỘNG TÌM VÀ KẾT NỐI SCANNER
        // ==============================================
        private async void btnAutoFindScanner_Click(object sender, EventArgs e)
        {
            try
            {
                btnAutoFindScanner.Enabled = false;
                btnAutoFindScanner.Text = "Đang tìm...";
                lblStatus.Text = "Đang tìm Barcode Scanner...";

                // Đợi một chút để UI update
                await Task.Delay(100);

                // Tìm COM port của Scanner
                string scannerPort = Helpers.ComPortHelper.FindScannerPort();

                if (string.IsNullOrEmpty(scannerPort))
                {
                    lblStatus.Text = "Không tìm thấy Barcode Scanner.";
                    MessageBox.Show("Không tìm thấy Barcode Scanner.\n\nVui lòng kiểm tra:\n- Scanner đã được kết nối\n- Driver đã được cài đặt\n- Thiết bị hiển thị trong Device Manager", 
                        "Không tìm thấy Scanner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Cập nhật ComboBox
                    ReloadPorts();
                    
                    // Chọn port tìm được
                    if (cbPorts.Items.Contains(scannerPort))
                    {
                        cbPorts.SelectedItem = scannerPort;
                        lblStatus.Text = $"Đã tìm thấy: {scannerPort}";

                        // Tự động kết nối
                        await Task.Delay(200);
                        
                        // Lấy các thông số cấu hình từ UI
                        int baudRate = (int)cbBaudRate.SelectedItem;
                        int dataBits = (int)cbDataBits.SelectedItem;
                        StopBits stopBits = (StopBits)cbStopBits.SelectedItem;
                        Parity parity = (Parity)cbParity.SelectedItem;
                        Handshake handshake = (Handshake)cbHandshake.SelectedItem;

                        scanner.Connect(scannerPort, baudRate, dataBits, stopBits, parity, handshake);
                        btnConnect.Enabled = false;
                        btnDisconnect.Enabled = true;
                        cbPorts.Enabled = false;
                        SetConnectionState(true);
                        lblStatus.Text = $"Đã tự động kết nối: {scannerPort}";
                    }
                    else
                    {
                        lblStatus.Text = $"Tìm thấy {scannerPort} nhưng không có trong danh sách.";
                        MessageBox.Show($"Tìm thấy Scanner tại {scannerPort} nhưng cổng này không có trong danh sách.\n\nVui lòng nhấn 'Tải lại COM' và thử lại.", 
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi khi tìm Scanner.";
                MessageBox.Show($"Lỗi khi tìm Scanner: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAutoFindScanner.Enabled = true;
                btnAutoFindScanner.Text = "Tự động tìm Scanner";
            }
        }

        private void ckbAutoConnectCOM_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoConnectCOM = ckbAutoConnectCOM.Checked;
            Properties.Settings.Default.Save();

            // Nếu bật, lưu lại cổng hiện tại (nếu có chọn)
            if (ckbAutoConnectCOM.Checked && cbPorts.SelectedItem != null)
            {
                Properties.Settings.Default.LastCOMPort = cbPorts.SelectedItem.ToString();
                Properties.Settings.Default.Save();
            }
        }

        // Thêm từ khóa 'async' vào khai báo hàm
        // Sửa lại logic tự động kết nối
        private async void LoadAutoConnectSettings()
        {
            try
            {
                // 1. Load cấu hình
                ckbAutoConnectCOM.Checked = Properties.Settings.Default.AutoConnectCOM;
                string lastPort = Properties.Settings.Default.LastCOMPort;

                // Nếu không bật tự động hoặc chưa từng lưu cổng nào -> Dừng
                if (!ckbAutoConnectCOM.Checked || string.IsNullOrEmpty(lastPort))
                {
                    return;
                }

                // Khóa nút kết nối thủ công trong lúc đang tự động tìm
                btnConnect.Enabled = false;

                int maxRetries = 5;   // Thử 5 lần
                int delayMs = 1000;   // Mỗi lần cách nhau 1 giây (nhanh hơn, đỡ chờ lâu)
                bool isConnected = false;

                for (int i = 1; i <= maxRetries; i++)
                {
                    lblStatus.Text = $"Đang tìm cổng {lastPort}... (Lần thử {i}/{maxRetries})";

                    // Lấy danh sách cổng thực tế từ Windows ngay lúc này
                    string[] availablePorts = SerialPort.GetPortNames();

                    if (availablePorts.Contains(lastPort))
                    {
                        // --- TÌM THẤY ---

                        // Quan trọng: Cập nhật lại ComboBox UI cho khớp với thực tế
                        // Vì lúc Form_Load chạy có thể chưa nhận diện được cổng này
                        cbPorts.Items.Clear();
                        cbPorts.Items.AddRange(availablePorts);
                        cbPorts.SelectedItem = lastPort;

                        // Lấy các thông số cấu hình từ Settings
                        int baudRate = Properties.Settings.Default.BaudRate;
                        int dataBits = Properties.Settings.Default.DataBits;
                        StopBits stopBits = (StopBits)Enum.Parse(typeof(StopBits), Properties.Settings.Default.StopBits);
                        Parity parity = (Parity)Enum.Parse(typeof(Parity), Properties.Settings.Default.Parity);
                        Handshake handshake = (Handshake)Enum.Parse(typeof(Handshake), Properties.Settings.Default.Handshake);

                        // Thực hiện kết nối với cấu hình đã lưu
                        scanner.Connect(lastPort, baudRate, dataBits, stopBits, parity, handshake);

                        // Cập nhật trạng thái UI thành công
                        btnConnect.Enabled = false;
                        btnDisconnect.Enabled = true;
                        cbPorts.Enabled = false;
                        lblStatus.Text = $"Đã tự động kết nối: {lastPort}";

                        isConnected = true;
                        break; // Thoát vòng lặp
                    }

                    // Nếu chưa tìm thấy, đợi một chút rồi thử lại
                    if (i < maxRetries)
                    {
                        await Task.Delay(delayMs);
                    }
                }

                // --- KẾT THÚC VÒNG LẶP MÀ VẪN KHÔNG THẤY ---
                if (!isConnected)
                {
                    lblStatus.Text = $"Không tìm thấy cổng {lastPort}. Vui lòng kết nối thủ công.";

                    // Mở lại nút để người dùng bấm tay
                    btnConnect.Enabled = true;
                    cbPorts.Enabled = true;

                    // Tùy chọn: Có thể hiện MessageBox hoặc không. 
                    // Thường khởi động app thì không nên hiện Popup làm phiền, chỉ hiện text ở Status là đủ.
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi tự động kết nối.";
                MessageBox.Show($"Lỗi auto-connect: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Reset lại trạng thái an toàn
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                cbPorts.Enabled = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Nếu icon bị null (chưa khởi tạo)
                if (notifyIcon1 == null)
                    return;

                // Hiển thị lại cửa sổ chính
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.BringToFront();
                this.Activate();

                // Ẩn icon ở khay hệ thống khi cửa sổ đã mở lại
                notifyIcon1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở lại cửa sổ: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==============================================
        // 2️⃣ KHỞI TẠO CẤU HÌNH COM PORT
        // ==============================================
        private void InitializeComPortSettings()
        {
            // Khởi tạo BaudRate
            cbBaudRate.Items.Clear();
            int[] baudRates = { 9600, 19200, 38400, 57600, 115200, 230400, 460800, 921600 };
            cbBaudRate.Items.AddRange(baudRates.Cast<object>().ToArray());
            cbBaudRate.SelectedItem = Properties.Settings.Default.BaudRate;
            if (cbBaudRate.SelectedItem == null)
                cbBaudRate.SelectedIndex = 0;

            // Khởi tạo DataBits
            cbDataBits.Items.Clear();
            int[] dataBitsValues = { 5, 6, 7, 8 };
            cbDataBits.Items.AddRange(dataBitsValues.Cast<object>().ToArray());
            cbDataBits.SelectedItem = Properties.Settings.Default.DataBits;
            if (cbDataBits.SelectedItem == null)
                cbDataBits.SelectedIndex = 3; // Mặc định 8

            // Khởi tạo StopBits
            cbStopBits.Items.Clear();
            cbStopBits.Items.Add(StopBits.None);
            cbStopBits.Items.Add(StopBits.One);
            cbStopBits.Items.Add(StopBits.Two);
            cbStopBits.Items.Add(StopBits.OnePointFive);
            try
            {
                StopBits savedStopBits = (StopBits)Enum.Parse(typeof(StopBits), Properties.Settings.Default.StopBits);
                cbStopBits.SelectedItem = savedStopBits;
            }
            catch
            {
                cbStopBits.SelectedIndex = 1; // Mặc định One
            }
            if (cbStopBits.SelectedItem == null)
                cbStopBits.SelectedIndex = 1; // Mặc định One

            // Khởi tạo Parity
            cbParity.Items.Clear();
            cbParity.Items.Add(Parity.None);
            cbParity.Items.Add(Parity.Odd);
            cbParity.Items.Add(Parity.Even);
            cbParity.Items.Add(Parity.Mark);
            cbParity.Items.Add(Parity.Space);
            try
            {
                Parity savedParity = (Parity)Enum.Parse(typeof(Parity), Properties.Settings.Default.Parity);
                cbParity.SelectedItem = savedParity;
            }
            catch
            {
                cbParity.SelectedIndex = 0; // Mặc định None
            }
            if (cbParity.SelectedItem == null)
                cbParity.SelectedIndex = 0; // Mặc định None

            // Khởi tạo Handshake
            cbHandshake.Items.Clear();
            cbHandshake.Items.Add(Handshake.None);
            cbHandshake.Items.Add(Handshake.XOnXOff);
            cbHandshake.Items.Add(Handshake.RequestToSend);
            cbHandshake.Items.Add(Handshake.RequestToSendXOnXOff);
            try
            {
                Handshake savedHandshake = (Handshake)Enum.Parse(typeof(Handshake), Properties.Settings.Default.Handshake);
                cbHandshake.SelectedItem = savedHandshake;
            }
            catch
            {
                cbHandshake.SelectedIndex = 0; // Mặc định None
            }
            if (cbHandshake.SelectedItem == null)
                cbHandshake.SelectedIndex = 0; // Mặc định None
        }

        // ==============================================
        // 3️⃣ XỬ LÝ THAY ĐỔI CẤU HÌNH
        // ==============================================
        private void cbBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBaudRate.SelectedItem != null)
            {
                Properties.Settings.Default.BaudRate = (int)cbBaudRate.SelectedItem;
                Properties.Settings.Default.Save();
            }
        }

        private void cbDataBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDataBits.SelectedItem != null)
            {
                Properties.Settings.Default.DataBits = (int)cbDataBits.SelectedItem;
                Properties.Settings.Default.Save();
            }
        }

        private void cbStopBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStopBits.SelectedItem != null)
            {
                Properties.Settings.Default.StopBits = cbStopBits.SelectedItem.ToString();
                Properties.Settings.Default.Save();
            }
        }

        private void cbParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbParity.SelectedItem != null)
            {
                Properties.Settings.Default.Parity = cbParity.SelectedItem.ToString();
                Properties.Settings.Default.Save();
            }
        }

        private void cbHandshake_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHandshake.SelectedItem != null)
            {
                Properties.Settings.Default.Handshake = cbHandshake.SelectedItem.ToString();
                Properties.Settings.Default.Save();
            }
        }

        // ==============================================
        // 4️⃣ XỬ LÝ FOCUS WINDOW
        // ==============================================
        private void ckbFocusWindow_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FocusWindowEnabled = ckbFocusWindow.Checked;
            Properties.Settings.Default.Save();
            scanner.FocusWindowEnabled = ckbFocusWindow.Checked;
            btnSelectWindow.Enabled = ckbFocusWindow.Checked;
        }

        private void btnSelectWindow_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách tất cả các cửa sổ
                var windows = SerialScannerApp.Helpers.WindowHelper.GetAllWindows(); 
                
                if (windows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy cửa sổ nào đang mở.", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Tạo form dialog để chọn cửa sổ
                using (var selectForm = new Form())
                {
                    selectForm.Text = "Chọn cửa sổ để focus";
                    selectForm.Size = new System.Drawing.Size(600, 400);
                    selectForm.StartPosition = FormStartPosition.CenterParent;
                    selectForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    selectForm.MaximizeBox = false;
                    selectForm.MinimizeBox = false;

                    var listBox = new ListBox
                    {
                        Dock = DockStyle.Fill,
                        Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))
                    };

                    listBox.Items.AddRange(windows.ToArray());
                    listBox.SelectedIndex = 0;

                    var btnOK = new Button
                    {
                        Text = "Chọn",
                        DialogResult = DialogResult.OK,
                        Dock = DockStyle.Bottom,
                        Height = 35
                    };

                    var btnCancel = new Button
                    {
                        Text = "Hủy",
                        DialogResult = DialogResult.Cancel,
                        Dock = DockStyle.Bottom,
                        Height = 35
                    };

                    selectForm.Controls.Add(listBox);
                    selectForm.Controls.Add(btnOK);
                    selectForm.Controls.Add(btnCancel);

                    selectForm.AcceptButton = btnOK;
                    selectForm.CancelButton = btnCancel;

                    if (selectForm.ShowDialog(this) == DialogResult.OK && listBox.SelectedItem != null)
                    {
                        var selectedWindow = (SerialScannerApp.Helpers.WindowInfo)listBox.SelectedItem;
                        Properties.Settings.Default.TargetWindowTitle = selectedWindow.Title;
                        Properties.Settings.Default.Save();
                        scanner.TargetWindowTitle = selectedWindow.Title;
                        UpdateSelectedWindowLabel();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn cửa sổ: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSelectedWindowLabel()
        {
            string windowTitle = Properties.Settings.Default.TargetWindowTitle;
            if (!string.IsNullOrWhiteSpace(windowTitle))
            {
                lblSelectedWindow.Text = windowTitle;
                lblSelectedWindow.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                lblSelectedWindow.Text = "Chưa chọn cửa sổ";
                lblSelectedWindow.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private void SetConnectionState(bool isConnected)
        {
            if (isConnected)
            {
                // Lấy ảnh Bitmap từ Resource
                using (var ms = new MemoryStream(Properties.Resources.IconConnected))
                {
                    Bitmap bitmap = new Bitmap(ms);
                    // Chuyển đổi Bitmap sang Icon
                    IntPtr hIcon = bitmap.GetHicon();
                    Icon myIcon = Icon.FromHandle(hIcon);

                    this.Icon = myIcon;
                    notifyIcon1.Icon = myIcon;
                    notifyIcon1.Text = "Serial Scanner: Đã kết nối";
                }
            }
            else
            {
                // Tương tự cho icon ngắt kết nối
                using (var ms = new MemoryStream(Properties.Resources.IconDisconnected))
                {
                    Bitmap bitmap = new Bitmap(ms);
                    IntPtr hIcon = bitmap.GetHicon();
                    Icon myIcon = Icon.FromHandle(hIcon);

                    this.Icon = myIcon;
                    notifyIcon1.Icon = myIcon;
                    notifyIcon1.Text = "Serial Scanner: Chưa kết nối";
                }
            }
        }

        // ==============================================
        // 6️⃣ XỬ LÝ CUSTOM PARSING
        // ==============================================
        private void LoadCustomParsingSettings()
        {
            ckbCustomParsing.Checked = Properties.Settings.Default.CustomParsingEnabled;
            txtDelimiter.Text = Properties.Settings.Default.CustomDelimiter;
            nudFieldIndex.Value = Properties.Settings.Default.CustomFieldIndex;
            nudReadSpeed.Value = Properties.Settings.Default.ReadSpeedMs;

            // Áp dụng vào scanner
            scanner.CustomParsingEnabled = ckbCustomParsing.Checked;
            scanner.CustomDelimiter = txtDelimiter.Text;
            scanner.CustomFieldIndex = (int)nudFieldIndex.Value;
            scanner.ReadSpeedMs = (int)nudReadSpeed.Value;

            // Enable/disable controls
            UpdateCustomParsingControls();
        }

        private void UpdateCustomParsingControls()
        {
            bool enabled = ckbCustomParsing.Checked;
            txtDelimiter.Enabled = enabled;
            nudFieldIndex.Enabled = enabled;
        }

        private void ckbCustomParsing_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CustomParsingEnabled = ckbCustomParsing.Checked;
            Properties.Settings.Default.Save();
            scanner.CustomParsingEnabled = ckbCustomParsing.Checked;
            UpdateCustomParsingControls();
        }

        private void txtDelimiter_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDelimiter.Text))
            {
                Properties.Settings.Default.CustomDelimiter = txtDelimiter.Text;
                Properties.Settings.Default.Save();
                scanner.CustomDelimiter = txtDelimiter.Text;
            }
        }

        private void nudFieldIndex_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CustomFieldIndex = (int)nudFieldIndex.Value;
            Properties.Settings.Default.Save();
            scanner.CustomFieldIndex = (int)nudFieldIndex.Value;
        }

        private void nudReadSpeed_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ReadSpeedMs = (int)nudReadSpeed.Value;
            Properties.Settings.Default.Save();
            scanner.ReadSpeedMs = (int)nudReadSpeed.Value;
        }

    }
}
