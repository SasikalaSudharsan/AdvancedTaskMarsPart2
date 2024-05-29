Feature: EducationFeature

As a user, 
I would like to add and delete education 
so that people seeking for education can look at it	

@tag1
Scenario Outline: 01 - Add and then delete education in the education list
  Given User logged into Mars URL with login details '<loginId>' and navigates to Education tab
   And  Delete all educations in the education list
	When User adds a new education '<educationId>' and should be added successfully
    When User deletes education '<educationId>' and should be deleted successfully

Examples: 
        | loginId | educationId |
        | 1       | 1           |
        | 1       | 2           |

Scenario Outline: 02 - Add an existing education in the education list
  Given User logged into Mars URL with login details '<loginId>' and navigates to Education tab
   And  Delete all educations in the education list
   And  User has education '<educationId>' in the education list
	When User tries to add education '<educationId>' again
	Then The education '<educationId>' should not be added again

Examples: 
        | loginId | educationId |
        | 1       | 1           |

Scenario Outline: 03 - Add an empty education in the education list
  Given User logged into Mars URL with login details '<loginId>' and navigates to Education tab
   And  Delete all educations in the education list
	When User tries to add empty education '<educationId>' in the education list
	Then The education '<educationId>' should not allow empty education

Examples: 
        | loginId | educationId |
        | 1       | 1           |

Scenario Outline: 04 - Add special characters in the education
  Given User logged into Mars URL with login details '<loginId>' and navigates to Education tab
   And  Delete all educations in the education list
	When User tries to add special characters '<educationId>' in the education
	Then The education '<educationId>' should not allow special characters

Examples: 
        | loginId | educationId |
        | 1       | 1           |