<!-- =========================================================================
     assignment.md — the spec for this coursework repo.

     This file holds WHAT you're building and how it's graded. CLAUDE.md is for
     HOW the code is built (conventions); this is the assignment itself. The
     agent and the "Draft tasks from this" flow read this file, so paste the
     real assignment text verbatim under each heading below.

     Only "## Requirements" is required — the lettered items you're graded on.
     Scenario, Rubric, and Common reasons for return are optional; fill the ones
     your PA actually provides. The HTML-comment hints below are ignored — leave
     them or delete them, it makes no difference.
     ========================================================================= -->

## Scenario

Ridgeline Outfitters is a small outdoor-gear rental shop. Staff currently track
rentals on a paper clipboard behind the counter, which has led to double-booked
items and no reliable way to answer "when is this due back?"

The owner has asked for a command-line tool the counter staff can run on the shop
laptop. It does not need a graphical interface or a database — the shop is small
enough that an in-memory catalog reset at the start of each shift is acceptable
for this first version. The owner has been explicit that the tool must never
crash on bad input, because the people using it are not technical and a stack
trace at the counter is worse than no tool at all.

You have been engaged to build the first version and to demonstrate that its
rental rules behave correctly under test.

## Requirements

**A. Catalog**

**A1.** Create a class that represents a rentable item with, at minimum, a unique
identifier, a display name, a daily rate, and a flag indicating whether the item
is currently rented out.

**A2.** Create a catalog type that holds a collection of rentable items and
exposes operations to add an item, look one up by its identifier, and list all
items. Looking up an identifier that does not exist must return a clear
not-found result rather than throwing.

**B. Rental operations**

**B1.** Implement a rental operation that marks an available item as rented and
records the number of days it is rented for. Attempting to rent an item that is
already rented must be refused with an explanatory message and must not change
any state.

**B2.** Implement a return operation that marks a rented item as available again
and reports the total charge, calculated as the daily rate multiplied by the
number of days rented. Attempting to return an item that is not currently rented
must be refused with an explanatory message.

**B3.** Implement a late fee: any rental returned after more than seven days
incurs an additional flat charge of $15.00 on top of the daily total. The
threshold and the fee must be defined as named constants rather than repeated
literals.

**C. Interface**

**C1.** Provide a command-line menu that lets the user list items, rent an item,
return an item, and exit. The menu must redisplay after each completed operation
until the user chooses to exit.

**C2.** Handle invalid input at every prompt — a non-numeric entry where a number
is expected, an out-of-range menu choice, or an unknown item identifier — by
displaying a message and re-prompting. The application must not terminate on
invalid input.

**D. Testing**

**D1.** Write unit tests covering the rental operation: renting an available
item succeeds, and renting an already-rented item is refused without altering
state.

**D2.** Write unit tests covering the charge calculation, including at least one
rental at or below the late-fee threshold and one above it.

**E. Version control**

**E1.** Commit your work incrementally with descriptive messages — not as a
single commit at the end. The history must show the work progressing.

## Rubric

Each criterion must reach **Competent** for the assessment to pass.

**A1 — Item representation**
*Competent:* A class represents a rentable item with a unique identifier, a
display name, a daily rate, and a rented-status indicator. Field types are
appropriate to the data they hold.

**A2 — Catalog operations**
*Competent:* A catalog type holds a collection of items and supports add,
lookup by identifier, and list. Lookup of a missing identifier returns a
not-found result and does not throw.

**B1 — Rent operation**
*Competent:* Renting an available item marks it rented and records the rental
duration. Renting an already-rented item is refused with an explanatory message
and leaves all state unchanged.

**B2 — Return operation and charge**
*Competent:* Returning a rented item marks it available and reports a charge
equal to the daily rate times the days rented. Returning an item that is not
rented is refused with an explanatory message.

**B3 — Late fee**
*Competent:* A rental exceeding seven days incurs an additional flat $15.00.
The threshold and fee are named constants, not repeated literals.

**C1 — Menu**
*Competent:* A command-line menu offers list, rent, return, and exit, and
redisplays after each completed operation until exit is chosen.

**C2 — Input validation**
*Competent:* Non-numeric input, out-of-range menu choices, and unknown item
identifiers each produce a message and a re-prompt. No input path terminates the
application or surfaces an unhandled exception.

**D1 — Rental tests**
*Competent:* Tests assert both that renting an available item succeeds and that
renting an already-rented item is refused with state unchanged.

**D2 — Charge tests**
*Competent:* Tests assert the charge calculation for at least one rental at or
below the late-fee threshold and one above it.

**E1 — Commit history**
*Competent:* The repository contains multiple commits with descriptive messages
that show the work progressing, rather than a single bulk commit.

## Common reasons for return

- **Refused operations change state anyway.** A rejected rent or return that
  still flips a flag or records a duration fails B1 or B2 even when the message
  is correct.
- **Magic numbers.** The seven-day threshold or the $15.00 fee written as bare
  literals in the calculation fails B3 regardless of whether the arithmetic is
  right.
- **Validation that exits.** Catching bad input and then terminating, rather than
  re-prompting, fails C2 — the requirement is that the application survives.
- **Tests that only cover the happy path.** D1 and D2 each name a failure or
  boundary case explicitly; asserting only the success case does not reach
  Competent.
- **A single commit.** E1 is graded on the history, not the final state. Squashing
  or committing once at the end fails it even when every other criterion passes.
- **Logic that cannot be tested.** Rental rules written inline in the menu loop
  rather than in a separately callable type make D1 and D2 impossible to satisfy
  without restructuring.

<!-- Optional — paste only if your PA ships a "common reasons for return" doc.
     It's a pre-written list of how submissions fail this exact PA, so it's the
     highest-signal thing here: every task gets checked against it. Delete this
     section if your PA has none. -->
