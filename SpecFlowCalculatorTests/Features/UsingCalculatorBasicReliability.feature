Feature: UsingCalculatorBasicReliability
In order to calculate the Basic Musa model's failures/intensities
As a Software Quality Metric enthusiast
I want to use my calculator to do this

@FailureIntensity
Scenario: Calculating Current Failure Intensity
	Given I have a calculator
	When I have entered the total number of failures as 10 and the total time as 100
	Then the current failure intensity result should be 0.1

@ExpectedFailures
Scenario: Calculating Average Number of Expected Failures
	Given I have a calculator
	When I have entered the failure intensity as 0.1 and the time period as 50
	Then the average number of expected failures result should be 5