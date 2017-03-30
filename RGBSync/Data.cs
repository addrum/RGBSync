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
        }
    }
}
