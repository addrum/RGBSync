using System.Configuration;
using System.Diagnostics;
using System.Timers;
using RGBSync.Properties;
using SharpHue;

namespace RGBSync
{
    public sealed class BridgeConnector : IConnector
    {
        public delegate void BridgeConnectedHandler(object sender, bool bridgeConnected);

        public bool InitConnector()
        {
            var userRegistered = false;
            //var userRegistered = InitialiseExistingUser();

            if (!userRegistered)
            {
                Debug.WriteLine("Couldn't register existing user, attempting to register new user...");
                userRegistered = RegisterNewUser();
            }

            return userRegistered;
        }

        private bool InitialiseExistingUser()
        {
            try
            {
                var username = Settings.Default["Username"].ToString();
                if (string.IsNullOrEmpty(username))
                {
                    throw new ConnectionException("BridgeConnector found username was empty");
                }
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

        private void OnChanged(bool bridgeConnected)
        {
            Changed?.Invoke(this, bridgeConnected);
        }
    }
}
