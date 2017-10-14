using System.Diagnostics;
using SharpHue;

namespace RGBSync
{
    public class HueController : Controller
    {
        public LightCollection Lights;
        public IConnector BridgeConnector;

        public override void Init()
        {
            BridgeConnector = BridgeConnector ?? new BridgeConnector();
            try
            {
                Initialised = BridgeConnector.InitConnector();
            }
            catch (ConnectionException e)
            {
                Debug.WriteLine(e);
                throw new InitializationException($"HueConnector was not initialized {e.Message}");
            }

            if (Initialised)
            {
                try
                {
                    CreateLights();
                }
                catch (HueConfigurationException e)
                {
                    Initialised = false;
                    Debug.WriteLine(e);
                    throw new InitializationException($"HueController was initialized but couldn't CreateLights: {e.Message}");
                }
            }
            else
            {
                throw new InitializationException("HueController was not intialized");
            }
        }

        public override void UnInit() { }

        public void CreateLights()
        {
            if (!Initialised)
            {
                throw new InitializationException("HueController was not itialized");
            }

            if (Lights != null) return;
            Lights = new LightCollection();
            foreach (var light in Lights)
            {
               Debug.WriteLine($"Light: {light.Name}"); 
            }
        } 

        public override bool SetRGB(Data.Colour dataRgbPercentValue)
        {
            return false;
            //byte brightness, Light[] lights
            if (!Initialised)
            {
                throw new InitializationException("HueController was not unitialized");
            }

            //new LightStateBuilder()
            //    .For(lights)
            //    .TurnOn()
            //    .Brightness(brightness)
            //    .Apply();
        }
    }
}
