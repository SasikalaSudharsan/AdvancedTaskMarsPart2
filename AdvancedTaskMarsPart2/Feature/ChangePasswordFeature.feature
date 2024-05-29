Feature: ChangePasswordFeature

As a user, 
I would like to change the new password

@tag1
Scenario Outline: 01 - Change the new password with valid details
    Given  User logged into Mars URL with login details '<loginId>' and navigates to User tab
	When User clicks Change Password and updates the new password with '<passwordId>'
	Then New Password '<passwordId>' updated successfully

Examples: 
      | loginId | passwordId |
      | 1       | 1          |

Scenario Outline: 02 - Change the new password with invalid details
Given  User logged into Mars URL with login details '<loginId>' and navigates to User tab
	When User clicks Change Password and updates the new password with invalid '<passwordId>'
	Then The Password '<passwordId>' should not be updated

Examples: 
      | loginId | passwordId |
      | 1       | 1          |