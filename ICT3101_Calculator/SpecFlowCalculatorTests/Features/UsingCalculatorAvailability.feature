Feature: UsingCalculatorAvailability
	In order to calculate MTBF and Availability
	As someone who struggles with math
	I want to be able to use my calculator to do this

@Availability
	Scenario: Calculating MTBF
	Given I have a calculator
	When I have entered 1000 and 5 into the calculator and press MTBF
	Then the MTBF result should be 200

@Availability
	Scenario: Calculating Availability
	Given I have a calculator
	When I have entered 200 and 50 into the calculator and press avail
	Then the availability result should be 0.8

@Availability
	Scenario: Calculating MTBF with zero failures
	Given I have a calculator
	When I have entered 1000 and 0 into the calculator and press MTBF
	Then an error should occur while calculating MTBF

@Availability
	Scenario: Calculating Availability with zero MTTR
	Given I have a calculator
	When I have entered 200 and 0 into the calculator and press avail
	Then the availability result should be 1.0
