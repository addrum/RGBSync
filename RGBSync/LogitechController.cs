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
            Debug.WriteLine("Successfully init Logitech");
            // Logitech recommends waiting inbetween init and doing any other calls
            Thread.Sleep(10000);
            LogitechGSDK.LogiLedSetTargetDevice(LogitechGSDK.LOGI_DEVICETYPE_RGB);
        }

        public override void UnInit()
        {
            LogitechGSDK.LogiLedShutdown();
            Debug.WriteLine("Successfully shutdown Logitech");
        }

        // ReSharper disable once InconsistentNaming
        public bool UpdateLogitechRGB(Data.Colour dataRgbPercentValue)
        {
            if (!Initialised)
            {
                throw new UninitializedException("Logitech Controller was not initialized");
            }

            Debug.WriteLine("Attempting to set Logitech lights");
            return LogitechGSDK.LogiLedSetLighting(dataRgbPercentValue.R, dataRgbPercentValue.G, dataRgbPercentValue.B);
        }
    }
}
