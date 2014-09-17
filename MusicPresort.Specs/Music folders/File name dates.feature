Feature: Catalogue pre-import
	In order to know when an album was added to the catalog
	As a thingy
	I want to determine the import date from a music folder

#Scenario: No file date
	#Given I have a music folder
	#And the folder name begins with a recognised timestamp format
	#When I pre-process the folder
#	Then the result should be 120 on the screen

Scenario: Valid date
	Given I have a music folder
	And the folder name is "2010-12-31 (2014) SomeArtist SomeAlbum 320Kbps MP3 [soundcloud]"
	When I pre-process the folder
	Then the result should have the date 31-12-2010
