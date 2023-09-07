Feature: CheckJobListingsUrl

As a user
I want to navigate to the correct JobListingPage url
In order to further use JobListingPage features

@Smoke
@Navigation
Scenario: Epam Site - JobListingPage - Navigation
	Given I navigate to the main page of Epam site
	And I accept all cookies on Epam site
	When I hover over the 'Careers' click on Join our team link from the dropdown menu
	Then I check that the 'Job Listing' Page is opend