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

            target.UnInitAll();
        }

        [TestMethod]
        public void TestInitLogitechRGB()
        {
            var target = new MainForm();
            Assert.IsTrue(target.LogitechController.Initialised);
            target.LogitechController.UnInit();
        }

        [TestMethod]
        public void TestUpdateLogitechRGB()
        {
            var target = new MainForm();
            Assert.IsTrue(target.LogitechController.UpdateLogitechRGB(new Data().RgbPercentValue));
            target.LogitechController.UnInit();
        }

        [TestMethod]
        public void TestInitRazerRGB()
        {
            var target = new MainForm();
            Assert.IsTrue(target.RazerController.Initialised);
            target.RazerController.UnInit();
        }

        [TestMethod]
        public void TestUpdateRazerRGB()
        {
            var target = new MainForm();
            Assert.IsTrue(target.RazerController.UpdateRazerRGB(new Data().RgbPercentValue.ColoreColor()));
            target.RazerController.UnInit();
        }
    }
}
