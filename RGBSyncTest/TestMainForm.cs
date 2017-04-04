using Microsoft.VisualStudio.TestTools.UnitTesting;
using RGBSync;

// ReSharper disable InconsistentNaming
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
        public void TestSetLogitechRGB()
        {
            var target = new MainForm();
            Assert.IsTrue(target.Controller.InitialisedLogitech);
            target.Controller.ShutdownLogitech();
        }

        [TestMethod]
        public void TestSetLogitechSetRGB()
        {
            var target = new MainForm();
            Assert.IsTrue(target.Controller.UpdateLogitechRGB(new Data().RgbPercentValue));
            target.Controller.ShutdownLogitech();
        }

        [TestMethod]
        public void TestSetRazerRGB()
        {
            var target = new MainForm();
            Assert.IsTrue(target.Controller.InitialiasedRazer);
            target.Controller.ShutdownRazer();
        }
    }
}
