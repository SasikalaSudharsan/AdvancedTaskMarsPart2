Feature: CertificationsFeature

As a user, 
I would like to add, edit and delete certifications 
so that people seeking for certifications can look at it	

@tag1
Scenario: 01 - Delete all records in the certifications list
	Given User logged into Mars URL and navigates to Certifications tab
	When Delete all records in the certifications list

Scenario Outline: 02 - Add new certification in the certifications list
    Given User logged into Mars URL and navigates to Certifications tab
	When User creates a new certification with '<id>'
	Then The certification with '<id>' should be created successfully

Examples: 
        | id |
        | 1  |
        | 2  |
        | 3  |
        | 4  |

Scenario Outline: 03 - Delete an existing certification in the certifications list
    Given User logged into Mars URL and navigates to Certifications tab
	When User deletes an existing certification with '<id>'
	Then The certification with '<id>' should be deleted successfully

Examples: 
        | id |
        | 1  |