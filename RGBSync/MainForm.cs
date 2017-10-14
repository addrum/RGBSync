using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using LedCSharp;

namespace RGBSync
{
    public partial class MainForm : Form
    {
        public List<Controller> Controllers;
        public readonly Data Data;
        public readonly LogitechController LogitechController;
        public readonly RazerController RazerController;

        private BridgeConnector _bridgeConnector;

        public MainForm()
        {
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;

            InitializeComponent();

            Data = new Data();

            Controllers = new List<Controller>();

            LogitechController = new LogitechController();
            RazerController = new RazerController(Handle);

            Controllers.Add(LogitechController);
            Controllers.Add(RazerController);
        }

        public void buttonUpdate_Click(object sender, EventArgs e)
        {
            Data.RgbPercentValue.R = Convert.ToInt32(numericUpDownR.Text);
            Data.RgbPercentValue.G = Convert.ToInt32(numericUpDownG.Text);
            Data.RgbPercentValue.B = Convert.ToInt32(numericUpDownB.Text);

            foreach (var controller in Controllers)
            {
                var success = controller.SetRGB(Data.RgbPercentValue);
                Debug.WriteLine($"{controller.GetType()} successfully set RGB: {success}");
            }
        }

        // only uninit logitech on app exit else it will reset if we do
        // it on form closing
        private void OnProcessExit(object sender, EventArgs e)
        {
            if (LogitechController.Initialised)
            {
                LogitechController.UnInit();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (RazerController.Initialised)
            {
                RazerController.UnInit();
            }
        }

        private void buttonHue_Click(object sender, EventArgs e)
        {
            if (_bridgeConnector == null)
            {
                _bridgeConnector = new BridgeConnector();
                _bridgeConnector.Changed += BridgeConnectorOnChanged;
                _bridgeConnector.InitConnector();

                buttonHue.Enabled = false;
            }
        }

        private void BridgeConnectorOnChanged(object sender, bool bridgeConnected)
        {
            buttonHue.Text = bridgeConnected ? "Hue Bridge Connected" : "Press Hue Bridge button now";
        }

        /// <summary>
        /// Useful in tests to initialise all controllers without needing to "show" the form
        /// </summary>
        public void InitAll()
        {
            foreach (var controller in Controllers)
            {
                controller.Init();
            }
        }

        public void UnInitAll()
        {
            foreach (var controller in Controllers)
            {
                controller.UnInit();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            InitAll();
        }
    }
}
