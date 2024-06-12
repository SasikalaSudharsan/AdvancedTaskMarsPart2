Feature: CertificationsFeature

As a user, 
I would like to add and delete certifications 
so that people seeking for certifications can look at it
       
@tag1
Scenario Outline: 01 - Add and then delete certification in the certifications list
   Given  User logged into Mars URL with login details '<loginId>' and navigates to Certifications tab
    And  Delete all certifications in the certifications list
	When User adds a new certification '<certificationId>' and should be added successfully
     When User deletes certification '<certificationId>' and should be deleted successfully
    
Examples: 
        | loginId | certificationId |
        | 1       | 1               |
        | 1       | 2               |
        | 1       | 3               |

Scenario Outline: 02 - Add an existing certification in the certifications list
   Given  User logged into Mars URL with login details '<loginId>' and navigates to Certifications tab
    And  Delete all certifications in the certifications list
   And User has a certification '<certificationId>' in the certifications list
   When User tries to add the certification '<certificationId>' again
   Then The certification '<certificationId>' should not be added 

Examples: 
        | loginId | certificationId |
        | 1       | 1               |

Scenario Outline: 03 - Add an empty certification in the certifications list
  Given  User logged into Mars URL with login details '<loginId>' and navigates to Certifications tab
    And  Delete all certifications in the certifications list
   When User tries to add empty certification '<certificationId>' in the certifications list
   Then The certification '<certificationId>' should not allow empty certification

Examples: 
        | loginId | certificationId |
        | 1       | 1               |

Scenario Outline: 04 - Add special characters in the certification
  Given  User logged into Mars URL with login details '<loginId>' and navigates to Certifications tab
    And  Delete all certifications in the certifications list
   When User tries to add special characters in the certification '<certificationId>'
   Then The certification '<certificationId>' should not allow special characters

Examples: 
        | loginId | certificationId |
        | 1       | 1               |