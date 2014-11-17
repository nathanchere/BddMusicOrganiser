Feature: Folder status
	In order to know what to do next
	As a thingy
	I want to know what the current status of the Music Folder is

Scenario: Newly imported
	Given I have a music folder
	And the music folder hasn't been analysed	
	Then the folder status should be "Not Analysed"

Scenario: Analysis found errors
	Given I have a music folder
	And the music folder has been analysed with errors
	Then the folder status should be "Analysed With Errors"

Scenario: Analysis found no errors
	Given I have a music folder
	And the music folder has been analysed wihout any errors	
	Then the folder status should be "Ready To Process"

Scenario: Processed
	Given I have a music folder
	And the music folder has been processed
	Then the folder should have a metadata cache
	And the folder status should be "Complete"
