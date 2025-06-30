using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;

namespace Uyanik
{
    public partial class MouseJigglerForm : Form
    {
        private Timer jiggleTimer;
        private bool zenMode = false;
        private int jiggleInterval = 10;
        private bool minimizeOnStart = false;
        private bool isJiggling = true;
        private NotifyIcon trayIcon;
        private Label labelJiggle;
        private Timer jiggleSignTimer;
        private const string RegistryPath = @"Software\Uyanik\MouseJiggler";
        private const string RegistryKeyName = "MinimizeOnStart";
        private const string StartupRegistryPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private const string StartupAppName = "UyanikMouseJiggler";

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(out POINT lpPoint);
        public struct POINT { public int X; public int Y; }

        [StructLayout(LayoutKind.Sequential)]
        struct INPUT
        {
            public uint type;
            public MOUSEINPUT mi;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);
        const int INPUT_MOUSE = 0;
        const uint MOUSEEVENTF_MOVE = 0x0001;

        public MouseJigglerForm()
        {
            InitializeComponent();
            // Form ve tray için özel icon yükle
            try {
                Icon appIcon = new Icon("mouse.ico");
                this.Icon = appIcon;
                trayIcon = new NotifyIcon();
                trayIcon.Icon = appIcon;
            } catch { // Dosya yoksa default icon kullan
                trayIcon = new NotifyIcon();
                trayIcon.Icon = SystemIcons.Application;
            }
            // Registry'den minimize ayarını oku
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryPath))
            {
                object value = key.GetValue(RegistryKeyName, "0");
                minimizeOnStart = value != null && value.ToString() == "1";
                checkBoxMinimize.Checked = minimizeOnStart;
            }
            // Windows ile başlat ayarını oku
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupRegistryPath, false))
            {
                object value = key?.GetValue(StartupAppName);
                checkBoxStartup.Checked = value != null;
            }
            isJiggling = checkBoxJiggling.Checked;
            jiggleTimer = new Timer();
            jiggleTimer.Interval = jiggleInterval * 1000;
            jiggleTimer.Tick += JiggleTimer_Tick;
            jiggleTimer.Start();
            buttonSettings.Click += buttonSettings_Click;
            buttonMenu.Click += buttonMenu_Click;
            trayIcon.Text = "Mouse Jiggler";
            trayIcon.Visible = false;
            trayIcon.DoubleClick += TrayIcon_DoubleClick;
            trayIcon.ContextMenuStrip = trayMenu;
            menuShow.Click += (s, e) => { this.Show(); this.WindowState = FormWindowState.Normal; trayIcon.Visible = false; };
            menuExit.Click += (s, e) => { Application.Exit(); };
            trayIcon.BalloonTipTitle = "Mouse Jiggler";
            trayIcon.BalloonTipText = "Uygulama arka planda çalışıyor.";
            labelJiggle = new Label();
            labelJiggle.Text = "Jiggle!";
            labelJiggle.ForeColor = Color.Red;
            labelJiggle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            labelJiggle.Visible = false;
            labelJiggle.Location = new Point(220, 45);
            labelJiggle.AutoSize = true;
            this.Controls.Add(labelJiggle);
            jiggleSignTimer = new Timer();
            jiggleSignTimer.Interval = 500;
            jiggleSignTimer.Tick += (s, e) => { labelJiggle.Visible = false; jiggleSignTimer.Stop(); };
            checkBoxStartup.CheckedChanged += checkBoxStartup_CheckedChanged;
            this.Shown += MouseJigglerForm_Shown;
        }

        private void JiggleTimer_Tick(object sender, EventArgs e)
        {
            if (!isJiggling) return;
            labelJiggle.Visible = true;
            jiggleSignTimer.Stop();
            jiggleSignTimer.Start();
            if (zenMode)
            {
                JiggleMouse(0, 5);
                JiggleMouse(0, -5);
            }
            else
            {
                JiggleMouse(5, 0);
                JiggleMouse(-5, 0);
            }
        }

        private void checkBoxJiggling_CheckedChanged(object sender, EventArgs e)
        {
            isJiggling = checkBoxJiggling.Checked;
        }

        private void checkBoxZen_CheckedChanged(object sender, EventArgs e)
        {
            zenMode = checkBoxZen.Checked;
        }

        private void checkBoxMinimize_CheckedChanged(object sender, EventArgs e)
        {
            minimizeOnStart = checkBoxMinimize.Checked;
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryPath))
            {
                key.SetValue(RegistryKeyName, minimizeOnStart ? "1" : "0");
            }
        }

        private void trackBarInterval_Scroll(object sender, EventArgs e)
        {
            jiggleInterval = trackBarInterval.Value;
            jiggleTimer.Interval = jiggleInterval * 1000;
            labelInterval.Text = jiggleInterval + " s";
        }

        private void MouseJigglerForm_Load(object sender, EventArgs e)
        {
            panelBottom.Visible = false;
            this.Height = 120;
        }

        private void MouseJigglerForm_Shown(object sender, EventArgs e)
        {
            if (minimizeOnStart)
            {
                trayIcon.Visible = true;
                trayIcon.ShowBalloonTip(2000);
                this.Hide();
            }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            panelBottom.Visible = !panelBottom.Visible;
            this.Height = panelBottom.Visible ? 190 : 120;
        }
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            trayIcon.Visible = true;
            trayIcon.ShowBalloonTip(2000);
            this.Hide();
        }
        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            trayIcon.Visible = false;
        }

        private void checkBoxStartup_CheckedChanged(object sender, EventArgs e)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupRegistryPath, true))
            {
                if (checkBoxStartup.Checked)
                {
                    string exePath = Application.ExecutablePath;
                    key.SetValue(StartupAppName, '"' + exePath + '"');
                }
                else
                {
                    key.DeleteValue(StartupAppName, false);
                }
            }
        }

        private void JiggleMouse(int dx, int dy)
        {
            INPUT[] inputs = new INPUT[1];
            inputs[0].type = INPUT_MOUSE;
            inputs[0].mi.dx = dx;
            inputs[0].mi.dy = dy;
            inputs[0].mi.mouseData = 0;
            inputs[0].mi.dwFlags = MOUSEEVENTF_MOVE;
            inputs[0].mi.time = 0;
            inputs[0].mi.dwExtraInfo = IntPtr.Zero;
            SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
        }
    }
} 