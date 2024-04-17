Feature: EducationFeature

As a user, 
I would like to add, edit and delete education 
so that people seeking for education can look at it	

@tag1
Scenario: 01 - Delete all records in the education list
	Given User logged into Mars URL and navigates to Education tab
	When Delete all records in the education list

Scenario Outline: 02 - Add new education in the education list
    Given User logged into Mars URL and navigates to Education tab
	When User creates a new education with '<id>'
	Then The education with '<id>' should be created successfully

Examples: 
        | id |
        | 1  |
        | 2  |
        | 3  |
        | 4  |
        | 5  |

Scenario Outline: 03 - Delete an existing education in the education list
    Given User logged into Mars URL and navigates to Education tab
	When User deletes an existing education with '<id>'
	Then The education with '<id>' should be deleted successfully

Examples: 
        | id |
        | 1  |