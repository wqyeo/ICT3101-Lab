Feature: UsingCalculatorBasicReliability
	In order to calculate the Basic Musa model's failures/intensities
	As a Software Quality Metric enthusiast
	I want to use my calculator to do this

@BasicReliability
	Scenario: Calculating Current Failure Intensity
	Given I have a calculator
	When I have entered initial failure intensity 50, total expected failures 1000, and time 10 into the calculator and press cfi
	Then the failure intensity result should be 30.32653298563167

@BasicReliability
	Scenario: Calculating Average Number of Expected Failures
	Given I have a calculator
	When I have entered initial failure intensity 50, total expected failures 1000, and time 10 into the calculator and press anef
	Then the expected failures result should be 393.4693402873666

@BasicReliability
	Scenario: Calculating Current Failure Intensity with zero time
	Given I have a calculator
	When I have entered initial failure intensity 50, total expected failures 1000, and time 0 into the calculator and press cfi
	Then the failure intensity result should be 50

@BasicReliability
	Scenario: Calculating Average Number of Expected Failures with zero time
	Given I have a calculator
	When I have entered initial failure intensity 50, total expected failures 1000, and time 0 into the calculator and press anef
	Then the expected failures result should be 0

@BasicReliability
	Scenario: Calculating with negative time
	Given I have a calculator
	When I have entered initial failure intensity 50, total expected failures 1000, and time -5 into the calculator and press cfi
	Then an error should occur while calculating failure intensity
