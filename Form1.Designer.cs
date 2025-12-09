namespace SerialScannerApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnReloadPort = new System.Windows.Forms.Button();
            this.btnAutoFindScanner = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbHandshake = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtExample = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.nudReadSpeed = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.nudFieldIndex = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ckbCustomParsing = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.lblSelectedWindow = new System.Windows.Forms.Label();
            this.btnSelectWindow = new System.Windows.Forms.Button();
            this.ckbFocusWindow = new System.Windows.Forms.CheckBox();
            this.ckbAutoConnectCOM = new System.Windows.Forms.CheckBox();
            this.ckbEnter = new System.Windows.Forms.CheckBox();
            this.ckbStartUpWindow = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReadSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFieldIndex)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cổng COM:";
            // 
            // cbPorts
            // 
            this.cbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(83, 15);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(119, 21);
            this.cbPorts.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(226, 14);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Kết nối";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.Location = new System.Drawing.Point(320, 14);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "Ngắt kết nối";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(87, 45);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(67, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Chưa kết nối";
            // 
            // btnReloadPort
            // 
            this.btnReloadPort.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadPort.Location = new System.Drawing.Point(8, 40);
            this.btnReloadPort.Name = "btnReloadPort";
            this.btnReloadPort.Size = new System.Drawing.Size(75, 23);
            this.btnReloadPort.TabIndex = 5;
            this.btnReloadPort.Text = "Tải lại COM";
            this.btnReloadPort.UseVisualStyleBackColor = true;
            this.btnReloadPort.Click += new System.EventHandler(this.btnReloadPort_Click);
            // 
            // btnAutoFindScanner
            // 
            this.btnAutoFindScanner.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoFindScanner.Location = new System.Drawing.Point(8, 69);
            this.btnAutoFindScanner.Name = "btnAutoFindScanner";
            this.btnAutoFindScanner.Size = new System.Drawing.Size(112, 23);
            this.btnAutoFindScanner.TabIndex = 6;
            this.btnAutoFindScanner.Text = "Tự động tìm Scanner";
            this.btnAutoFindScanner.UseVisualStyleBackColor = true;
            this.btnAutoFindScanner.Click += new System.EventHandler(this.btnAutoFindScanner_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbPorts);
            this.groupBox1.Controls.Add(this.btnReloadPort);
            this.groupBox1.Controls.Add(this.btnAutoFindScanner);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(404, 99);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều khiển và kết nối";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(322, 348);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 39);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 348);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 39);
            this.button1.TabIndex = 9;
            this.button1.Text = "Kết thúc";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cbHandshake);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.cbParity);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.cbStopBits);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.cbDataBits);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.cbBaudRate);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage3.Size = new System.Drawing.Size(396, 189);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cấu hình COM";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbHandshake
            // 
            this.cbHandshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHandshake.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHandshake.FormattingEnabled = true;
            this.cbHandshake.Location = new System.Drawing.Point(90, 130);
            this.cbHandshake.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbHandshake.Name = "cbHandshake";
            this.cbHandshake.Size = new System.Drawing.Size(151, 20);
            this.cbHandshake.TabIndex = 9;
            this.cbHandshake.SelectedIndexChanged += new System.EventHandler(this.cbHandshake_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 132);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Handshake:";
            // 
            // cbParity
            // 
            this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParity.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(90, 106);
            this.cbParity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(151, 20);
            this.cbParity.TabIndex = 7;
            this.cbParity.SelectedIndexChanged += new System.EventHandler(this.cbParity_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 108);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Parity:";
            // 
            // cbStopBits
            // 
            this.cbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStopBits.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Location = new System.Drawing.Point(90, 81);
            this.cbStopBits.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(151, 20);
            this.cbStopBits.TabIndex = 5;
            this.cbStopBits.SelectedIndexChanged += new System.EventHandler(this.cbStopBits_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 84);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Stop Bits:";
            // 
            // cbDataBits
            // 
            this.cbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataBits.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Location = new System.Drawing.Point(90, 57);
            this.cbDataBits.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(151, 20);
            this.cbDataBits.TabIndex = 3;
            this.cbDataBits.SelectedIndexChanged += new System.EventHandler(this.cbDataBits_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 59);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Data Bits:";
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaudRate.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Location = new System.Drawing.Point(90, 32);
            this.cbBaudRate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(151, 20);
            this.cbBaudRate.TabIndex = 1;
            this.cbBaudRate.SelectedIndexChanged += new System.EventHandler(this.cbBaudRate_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 35);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Baud Rate:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtExample);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.nudReadSpeed);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.nudFieldIndex);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.txtDelimiter);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.ckbCustomParsing);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage4.Size = new System.Drawing.Size(396, 189);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tùy chỉnh chuỗi";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtExample
            // 
            this.txtExample.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExample.Location = new System.Drawing.Point(7, 126);
            this.txtExample.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtExample.Multiline = true;
            this.txtExample.Name = "txtExample";
            this.txtExample.ReadOnly = true;
            this.txtExample.Size = new System.Drawing.Size(387, 58);
            this.txtExample.TabIndex = 8;
            this.txtExample.Text = "123456789||Nguyễn Văn A|01012000|Nam|...\r\nVới delimiter=\"|\" và index=0 -> Lấy: 12" +
    "3456789\r\nVới delimiter=\"|\" và index=2 -> Lấy: Nguyễn Văn A";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(7, 110);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Ví dụ:";
            // 
            // nudReadSpeed
            // 
            this.nudReadSpeed.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudReadSpeed.Location = new System.Drawing.Point(90, 83);
            this.nudReadSpeed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudReadSpeed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudReadSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudReadSpeed.Name = "nudReadSpeed";
            this.nudReadSpeed.Size = new System.Drawing.Size(75, 21);
            this.nudReadSpeed.TabIndex = 6;
            this.nudReadSpeed.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.nudReadSpeed.ValueChanged += new System.EventHandler(this.nudReadSpeed_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(7, 85);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Tốc độ đọc (ms):";
            // 
            // nudFieldIndex
            // 
            this.nudFieldIndex.Enabled = false;
            this.nudFieldIndex.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFieldIndex.Location = new System.Drawing.Point(90, 58);
            this.nudFieldIndex.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudFieldIndex.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudFieldIndex.Name = "nudFieldIndex";
            this.nudFieldIndex.Size = new System.Drawing.Size(75, 21);
            this.nudFieldIndex.TabIndex = 4;
            this.nudFieldIndex.ValueChanged += new System.EventHandler(this.nudFieldIndex_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(7, 61);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Vị trí trường (Index):";
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Enabled = false;
            this.txtDelimiter.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelimiter.Location = new System.Drawing.Point(90, 34);
            this.txtDelimiter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(38, 21);
            this.txtDelimiter.TabIndex = 2;
            this.txtDelimiter.Text = "|";
            this.txtDelimiter.TextChanged += new System.EventHandler(this.txtDelimiter_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 37);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Ký tự phân cách:";
            // 
            // ckbCustomParsing
            // 
            this.ckbCustomParsing.AutoSize = true;
            this.ckbCustomParsing.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbCustomParsing.Location = new System.Drawing.Point(7, 12);
            this.ckbCustomParsing.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ckbCustomParsing.Name = "ckbCustomParsing";
            this.ckbCustomParsing.Size = new System.Drawing.Size(174, 17);
            this.ckbCustomParsing.TabIndex = 0;
            this.ckbCustomParsing.Text = "Bật tùy chỉnh chuỗi (Custom)";
            this.ckbCustomParsing.UseVisualStyleBackColor = true;
            this.ckbCustomParsing.CheckedChanged += new System.EventHandler(this.ckbCustomParsing_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(396, 189);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Thông tin";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(101, 171);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(291, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cty TNHH Giải pháp Công nghệ Lead And Aim Việt Nam";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "v2.0.0beta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đây là bản thử nghiệm đang trong quá trình phát triển";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "SerialScanner - Demo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.lblSelectedWindow);
            this.tabPage1.Controls.Add(this.btnSelectWindow);
            this.tabPage1.Controls.Add(this.ckbFocusWindow);
            this.tabPage1.Controls.Add(this.ckbAutoConnectCOM);
            this.tabPage1.Controls.Add(this.ckbEnter);
            this.tabPage1.Controls.Add(this.ckbStartUpWindow);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(396, 189);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hệ thống";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 122);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Cửa sổ đã chọn:";
            // 
            // lblSelectedWindow
            // 
            this.lblSelectedWindow.AutoSize = true;
            this.lblSelectedWindow.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedWindow.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblSelectedWindow.Location = new System.Drawing.Point(7, 136);
            this.lblSelectedWindow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedWindow.Name = "lblSelectedWindow";
            this.lblSelectedWindow.Size = new System.Drawing.Size(91, 13);
            this.lblSelectedWindow.TabIndex = 5;
            this.lblSelectedWindow.Text = "Chưa chọn cửa sổ";
            // 
            // btnSelectWindow
            // 
            this.btnSelectWindow.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectWindow.Location = new System.Drawing.Point(7, 94);
            this.btnSelectWindow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSelectWindow.Name = "btnSelectWindow";
            this.btnSelectWindow.Size = new System.Drawing.Size(112, 23);
            this.btnSelectWindow.TabIndex = 4;
            this.btnSelectWindow.Text = "Chọn cửa sổ...";
            this.btnSelectWindow.UseVisualStyleBackColor = true;
            this.btnSelectWindow.Click += new System.EventHandler(this.btnSelectWindow_Click);
            // 
            // ckbFocusWindow
            // 
            this.ckbFocusWindow.AutoSize = true;
            this.ckbFocusWindow.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbFocusWindow.Location = new System.Drawing.Point(7, 74);
            this.ckbFocusWindow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ckbFocusWindow.Name = "ckbFocusWindow";
            this.ckbFocusWindow.Size = new System.Drawing.Size(202, 17);
            this.ckbFocusWindow.TabIndex = 3;
            this.ckbFocusWindow.Text = "Tự động focus vào cửa sổ đã chọn";
            this.ckbFocusWindow.UseVisualStyleBackColor = true;
            this.ckbFocusWindow.CheckedChanged += new System.EventHandler(this.ckbFocusWindow_CheckedChanged);
            // 
            // ckbAutoConnectCOM
            // 
            this.ckbAutoConnectCOM.AutoSize = true;
            this.ckbAutoConnectCOM.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbAutoConnectCOM.Location = new System.Drawing.Point(7, 53);
            this.ckbAutoConnectCOM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ckbAutoConnectCOM.Name = "ckbAutoConnectCOM";
            this.ckbAutoConnectCOM.Size = new System.Drawing.Size(123, 17);
            this.ckbAutoConnectCOM.TabIndex = 2;
            this.ckbAutoConnectCOM.Text = "Tự động kết nối lại";
            this.ckbAutoConnectCOM.UseVisualStyleBackColor = true;
            this.ckbAutoConnectCOM.CheckedChanged += new System.EventHandler(this.ckbAutoConnectCOM_CheckedChanged);
            // 
            // ckbEnter
            // 
            this.ckbEnter.AutoSize = true;
            this.ckbEnter.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbEnter.Location = new System.Drawing.Point(7, 32);
            this.ckbEnter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ckbEnter.Name = "ckbEnter";
            this.ckbEnter.Size = new System.Drawing.Size(127, 17);
            this.ckbEnter.TabIndex = 1;
            this.ckbEnter.Text = "Enter (Xuống dòng)";
            this.ckbEnter.UseVisualStyleBackColor = true;
            this.ckbEnter.CheckedChanged += new System.EventHandler(this.ckbEnter_CheckedChanged);
            // 
            // ckbStartUpWindow
            // 
            this.ckbStartUpWindow.AutoSize = true;
            this.ckbStartUpWindow.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbStartUpWindow.Location = new System.Drawing.Point(7, 12);
            this.ckbStartUpWindow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ckbStartUpWindow.Name = "ckbStartUpWindow";
            this.ckbStartUpWindow.Size = new System.Drawing.Size(154, 17);
            this.ckbStartUpWindow.TabIndex = 0;
            this.ckbStartUpWindow.Text = "Khởi động cùng window";
            this.ckbStartUpWindow.UseVisualStyleBackColor = true;
            this.ckbStartUpWindow.CheckedChanged += new System.EventHandler(this.ckbStartUpWindow_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(9, 126);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(404, 217);
            this.tabControl1.TabIndex = 7;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(248, 121);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(143, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 396);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cài đặt máy quét";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReadSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFieldIndex)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnReloadPort;
        private System.Windows.Forms.Button btnAutoFindScanner;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cbHandshake;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox ckbCustomParsing;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDelimiter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nudFieldIndex;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nudReadSpeed;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtExample;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox ckbAutoConnectCOM;
        private System.Windows.Forms.CheckBox ckbEnter;
        private System.Windows.Forms.CheckBox ckbStartUpWindow;
        private System.Windows.Forms.CheckBox ckbFocusWindow;
        private System.Windows.Forms.Button btnSelectWindow;
        private System.Windows.Forms.Label lblSelectedWindow;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}