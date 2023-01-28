using System;
using System.Collections.Generic;
using System.Linq;
using Oxide.Core.Plugins;
using Oxide.Core;
using Oxide.Core.Libraries;

namespace Oxide.Plugins
{
    [Info("X9", "Screamo", 1.0)]
    [Description("Delator de players fazendo explosive charge.")]
    class HeadRecomp: RustLegacyPlugin
    {
        [PluginReference] Plugin FriendsDatabase;
        static System.Random random = new System.Random();

        static List<ulong> ByAdmin = new List<ulong>();
        static List<ulong> ByRandom = new List<ulong>();
        static List<string> logger = new List<string>();
        readonly Dictionary<int, ItemDataBlock> dataBockPremio = new Dictionary<int, ItemDataBlock>();

        static string Prefixo = "LaCaza";
        static bool PlayerRandomActive = false;

        void OnServerInitialized()
        {
            //StartRandom();
            dataBockPremio.Clear();
            foreach (var item in DatablockDictionary.All)
            {
                dataBockPremio.Add(dataBockPremio.Count, item);
            }
            
            
        }
        void Loaded()
        {
            logger = Interface.Oxide.DataFileSystem.ReadObject<List<string>>("HeadRecomp/Logger");
        }
        void SaveData()
        {
            Interface.Oxide.DataFileSystem.WriteObject("HeadRecomp/Logger", logger);
        }

        [ChatCommand("rh")]
        void cmdRh(NetUser netuser, string cmd, string[] args)
        {
            if (!netuser.CanAdmin()) { rust.Notice(netuser, "No puedes usar este comando"); return; }
            if (args.Length < 1) { rust.Notice(netuser, "Use /rh nick, para colocar precio a la cabeza de un jugador jeje"); return; }
            NetUser targetuser = rust.FindPlayer(args[0]);
            if (targetuser == null) { rust.Notice(netuser, "No encontramos al jugador"); return; }
            if (ByAdmin.Contains(targetuser.userID) || ByRandom.Contains(targetuser.userID))
            { rust.Notice(netuser, "[color orange]El que traiga [color red]LA CABEZA[color orange] de [color purple](" + targetuser.displayName + ") [color orange]sera [color green]PREMIADO"); return; }
            ByAdmin.Add(targetuser.userID);
            //NoticeAll("A Cabeça De (" + targetuser.displayName + ") Foi Colocada a Premio Pelo Admin");
            rust.BroadcastChat(Prefixo, "[color orange]El que traiga [color red]LA CABEZA[color orange] de el jugador  [color purple]" + targetuser.displayName + " [color green]Recibira un PREMIO");
        }

        void StartRandom()
        {
            timer.Repeat(5f, 0, () => {
                if (!PlayerRandomActive)
                {
                    try
                    {
                        if (PlayerClient.All.Count < 1) return;
                        int randomPlayer = random.Next(1, PlayerClient.All.Count);
                        int t = 0;
                        NetUser user = null;
                        foreach (var pair in PlayerClient.All)
                        {
                            t++;
                            if (t == randomPlayer) user = pair.netUser;

                        }
                        ByRandom.Add(user.userID);
                        PlayerRandomActive = true;
                        NoticeAll("El que traiga LA CABEZA de (" + user.displayName + ") sera PREMIADO!");

                    }
                    catch (Exception ex)
                    {
                        Logger(string.Format("{0} - Number 1 - {1}", DateTime.Now.ToString(), ex));
                    }
                }
                else
                {
                    try
                    {
                        NetUser user = null;
                        foreach (var pair in ByRandom.ToList())
                        {
                            user = rust.FindPlayer(pair.ToString());
                        }
                        if (user == null)
                        {
                            ByRandom.Clear();
                            PlayerRandomActive = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger(string.Format("{0} - Number 2 - {1}", DateTime.Now.ToString(), ex));
                    }
                }
            });
        }

        private void OnPlayerDeath(TakeDamage takedamage, DamageEvent damage)
        { 
            NetUser Attacker = damage.attacker.client?.netUser ?? null;
            NetUser Victim = damage.victim.client?.netUser ?? null;

            if(ByAdmin.Contains(Victim.userID) || ByRandom.Contains(Victim.userID) && Attacker != null)
            {
                NoticeAll(string.Format("{0} MATO A {1} Y POR ESTO FUE PREMIADO!", Attacker.displayName, Victim.displayName));
                rust.BroadcastChat(Prefixo, string.Format("[color purple]{0}[color orange] MATO A [color purple]{1}[color orange] Y POR ESO FUE PREMIADO", Attacker.displayName, Victim.displayName));
                Premiar(Attacker);
                if (ByAdmin.Contains(Victim.userID)) ByAdmin.Remove(Victim.userID);
                else if (ByRandom.Contains(Victim.userID)) ByRandom.Clear();
            }
        }

        bool Shared(string AttaKer, string Victim)
        {
            object isFriend = Interface.CallHook("isSharing", Victim, AttaKer);
            if (isFriend is bool && (bool)isFriend) return true;
            return false;
        }
        readonly static List<string> Blocks = new List<string>(new string[] 
        {
            "handmade shell blueprint","casing","empty","primed","invisible", "armor part","can","bp","blueprint", "weapon part", "camp fire", "large wood storage"
        });
        readonly static List<string> livre = new List<string>(new string[]
        {
            "ammo", "wood planks ","leather","low quality metal","metal fragments","metal ore","sulfur","sulfur ore","charcoal","cloth","wood","weapon","kevlar"
        });
        void Premiar(NetUser netuser)
        {
            int randompremio = random.Next(1, dataBockPremio.Count);
            ItemDataBlock item = null;
            
            foreach(var pair in dataBockPremio.ToList())
            {
                if (pair.Key == randompremio)
                {
                    item = pair.Value;
                    break;
                }
                else continue;
            }
            bool teste = false;
            foreach(var pair in Blocks)
            {
                if (item.name.ToLower().Contains(pair))
                {
                    Premiar(netuser);
                    teste = true;
                    break;
                }
            }
            if (teste) return;
            int uses = item._maxUses;
            foreach(var pair in livre)
            {
                if(!item.name.Contains(pair) && item._maxUses > 5 || item.ToString().ToLower().Contains("bulletweapondatablock"))
                {
                    uses = 5;
                }
            }

            Inventory inv = netuser.playerClient.rootControllable.GetComponent<Inventory>();
            inv.AddItemAmount(item, uses);

        }

        void Logger(string m) { logger.Add(m); SaveData(); }
        void NoticeAll(string m)
        {
            foreach (PlayerClient netuser in PlayerClient.All)
            {
                rust.Notice(netuser.netUser, m);
            }
        }
    }
}
