namespace Calculator.Tests_NUnit
{
    public class CalcTests
    {
        [Test]
        public void Sum_2_and_3_results_5()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(2, 3);

            //Assert
            Assert.AreEqual(5, result);
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(2, 3, 5)]
        [TestCase(-2, -3, -5)]
        [TestCase(-2, 3, 1)]
        [TestCase(2, -3, -1)]
        public void Sum(int a, int b, int exp)
        {
            var calc = new Calc();

            var result = calc.Sum(a, b);

            Assert.AreEqual(exp, result);
        }

        [Test]
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            var calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }
    }
}