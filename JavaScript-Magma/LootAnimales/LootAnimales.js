 function On_NPCKilled(DeathEvent) {
            var att = DeathEvent.Attacker;
            var vic = DeathEvent.Victim;
            var attloc = att.Location;
            var vicloc = vic.Character.get_origin();
            var vicloc2 = vicloc.toString();
            //var SpawnPA = vicloc2.split(",");
            if (DeathEvent.Victim.Name == "Wolf" || DeathEvent.Victim.Name == "Bear") {
                World.Spawn(";drop_lootsack_zombie", vicloc);
            }

    }


