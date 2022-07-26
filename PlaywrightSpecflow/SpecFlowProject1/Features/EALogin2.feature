Feature: EAEAppTest2

    @smoke
    Scenario: Test Login operation of EA Application2
        Given I navigate to appliacation
        And I click login link
        And I enter following login details
          | UserName | Password |
          | admin    | password |
        Then I see Employee Lists