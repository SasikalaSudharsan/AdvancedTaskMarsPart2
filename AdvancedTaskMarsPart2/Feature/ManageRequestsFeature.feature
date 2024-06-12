Feature: ManageRequestsFeature

As a user, 
I would like to receive, sent and complete requests in the Manage Requests

Scenario Outline: 01 - Accept the received requests in the Manage Requests
	Given User logged into Mars URL with login details '<loginId>' and navigates to Manage Requests tab
	When User clicks received requests 
	And User accepts the received requests with '<id>' in the Manage Requests
	Then The accept requests with '<id>' are accepted successfully

Examples: 
      | loginId | id |
      | 1       | 1  |

Scenario Outline: 02 - Decline the received requests in the Manage Requests
	Given User logged into Mars URL with login details '<loginId>' and navigates to Manage Requests tab
	When User clicks received requests 
	And User declines the received requests with '<id>' in the Manage Requests
	Then The decline requests with '<id>' are declined successfully

Examples: 
      | loginId | id |
      | 1       | 1  |

Scenario Outline: 03 - Complete the received requests in the Manage Requests
	Given User logged into Mars URL with login details '<loginId>' and navigates to Manage Requests tab
	When User clicks received requests 
	And User accepts and completes the received requests with '<id>' in the Manage Requests
	Then The received requests with '<id>' are completed successfully

Examples: 
      | loginId | id |
      | 1       | 2  |

Scenario Outline: 04 - Withdraw the sent requests in the Manage Requests
	Given User logged into Mars URL with login details '<loginId>' and navigates to Manage Requests tab
	When User clicks sent requests 
	And User withdraw the sent requests with '<id>' in the Manage Requests
	Then The withdraw requests with '<id>' are withdrawn successfully

Examples: 
      | loginId | id |
      | 1       | 1  |