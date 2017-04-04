using System;
using System.Diagnostics;
using System.Threading;
using Corale.Colore.Core;
using LedCSharp;

// ReSharper disable InconsistentNaming
namespace RGBSync
{
    public class Controller
    {
        public bool InitialisedLogitech;
        public bool InitialiasedRazer;

        private Chroma _chromaInstance;

        public Controller(IntPtr windowHandle)
        {
            InitialisedLogitech = InitLogitech();
            InitialiasedRazer = InitRazer(windowHandle);
        }

        public bool InitLogitech()
        {
            var success = LogitechGSDK.LogiLedInit();
            Debug.WriteLine("Successfully init Logitech");
            // Logitech recommends waiting inbetween init and doing any other calls
            Thread.Sleep(10000);
            LogitechGSDK.LogiLedSetTargetDevice(LogitechGSDK.LOGI_DEVICETYPE_RGB);
            return success;
        }

        public void ShutdownLogitech()
        {
            LogitechGSDK.LogiLedShutdown();
            Debug.WriteLine("Successfully shutdown Logitech");
        }

        public bool UpdateLogitechRGB(Data.Colour dataRgbPercentValue)
        {
            Debug.WriteLine("Attempting to set Logitech lights");
            return LogitechGSDK.LogiLedSetLighting(dataRgbPercentValue.R, dataRgbPercentValue.G, dataRgbPercentValue.B);
        }

        public bool InitRazer(IntPtr windowHandle)
        {
            if (!Chroma.SdkAvailable) return false;

            Debug.WriteLine("Successfully init Razer");
            _chromaInstance = (Chroma) Chroma.Instance;
            _chromaInstance.Register(windowHandle);
            return true;
        }

        public void ShutdownRazer()
        {
            _chromaInstance.Uninitialize();
            Debug.WriteLine("Successfully shutdown Razer");
        }

        public bool UpdateRazerRGB(Color color)
        {
            try
            {
                _chromaInstance.SetAll(color);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Couldn't set Razer lights");
                return false;
            }
        }
    }
}
