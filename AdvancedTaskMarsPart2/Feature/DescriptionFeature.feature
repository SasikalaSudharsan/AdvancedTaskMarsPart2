Feature: DescriptionFeature

As a user, 
I would like to enter description in the profile page

@tag1
Scenario Outline: 01 - Add description in the profile page
  Given User logged into Mars URL with login details '<loginId>' and navigates to Description icon
	When User adds description '<descriptionId>' in the profile page 
	Then The description '<descriptionId>' should be saved successfully

Examples: 
        | loginId | descriptionId |
        | 1       | 1             |