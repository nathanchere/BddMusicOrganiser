Feature: Folder analysis
	In order to provide an audit trail if anything goes wrong
	And improve performance when running the import multiple times
	As a thingy
	I want to persist a cache of import results

#Scenario: No file date
	#Given I have a music folder
	#And the folder name begins with a recognised timestamp format
	#When I pre-process the folder
#	Then the result should be 120 on the screen

Scenario: Folder not previously analysed
	Given I have a music folder
	And the folder has no analysis cache
	When I process the folder
	Then the folder should be processed

Scenario: Folder previously analysed
	Given I have a music folder
	And the folder has an analysis cache
	When I process the folder
	Then processing should be skipped