Feature: GoogleSearchEpam
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Google search for epam upper case
	Given I opened Google Search page
	When I search for EPAM
	Then first found site is https://careers.epam.by

Scenario: Google search for epam lower case
	Given I opened Google Search page
	When I search for epam
	Then first found site is https://careers.epam.by

Scenario: Google search for epam camel case
	Given I opened Google Search page
	When I search for Epam
	Then first found site is https://careers.epam.by


