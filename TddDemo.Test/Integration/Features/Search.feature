Feature: Search
    As a customer, I want to be able to find search for books by author or title.

    Background:
        Given the following books exist:
            | title             | author            | publish year |
            | "Moby Dick"       | "Herman Melville" | 1851         |
            | "Of Mice and Men" | "John Steinbeck"  | 1937         |

    Scenario: Search for an author
        When I search for author "John Steinbeck"
        Then I should see book "Of Mice and Men"

    Scenario: Search for a title
        When I search for title "Moby Dick"
        Then I should see book "Moby Dick"