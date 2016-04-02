
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace UpsMonitorUI
{
    internal sealed class UpsMonitor : IDisposable
    {
        private string _portName;
        private SerialPort _serialPort;

        private bool _lastOnBattery = false;
        private bool _lastLowBattery = false;

        private bool _continue;
        private int _readInterval = 500;    // milliseconds

        public event EventHandler UpsStatusUpdated;
        public event EventHandler OnBatteryChanged;
        public event EventHandler LowBatteryChanged;

        public UpsMonitor(string portName)
        {
            if (string.IsNullOrEmpty(portName)) throw new ArgumentNullException("portName");
            _portName = portName;

            _serialPort = new SerialPort(_portName);
            _serialPort.Handshake = Handshake.None;
            //_serialPort.BaudRate = 2400;
            //_serialPort.DataBits = 8;
            //_serialPort.Parity = Parity.None;
            //_serialPort.StopBits = StopBits.One;
        }

        public string PortName
        {
            get { return _serialPort.PortName; }
        }

        public bool IsOpen 
        {
            get { return _serialPort.IsOpen; }
        }
        
        public bool Start()
        {   
            try
            {
                _serialPort.Open();
                _serialPort.RtsEnable = true;

                _continue = true;

                Thread readThread = new Thread(ReadThreadWork);
                readThread.Start();
            }
            catch (IOException ex)
            {
                _continue = false;
                _serialPort.Close();
                Trace.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        public void Stop()
        {
            _continue = false;
            _serialPort.Close();
        }               

        public bool OnBattery
        {
            get { return _lastOnBattery; }
        }

        public bool LowBattery
        {
            get { return _lastLowBattery; }
        }

        public bool ShutdownUPS()
        {
            // Shutdown when set by computer for 1-5 seconds.
            _serialPort.DtrEnable = true;
            return _serialPort.DsrHolding;
        }
        
        private void ReadThreadWork()
        {
            bool flag;

            while (_continue)
            {
                try
                {
                    flag = !_serialPort.CtsHolding;  // On battery power
                    if (flag != _lastOnBattery)
                    {
                        _lastOnBattery = flag;

                        EventHandler OnBatteryChangedEventHandler = OnBatteryChanged;
                        if (OnBatteryChangedEventHandler != null)
                        {
                            OnBatteryChangedEventHandler(this, new EventArgs());
                        }                        
                    }

                    flag = !_serialPort.CDHolding;   // Low battery
                    if (flag != _lastLowBattery)
                    {
                        _lastLowBattery = flag;

                        EventHandler LowBatteryChangedEventHandler = LowBatteryChanged;
                        if (LowBatteryChangedEventHandler != null)
                        {
                            LowBatteryChangedEventHandler(this, new EventArgs());
                        }                        
                    }

                    EventHandler UpsStatusUpdatedEventHandler = UpsStatusUpdated;
                    if (UpsStatusUpdatedEventHandler != null)
                    {
                        UpsStatusUpdatedEventHandler(this, new EventArgs());
                    }
                    
                    Thread.Sleep(_readInterval);
                }
                catch (TimeoutException) { }
            }
        }
                
        public void Dispose()
        {
            this.Stop();            
        }

    }
}
