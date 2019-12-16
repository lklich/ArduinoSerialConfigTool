using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace KLTool
{
    public partial class mWindow : Form
    {
        private static string VER = "30021"; //identyfikator urządzenia zapisany w Arduino

        public mWindow()
        {
            InitializeComponent();
        }

        private void mWindow_Load(object sender, System.EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            cbPort.DataSource = ports;
            sPort.Close();
        }

        private void cbPort_DropDown(object sender, System.EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            cbPort.DataSource = ports;
        }

        private void btnConnect_Click(object sender, System.EventArgs e)
        {
            SerialOpen();            
        }


        private void SerialOpen()
        {
            if (!sPort.IsOpen)
            {
                sPort.PortName = cbPort.Text;
                sPort.BaudRate = 9600;
                sPort.Parity = Parity.None;
                sPort.DataBits = 8;
                sPort.ReadTimeout = 2000;
                sPort.WriteTimeout = 2000;
                sPort.Handshake = Handshake.None;

                try
                {
                    sPort.Open();
                }
                catch (UnauthorizedAccessException)
                {
                    LogW("Port " + sPort.PortName + " jest już w użyciu. Zrestartuj komputer i spróbuj ponownie.");
                }
                catch (Exception ex)
                {
                    LogW("Błąd połączenia z urządzeniem. " + ex.Message + " Zrestartuj komputer i spróbuj ponownie.");
                }

                if (IsValidDevice())
                {
                    btnConnect.Text = "Rozłącz";
                    cbPort.Enabled = false;
                    btnConfig.Enabled = true;
                    btnDebug.Enabled = true;
                    LogW("Połączono");
                    GetConfig();
                }
                else SerialClose();
            }
            else
            {
                SerialClose();
            }
        }

        private bool IsValidDevice()
        {
            if ((sPort.IsOpen) && (PortWrite("[IDE]").Trim() == VER))
            {
                grConfig.Enabled = true;
                return true;
            }
            else
            {
                LogW("Nierozpozmnane urządzenie!");
                SerialClose();
                return false;
            }
        }

        private void SetConfig()
        {
            if (sPort.IsOpen)
            {
                LogW("Zapis parametrów...");
                ChangeParam("[TIM:" + numCzas.Value.ToString() + "]");
                ChangeParam("[HIS:" + numHist.Value.ToString() + "]");
                ChangeParam("[HIS:" + numHist.Value.ToString() + "]");
                ChangeParam("[LEV:" + minLight.Value.ToString() + "]");
                if (chDebug.Checked) ChangeParam("[DEB:1]"); else ChangeParam("[DEB:0]");
                LogW("Gotowe.");
            }
            else LogW("Błąd! Port jest zamknięty!");
        }


        private void GetConfig()
        {
            if (sPort.IsOpen)
            {               
                mWindow.ActiveForm.Text = "LK Sterownik v:" + PortWrite("[VER]");
                numCzas.Value = Convert.ToInt32(PortWrite("[TIM]"));
                numHist.Value = Convert.ToInt32(PortWrite("[HIS]"));
                minLight.Value = Convert.ToInt32(PortWrite("[LEV]"));
                if (PortWrite("[DEB]") == "1") chDebug.Checked = true; else chDebug.Checked = false;
                grConfig.Enabled = true;
            }
            else LogW("Błąd! Port jest zamknięty!");
        }

        private void LogW(string mess)
        {
            txtLog.AppendText(mess + Environment.NewLine);
        }

        private void SerialClose()
        {
            if (sPort.IsOpen)
            {
                sPort.Close();
                grConfig.Enabled = false;
                pAnalyze.Visible = false;
                btnConnect.Text = "Połącz";
                btnConfig.Enabled = false;
                btnDebug.Enabled = false;
                cbPort.Enabled = true;
                LogW("Rozłączono");
            }
            else LogW("Port jest zamknięty!");
        }


        private string PortWrite(string message)
        {
            string ret = "";
            sPort.WriteLine(message);
            Thread.Sleep(100);
            try
            {
                    ret = sPort.ReadLine().Trim();
                }
                catch (TimeoutException)
                {
                    MessageBox.Show("Błąd połączenia. Upłynął czas połączenia...");
                }
            return ret;
        }

        private bool ChangeParam(string message)
        {
            try
            {
                sPort.WriteLine(message);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Błąd połączenia z urządzeniem.");
                return false;
            }
            return true;
        }

        private void mWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerialClose();
        }


        private void btnConfig_Click(object sender, EventArgs e)
        {
            SetConfig();
        }

        private void sPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show("Błąd komunikacji z portem COM!");
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            if (pAnalyze.Visible == false)
            {
                pAnalyze.Visible = true;
                btnConfig.Enabled = false;
                timer1.Start();
            }
            else
            {
                pAnalyze.Visible = false;
                btnConfig.Enabled = true;
                timer1.Stop();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SerialClose();
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sPort.IsOpen)
            {
                lLev.Text = PortWrite("[LEV]");
                lMov.Text = (Convert.ToInt16(PortWrite("[MOV]")) == 1) ? "Brak ruchu" : "Ruch wykryty";
                lDay.Text = (Convert.ToInt16(PortWrite("[DAY]")) == 0) ? "Noc" : "Dzień";
                lRelay.Text = (Convert.ToInt16(PortWrite("[REL]")) == 0) ? "Wyłączony" : "Włączony";
            }
            else
            {
                SerialClose();
                LogW("Błąd! Port jest zamknięty!");
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Zresetować urządzenie do wartości domyślnych?", "Potwierdź", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (sPort.IsOpen)
                {
                    LogW("Przywracanie parametrów domyślnych...");
                    ChangeParam("[DEF:0]");
                    Thread.Sleep(500);
                    GetConfig();
                    LogW("Gotowe.");
                }
                else LogW("Błąd! Port jest zamknięty!");
            }          
        }
    }

}


