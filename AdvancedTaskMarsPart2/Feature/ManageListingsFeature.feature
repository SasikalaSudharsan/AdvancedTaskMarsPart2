Feature: ManageListingsFeature

As a user, 
I would like to edit, update, view and delete Skills in the Manage Listings

@tag1
Scenario Outline: 01 - Edit and Update the skills in the Manage Listings
	Given User logged into Mars URL and navigates to Manage Listings tab
	When User edits and update the skills with '<id>' in the Manage Listings
	Then The skills with '<id>' are updated successfully

Examples: 
      | id |
      | 1  |


Scenario Outline: 02 - View the skills in detail in the Manage Listings
	Given User logged into Mars URL and navigates to Manage Listings tab
	When User view the skills with '<id>' in the Manage Listings
	Then The skills with '<id>' are viewed in detail successfully

Examples: 
      | id |
      | 1  |


Scenario Outline: 03 - Delete the skills in the Manage Listings
	Given User logged into Mars URL and navigates to Manage Listings tab
	When User deletes the skill with '<id>' in the Manage Listings
	Then The skill with '<id>' are deleted successfully

Examples: 
      | id |
      | 1  |


Scenario Outline: 04 - Disable the skill in the Manage Listings
    Given User logged into Mars URL and navigates to Manage Listings tab
	When User deactivates the existing skill with '<id>'
	Then The skill should be deactivated successfully

Examples: 
      | id |
      | 1  |


Scenario Outline: 05 - Enable the skill in the Manage Listings
    Given User logged into Mars URL and navigates to Manage Listings tab
	When User activates the existing skill with '<id>'
	Then The skill should be activated successfully

Examples: 
      | id |
      | 1  |