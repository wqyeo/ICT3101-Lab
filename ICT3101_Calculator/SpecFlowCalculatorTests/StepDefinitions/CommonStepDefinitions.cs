// CommonStepDefinitions.cs
namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class CommonStepDefinitions
    {

        // Placeholder class for common steps, so as to satisfy the build requirements for a "I have a calculator" step
        public CommonStepDefinitions()
        {

        }

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            // This step is a placeholder, and does not need to do anything
            // This is bypassed by having the Calculator instance directly injected into the step definitions themselves
        }
    }
}
