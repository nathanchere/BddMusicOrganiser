﻿Feature: Verifying consistency of tags
	In order to determine if a music folder is ready to be catalogued
	As a pre-sort filter
	I want to filter out any invalid folders

Scenario: Mixed artist names
	Given I have a music folder
	And the folder has MP3s with mixed artist names
	When I process the folder
	Then the folder should be filtered out

Scenario: Mixed album titles
	Given I have a music folder
	And the folder has MP3s with mixed album titles
	When I process the folder
	Then the folder should be filtered out

Scenario: Missing artist names
	Given I have a music folder
	And the folder has MP3s with missing artist names
	When I process the folder
	Then the folder should be filtered out

Scenario: Missing album titles
	Given I have a music folder
	And the folder has MP3s with missing album titles
	When I process the folder
	Then the folder should be filtered out

Scenario: Missing track titles
	Given I have a music folder
	And the folder has MP3s with missing track titles
	When I process the folder
	Then the folder should be filtered out

@ignore
Scenario: Missing track numbers

@ignore
Scenario: Incomplete sequence of track numbers

@ignore
Scenario: No tags

Scenario: No MP3s
	Given I have a music folder
	And the folder has no MP3s
	When I process the folder
	Then the folder should be filtered out

# TODO: how to deal with albumartist