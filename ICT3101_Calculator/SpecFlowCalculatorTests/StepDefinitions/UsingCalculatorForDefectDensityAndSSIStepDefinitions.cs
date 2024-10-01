// UsingCalculatorForDefectDensityAndSSIStepDefinitions.cs
using ICT3101_Calculator;
using NUnit.Framework;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorForDefectDensityAndSSIStepDefinitions
    {
        private Calculator _calculator;
        private double _result;
        private Exception _caughtException;

        public UsingCalculatorForDefectDensityAndSSIStepDefinitions(Calculator calc)
        {
            this._calculator = calc;
        }

        // Step Definition for Defect Density Calculation
        [When(@"I have entered total defects (.*) and total SSI (.*) into the calculator and press defectdensity")]
        public void WhenIHaveEnteredTotalDefectsAndTotalSSIIntoTheCalculatorAndPressDefectDensity(double totalDefects, double totalSSI)
        {
            try
            {
                _result = _calculator.DefectDensity(totalDefects, totalSSI);
            }
            catch (Exception ex)
            {
                _caughtException = ex;
            }
        }

        // Verification Step for Defect Density Result
        [Then(@"the defect density result should be (.*)")]
        public void ThenTheDefectDensityResultShouldBe(double expectedResult)
        {
            Assert.That(_result, Is.EqualTo(expectedResult).Within(0.0001));
        }

        // Error Handling for Defect Density Calculation
        [Then(@"an error should occur while calculating defect density")]
        public void ThenAnErrorShouldOccurWhileCalculatingDefectDensity()
        {
            Assert.That(_caughtException, Is.Not.Null, "Expected an exception but none was thrown.");
            Assert.That(_caughtException.Message, Does.Contain("Total SSI must be greater than zero."));
        }

        // Step Definition for New Total SSI Calculation
        [When(@"I have entered previous SSI (.*) and new SSI (.*) into the calculator and press newssi")]
        public void WhenIHaveEnteredPreviousSSIAndNewSSIIntoTheCalculatorAndPressNewSSI(double previousSSI, double newSSI)
        {
            try
            {
                _result = _calculator.NewTotalSSI(previousSSI, newSSI);
            }
            catch (Exception ex)
            {
                _caughtException = ex;
            }
        }

        // Verification Step for New Total SSI Result
        [Then(@"the new total SSI result should be (.*)")]
        public void ThenTheNewTotalSSIResultShouldBe(double expectedResult)
        {
            Assert.That(_result, Is.EqualTo(expectedResult));
        }
    }
}
