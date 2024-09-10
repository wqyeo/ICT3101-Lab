using NUnit.Framework.Constraints;

namespace ICT3101_Calculator.UnitTests
{
    public class CalculatorTests
    {
        private Calculator _calculator;
        [SetUp]
        public void Setup()
        {
            // Arrange
            _calculator = new Calculator();
        }

        [Test]
        public void Add_WhenAddingTwoNumbers_ResultEqualToSum()
        {
            // Act
            double result = _calculator.Add(10, 20);
            // Assert
            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void Subtract_WhenSubtractTwoNumbers_ResultEqualToDifference()
        {
            double result = _calculator.Subtract(30, 20);
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void Divide_WhenDivideTwoNumbers_ResultEqualToFraction()
        {
            double result = _calculator.Divide(8, 2);
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void Multiply_WhenMultiplyTwoNumbers_ResultEqualToMultiplication()
        {
            double result = _calculator.Multiply(4, 5);
            Assert.That(result, Is.EqualTo(20));
        }


        [Test]
        [TestCase(0, 0)]
        [TestCase(0, 10)]
        [TestCase(10, 0)]
        public void Divide_WithZerosAsInputs_ResultThrowArgumentException(double a, double b) {
            Assert.That(() => _calculator.Divide(a, b), Throws.ArgumentException);
        }


        [TestCase(-100)]
        [TestCase(-10)]
        [TestCase(-1)]
        public void Factorial_WhenNonPositiveAsInputs_ResultsThrowArgumentException(int a)
        {
            Assert.That(() => _calculator.Factorial(a), Throws.ArgumentException);
        }

        [TestCase(4, 24)]
        [TestCase(6, 720)]
        [TestCase(12, 479001600)]
        public void Factorial_WhenInput_ResultsEqualsExpectedFactorial(int input, int expected)
        {
            Assert.That(_calculator.Factorial(input), Is.EqualTo(expected));
        }


        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(-1, -1)]
        [TestCase(1, -1)]
        [TestCase(-1, 1)]
        public void TriangleArea_WhenNonPositiveInputs_ResultsThrowArgumentException(double a, double b)
        {
            Assert.That(() => _calculator.TriangleArea(a, b), Throws.ArgumentException);
        }

        [TestCase(14, 20, 140)]
        [TestCase(33, 22, 363)]
        [TestCase(1, 1, 0.5)]
        public void TriangleArea_WhenCalculating_ResultsEqualsExpectedArea(double length, double height, double expected)
        {
            // Accurate within 2 decimal places.
            double tolerance = 0.01;
            Assert.That(_calculator.TriangleArea(length, height), Is.EqualTo(expected).Within(tolerance));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CircleArea_WhenNonPositiveInputs_ResultsThrowArgumentException(double a)
        {
            Assert.That(() => _calculator.CircleArea(a), Throws.ArgumentException);
        }

        [TestCase(4, 50.27)]
        [TestCase(8, 201.06)]
        [TestCase(1, 3.1416)]
        public void CircleArea_WhenCalculating_ResultsEqualsExpectedArea(double radius, double expected)
        {
            // Accurate within 2 decimal places.
            double tolerance = 0.01;
            Assert.That(_calculator.CircleArea(radius), Is.EqualTo(expected).Within(tolerance));
        }
    }
}