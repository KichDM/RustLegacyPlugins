// R-eference: Facepunch.ID
// R-eference: Google.ProtocolBuffers
// Reference: Facepunch.HitBox
 
using Oxide.Core;
using Oxide.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using static Oxide.Core.Configuration.DynamicConfigFile;
namespace Oxide.Plugins
{
    [Info("Stats", "BDM", "1.0.0")]
    public class Stats : RustLegacyPlugin
    {
        void LoadDefaultMessages()
        {
            var messages = new Dictionary<string, string>
            {
                {"Prefix", "Stats"},
                { "pvpinformationintro", "[color orange]----------------------PVP Information---------------------"},
                { "killdeathratio", "Kill/Death Ratio: "},
                { "playerkills", "Tus Asesinatos: "},
                { "playerdeaths", "Tus Muertes: "},
                { "mostusedgun", "Arma mas Usada: "},
                { "mostusedmeleeweapon", "Arma mele mas usada: "},
                { "playersuicides", "Te Suicidaste: "},
                { "nopermwipe", "You dont have permission to use /wipe"},
                { "datawiped", "[color red]Stats Data Wiped!"}
        };
            lang.RegisterMessages(messages, this);
        }
        [PluginReference]
        private Plugin Death;
        private Dictionary<string, Player> stats;
        void Loaded()
        {
            permission.RegisterPermission("stats.allowed", this);
            stats = Interface.Oxide.DataFileSystem.ReadObject<Dictionary<string, Player>>("Stats");
            LoadDefaultMessages();
        }
        private void SaveData()
        {
            Interface.Oxide.DataFileSystem.WriteObject("Stats", stats);
        }
         private void OnPlayerSuicide(TakeDamage takedamage, DamageEvent damage, object tags)
        {
            Player steamId = getPlayerCreateIfNotExist(tags.GetProperty("killerId").ToString());
 
            if (steamId == null) return;
 
            steamId.name = tags.GetProperty("killer").ToString();
            steamId.steamId = tags.GetProperty("killerId").ToString();
            steamId.suicides++;
            int suicide = steamId.suicides;
            SaveData();
        }
         private void OnPlayerDeath(TakeDamage takedamage, DamageEvent damage, object tags)
        {
            string weapon = tags.GetProperty("weapon").ToString();
            string deathtype = tags.GetProperty("deathType").ToString();
            string body = tags.GetProperty("bodypart").ToString();
            string killer = tags.GetProperty("killerId").ToString();
            string bodyPart = tags.GetProperty("bodypart").ToString();
            Player pKiller = getPlayerCreateIfNotExist(tags.GetProperty("killerId").ToString());
            Player pKilled = getPlayerCreateIfNotExist(tags.GetProperty("killedId").ToString());
            pKiller.name = tags.GetProperty("killer").ToString();
            pKiller.steamId = tags.GetProperty("killerId").ToString();
            pKiller.kills++;
            pKilled.name = tags.GetProperty("killed").ToString();
            pKilled.steamId = tags.GetProperty("killedId").ToString();
            pKilled.deaths++;
            int beginm4 = pKiller.m4;
            int beginp250 = pKiller.p250;
            int begin9mm = pKiller.pistol9mm;
            int beginhuntingbow = pKiller.huntingbow;
            int addone = 1;         
            if (weapon == "M4")
            {
                pKiller.m4 = beginm4 + addone;
            }
            else if (weapon == "P250")
            {
                pKiller.p250 = beginp250 + addone;
            }
            else if (weapon == "9mm Pistol")
            {
                pKiller.pistol9mm = begin9mm + addone;
            }
            else if (weapon == "Hunting Bow")
            {
                pKiller.huntingbow = beginhuntingbow + addone;
            }
            /*
            if (body == "head")
            {
                pKiller.experience = begin + head;
            }
            else if (body == "neck")
            {
                pKiller.experience = begin + neck;
            }
            else if (body == "chest")
            {
                pKiller.experience = begin + chest;
            }
            else if (body == "torso")
            {
                pKiller.experience = begin + torso;
            }
            else if (body == "hip")
            {
                pKiller.experience = begin + hip;
            }
            else if (body == "left calve")
            {
                pKiller.experience = begin + leftcalve;
            }
            else if (body == "right calve")
            {
                pKiller.experience = begin + rightcalve;
            }
            else if (body == "right shoulder")
            {
                pKiller.experience = begin + rightshoulder;
            }
            else if (body == "left shoulder")
            {
                pKiller.experience = begin + leftshoulder;
            }
            else if (body == "right bicep")
            {
                pKiller.experience = begin + rightbicep;
            }
            else if (body == "left bicep")
            {
                pKiller.experience = begin + leftbicep;
            }
            else if (body == "right foot")
            {
                pKiller.experience = begin + rightfoot;
            }
            else if (body == "left foot")
            {
                pKiller.experience = begin + leftfoot;
            }
            else if (body == "right wrist")
            {
                pKiller.experience = begin + rightwrist;
            }
            else if (body == "left wrist")
            {
                pKiller.experience = begin + leftwrist;
            }
            else if (body == "right ankle")
            {
                pKiller.experience = begin + rightankle;
            }
            else if (body == "left ankle")
            {
                pKiller.experience = begin + leftankle;
            }
            else
            {
                pKiller.experience = begin + addone;
            }
            SaveData();
            */
        }
         void OnPlayerConnected(NetUser netUser)
        {
            Player player = getPlayerCreateIfNotExist(netUser.userID.ToString());
        }
        [ChatCommand("stats")]
        void cmdPlayers(NetUser netUser, string command, string[] args)
        {
            Player player = getPlayerCreateIfNotExist(netUser.userID.ToString());
            float killdeath = (float)player.kills / (float)player.deaths;
            player.killdeath = killdeath;
            string KillsDeaths = killdeath.ToString();
            player.steamId = netUser.userID.ToString();
            player.name = netUser.displayName.ToString();
            int m4uses = player.m4;
            int p250uses = player.p250;
            int huntingbowuses = player.huntingbow;
            int pistol9mmuses = player.pistol9mm;
            if (m4uses > p250uses && m4uses > pistol9mmuses && m4uses > huntingbowuses)
            {
                string commongun = "M4";
                player.commongunused = commongun;
            }
            if (p250uses > m4uses && p250uses > pistol9mmuses && p250uses > huntingbowuses)
            {
                string commongun = "P250";
                player.commongunused = commongun;
            }
            if (pistol9mmuses > m4uses && pistol9mmuses > p250uses && pistol9mmuses > huntingbowuses)
            {
                string commongun = "9mm Pistol";
                player.commongunused = commongun;
            }
            if (huntingbowuses > m4uses && huntingbowuses > pistol9mmuses && huntingbowuses > p250uses)
            {
                string commongun = "Hunting Bow";
                player.commongunused = commongun;
            }
            rust.SendChatMessage(netUser, GetMessage("Prefix", netUser.userID.ToString()), GetMessage("pvpinformationintro", netUser.userID.ToString()));
            rust.SendChatMessage(netUser, GetMessage("Prefix", netUser.userID.ToString()), GetMessage("killdeathratio", netUser.userID.ToString()) + KillsDeaths);
            rust.SendChatMessage(netUser, GetMessage("Prefix", netUser.userID.ToString()), GetMessage("playerkills", netUser.userID.ToString()) + player.kills);
            rust.SendChatMessage(netUser, GetMessage("Prefix", netUser.userID.ToString()), GetMessage("playerdeaths", netUser.userID.ToString()) + player.deaths);
            rust.SendChatMessage(netUser, GetMessage("Prefix", netUser.userID.ToString()), GetMessage("mostusedgun", netUser.userID.ToString()) + player.commongunused);
            rust.SendChatMessage(netUser, GetMessage("Prefix", netUser.userID.ToString()), GetMessage("mostusedmeleeweapon", netUser.userID.ToString()) + "Coming soon");
            rust.SendChatMessage(netUser, GetMessage("Prefix", netUser.userID.ToString()), GetMessage("playersuicides", netUser.userID.ToString()) + player.suicides);
        }     
                         [ChatCommand("wipestats")]
        void cmdWipeStats(NetUser netUser, string command)
				{
            if (!permission.UserHasPermission(netUser.playerClient.userID.ToString(), "stats.allowed"))
					{
                rust.SendChatMessage(netUser, GetMessage("Prefix", netUser.userID.ToString()), GetMessage("nopermwipe", netUser.userID.ToString()));
            }
            else 
                    {
                stats.Clear();
                rust.SendChatMessage(netUser, GetMessage("Prefix", netUser.userID.ToString()), GetMessage("datawiped", netUser.userID.ToString()));
            }
        }
        private Player getPlayerCreateIfNotExist(string v)
        {
            Player player;
            if (!stats.TryGetValue(v, out player))
            {
                player = new Player();
                stats.Add(v, player);
            }
            return player;
        }
        class Player
        {
            public string name { get; set; }
            public string steamId { get; set; }
            public int suicides { get; set; }
            public int kills { get; set; }
            public int deaths { get; set; }
            public float killdeath { get; set; }
            public int m4 { get; set; }
            public int p250 { get; set; }
            public int pistol9mm { get; set; }
            public int huntingbow { get; set; }
            public string commongunused { get; set; }
        }
        string GetMessage(string key, string steamId = null) => lang.GetMessage(key, this, steamId);
    }
}