Feature: UsingCalculatorForDefectDensityAndSSI
    In order to calculate defect density and new total SSI in successive releases
    As a system quality engineer
    I want to use my calculator to perform these calculations

@DefectDensity
Scenario: Calculating Defect Density
    Given I have a calculator
    When I have entered total defects 50 and total SSI 1000 into the calculator and press defectdensity
    Then the defect density result should be 0.05

@DefectDensity
Scenario: Calculating Defect Density with zero defects
    Given I have a calculator
    When I have entered total defects 0 and total SSI 1000 into the calculator and press defectdensity
    Then the defect density result should be 0

@DefectDensity
Scenario: Calculating Defect Density with zero SSI
    Given I have a calculator
    When I have entered total defects 50 and total SSI 0 into the calculator and press defectdensity
    Then an error should occur while calculating defect density

@SSI
Scenario: Calculating New Total SSI in Successive Releases
    Given I have a calculator
    When I have entered previous SSI 1000 and new SSI 200 into the calculator and press newssi
    Then the new total SSI result should be 1200

@SSI
Scenario: Calculating New Total SSI with negative new SSI
    Given I have a calculator
    When I have entered previous SSI 1000 and new SSI -200 into the calculator and press newssi
    Then the new total SSI result should be 800

@SSI
Scenario: Calculating New Total SSI with zero new SSI
    Given I have a calculator
    When I have entered previous SSI 1000 and new SSI 0 into the calculator and press newssi
    Then the new total SSI result should be 1000
