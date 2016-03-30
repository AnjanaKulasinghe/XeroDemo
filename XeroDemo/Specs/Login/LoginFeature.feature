Feature: LoginFeature

#---------------------------- Basic Flows ------------------------------

@BVT
@Login
Scenario: Basic Flow - Simple Login
	Given I'm on the login page
	When I enter correct username and password
	Then I should see main dash board