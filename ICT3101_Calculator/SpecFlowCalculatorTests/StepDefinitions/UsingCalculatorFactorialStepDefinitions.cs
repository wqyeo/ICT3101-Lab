// UsingCalculatorFactorialStepDefinitions.cs
using ICT3101_Calculator;
using NUnit.Framework;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorFactorialStepDefinitions
    {
        private Calculator _calculator;
        private double _result;
        private Exception _caughtException;

        public UsingCalculatorFactorialStepDefinitions(Calculator calc)
        {
            this._calculator = calc;
        }

        [When(@"I calculate the factorial of (.*)")]
        public void WhenICalculateTheFactorialOf(int number)
        {
            try
            {
                _result = _calculator.Factorial(number);
            }
            catch (Exception ex)
            {
                _caughtException = ex;
            }
        }

        [Then(@"the factorized result should be (.*)")]
        public void ThenTheResultShouldBe(double expectedResult)
        {
            Assert.That(_result, Is.EqualTo(expectedResult));
        }

        [Then(@"an error should occur while calculating the factorial")]
        public void ThenAnErrorShouldOccur()
        {
            Assert.That(_caughtException, Is.Not.Null, "Expected an exception but none was thrown.");
        }
    }
}
