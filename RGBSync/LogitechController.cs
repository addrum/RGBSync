using System;
using System.Diagnostics;
using System.Threading;
using LedCSharp;

namespace RGBSync
{
    public class LogitechController : Controller
    {
        public override void Init()
        {
            Initialised = LogitechGSDK.LogiLedInit();
            if (Initialised)
            {
                Debug.WriteLine("Successfully init Logitech");
                // Logitech recommends waiting inbetween init and doing any other calls
                Thread.Sleep(10000);
                LogitechGSDK.LogiLedSetTargetDevice(LogitechGSDK.LOGI_DEVICETYPE_RGB);
            }
            else
            {
                throw new InitializationException("LogitechController was not initialized");
            }
        }

        public override void UnInit()
        {
            try
            {
                LogitechGSDK.LogiLedShutdown();
                Debug.WriteLine("Successfully shutdown Logitech");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw new InitializationException($"LogitechController was not unitialized: {e.Message}");
            }
        }

        public override bool SetRGB(Data.Colour dataRgbPercentValue)
        {
            if (!Initialised)
            {
                throw new InitializationException("LogitechController was not initialized");
            }

            Debug.WriteLine("Attempting to set Logitech lights");
            if (LogitechGSDK.LogiLedSetLighting(dataRgbPercentValue.R, dataRgbPercentValue.G, dataRgbPercentValue.B))
            {
                return LogitechGSDK.LogiLedSaveCurrentLighting();
            }
            throw new RGBSetException("LogitechController couldn't set RGB");
        }
    }
}
