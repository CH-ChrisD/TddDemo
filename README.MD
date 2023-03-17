# TDD

## Summary

Test Driven Development (TDD) is a programming technique where you write failing tests before writing each piece of code. The basic workflow of TDD is:

1. Red
    * Write a failing test
2. Green
    * Make the test pass
3. Refactor
    * Refactor your code to improve it, while keeping the test green
4. Repeat: go back to #1

With this style of programming, you are always focused on **one** of these tasks at a time. You should avoid jumping between them. And once your refactor is complete, you repeat the cycle until your story is complete.

## Benefits

* Improves design by focusing attention on interfaces over implementations
* Ensures test coverage of new code
* Ensures new tests are valid
* Ensures new code is useful
* With upcoming AI advances, this may become the **only** efficient way to code!

In this author's opinion, the main benefit TDD brings is improving your design. Code written to fullfil a contract is noticeably different to code written around an implementation, which then forces some convenient contract onto consumers. With TDD, you put consumers first and work to make their life easy.

It also forces you to only write testable code. You cannot get yourself stuck by coding a whole class up, coming to write unit tests, and realising that your design makes testing difficult or impossible.

## Downsides

* Requires some familiarisation
* Can be harder to start using in an existing solution with untestable code
* Is often thought of as slower in short run
  * In this biased author's opinion, this is not true except on a tiny scale

Familiriarisation is probably the biggest downside of TDD, again in author's opinion. This can feel like a very "weird" way of working if you're not used to it. I would encourage hesitant readers to try it out for themselves, give it at least a few solid days, and see how you feel about it at the end.

## What kind of "test" drives the development?

TDD can be applied at many levels. At it's most comprehensive, you would:

1. Create a failing integration test
2. Start doing individual TDD loops for unit tests until this integration test passes
3. Commit
4. Repeat: go back to #1

**But**, there's absolutely no reason you can't use TDD for just unit tests if you're in solution which struggles to implement integration tests! TDD is another tool in your belt, use it as you find helpful.

### TDD Schools

If you *are* using TDD for both integration and unit tests, there are 2 schools for how to do it:
| School                 | Approach |
| --- | --- |
| Outside-in / "London"  | Start at the integration test interface. Develop the outermost class, mocking any dependencies it needs. Work inwards. |
| Inside-out / "Detroit" | Start at the innermost class, the one needing no dependencies. This means no mocks are needed as you can always use the real dependencies |

This is one of those programming debates with extremely opinionated proponents on each side. Author's advice: do what works for you and your team. If you're used to independent unit tests using extensive mocking, choose London. If you're used to testing using the real concrete classes, choose Detroit. Either school will likely give you better results than nothing!
