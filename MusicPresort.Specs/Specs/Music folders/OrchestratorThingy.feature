Feature: Orchestrator thingy
	In order to provide an audit trail if anything goes wrong
	And improve performance when running the import multiple times
	As a thingy
	I want to persist a cache of import results

@ignore
Scenario: Should not process previously analysed folder
	Given I have a music folder
	And the folder has no analysis cache
	When I process the folder
	Then the folder should be processed
@ignore
Scenario: Should process folders which haven't been previously analysed
	Given I have a music folder
	And the folder has an analysis cache
	When I process the folder
	Then processing should be skipped