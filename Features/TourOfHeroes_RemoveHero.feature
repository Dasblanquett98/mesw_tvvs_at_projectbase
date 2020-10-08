Feature: TourOfHeroes_RemoveHero
In order to impose my power
As a Hero manager
I want to remove a bad Hero

@mytag3
Scenario: Remove Hero
	Given That Im in Heroes view and 'm9' is shown
	When when I click delete near the'm9' name
	Then 'm9'shouldn't be in My Heroes list
