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
                throw new UninitializedException("RazerController was not initialized: Chrome SDK not available");
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
                throw new UninitializedException($"RazerController was not initialized: {e.Message}");
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
                throw new UninitializedException($"RazerController was not unitialized: {e.Message}");
            }
        }

        // ReSharper disable once InconsistentNaming
        public bool UpdateRazerRGB(Color color)
        {
            if (!Initialised)
            {
                throw new UninitializedException("RazerController was not initalized");
            }

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
