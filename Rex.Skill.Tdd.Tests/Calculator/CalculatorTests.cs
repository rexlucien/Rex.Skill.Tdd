using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Rex.Skill.Tdd.Calculator;

namespace Rex.Skill.Tdd.Tests.Calculator
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Tdd.Calculator.Calculator cal = new Tdd.Calculator.Calculator();
            const int mian = 1;
            const int sub = 2;

            int result = cal.Add(mian, sub);

            Assert.AreEqual(3, result);
        }

        [TestMethod()]
        public void AddNsubTest()
        {
            const int mian = 1;
            const int sub = 2;
            ICalculator cal = Substitute.For<ICalculator>();
            cal.Add(1, 2).Returns(3);

            int result = cal.Add(mian, sub);

            Assert.AreEqual(3, result);
        }
    }
}