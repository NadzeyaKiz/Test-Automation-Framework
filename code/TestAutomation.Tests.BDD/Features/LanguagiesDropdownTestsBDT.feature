Feature: LanguagiesDropdownTestsBDT

As a user
I want to change the Epam site language
In order to get required info in desired language 

@Smoke
@Languagies
Scenario: EpamSite - Languagies Dropdown
	Given I navigate to the main page of Epam site
	And I accept all cookies on Epam site
	When I click on the 'Languagies' dropdown button
	Then I check that the list of desired languagies contains the following <language>:
	| landuage       |
	| "(English)"    |
	| "(Русский)"    |
	| "(Čeština)"    |
	| "(Українська)" |
	| "(日本語)"      |
	| "(中文)"        |
	| "(Deutsch)"    |  
	| "(Polski)"	 |

