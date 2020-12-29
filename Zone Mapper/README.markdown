Adds the `mapzone` wish, which exports the zone you're in to Qud's map format, useable in the map editor and when modding the game itself.

An approximation of everything in the zone is added, including things that weren't there when the zone was built, except for the following:

- the current player body
- anyone led by the current player body

There are some noteable limitations. If an object differs in some way from its blueprint, those changes will *not* be recorded. For example:

- damage
- status effects
- attributes and mutation levels
- sludge and cherub variants

The only exception is the owner of the object, which *is* recorded.
