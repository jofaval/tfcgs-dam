using Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataIntegrityTests
{
    [TestClass]
    public class DataIntegrityTest
    {
        [TestMethod]
        public void CheckDataIntegritySQLInjectionV1()
        {
            var testPassword = "OR 1=1";
            var state = DataIntegrityChecker.CheckDataIntegrity(testPassword);
            Assert.IsFalse(state);
        }

        [TestMethod]
        public void CheckDataIntegritySQLInjectionV2()
        {
            var testPassword = ";DROP TABLE DATOS";
            var state = DataIntegrityChecker.CheckDataIntegrity(testPassword);
            Assert.IsFalse(state);
        }

        [TestMethod]
        public void CheckDataIntegrityTrue()
        {
            var testPassword = "bdatos.tabla.campo.dato**";
            var state = DataIntegrityChecker.CheckDataIntegrity(testPassword);
            Assert.IsTrue(state);
        }

        [TestMethod]
        public void CheckPasswordStrengthLevel1()
        {
            var testPassword = "pas";
            var level = DataIntegrityChecker.CheckPasswordStrengthLevel(testPassword);
            var expectedLevel = 1;
            Assert.AreEqual(expectedLevel, level);
        }

        [TestMethod]
        public void CheckPasswordStrengthLevel2()
        {
            var testPassword = "password";
            var level = DataIntegrityChecker.CheckPasswordStrengthLevel(testPassword);
            var expectedLevel = 2;
            Assert.AreEqual(expectedLevel, level);
        }

        [TestMethod]
        public void CheckPasswordStrengthLevel3()
        {
            var testPassword = "PaSsWoRd";
            var level = DataIntegrityChecker.CheckPasswordStrengthLevel(testPassword);
            var expectedLevel = 3;
            Assert.AreEqual(expectedLevel, level);
        }

        [TestMethod]
        public void CheckPasswordStrengthLevel4()
        {
            var testPassword = "PaSsWoRd1";
            var level = DataIntegrityChecker.CheckPasswordStrengthLevel(testPassword);
            var expectedLevel = 4;
            Assert.AreEqual(expectedLevel, level);
        }

        [TestMethod]
        public void CheckPasswordStrengthLevel5()
        {
            var testPassword = "PaSsWoRd1**";
            var level = DataIntegrityChecker.CheckPasswordStrengthLevel(testPassword);
            var expectedLevel = 5;
            Assert.AreEqual(expectedLevel, level);
        }

        [TestMethod]
        public void CheckPasswordStrengthLevel0()
        {
            var testPassword = "1234";
            var level = DataIntegrityChecker.CheckPasswordStrengthLevel(testPassword);
            var expectedLevel = 0;
            Assert.AreEqual(expectedLevel, level);
        }

        [TestMethod]
        public void CheckUsernameIntegrityNotEnoughCharacters()
        {
            var testUsername = "nop";
            var state = DataIntegrityChecker.CheckUsernameIntegrity(testUsername);
            Assert.IsFalse(state);
        }

        [TestMethod]
        public void CheckUsernameIntegrityTooManyCharacters()
        {
            var testUsername = "demasiadoscaracteres";
            var state = DataIntegrityChecker.CheckUsernameIntegrity(testUsername);
            Assert.IsFalse(state);
        }

        [TestMethod]
        public void CheckUsernameIntegrityGoodCombination()
        {
            var testUsername = "username.1234";
            var state = DataIntegrityChecker.CheckUsernameIntegrity(testUsername);
            Assert.IsTrue(state);
        }

        [TestMethod]
        public void CheckUsernameIntegrityBadCombination()
        {
            var testUsername = "username*;1234";
            var state = DataIntegrityChecker.CheckUsernameIntegrity(testUsername);
            Assert.IsFalse(state);
        }

        //DataGenerator
        [TestMethod]
        public void CheckBadEmail()
        {
            var testEmail = "mi@email@.com";
            var state = DataIntegrityChecker.CheckEmail(testEmail);
            Assert.IsFalse(state);
        }

        [TestMethod]
        public void CheckGoodEmail()
        {
            var testEmail = "mi@email.com";
            testEmail = DataGenerator.GetInstance().GenerateEmail();
            var state = DataIntegrityChecker.CheckEmail(testEmail);
            Assert.IsTrue(state);
        }

        [TestMethod]
        public void CheckGeneratedUsername()
        {
            var testUsername = DataGenerator.GetInstance().GenerateUsername();
            var state = DataIntegrityChecker.CheckUsernameIntegrity(testUsername);
            Assert.IsTrue(state);
        }
    }
}
