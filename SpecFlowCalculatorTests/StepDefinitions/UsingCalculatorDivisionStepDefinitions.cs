using ICT3101_Calculator;
using NUnit.Framework;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorDivisionStepDefinitions
    {
        private Calculator _calculator;
        private double _result;
        private Exception _caughtException;

        public UsingCalculatorDivisionStepDefinitions(Calculator calc)
        {
            this._calculator = calc;
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press divide")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressDivide(double p0, double p1)
        {
            try
            {
                _result = _calculator.Divide(p0, p1);
                _caughtException = null;
            }
            catch (Exception ex)
            {
                _caughtException = ex;
            }
        }

        [Then(@"the division result should be (.*)")]
        public void ThenTheDivisionResultShouldBe(double expectedResult)
        {
            Assert.IsNull(_caughtException, "Expected no exception, but an exception was caught.");
            Assert.That(_result, Is.EqualTo(expectedResult));
        }

        [Then(@"the division result equals argument_exception")]
        public void ThenTheDivisionResultEqualsArgumentException()
        {
            Assert.IsNotNull(_caughtException, "Expected an exception, but no exception was caught.");
            Assert.That(_caughtException, Is.TypeOf<ArgumentException>());
        }
    }
}
