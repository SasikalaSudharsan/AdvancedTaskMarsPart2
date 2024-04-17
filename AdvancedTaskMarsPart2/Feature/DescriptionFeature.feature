Feature: DescriptionFeature

As a user, 
I would like to enter description in the profile page

@tag1
Scenario Outline: 01 - Enter description in the profile page
	Given User logged into Mars URL and navigates to Description icon
	When Enter the description details with '<id>'
	Then Description '<id>' should be saved successfully

Examples: 
        | id |
        | 1  |