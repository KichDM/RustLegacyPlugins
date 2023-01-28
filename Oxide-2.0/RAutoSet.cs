using System;

using System.Collections.Generic;



namespace Oxide.Plugins

{

    [Info("AutoSet", "Kazzooom", "1.0.0")]

    class RAutoSet : RustLegacyPlugin

    {

        private Dictionary<string, int> commandsToUse = new Dictionary<string, int>()            

        {   

            { "serv.remove \"CampFire\"", 600 },

            { "serv.remove \"Barricade Fence Deployable\"", 600 }

        };



        void Loaded()

        {

            foreach (var command in commandsToUse)

            {

                timer.Repeat(command.Value, 0, () => rust.RunServerCommand(command.Key));

            }

        }

    }

}

