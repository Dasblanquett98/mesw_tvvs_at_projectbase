Feature: TourOfHeroes_AddHero
	In order to be more powerful
	As a Hero manager
	I want to add a new Hero

@mytag
Scenario: Add new Hero
	Given That I'm in Heroes view
	When I write a hero name 'Jose' AND I click Add
	Then A Hero named 'Jose' should appear