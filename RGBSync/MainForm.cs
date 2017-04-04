using System;
using System.Windows.Forms;
using LedCSharp;

namespace RGBSync
{
    public partial class MainForm : Form
    {
        public readonly Data Data;
        public readonly Controller Controller;

        private BridgeConnector _bridgeConnector;

        public MainForm()
        {
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;

            InitializeComponent();
            Data = new Data();
            Controller = new Controller(Handle);
        }

        public void buttonUpdate_Click(object sender, EventArgs e)
        {
            Data.RgbPercentValue.R = Convert.ToInt32(numericUpDownR.Text);
            Data.RgbPercentValue.G = Convert.ToInt32(numericUpDownG.Text);
            Data.RgbPercentValue.B = Convert.ToInt32(numericUpDownB.Text);

            if (Controller.InitialisedLogitech)
            {
                if (Controller.UpdateLogitechRGB(Data.RgbPercentValue))
                {
                    LogitechGSDK.LogiLedSaveCurrentLighting();
                }
            }

            if (Controller.InitialiasedRazer)
            {
                Controller.UpdateRazerRGB(Data.RgbPercentValue.ColoreColor());
            }
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            if (Controller.InitialisedLogitech)
            {
                Controller.ShutdownLogitech();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Controller.InitialiasedRazer)
            {
                Controller.ShutdownRazer();
            }
        }

        private void buttonHue_Click(object sender, EventArgs e)
        {
            if (_bridgeConnector == null)
            {
                _bridgeConnector = new BridgeConnector();
                _bridgeConnector.Changed += BridgeConnectorOnChanged;
                _bridgeConnector.InitBridgeConnector();

                buttonHue.Enabled = false;
            }
        }

        private void BridgeConnectorOnChanged(object sender, bool bridgeConnected)
        {
            buttonHue.Text = bridgeConnected ? "Hue Bridge Connected" : "Press Hue Bridge button now";
        }
    }
}
