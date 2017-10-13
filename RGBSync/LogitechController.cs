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
                throw new UninitializedException("LogitechController was not initialized");
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
                throw new UninitializedException($"LogitechController was not unitialized: {e.Message}");
            }
        }

        // ReSharper disable once InconsistentNaming
        public bool UpdateLogitechRGB(Data.Colour dataRgbPercentValue)
        {
            if (!Initialised)
            {
                throw new UninitializedException("LogitechController was not initialized");
            }

            Debug.WriteLine("Attempting to set Logitech lights");
            return LogitechGSDK.LogiLedSetLighting(dataRgbPercentValue.R, dataRgbPercentValue.G, dataRgbPercentValue.B);
        }
    }
}
