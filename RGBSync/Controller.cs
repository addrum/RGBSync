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

            try
            {
                Chroma.Instance.Register(windowHandle);
                Debug.WriteLine("Successfully init Razer");
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public void ShutdownRazer()
        {
            Chroma.Instance.Uninitialize();
            Debug.WriteLine("Successfully shutdown Razer");
        }

        public bool UpdateRazerRGB(Color color)
        {
            try
            {
                Debug.WriteLine("Attempting to set Razer lights");
                Chroma.Instance.SetAll(color);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
    }
}
