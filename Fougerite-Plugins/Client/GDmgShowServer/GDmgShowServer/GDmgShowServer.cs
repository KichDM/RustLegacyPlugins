using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RustBuster2016Server;
using Fougerite;
using UnityEngine;

namespace GDmgShowServer {
    public class FougeritePlugin : Fougerite.Module {
        public List<string> IDs = new List<string>();

        public override string Author {
            get { return "Gintaras"; }
        }

        public override string Name {
            get { return "GDmgShowServer"; }
        }

        public override Version Version {
            get { return new Version("1.0"); }
        }

        public override string Description {
            get { return "Server side for dmg show"; }
        }

        public override void DeInitialize() {
            API.OnRustBusterUserMessage -= On_MessageReceived;
            Hooks.OnPlayerHurt -= HandlerPlayerHurts;
            Hooks.OnPlayerConnected -= PlayerConnected;
            Hooks.OnPlayerDisconnected -= PlayerDisconnected;
        }

        public override void Initialize() {
            IDs.Add("655245752526252");
            API.OnRustBusterUserMessage += On_MessageReceived;
            Hooks.OnPlayerHurt += HandlerPlayerHurts;
            Hooks.OnPlayerConnected += PlayerConnected;
            Hooks.OnPlayerDisconnected += PlayerDisconnected;
        }

        public void On_MessageReceived(API.RustBusterUserAPI user, Message msgc) {
            // If the Client Plugin that is sending the message is TestPlugin
            // Ensure to do this ALL the time, or you can mess up other plugin's code.
            if (msgc.PluginSender == "GMap") {
                string msg = msgc.MessageByClient;
                string[] split = msg.Split('-');
                // If The client wants to know that it can enable the gui
                if (split[1] == "CanGUI") {
                    if (IDs.Contains(split[0])) {
                        // Answer yes
                        msgc.ReturnMessage = "yes";
                    } else {
                        msgc.ReturnMessage = "no";
                    }
                }
            }
        }
        public void HandlerPlayerHurts(HurtEvent e) {
            // Checking if the Attacker is a Player
            if (e.Attacker is Fougerite.Player) {
                Player attacker = (Player)e.Attacker;
                Player victim = (Player)e.Victim;

                string attackerName = attacker.Name;
                string victimName = victim.Name;

                float damageAmount = e.DamageAmount;

                Server.GetServer().Broadcast(attackerName + " dealt " + damageAmount + " damage to " + victimName);
            }
        }
        public void PlayerConnected(Fougerite.Player Player) {

        }
        public void PlayerDisconnected(Fougerite.Player Player) {

        }
    }
}
