Feature: TourOfHeroes_CheckTopHeroes
	In order to be check in in my Top Heroes
	As a Hero manager
	I want to go to Dashboard and check if my Hero is OK!

@mytag2
Scenario: In the Dashboard, choose one of the heroes and go to the details page, change its name and save it;
	Given That Im in Dashboard view AND I have the Hero 'Mr.Nice,Narco'
	When I Click'Mr.Nice'
	Then Mr.Nice Information should appear with Id > 0 and Name as'Mr.Nice'