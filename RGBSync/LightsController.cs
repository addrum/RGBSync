using System.Collections.Generic;
using System.Diagnostics;
using SharpHue;

namespace RGBSync
{
    public class LightsController
    {
        private LightCollection _lights;

        public void CreateLights()
        {
            if (_lights != null) return;
            _lights = new LightCollection();
            foreach (var light in _lights)
            {
               Debug.WriteLine($"Light: {light.Name}"); 
            }
        } 

        public void SetLights(byte brightness, Light[] lights)
        {
            new LightStateBuilder()
                .For(lights)
                .TurnOn()
                .Brightness(brightness)
                .Apply();
        }
    }
}
