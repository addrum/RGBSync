using System.Diagnostics;
using SharpHue;

namespace RGBSync
{
    public class HueController : Controller
    {
        public LightCollection Lights;

        private BridgeConnector _bridgeConnector;

        public override void Init()
        {
            _bridgeConnector = new BridgeConnector();
            Initialised = _bridgeConnector.InitBridgeConnector();

            if (Initialised)
            {
                CreateLights();
            }
            else
            {
                Debug.WriteLine("Couldn't register any user");
            }
        }

        public override void UnInit() { }

        public void CreateLights()
        {
            if (Lights != null) return;
            Lights = new LightCollection();
            foreach (var light in Lights)
            {
               Debug.WriteLine($"Light: {light.Name}"); 
            }
        } 

        public void UpdateRGB(byte brightness, Light[] lights)
        {
            new LightStateBuilder()
                .For(lights)
                .TurnOn()
                .Brightness(brightness)
                .Apply();
        }
    }
}
