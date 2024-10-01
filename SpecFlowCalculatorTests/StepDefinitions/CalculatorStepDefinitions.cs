using ICT3101_Calculator;
using NUnit.Framework;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        [Binding]
        public sealed class UsingCalculatorStepDefinitions
        {
            private double _defectDensity;
            private double _totalSSI;
            private double _failureIntensity;
            private double _expectedFailures;

            private int _totalDefects;
            private int _totalLinesOfCode;

            private Calculator _calculator;
            private double _result;
            [Given(@"I have a calculator")]
            public void GivenIHaveACalculator()
            {
                _calculator = new Calculator();
            }
            [When(@"I have entered (.*) and (.*) into the calculator and press add")]
            public void WhenIHaveEnteredAndIntoTheCalculator(double p0, double p1)
            {
                _result = _calculator.Add(p0, p1);
            }
            [Then(@"the result should be (.*)")]
            public void ThenTheResultShouldBeOnTheScreen(int p0)
            {
                Assert.That(_result, Is.EqualTo(p0));
            }

            [When(@"I have a total number of defects as (.*)")]
            public void GivenIHaveATotalNumberOfDefectsAs(int totalDefects)
            {
                _totalDefects = totalDefects;
            }

            [When(@"I have a total lines of code as (.*)")]
            public void GivenIHaveATotalLinesOfCodeAs(int totalLinesOfCode)
            {
                _totalLinesOfCode = totalLinesOfCode;
            }

            [When(@"I calculate the defect density")]
            public void WhenICalculateTheDefectDensity()
            {
                _defectDensity = _calculator.CalculateDefectDensity(_totalDefects, _totalLinesOfCode);
            }

            [Then(@"the defect density should be (.*)")]
            public void ThenTheDefectDensityShouldBe(double expectedDensity)
            {
                Assert.That(_defectDensity, Is.EqualTo(expectedDensity).Within(0.001));
            }

            [When(@"I have the SSI for the first release as (.*)")]
            public void GivenIHaveTheSSIForTheFirstReleaseAs(int firstReleaseSSI)
            {
                _totalSSI = firstReleaseSSI;
            }

            [When(@"I have the SSI for the second release as (.*)")]
            public void GivenIHaveTheSSIForTheSecondReleaseAs(int secondReleaseSSI)
            {
                _totalSSI += secondReleaseSSI;
            }

            [When(@"I calculate the total SSI")]
            public void WhenICalculateTheTotalSSI()
            {
            }

            [Then(@"the total SSI should be (.*)")]
            public void ThenTheTotalSSIShouldBe(double expectedSSI)
            {
                Assert.That(_totalSSI, Is.EqualTo(expectedSSI).Within(0.001));
            }

            [When(@"I have a total number of failures as (.*)")]
            public void GivenIHaveATotalNumberOfFailuresAs(int totalFailures)
            {
                _failureIntensity = totalFailures;
            }

            [When(@"I have a total time as (.*)")]
            public void GivenIHaveATotalTimeAs(double totalTime)
            {
                _failureIntensity = _calculator.CalculateFailureIntensity((int)_failureIntensity, totalTime);
            }

            [When(@"I have the time period as (.*)")]
            public void GivenIHaveTheTimePeriodAs(double timePeriod)
            {
                _expectedFailures = _calculator.CalculateExpectedFailures(_failureIntensity, timePeriod);
            }

            [When(@"I calculate failure intensity and expected failures")]
            public void WhenICalculateFailureIntensityAndExpectedFailures()
            {
            }

            [Then(@"the failure intensity should be (.*)")]
            public void ThenTheFailureIntensityShouldBe(double expectedIntensity)
            {
                Assert.That(_failureIntensity, Is.EqualTo(expectedIntensity).Within(0.001));
            }

            [Then(@"the expected failures should be (.*)")]
            public void ThenTheExpectedFailuresShouldBe(double expectedFailures)
            {
                Assert.That(_expectedFailures, Is.EqualTo(expectedFailures).Within(0.001));
            }
        }
    }
}
