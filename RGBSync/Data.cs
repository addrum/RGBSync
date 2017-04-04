using Corale.Colore.Core;

namespace RGBSync
{
    public class Data
    {
        public Colour RgbPercentValue;

        public Data()
        {
            RgbPercentValue = new Colour(100, 100, 100);
        }

        public struct Colour
        {
            public int R;
            public int G;
            public int B;

            public Colour(int r, int g, int b)
            {
                R = r;
                G = g;
                B = b;
            }

            public Color ColoreColor()
            {
                var r = R / 100;
                var g = G / 100;
                var b = B / 100;

                return new Color(r, g, b);
            }
        }
    }
}
