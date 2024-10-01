using ICT3101_Calculator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorAvailabilityStepDefinitions
    {
        private Calculator _calculator;
        private double _result;

        public UsingCalculatorAvailabilityStepDefinitions(Calculator calc)
        {
            this._calculator = calc;
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press MTBF")]
        public void WhenIHaveEnteredMTBFIntoTheCalculator(double p0, int p1)
        {
            _result = _calculator.CalculateMTBF(p0, p1);
        }

        [When(@"I have entered (.*), (.*) and (.*) into the calculator and press Availability")]
        public void WhenIHaveEnteredAvailabilityIntoTheCalculator(double p0, int p1, double p2)
        {
            _result = _calculator.CalculateAvailability(p0, p1, p2);
        }

        [Then(@"the availability result should be (.*)")]
        public void ThenTheResultShouldBeOnTheScreen(double p0)
        {
            double tolerance = 0.001;
            Assert.That(_result, Is.EqualTo(p0).Within(tolerance));
        }

        [When(@"I have entered the total number of failures as (.*) and the total time as (.*)")]
        public void WhenIHaveEnteredTheTotalNumberOfFailuresAndTotalTime(int totalFailures, double totalTime)
        {
            _result = _calculator.CalculateCurrentFailureIntensity(totalFailures, totalTime);
        }

        [Then(@"the current failure intensity result should be (.*)")]
        public void ThenTheCurrentFailureIntensityResultShouldBe(double expectedIntensity)
        {
            Assert.That(_result, Is.EqualTo(expectedIntensity).Within(0.001));
        }

        [When(@"I have entered the failure intensity as (.*) and the time period as (.*)")]
        public void WhenIHaveEnteredTheFailureIntensityAndTimePeriod(double failureIntensity, double timePeriod)
        {
            _result = _calculator.CalculateAverageExpectedFailures(failureIntensity, timePeriod);
        }

        [Then(@"the average number of expected failures result should be (.*)")]
        public void ThenTheAverageNumberOfExpectedFailuresResultShouldBe(double expectedFailures)
        {
            Assert.That(_result, Is.EqualTo(expectedFailures).Within(0.001));
        }
    }
}
