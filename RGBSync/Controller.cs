using System;
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
            // Logitech recommends waiting inbetween init and doing any other calls
            Thread.Sleep(10000);
            LogitechGSDK.LogiLedSetTargetDevice(LogitechGSDK.LOGI_DEVICETYPE_RGB);
            return success;
        }

        public void ShutdownLogitech()
        {
            LogitechGSDK.LogiLedShutdown();
        }

        public bool UpdateLogitechRGB(Data.Colour dataRgbPercentValue)
        {
            return LogitechGSDK.LogiLedSetLighting(dataRgbPercentValue.R, dataRgbPercentValue.G, dataRgbPercentValue.B);
        }

        public bool InitRazer(IntPtr windowHandle)
        {
            if (!Chroma.SdkAvailable) return false;

            _chromaInstance = (Chroma) Chroma.Instance;
            _chromaInstance.Register(windowHandle);
            return true;
        }

        public void ShutdownRazer()
        {
            _chromaInstance.Uninitialize();
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
                return false;
            }
        }
    }
}
