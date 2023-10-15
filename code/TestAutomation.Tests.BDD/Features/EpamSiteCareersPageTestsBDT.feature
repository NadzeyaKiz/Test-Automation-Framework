Feature:EpamSiteCareersPageTestsBDT

As a user interested in the Epam company
I want to be able to reviw Careers page
In order to be able to get information about opend roles in the Epam company


@Smoke
@CareersLokations
Scenario: Epam Site - Careers Page - Locations
	Given I navigate to the main page of Epam site
	And I accept all cookies on Epam site
	And I open Careers page with click on 'Careers' button 
	When I click on the 'Find your dream job button'
	Then I check that the actual list of locations contains the following <locations>:
	| "AMERICAS" |
	| "EMEA"     |
	| "APAC"     |

@CriticalPath
@TypeOfWorking
Scenario: Epam Site - Careers Page - Type of working checkboxes
	Given I navigate to the main page of Epam site
	And I accept all cookies on Epam site
	And I open Careers page with click on 'Careers' button 
	When I click on the 'Find your dream job button'
	Then I check that the all of the check boxes for choosing type of work are presented on the page <TypesOfWork>:
	| "Remote"					|
	| "Office"					|
	| "Open to Relocation"		|
