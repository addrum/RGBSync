using Microsoft.VisualStudio.TestTools.UnitTesting;
using RGBSync;

namespace RGBSyncTest
{
    [TestClass]
    public class TestMainForm
    {
        private const int ExpectedR = 50;
        private const int ExpectedG = 50;
        private const int ExpectedB = 100;

        [TestMethod]
        public void TestDataUpdated()
        {
            var target = new MainForm
            {
                numericUpDownR = {Value = ExpectedR},
                numericUpDownG = {Value = ExpectedG},
                numericUpDownB = {Value = ExpectedB}
            };

            target.buttonUpdate_Click(null, null);

            Assert.AreEqual(ExpectedR, target.Data.RgbPercentValue.R);
            Assert.AreEqual(ExpectedG, target.Data.RgbPercentValue.G);
            Assert.AreEqual(ExpectedB, target.Data.RgbPercentValue.B);
        }

        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void TestSetLogitechRGB()
        {
            var controller = new Controller();
            Assert.IsTrue(controller.InitialisedLogitech);
            controller.ShutdownLogitech();
        }

        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void TestSetLogitechSetRGB()
        {
            var controller = new Controller();
            Assert.IsTrue(controller.UpdateLogitechRGB(new Data().RgbPercentValue));
            controller.ShutdownLogitech();
        }
    }
}
