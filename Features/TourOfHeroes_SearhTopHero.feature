Feature: TourOfHeroes_SearhTopHero
	In order to be more efficient
	As a Hero manager
	I want to add search my Top Heroes

@mytag4
Scenario: Search top Hero
	Given That I'm in Dashboard view
	When I write a hero name 'Narco' in searchbar
	Then A Hero named "Narco" should appear
