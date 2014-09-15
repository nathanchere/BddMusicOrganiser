Feature: Verifying consistency of tags
	In order to determine if a music folder is ready to be catalogued
	As a pre-sort filter
	I want to filter out any invalid folders

Scenario: Mixed artist names
	Given I pass in a music folder
	And I the folder has 
	When I process the folder
	Then the result should be 120 on the screen

Scenario: Mixed album names

Scenario: Missing artist names

Scenario: Missing track names

Scenario: Missing track numbers

Scenario: Incomplete sequence of track numbers