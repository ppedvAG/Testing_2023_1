using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Sum_2_and_3_results_5()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(2, 3);

            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Sum_10_and_6_results_16()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(10, 6);

            //Assert
            Assert.AreEqual(16, result);
            //throw new NotImplementedException();
        }

        [TestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(2, 3, 5)]
        [DataRow(-2, -3, -5)]
        [DataRow(-2, 3, 1)]
        [DataRow(2, -3, -1)]
        public void Sum(int a, int b, int exp)
        {
            var calc = new Calc();

            var result = calc.Sum(a, b);

            Assert.AreEqual(exp, result);
        }

        [TestMethod]
        [TestCategory("ExceptionTest")]
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            var calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }



    }
}