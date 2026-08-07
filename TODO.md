# TODO LIST

- [x] **[MEDIUM]** Add a RentableItem class representing a single rentable item — Completed: 2026-08-07
  - Type: feature
  - Description: Create a `RentableItem` class in MyApp.Core exposing a unique identifier, a display name, a daily rate, and a boolean flag for whether it is currently rented. Use appropriate field types (string id and name, `decimal` daily rate, `bool` rented flag). Replace the placeholder `Class1.cs`. Follow the C# adaptation of `.claude/commenting-style.md` (file header with author Robert Sterenchak, member and inline comments) and `.claude/style.md`.
  - File: `src/MyApp.Core/RentableItem.cs`, `src/MyApp.Core/Class1.cs
  <!-- id: 71c98146-3f6f-4c11-95fa-e543e97e3079 -->

- [ ] **[MEDIUM]** Add a Catalog type holding items with add, lookup, and list
  - Type: feature
  - Description: Create a `Catalog` class in MyApp.Core holding a collection of `RentableItem`, with methods to add an item, look one up by identifier, and list all items. A lookup for a missing identifier must return a not-found result (a nullable item or a `TryFind` bool pattern) and must not throw. Depends on `RentableItem` (A1). Follow `.claude/style.md` and the C# adaptation of `.claude/commenting-style.md`.
  - File: `src/MyApp.Core/Catalog.cs`, `src/MyApp.Core/RentableItem.cs
  <!-- id: 921ce916-a876-4b33-b2eb-3d0ac54042e2 -->
