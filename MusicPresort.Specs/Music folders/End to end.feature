Feature: End to end
	In order to keep track of what music was added to my library and when
	As a user
	I want to know what artist and album a folder contains
	And when it was added

@mytag
Scenario: Import a shitload of folders
	Given I have a collection of folders
	When I process the collection of folders
	Then the valid ones should
	And the invalid ones should

