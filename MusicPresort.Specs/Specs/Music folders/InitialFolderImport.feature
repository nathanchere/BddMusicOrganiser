Feature: Initial folder import
	In order to know when an album was added to the catalog
	As a thingy
	I want to determine the import date from a music folder

Scenario: Valid date
	Given I have a full folder path
	And the folder name is in a valid format
	When I pre-process the folder
	Then the result should have the date

Scenario: Invalid date
	Given I have a full folder path
	And the folder name is in a valid format but with an invalid date
	When I pre-process the folder
	Then the result should have no date
	# and the result should have an error "Invalid date"
	# Date validation to come later

Scenario: Invalid format
	Given I have a full folder path
	And the folder name is not in a valid format
	When I pre-process the folder
	Then the result should have no date
	# and the result should have an error "Invalid format"

	# exists on disk
	#doesn't exist