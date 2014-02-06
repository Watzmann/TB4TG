TB4TG
=====

Tourneybot for TigerGammon. http://www.tigergammon.com


Supports the following tell commands:

* list
* create [tourneyname] [match length] [final match length]
* register [tourneyname | id]
* unregister [tourneyname | id]
* start [tourneyname | id]

List
----
Returns all pending tourneys

Create
------
Will create a tourney and shout something about it

Register
--------
Register sender of tell in tourney. Returns message if ok.

Unregister
----------
Unregister sender of tell in tourney. Returns message if ok.

Start
-----
Starts tourney for registering results etc. and shouts that its starting.

Sequence of a tourney
---------------------
1. Create a tourney
2. Register/Unregister players
3. Start it
4. Sit back, play and enjoy ;-)

General
-------
This is the barebone tourneybot with the most essential functionality.


There are by now, NO info to registered players after starting. There are no timeouts or other actions if
user logs out, leaves game or otherwise.

No other interactions either in shout or tell are implemented yet.

Atm. there are also a bug which will not take into account that the final match length may diverge from
other match lengths, so all tourneys must be played according to same match length for all matches INCLUDING
final. This bug will be fixed asap!

No other bugs known at time of writing...

Ordinary handling of tourneys like adding users, results etc., on Challonge are also available/possible. Mixing these with tourneybot should not be a problem.
