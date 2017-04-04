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
                return;
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
            }
        }

        public override void UnInit()
        {
            Chroma.Instance.Uninitialize();
            Debug.WriteLine("Successfully shutdown Razer");
        }

        // ReSharper disable once InconsistentNaming
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
