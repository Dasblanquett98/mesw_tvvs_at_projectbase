Feature: Displaying book details
	As a potential customer
	I want to see the details of a book
	So that I can better decide to buy it.

Scenario: The author, the title and the price of a book can be seen
	Given the following books
		| Author        | Title                              | Price |
		| Martin Fowler	| Refactoring						 | 29,55 |
		| David Chelimsky | The RSpec Book					 | 17,50 |
	When I open the details of 'Refactoring'
	Then the book details should show
		| Author        | Title             | Price |
		| Martin Fowler	| Refactoring		 | 29,55 |
