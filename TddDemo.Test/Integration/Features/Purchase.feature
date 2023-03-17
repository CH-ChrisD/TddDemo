Feature: Purchase
    As a customer, I want to be able to buy books.

Background:
	Given the following books exist:
		| title             | author            | publish year | price in £ |
		| "Moby Dick"       | "Herman Melville" | 1851         | 10.00      |
		| "Of Mice and Men" | "John Steinbeck"  | 1937         | 15.00      |

Scenario: Add book to basket
	When I add the book "Moby Dick" to my basket
	And I view my basket
	Then I see book "Moby Dick"

Scenario: Buy 1 book
	Given I have added "Moby Dick" to my basket
	When I go to checkout
	Then I should see a total of £10.00

Scenario: Buy 2 books
	Given I have added the following books to my basket:
		| title             |
		| "Moby Dick"       |
		| "Of Mice and Men" |
	When I go to checkout
	Then I should see a total of £15.00