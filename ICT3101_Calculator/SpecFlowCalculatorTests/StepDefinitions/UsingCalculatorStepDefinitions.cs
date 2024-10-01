// UsingCalculatorStepDefinitions.cs
using ICT3101_Calculator;
using NUnit.Framework;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorStepDefinitions
    {
        private Calculator _calculator;
        private double _result;

        public UsingCalculatorStepDefinitions(Calculator calc)
        {
            this._calculator = calc;
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press add")]
        public void WhenIHaveEnteredAndIntoTheCalculator(double p0, double p1)
        {
            _result = _calculator.Add(p0, p1);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(double p0)
        {
            Assert.That(_result, Is.EqualTo(p0));
        }
    }
}
