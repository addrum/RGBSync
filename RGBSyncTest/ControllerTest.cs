using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RGBSync;

namespace RGBSyncTest
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod, TestCategory("logitech")]
        public void TestInitLogitechRGB()
        {
            var logitechController = new LogitechController();
            logitechController.Init();
            Assert.IsTrue(logitechController.Initialised);
            logitechController.UnInit();
        }

        [TestMethod, TestCategory("logitech")]
        public void TestUpdateLogitechRGB()
        {
            var logitechController = new LogitechController();
            logitechController.Init();
            Assert.IsTrue(logitechController.SetRGB(new Data().RgbPercentValue));
            logitechController.UnInit();
        }

        [TestMethod, TestCategory("razer")]
        public void TestInitRazerRGB()
        {
            var target = new MainForm();
            var razerController = new RazerController(target.Handle);
            razerController.Init();
            Assert.IsTrue(razerController.Initialised);
            razerController.UnInit();
        }

        [TestMethod, TestCategory("razer")]
        public void TestUpdateRazerRGB()
        {
            var target = new MainForm();
            var razerController = new RazerController(target.Handle);
            razerController.Init();
            Assert.IsTrue(razerController.SetRGB(new Data().RgbPercentValue));
            razerController.UnInit();
        }
    }
}
