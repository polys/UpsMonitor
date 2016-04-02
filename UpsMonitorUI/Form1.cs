
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace UpsMonitorUI
{
    internal partial class Form1 : Form
    {
        private UpsMonitor _upsmon;
        private SpeechSynthesizer _speech = null;
        private DateTime _timerStartTime;
        private bool _startup = true;

        private int _hibernateDelaySeconds = 15;

        private string _logFileName;

        public Form1()
        {
            InitializeComponent();
            this.Visible = false;
            this.TopMost = true;

            this.timer1.Interval = 1000;
            this.timer1.Enabled = false;

            this._speech = new SpeechSynthesizer();

            this._logFileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "UpsMonitor.log");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 20;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height - 20;

            this._hibernateDelaySeconds = Properties.Settings.Default.HibernateDelaySeconds;
            if (this._hibernateDelaySeconds < 5) this._hibernateDelaySeconds = 5;

            if (Properties.Settings.Default.SpeechEnabled)
                this._speech = new SpeechSynthesizer();
            else
                this._speech = null;

            string portName = Properties.Settings.Default.PortName;
            if (string.IsNullOrEmpty(portName)) portName = "COM6";

            this.Connect(portName);
            
            this.notifyIcon1.Visible = true;
            this.Visible = false;
        }
                
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_upsmon != null) _upsmon.Stop();
            if (_speech != null) _speech.Dispose();
        }
        
        private void Form1_Shown(object sender, EventArgs e)
        {
            if (_startup)
            {
                this.Visible = false;
                _startup = false;
            }
        }

        private void Connect(string portName)
        {
            if ((_upsmon != null) && _upsmon.IsOpen)
                _upsmon.Stop();

            _upsmon = new UpsMonitor(portName);

            _upsmon.UpsStatusUpdated += new EventHandler(_upsmon_UpsStatusUpdated);
            _upsmon.LowBatteryChanged += new EventHandler(_upsmon_LowBatteryChanged);
            _upsmon.OnBatteryChanged += new EventHandler(_upsmon_OnBatteryChanged);

            if (_upsmon.Start())
                this.Text = string.Format("UPS Monitor ({0})", _upsmon.PortName);
            else
                this.Text = string.Format("UPS Monitor (Not Connected)", _upsmon.PortName);

            this.notifyIcon1.Text = this.Text;

            UpdateUI();
        }

        private void _upsmon_UpsStatusUpdated(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void SpeakAsync(string textToSpeak)
        {
            if (this._speech != null)
                this._speech.SpeakAsync(textToSpeak);
        }
        
        private void _upsmon_OnBatteryChanged(object sender, EventArgs e)
        {
            UpdateUI();

            if (this._upsmon.OnBattery)
            {
                Trace.WriteLine("Power Failure at " + DateTime.Now.ToString());

                this.SpeakAsync(string.Format("Power Failure. Hibernating in {0} seconds.", this._hibernateDelaySeconds));

                this.notifyIcon1.ShowBalloonTip(10000, "UPS Power Failure",
                    string.Format("The UPS is running on batteries.\n\n" +
                    "The computer will hibernate in {0} seconds.\n" +
                    "Click here to abort hibernation.", this._hibernateDelaySeconds),
                    ToolTipIcon.Error);
                                
                this._timerStartTime = DateTime.Now;
                this.SetTimerEnabled(true);

                try
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(this._logFileName, true))
                    {
                        sw.WriteLine("{0}\t{1}", DateTime.Now.ToString(), "Power Failure");
                    }
                }
                catch { }   

            }
            else
            {
                this.SetTimerEnabled(false);

                Trace.WriteLine("AC Power Restored at " + DateTime.Now.ToString());

                this.SpeakAsync("Power Restored.");

                this._timerStartTime = DateTime.Now;
                this.SetTimerEnabled(true);

                this.notifyIcon1.ShowBalloonTip(1000, "UPS Power Restored",
                    "The AC power has been restored.", ToolTipIcon.Info);

                try
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(this._logFileName, true))
                    {
                        sw.WriteLine("{0}\t{1}", DateTime.Now.ToString(), "Power Restored");
                    }
                }
                catch { }
            }
        }

        private void _upsmon_LowBatteryChanged(object sender, EventArgs e)
        {
            UpdateUI();

            if (this._upsmon.LowBattery)
            {
                Trace.WriteLine("Low Battery at " + DateTime.Now.ToString());

                this.SpeakAsync("Low Battery.");

                if (!this.Visible)
                {
                    this.notifyIcon1.ShowBalloonTip(1000, "UPS Battery Low",
                        "The UPS battery is low.", ToolTipIcon.Warning);
                }

                try
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(this._logFileName, true))
                    {
                        sw.WriteLine("{0}\t{1}", DateTime.Now.ToString(), "Low Battery");
                    }
                }
                catch { }   

            }
        }

        private delegate void DelegateUpdateUI();

        private void UpdateUI()
        {
            if (this.InvokeRequired)
                this.Invoke(new DelegateUpdateUI(this.UpdateUnsafe));
            else
                this.UpdateUnsafe();
        }

        private void UpdateUnsafe()
        {
            if (!this.Visible) return;

            if (this._upsmon.IsOpen)
            {
                this.PortStatusLabel.Text = string.Format("Connected ({0})", _upsmon.PortName);
                this.PortStatusPicBox.Image = Properties.Resources.Green24;
            }
            else
            {
                this.PortStatusLabel.Text = "Not Connected";
                this.PortStatusPicBox.Image = Properties.Resources.Red24;
            }

            if (this._upsmon.OnBattery)
            {
                this.AcStatuslabel.Text = "Power Failure (on battery)";
                this.AcStatusPicBox.Image = Properties.Resources.Red24;
            }
            else
            {
                this.AcStatuslabel.Text = "AC Power";
                this.AcStatusPicBox.Image = Properties.Resources.Green24;
            }

            if (this._upsmon.LowBattery)
            {
                this.BatteryStatusLabel.Text = "Low Battery";
                this.BatteryStatusPicBox.Image = Properties.Resources.Yellow24;
            }
            else
            {
                this.BatteryStatusLabel.Text = "Battery OK";
                this.BatteryStatusPicBox.Image = Properties.Resources.Green24;
            }
        }

        private delegate void DelegateSetTimerEnabled(bool enabled);

        private void SetTimerEnabled(bool enabled)
        {
            if (this.InvokeRequired)
                this.Invoke(new DelegateSetTimerEnabled(this.SetTimerEnabledUnsafe), enabled);
            else
                this.SetTimerEnabledUnsafe(enabled);
        }

        private void SetTimerEnabledUnsafe(bool enabled)
        {
            this.timer1.Enabled = enabled;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                this.Visible = !this.Visible;
        }

        private void ShowHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
            if (this.Visible) this.UpdateUnsafe();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.ShowHideToolStripMenuItem.Text = this.Visible ? "Hide" : "Show";
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HideLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int tsecs = (int)Math.Floor(DateTime.Now.Subtract(this._timerStartTime).TotalSeconds);
            int diff = this._hibernateDelaySeconds - tsecs;

            if (tsecs > this._hibernateDelaySeconds)
            {
                if (this._upsmon.OnBattery)
                {
                    this.SpeakAsync("Hibernating.");
                    Trace.WriteLine("Hibernate at " + DateTime.Now.ToString());
                    Process.Start("shutdown", "/h /f");
                    try
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(this._logFileName, true))
                        {
                            sw.WriteLine("{0}\t{1}", DateTime.Now.ToString(), "Hibernating");
                        }
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(this._logFileName, true))
                        {
                            sw.WriteLine("{0}\t{1}", DateTime.Now.ToString(), "Hibernation Aborted");
                        }
                    }
                    catch { }
                }
                this.timer1.Enabled = false;
            }
            else if (diff <= 10)
            {
                this.SpeakAsync(diff.ToString() + ".");
            }
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.SpeakAsync("Hibernation Aborted.");
            try
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(this._logFileName, true))
                {
                    sw.WriteLine("{0}\t{1}", DateTime.Now.ToString(), "Hibernation Aborted by user");
                }
            }
            catch { }
        }

    }
}
