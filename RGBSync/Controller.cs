namespace RGBSync
{
    public abstract class Controller
    {
        public bool Initialised;

        public abstract void Init();
        public abstract void UnInit();
        public abstract bool SetRGB(Data.Colour dataRgbPercentValue);
    }
}
