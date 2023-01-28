DecayLog just logs decay events. The purpose is to verify decay settings
are working as intended. It's not a plugin you want to run all the time.

You can disable all decay processing for structures by setting

structure.framelimit "0"

in the Rust server.cfg. This stops decay processing from happening at all.
Use a plugin to manage structures. You can have a LOT more of them on a 
server without any decay processing of structures.

You can disable decay damage to items deployed on the ground by setting

decay.decaytickrate "2147483647"
decay.maxperframe "1"
decay.maxtestperframe "1"

The last two set the number of items processed per frame to the minimum possible.
The decaytickrate timer will never reach such a high value, but the game still
checks decay.maxperframe deployable objects each frame to see if it has.

  1 is the minimum value.
  0 makes it check every item.


