// UsingCalculatorAvailabilityStepDefinitions.cs
using ICT3101_Calculator;
using NUnit.Framework;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorAvailabilityStepDefinitions
    {
        private Calculator _calculator;
        private double _result;
        private Exception _caughtException;

        public UsingCalculatorAvailabilityStepDefinitions(Calculator calc)
        {
            this._calculator = calc;
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press MTBF")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressMTBF(double operationalTime, double failures)
        {
            try
            {
                _result = _calculator.MTBF(operationalTime, failures);
            }
            catch (Exception ex)
            {
                _caughtException = ex;
            }
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press avail")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressAvail(double mtbf, double mttr)
        {
            try
            {
                _result = _calculator.Availability(mtbf, mttr);
            }
            catch (Exception ex)
            {
                _caughtException = ex;
            }
        }

        [Then(@"the MTBF result should be (.*)")]
        public void ThenTheMTBFResultShouldBe(double expectedResult)
        {
            Assert.That(_result, Is.EqualTo(expectedResult));
        }

        [Then(@"the availability result should be (.*)")]
        public void ThenTheAvailabilityResultShouldBe(double expectedResult)
        {
            Assert.That(_result, Is.EqualTo(expectedResult));
        }

        [Then(@"an error should occur while calculating MTBF")]
        public void ThenAnErrorShouldOccurWhileCalculatingMTBF()
        {
            Assert.That(_caughtException, Is.Not.Null, "Expected an exception but none was thrown.");
            Assert.That(_caughtException.Message, Does.Contain("Number of failures must be greater than zero."));
        }
    }
}
