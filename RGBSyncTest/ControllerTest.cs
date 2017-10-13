using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RGBSync;

namespace RGBSyncTest
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void TestInitLogitechRGB()
        {
            var logitechController = new LogitechController();
            logitechController.Init();
            Assert.IsTrue(logitechController.Initialised);
            logitechController.UnInit();
        }

        [TestMethod]
        public void TestUpdateLogitechRGB()
        {
            var logitechController = new LogitechController();
            Assert.IsTrue(logitechController.UpdateLogitechRGB(new Data().RgbPercentValue));
            logitechController.UnInit();
        }

        [TestMethod]
        public void TestInitRazerRGB()
        {
            var target = new Mock<MainForm>();
            var razerController = new RazerController(target.Object.Handle);
            Assert.IsTrue(razerController.Initialised);
            razerController.UnInit();
        }

        [TestMethod]
        public void TestUpdateRazerRGB()
        {
            var target = new Mock<MainForm>();
            var razerController = new RazerController(target.Object.Handle);
            Assert.IsTrue(razerController.UpdateRazerRGB(new Data().RgbPercentValue.ColoreColor()));
            razerController.UnInit();
        }
    }
}
