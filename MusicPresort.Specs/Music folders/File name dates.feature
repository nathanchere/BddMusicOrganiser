Feature: Catalogue pre-import
	In order to know when an album was added to the catalog
	As a thingy
	I want to determine the import date from a music folder

#Scenario: No file date
	#Given I have a music folder
	#And the folder name begins with a recognised timestamp format
	#When I pre-process the folder
#	Then the result should be 120 on the screen

Scenario: Valid date
	Given I have a music folder
	And the folder name is in a valid format
	When I pre-process the folder
	Then the result should have the date

Scenario: Invalid date
	Given I have a music folder
	And the folder name is not in a valid format
	When I pre-process the folder
	Then the result should have no date
	// and the result should have an error "Invalid date"
