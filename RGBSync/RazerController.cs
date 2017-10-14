using System;
using System.Diagnostics;
using Corale.Colore.Core;

namespace RGBSync
{
    public class RazerController : Controller
    {
        public IntPtr WindowHandle;

        public RazerController(IntPtr windowHandle)
        {
            WindowHandle = windowHandle;
        }

        public override void Init()
        {
            if (!Chroma.SdkAvailable)
            {
                throw new InitializationException("RazerController was not initialized: Chrome SDK not available");
            }

            try
            {
                Chroma.Instance.Register(WindowHandle);
                Debug.WriteLine("Successfully init Razer");
                Initialised = true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw new InitializationException($"RazerController was not initialized: {e.Message}");
            }
        }

        public override void UnInit()
        {
            try
            {
                Chroma.Instance.Unregister();
                Chroma.Instance.Uninitialize();
                Debug.WriteLine("Successfully shutdown Razer");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw new InitializationException($"RazerController was not unitialized: {e.Message}");
            }
        }

        public override bool SetRGB(Data.Colour dataRgbPercentValue)
        {
            if (!Initialised)
            {
                throw new InitializationException("RazerController was not initalized");
            }

            try
            {
                Debug.WriteLine("Attempting to set Razer lights");
                Chroma.Instance.SetAll(dataRgbPercentValue.ColoreColor());
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw new RGBSetException($"RazerController couldn't set RGB: {e.Message}");
            }
        }
    }
}
