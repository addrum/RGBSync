using System;
using System.Configuration;
using System.Diagnostics;
using System.Timers;
using RGBSync.Properties;
using SharpHue;

namespace RGBSync
{
    public class BridgeConnector
    {
        public LightsController LightsController;

        public delegate void BridgeConnectedHandler(object sender, bool bridgeConnected);

        public bool InitBridgeConnector()
        {
            //var userRegistered = false;
            var userRegistered = InitialiseExistingUser();

            if (!userRegistered)
            {
                Debug.WriteLine("Couldn't register existing user, attempting to register new user...");
                userRegistered = RegisterNewUser();
            }

            if (userRegistered)
            {
                LightsController = new LightsController();
                LightsController.CreateLights();
            }
            else
            {
                Debug.WriteLine("Couldn't register any user");
            }
            return userRegistered;
        }

        private bool InitialiseExistingUser()
        {
            try
            {
                var username = Settings.Default["Username"].ToString();
                Configuration.Initialize(username);
                Debug.WriteLine($"Initialised Hue connection with user: {Configuration.Username}");
                OnChanged(true);
                return true;
            }
            catch (HueApiException e)
            {
                Debug.WriteLine(e.Message);
            }
            catch (SettingsPropertyNotFoundException e)
            {
                Debug.WriteLine(e.Message);
            }
            return false;
        }

        private bool RegisterNewUser()
        {
            Debug.WriteLine("Press button on hue bridge now!");
            OnChanged(false);
            var timer = new Timer {Interval = 30000};
            timer.Start();

            var linked = false;
            while (!linked && timer.Enabled)
            {
                try
                {
                    Configuration.AddUser("HueAudioSync");
                    Settings.Default["Username"] = Configuration.Username;
                    Settings.Default.Save();
                    linked = true;
                    timer.Stop();
                    Debug.WriteLine("Bridge linked!");
                    OnChanged(true);
                    return true;
                }
                catch (HueApiException e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            return false;
        }

        public event BridgeConnectedHandler Changed;

        protected virtual void OnChanged(bool bridgeConnected)
        {
            Changed?.Invoke(this, bridgeConnected);
        }
    }
}
