using Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DataGeneratorTests
    {
        [TestMethod]
        public void CheckDNIHasCorrectLength()
        {
            var dni = DataGenerator.GetInstance().GenerateDNI();
            Assert.IsFalse(dni.Length == 9);
        }

        [TestMethod]
        public void CheckDNIIsCorrect()
        {
            var dni = "12345678Z";
            Assert.IsTrue(DataGenerator.GetInstance().CheckDniIsCorrect(dni));
        }

        [TestMethod]
        public void CheckDNIsIsIncorrect()
        {
            var dni = "12345678H";
            Assert.IsFalse(DataGenerator.GetInstance().CheckDniIsCorrect(dni));
        }

        [TestMethod]
        public void CheckDNINotInOrder()
        {
            var dni = "12345H678";
            Assert.IsFalse(DataGenerator.GetInstance().CheckDniIsCorrect(dni));
        }

        [TestMethod]
        public void CheckDNIAllLetters()
        {
            var dni = "sololetra";
            Assert.IsFalse(DataGenerator.GetInstance().CheckDniIsCorrect(dni));
        }

        [TestMethod]
        public void CheckDNIForeigner()
        {
            var dni = "12345665Y";
            Assert.IsTrue(DataGenerator.GetInstance().CheckDniIsCorrect(dni));
        }
    }
}
