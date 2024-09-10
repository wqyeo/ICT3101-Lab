using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT3101_Calculator.UnitTests
{
    internal class CalculatorStatisticsFunctionsTests
    {
        private Calculator _calculator;
        [SetUp]
        public void Setup()
        {
            // Arrange
            _calculator = new Calculator();
        }

        [Test]
        public void Permutation_WhenGivenTest0_Result()
        {
            // Act
            double result = _calculator.Permutation(5, 5);
            // Assert
            Assert.That(result, Is.EqualTo(120));
        }

        [Test]
        public void Permutation_WhenGivenTest1_Result()
        {
            // Act
            double result = _calculator.Permutation(5, 4);
            // Assert
            Assert.That(result, Is.EqualTo(120));
        }

        [Test]
        public void Permutation_WhenGivenTest2_Result()
        {
            // Act
            double result = _calculator.Permutation(5, 3);
            // Assert
            Assert.That(result, Is.EqualTo(60));
        }

        [Test]
        public void Permutation_WhenGivenTest3_ResultThrowArgumnetException()
        {
            // Act
            // Assert
            Assert.That(() => _calculator.Permutation(-4, 5), Throws.ArgumentException);
        }

        [Test]
        public void Permutation_WhenGivenTest4_ResultThrowArgumnetException()
        {
            // Act
            // Assert
            Assert.That(() => _calculator.Permutation(4, 5), Throws.ArgumentException);
        }

        [Test]
        public void BinomialCoefficient_WhenGivenTest0_Result()
        {
            // Act
            double result = _calculator.BinomialCoefficient(5, 5);
            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void BinomialCoefficient_WhenGivenTest1_Result()
        {
            // Act
            double result = _calculator.BinomialCoefficient(5, 4);
            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void BinomialCoefficient_WhenGivenTest2_Result()
        {
            // Act
            double result = _calculator.BinomialCoefficient(5, 3);
            // Assert
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void BinomialCoefficient_WhenGivenTest3_ResultThrowArgumnetException()
        {
            // Act
            // Assert
            Assert.That(() => _calculator.BinomialCoefficient(-4, 5), Throws.ArgumentException);
        }

        [Test]
        public void BinomialCoefficient_WhenGivenTest4_ResultThrowArgumnetException()
        {
            // Act
            // Assert
            Assert.That(() => _calculator.BinomialCoefficient(4, 5), Throws.ArgumentException);
        }
    }
}
