using System.Threading;
using LedCSharp;

// ReSharper disable InconsistentNaming
namespace RGBSync
{
    public class Controller
    {
        public bool InitialisedLogitech;

        public Controller()
        {
            InitLogitech();
        }

        public bool InitLogitech()
        {
            var success = LogitechGSDK.LogiLedInit();
            Thread.Sleep(10000);
            InitialisedLogitech = success;
            LogitechGSDK.LogiLedSetTargetDevice(LogitechGSDK.LOGI_DEVICETYPE_RGB);
            return success;
        }

        public void ShutdownLogitech()
        {
            LogitechGSDK.LogiLedShutdown();        }

        public bool UpdateLogitechRGB(Data.Colour dataRgbPercentValue)
        {
            return LogitechGSDK.LogiLedSetLighting(dataRgbPercentValue.R, dataRgbPercentValue.G, dataRgbPercentValue.B);
        }
    }
}
