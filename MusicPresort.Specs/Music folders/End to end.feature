Feature: End to end
	In order to keep track of what music was added to my library and when
	As a user
	I want to know what artist and album a folder contains
	And when it was added

@mytag
Scenario: Import valid folders
	Given I have a collection of folders
	And there are some valid folders within
	When I process the collection of folders
	Then the valid ones should have an import date
	And the valid ones should have an artist name
	And the valid ones should have an album title
	And the valid ones should have an album year

