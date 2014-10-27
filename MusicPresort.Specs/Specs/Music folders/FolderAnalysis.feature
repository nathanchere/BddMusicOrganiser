Feature: Folder analysis
	In order to provide an audit trail if anything goes wrong
	And improve performance when running the import multiple times
	As a thingy
	I want to persist a cache of import results

# assumes pre-import is already done and passed on these examples

Scenario: Should not process previously analysed folder
	Given I have a music folder
	And the folder has no analysis cache
	When I process the folder
	Then the folder should be processed

Scenario: Should process folders which haven't been previously analysed
	Given I have a music folder
	And the folder has an analysis cache
	When I process the folder
	Then processing should be skipped

Scenario: Analysis cache contains list of files in folder
	Given I have a music folder which hasn't been processed
	And the music folder has some files
	When I process the folder
	Then analysis cache should list the input files

