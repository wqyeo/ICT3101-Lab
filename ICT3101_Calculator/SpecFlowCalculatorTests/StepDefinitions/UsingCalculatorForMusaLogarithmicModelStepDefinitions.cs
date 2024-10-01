// UsingCalculatorForMusaLogarithmicModelStepDefinitions.cs
using ICT3101_Calculator;
using NUnit.Framework;
using System.Globalization;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorForMusaLogarithmicModelStepDefinitions
    {
        private Calculator _calculator;
        private double _result;
        private Exception _caughtException;

        public UsingCalculatorForMusaLogarithmicModelStepDefinitions(Calculator calc)
        {
            this._calculator = calc;
            // Set the culture to InvariantCulture to ensure consistent number parsing
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        // Step Definition for Failure Intensity Calculation
        [When(@"I have entered initial failure intensity (.*), fault exposure ratio (.*), and execution time (.*) into the calculator and press musaFI")]
        public void WhenIHaveEnteredInitialFailureIntensityFaultExposureRatioAndExecutionTimeIntoTheCalculatorAndPressMusaFI(double lambda0, double phi, double t)
        {
            try
            {
                _result = _calculator.MusaLogModelFailureIntensity(lambda0, phi, t);
            }
            catch (Exception ex)
            {
                _caughtException = ex;
            }
        }

        // Verification Step for Failure Intensity Result
        [Then(@"the Musa Logarithmic model failure intensity result should be approximately (-?\d+\.?\d*)")]
        public void ThenTheMusaLogFailureIntensityResultShouldBeApproximately(double expectedResult)
        {
            Assert.That(_result, Is.EqualTo(expectedResult).Within(0.0001));
        }

        // Step Definition for Expected Failures Calculation
        [When(@"I have entered total expected failures (.*), fault exposure ratio (.*), and execution time (.*) into the calculator and press musaEF")]
        public void WhenIHaveEnteredTotalExpectedFailuresFaultExposureRatioAndExecutionTimeIntoTheCalculatorAndPressMusaEF(double N0, double phi, double t)
        {
            try
            {
                _result = _calculator.MusaLogModelExpectedFailures(N0, phi, t);
            }
            catch (Exception ex)
            {
                _caughtException = ex;
            }
        }

        // Verification Step for Expected Failures Result
        [Then(@"the Musa Logarithmic model expected number of failures result should be approximately (-?\d+\.?\d*)")]
        public void ThenTheMusaLogExpectedFailuresResultShouldBeApproximately(double expectedResult)
        {
            Assert.That(_result, Is.EqualTo(expectedResult).Within(0.0001));
        }

        // Error Handling for Negative Execution Time
        [Then(@"an error should occur while calculating failure intensity using Musa Logarithmic model")]
        public void ThenAnErrorShouldOccurWhileCalculatingFailureIntensityUsingMusaLogModel()
        {
            Assert.That(_caughtException, Is.Not.Null, "Expected an exception but none was thrown.");
            Assert.That(_caughtException.Message, Does.Contain("Execution time cannot be negative."));
        }
    }
}
