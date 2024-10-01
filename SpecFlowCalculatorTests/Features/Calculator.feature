Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowCalculatorTests/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@Addition
Scenario: Add two numbers
	Given I have a calculator
	When I have entered 50 and 70 into the calculator and press add
	Then the result should be 120

@Addition
Scenario Outline: Add zeros for special cases
	Given I have a calculator
	When I have entered <value1> and <value2> into the calculator and press add
	Then the result should be <value3>
	Examples:
	|value1 |value2 |value3 |
	|1 |11 |7 |
	|10 |11 |11 |
	|11 |11 |15 |

@Metrics
Scenario: Calculating Defect Density
    Given I have a calculator
    When I have a total number of defects as 15
    And I have a total lines of code as 3000
    And I calculate the defect density
    Then the defect density should be 0.005

@Metrics
Scenario: Calculating Total Shipped Source Instructions
    Given I have a calculator
    When I have the SSI for the first release as 1000
    And I have the SSI for the second release as 1200
    And I calculate the total SSI
    Then the total SSI should be 2200

@Metrics
Scenario: Calculating Failure Intensity and Expected Failures
    Given I have a calculator
    When I have a total number of failures as 10
    And I have a total time as 100
    And I have the time period as 50
    And I calculate failure intensity and expected failures
    Then the failure intensity should be 0.1
    And the expected failures should be 5