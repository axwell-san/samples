Feature: GoogleSearchEpamResources
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Google search for my epam
	Given I opened Google Search page
	When I search for my epam
	Then first found site is https://sharepoint.epam.com

Scenario: Google search for epam time
	Given I opened Google Search page
	When I search for epam time
	Then first found site is https://login.epam.com › adfs


