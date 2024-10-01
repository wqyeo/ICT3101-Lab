Feature: UsingCalculatorForMusaLogarithmicModel
    In order to calculate failure intensity and expected failures using the Musa Logarithmic model
    As a system quality engineer
    I want to use my calculator to perform these calculations

@MusaLogModel
Scenario: Calculating Failure Intensity Using Musa Logarithmic Model
    Given I have a calculator
    When I have entered initial failure intensity 50, fault exposure ratio 0.02, and execution time 100 into the calculator and press musaFI
    Then the Musa Logarithmic model failure intensity result should be approximately 6.76676416

@MusaLogModel
Scenario: Calculating Expected Number of Failures Using Musa Logarithmic Model
    Given I have a calculator
    When I have entered total expected failures 1000, fault exposure ratio 0.02, and execution time 100 into the calculator and press musaEF
    Then the Musa Logarithmic model expected number of failures result should be approximately 864.6647168

@MusaLogModel
Scenario: Calculating Failure Intensity with zero execution time
    Given I have a calculator
    When I have entered initial failure intensity 50, fault exposure ratio 0.02, and execution time 0 into the calculator and press musaFI
    Then the Musa Logarithmic model failure intensity result should be approximately 50

@MusaLogModel
Scenario: Calculating Expected Number of Failures with zero execution time
    Given I have a calculator
    When I have entered total expected failures 1000, fault exposure ratio 0.02, and execution time 0 into the calculator and press musaEF
    Then the Musa Logarithmic model expected number of failures result should be approximately 0

@MusaLogModel
Scenario: Calculating with negative execution time
    Given I have a calculator
    When I have entered initial failure intensity 50, fault exposure ratio 0.02, and execution time -10 into the calculator and press musaFI
    Then an error should occur while calculating failure intensity using Musa Logarithmic model
