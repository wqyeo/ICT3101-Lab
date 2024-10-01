using ICT3101_Calculator;
using NUnit.Framework;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorBasicReliabilityStepDefinitions
    {
        private Calculator _calculator;
        private double _result;
        private Exception _caughtException;

        public UsingCalculatorBasicReliabilityStepDefinitions(Calculator calc)
        {
            this._calculator = calc;
        }

        [When(@"I have entered initial failure intensity (.*), total expected failures (.*), and time (.*) into the calculator and press cfi")]
        public void WhenIHaveEnteredInitialFailureIntensityTotalExpectedFailuresAndTimeIntoTheCalculatorAndPressCfi(double lambda0, double mu0, double tau)
        {
            try
            {
                _result = _calculator.CurrentFailureIntensity(lambda0, mu0, tau);
            }
            catch (Exception ex)
            {
                _caughtException = ex;
            }
        }

        [When(@"I have entered initial failure intensity (.*), total expected failures (.*), and time (.*) into the calculator and press anef")]
        public void WhenIHaveEnteredInitialFailureIntensityTotalExpectedFailuresAndTimeIntoTheCalculatorAndPressAnef(double lambda0, double mu0, double tau)
        {
            try
            {
                _result = _calculator.AverageExpectedFailures(lambda0, mu0, tau);
            }
            catch (Exception ex)
            {
                _caughtException = ex;
            }
        }

        [Then(@"the failure intensity result should be (.*)")]
        public void ThenTheFailureIntensityResultShouldBe(double expectedResult)
        {
            Assert.That(_result, Is.EqualTo(expectedResult).Within(0.0001));
        }

        [Then(@"the expected failures result should be (.*)")]
        public void ThenTheExpectedFailuresResultShouldBe(double expectedResult)
        {
            Assert.That(_result, Is.EqualTo(expectedResult).Within(0.0001));
        }

        [Then(@"an error should occur while calculating failure intensity")]
        public void ThenAnErrorShouldOccurWhileCalculatingFailureIntensity()
        {
            Assert.That(_caughtException, Is.Not.Null, "Expected an exception but none was thrown.");
            Assert.That(_caughtException.Message, Does.Contain("Time cannot be negative."));
        }
    }
}
