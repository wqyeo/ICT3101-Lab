Feature: UsingCalculatorFactorial

Scenario: Calculating the factorial of a positive number
	Given I have a calculator
	When I calculate the factorial of 5
	Then the factorized result should be 120

Scenario: Calculating the factorial of zero
	Given I have a calculator
	When I calculate the factorial of 0
	Then the factorized result should be 1

Scenario: Calculating the factorial of a negative number
	Given I have a calculator
	When I calculate the factorial of -5
	Then an error should occur while calculating the factorial
