Feature: Initial folder import
	In order to determine which folders are valid for processing
	As a MusicFolderFactory (WTF do I put here?)
	I want to verify that input directories exist
	And that the folder name contains the import date

Scenario: Folder exists
	Given a folder path
	And the folder path exists on disk
	When the folder is imported
	Then the result should not have a 'Not Found' error

Scenario: Folder doesn't exist
	Given a folder path
	And the folder path doesn't exist on disk
	When the folder is imported
	Then the result should have a 'Not Found' error

Scenario: Valid date
	Given a folder path
	And the folder name is in a valid format
	And the folder path exists on disk
	When the folder is imported
	Then the result should have the date

Scenario: Invalid date
	Given a folder path
	And the folder name is in a valid format but with an invalid date
	And the folder path exists on disk
	When the folder is imported
	Then the result should have no date
	And the result should have an 'Invalid Date' error

Scenario: Invalid format
	Given a folder path
	And the folder name is not in a valid format
	And the folder path exists on disk
	When the folder is imported
	Then the result should have no date
	And the result should have an 'Invalid Folder Name' error

Scenario: No analysis cache
	Given a folder path
	And the folder name is in a valid format
	And the folder path exists on disk
	When the folder is imported	
	Then the result should have no error
	And the result should have no analysis cache

Scenario: Analysis cache
	Given a folder path
	And the folder name is in a valid format
	And the folder path exists on disk
	And the folder contains an analysis cache
	When the folder is imported	
	Then the result should have no error
	And the result should have an analysis cache