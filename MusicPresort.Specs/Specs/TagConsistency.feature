Feature: Tag consistency
	In order to determine if a music folder is ready to be catalogued
	As a pre-sort filter
	I want to filter out any invalid folders

	TODO: how to handle AlbumArtist?
	TODO: Disc number?
	TODO: handling numbers like "4/11"

Scenario: Mixed artist names
	Given I have a music folder
	And the folder has MP3s with mixed artist names
	When I analyse the folder
	Then the folder analysis status should be "Not Ready"
	And the folder analysis should contain an error "MixedArtistNames"

Scenario: Mixed album titles
	Given I have a music folder
	And the folder has MP3s with mixed album titles
	When I analyse the folder
	Then the folder analysis status should be "Not Ready"
	And the folder analysis should contain an error "MixedAlbumTitles"

Scenario: Missing artist names
	Given I have a music folder
	And the folder has MP3s with missing artist names
	When I analyse the folder
	Then the folder analysis status should be "Not Ready"
	And the folder analysis should contain an error "MissingArtistNames"

Scenario: Missing album titles
	Given I have a music folder
	And the folder has MP3s with missing album titles
	When I analyse the folder
	Then the folder analysis status should be "Not Ready"
	And the folder analysis should contain an error "MissingAlbumTitles"

Scenario: Missing track titles
	Given I have a music folder
	And the folder has MP3s with missing track titles
	When I analyse the folder
	Then the folder analysis status should be "Not Ready"
	And the folder analysis should contain an error "MissingTrackTitles"

Scenario: Missing track numbers
	Given I have a music folder
	And the folder has MP3s with missing track numbers
	When I analyse the folder
	Then the folder analysis status should be "Not Ready"
	And the folder analysis should contain an error "MissingTrackNumbers"

Scenario: Invalid track numbers
	Given I have a music folder
	And the folder has MP3s with invalid track numbers
	When I analyse the folder
	Then the folder analysis status should be "Not Ready"
	And the folder analysis should contain an error "InvalidTrackNumbers"

Scenario: Incomplete sequence of track numbers
	Given I have a music folder
	And the folder has MP3s with an incomplete sequence of track numbers
	When I analyse the folder
	Then the folder analysis status should be "Not Ready"
	And the folder analysis should contain an error "InvalidTrackNumberSequence"

Scenario: No tags
	Given I have a music folder
	And the folder has MP3s with an incomplete sequence of track numbers
	When I analyse the folder
	Then the folder analysis status should be "Not Ready"
	And the folder analysis should contain an error "MissingTags"
	

Scenario: No MP3s
	Given I have a music folder
	And the folder has no MP3s
	When I analyse the folder
	Then the folder analysis status should be "Not Ready"
	And the folder analysis should contain an error "NoMp3sFound"