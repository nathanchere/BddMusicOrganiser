Feature: Folder analysis
	In order to provide an audit trail if anything goes wrong
	And improve performance when running the import multiple times
	As a thingy
	I want to persist a cache of import results

# assumes pre-import is already done and passed on these examples

Scenario: Analysis cache created
	Given I have a music folder
	And the music folder hasn't been processed
	When I analyse the folder
	Then the music folder should cache the analysis results
	And the cache should be written to disk

Scenario: Analysis cache contains list of files in folder
	Given I have a music folder
	And the music folder hasn't been processed
	When I analyse the folder
	Then analysis cache should list the files in the music folder

Scenario: Analysis cache contains root path
	Given I have a music folder
	And the music folder hasn't been processed
	When I analyse the folder
	Then analysis cache should contain the root path of the music folder

Scenario: Analysis cache stores all file paths relative to root path
Given I have a music folder
	And the music folder hasn't been processed
	When I analyse the folder
	Then analysis cache should list the files relative to the root path
