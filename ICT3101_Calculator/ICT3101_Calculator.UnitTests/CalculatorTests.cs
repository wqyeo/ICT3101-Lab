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

        #region Addition Tests

        // Default example test
        [Test]
        public void Add_WhenAddingTwoNumbers_ResultEqualToSum()
        {
            // Act
            double result = _calculator.Add(10, 20);
            // Assert
            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void Add_WhenAddingNegativeNumbers_ResultEqualToSum()
        {
            // Arrange
            double num1 = -10;
            double num2 = -20;

            // Act
            double result = _calculator.Add(num1, num2);

            // Assert
            Assert.That(result, Is.EqualTo(-30));
        }

        [Test]
        public void Add_WhenAddingTwoNumbers_ResultNotEqualToIncorrectSum()
        {
            // Arrange
            double num1 = 10;
            double num2 = 20;

            // Act
            double result = _calculator.Add(num1, num2);

            // Assert
            Assert.That(result, Is.Not.EqualTo(40));
        }
        #endregion

        #region Subtraction Tests
        [Test]
        public void Subtract_WhenSubtractingTwoNumbers_ResultEqualToDifference()
        {
            // Arrange
            double num1 = 20;
            double num2 = 10;

            // Act
            double result = _calculator.Subtract(num1, num2);

            // Assert
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void Subtract_WhenSubtractingNegativeNumbers_ResultEqualToDifference()
        {
            // Arrange
            double num1 = -20;
            double num2 = -10;

            // Act
            double result = _calculator.Subtract(num1, num2);

            // Assert
            Assert.That(result, Is.EqualTo(-10));
        }

        [Test]
        public void Subtract_WhenSubtractingTwoNumbers_ResultNotEqualToIncorrectDifference()
        {
            // Arrange
            double num1 = 20;
            double num2 = 10;

            // Act
            double result = _calculator.Subtract(num1, num2);

            // Assert
            Assert.That(result, Is.Not.EqualTo(5));
        }
        #endregion

        #region Multiplication Tests
        [Test]
        public void Multiply_WhenMultiplyingTwoNumbers_ResultEqualToProduct()
        {
            // Arrange
            double num1 = 5;
            double num2 = 4;

            // Act
            double result = _calculator.Multiply(num1, num2);

            // Assert
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void Multiply_WhenMultiplyingByNegativeNumber_ResultEqualToProduct()
        {
            // Arrange
            double num1 = -5;
            double num2 = 4;

            // Act
            double result = _calculator.Multiply(num1, num2);

            // Assert
            Assert.That(result, Is.EqualTo(-20));
        }

        [Test]
        public void Multiply_WhenMultiplyingTwoNumbers_ResultNotEqualToIncorrectProduct()
        {
            // Arrange
            double num1 = 5;
            double num2 = 4;

            // Act
            double result = _calculator.Multiply(num1, num2);

            // Assert
            Assert.That(result, Is.Not.EqualTo(25));
        }
        #endregion

        #region Division Tests
        [Test]
        public void Divide_WhenDividingTwoNumbers_ResultEqualToQuotient()
        {
            // Arrange
            double num1 = 20;
            double num2 = 4;

            // Act
            double result = _calculator.Divide(num1, num2);

            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Divide_WhenDividingNegativeNumbers_ResultEqualToQuotient()
        {
            // Arrange
            double num1 = -20;
            double num2 = 4;

            // Act
            double result = _calculator.Divide(num1, num2);

            // Assert
            Assert.That(result, Is.EqualTo(-5));
        }

        [Test]
        public void Divide_WhenDividingTwoNumbers_ResultNotEqualToIncorrectQuotient()
        {
            // Arrange
            double num1 = 20;
            double num2 = 4;

            // Act
            double result = _calculator.Divide(num1, num2);

            // Assert
            Assert.That(result, Is.Not.EqualTo(10));
        }
        #endregion

        #region Factorial Tests

        [Test]
        public void Factorial_WhenInputIsZero_ResultIsOne()
        {
            // Arrange
            double num = 0;

            // Act
            double result = _calculator.Factorial(num);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Factorial_WhenInputIsPositiveNumber_ResultIsFactorial()
        {
            // Arrange
            double num = 5;

            // Act
            double result = _calculator.Factorial(num);

            // Assert
            Assert.That(result, Is.EqualTo(120)); // 5! = 120
        }

        [Test]
        public void Factorial_WhenInputIsNegative_ThrowsArgumentException()
        {
            // Arrange
            double num = -5;

            // Act
            TestDelegate testDelegate = () => _calculator.Factorial(num);

            // Assert
            Assert.That(testDelegate, Throws.ArgumentException);
        }

        #endregion

        #region Divide by 0 results in Infinity Tests
        [Test]
        public void Divide_WithZerosAsInput_ResultIsPositiveInfinity()
        {
            // Arrange
            double num1 = 10;
            double num2 = 0;

            // Act
            double result = _calculator.Divide(num1, num2);

            // Assert
            Assert.That(result, Is.EqualTo(double.PositiveInfinity));
        }
        #endregion

        #region Parameterized Test Cases for testing 0 division and Exception Throwing
        [Test]
        [TestCase(0, 0, 1)]
        [TestCase(0, 10, 0)]
        [TestCase(10, 0, double.PositiveInfinity)]
        public void Divide_WithZerosAsInput_ResultInCustomValue(double num1, double num2, double result)
        {
            // Act
            double actualResult = _calculator.Divide(num1, num2);

            // Assert
            Assert.That(actualResult, Is.EqualTo(result));
        }
        #endregion

        #region Triangle Area Tests

        [Test]
        public void AreaOfTriangle_WhenBaseAndHeightArePositive_ResultIsCorrect()
        {
            // Arrange
            double baseLength = 10;
            double height = 5;

            // Act
            double result = _calculator.AreaOfTriangle(baseLength, height);

            // Assert
            Assert.That(result, Is.EqualTo(25)); // 0.5 * 10 * 5 = 25
        }

        [Test]
        public void AreaOfTriangle_WhenBaseOrHeightIsZero_ResultIsZero()
        {
            // Arrange
            double baseLength = 0;
            double height = 5;

            // Act
            double result = _calculator.AreaOfTriangle(baseLength, height);

            // Assert
            Assert.That(result, Is.EqualTo(0)); // Area is 0 if base or height is 0
        }

        [Test]
        public void AreaOfTriangle_WhenBaseOrHeightIsNegative_ThrowsArgumentException()
        {
            // Arrange
            double baseLength = -10;
            double height = 5;

            // Act
            TestDelegate testDelegate = () => _calculator.AreaOfTriangle(baseLength, height);

            // Assert
            Assert.That(testDelegate, Throws.ArgumentException);
        }

        #endregion

        #region Circle Area Tests

        [Test]
        public void AreaOfCircle_WhenRadiusIsPositive_ResultIsCorrect()
        {
            // Arrange
            double radius = 7;

            // Act
            double result = _calculator.AreaOfCircle(radius);

            // Assert
            Assert.That(result, Is.EqualTo(Math.PI * radius * radius));
        }

        [Test]
        public void AreaOfCircle_WhenRadiusIsZero_ResultIsZero()
        {
            // Arrange
            double radius = 0;

            // Act
            double result = _calculator.AreaOfCircle(radius);

            // Assert
            Assert.That(result, Is.EqualTo(0)); // Area is 0 if radius is 0
        }

        [Test]
        public void AreaOfCircle_WhenRadiusIsNegative_ThrowsArgumentException()
        {
            // Arrange
            double radius = -7;

            // Act
            TestDelegate testDelegate = () => _calculator.AreaOfCircle(radius);

            // Assert
            Assert.That(testDelegate, Throws.ArgumentException);
        }

        #endregion
    }
}
