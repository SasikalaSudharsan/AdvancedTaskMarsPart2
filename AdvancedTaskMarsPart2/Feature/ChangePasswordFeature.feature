Feature: ChangePasswordFeature

As a user, 
I would like to change the new password

@tag1
Scenario Outline: 01 - Change the new password
	Given User logged into Mars URL and navigates to User tab
	When User clicks Change Password and updates the new password with '<id>'
	Then New Password updated with '<id>' successfully

Examples: 
      | id |
      | 1  |