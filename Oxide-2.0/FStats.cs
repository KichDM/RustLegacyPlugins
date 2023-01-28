using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Facepunch.Clocks.Counters;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Core.Configuration;
using UnityEngine;
using RustExtended;

namespace Oxide.Plugins
{

    [Info("RNDStat", "lutseferTest", "0.1")]
    [Description("RNDStat")]
    class FStats : RustLegacyPlugin
    {










        bool hasAccess(NetUser player)
        {
            if (!player.CanAdmin())
            {

                return false;
            }
            return true;
        }








        public static List<string> ToListAs(string text, string inx)
        {
            string[] itemnom = new string[] { inx };
            string[] result = text.Split(itemnom, StringSplitOptions.RemoveEmptyEntries);
            return result.ToList();
        }



        string ChatName = RustExtended.Core.ServerName;

        static void SendMessage(PlayerClient player, string message) { ConsoleNetworker.SendClientCommand(player.netPlayer, "chat.add Statistics " + Facepunch.Utility.String.QuoteSafe(message)); }


        [ChatCommand("stat")]
        void statistic(NetUser netuser, string command, string[] args)
        {

            SendMessage(netuser.playerClient, string.Format("{0}", "[color#00FFFF]Вы играете на сервере: [color #FFFF00]Military RUST"));
            string time = "[color #00FFFF]Вы провели в игре :   [color #00FF00]" + gentext(netuser.userID.ToString()) + "[color #00FF00]";
            UserData userData = Users.GetBySteamID(netuser.userID);
            string plkil = "[color #00FFFF]Убито игроков:   [color #00FF00]" + RustExtended.Economy.Get(netuser.userID).PlayersKilled + "[color #00FF00]";
            string mutkil = "[color #00FFFF]Убито мутантов:   [color #00FF00]" + RustExtended.Economy.Get(netuser.userID).MutantsKilled + "[color #00FF00]";
            string anikill = "[color #00FFFF]Убито животных:   [color #00FF00]" + RustExtended.Economy.Get(netuser.userID).AnimalsKilled + "[color #00FF00]";
            string death = "[color #00FFFF]Погибли:   [color #00FF00]" + RustExtended.Economy.Get(netuser.userID).Deaths + "[color #00FF00]";
            string rang = "[color #00FFFF]Ваш статус :   [color #00FF00]" + RustExtended.Core.Ranks[userData.Rank] + "[color #00FF00]";

            SendMessage(netuser.playerClient, string.Format("{0}", time));
            SendMessage(netuser.playerClient, string.Format("{0}", rang));
            SendMessage(netuser.playerClient, string.Format("{0}", plkil));
            SendMessage(netuser.playerClient, string.Format("{0}", mutkil));
            SendMessage(netuser.playerClient, string.Format("{0}", anikill));
            SendMessage(netuser.playerClient, string.Format("{0}", death));

        }


        [ChatCommand("sclear")]
        void statisticxx(NetUser netuser, string command, string[] args)
        {


            if (hasAccess(netuser))
            {
                data.Clear();
            }
            statistic(netuser, command, args);
        }





        public string ufind(NetUser netuser,string text)
        {
            UserData userData3 = Users.Find(text);
            if (userData3 == null)
            {
                rust.SendChatMessage(netuser, "Tops", " игрок не найден");
                return null;
            }
            
            return userData3.SteamID.ToString();
        }



        [ChatCommand("tops")]
        void statistictpps(NetUser netuser, string command, string[] args)
        {



            if (hasAccess(netuser))
            {
               
                if (args.Length > 2)
                {


                    if (args[0].ToLower() == "add")
                    {


                        if (args[1] != null && args[2] != null)
                        {
                            
                         string  uid  = ufind(netuser, args[1]);
                            if (uid !=null)
                            {

                                var date = DateTimeTOsting(DB(uid).TimePlayGame);
                                DB(uid).TimePlayGame = DateTimeTOsting(date.AddSeconds(Convert.ToDouble(args[2])));
                                SendMessage(netuser.playerClient, string.Format("{0}", " ok!!"));
                            }



                        }
                        else
                        {
                            SendMessage(netuser.playerClient, string.Format("{0}", " пример /tops add 77777000 10"));
                            SendMessage(netuser.playerClient, string.Format("{0}", " пример /tops add Atamg 10"));
                            SendMessage(netuser.playerClient, string.Format("{0}", " пример /tops add Ata* 10"));
                        }




                    }

                    if (args[0].ToLower() == "set")
                    {


                        if (args[1] != null && args[2] != null)
                        {



                            string  uid  = ufind(netuser, args[1]);
                            if (uid !=null)
                            {

                                var date = new DateTime(1, 1, 1, 0, 0, 0, 0);
                                DB(uid).TimePlayGame = DateTimeTOsting(date.AddSeconds(Convert.ToDouble(args[2])));
                                SendMessage(netuser.playerClient, string.Format("{0}", " ok!!"));
                            }
                      

                        }
                        else
                        {

                            SendMessage(netuser.playerClient, string.Format("{0}", " пример /tops set 77777000 10"));
                            SendMessage(netuser.playerClient, string.Format("{0}", " пример /tops set Atamg 10"));
                            SendMessage(netuser.playerClient, string.Format("{0}", " пример /tops set Ata* 10"));
                        }




                    }






                    return;

                }
                SendMessage(netuser.playerClient, string.Format("{0}", "/tops add uid-name second"));
                SendMessage(netuser.playerClient, string.Format("{0}", "/tops set uid-name second"));
            }
            SendMessage(netuser.playerClient, string.Format("{0}", "[color #00FFFF]Лидеры по игре на сервере: [color #FFFF00]Military RUST"));






            List<KeyValuePair<string, Userstimegame>> myList = new List<KeyValuePair<string, Userstimegame>>(data);
            myList.Sort(
                delegate(KeyValuePair<string, Userstimegame> firstPair,
                    KeyValuePair<string, Userstimegame> nextPair)
                {




                    return DateTimeTOsting(nextPair.Value.TimePlayGame).CompareTo(DateTimeTOsting(firstPair.Value.TimePlayGame));
                }
            );


            int nn = 0;
            string othernick = "";
            foreach (var players in myList)
            {
                nn++;
                if (nn < 5)
                {

                    string tex1 = String.Format("{0} место", nn);
                    string tex2 = String.Format("{0} : {1}", getnameuserindb(players.Key), gentext(players.Key));
                    rust.SendChatMessage(netuser, tex1, tex2);
                }
                else
                {
                    othernick += getnameuserindb(players.Key) + ", ";
                }




            }

            if (othernick.Length > 0)
            {
                string xxx = "[color #00FFFF]Остальные игроки :   [color #00FF00]" + othernick + "[color #00FF00]";
                rust.SendChatMessage(netuser, "Остальные игроки", othernick);

            }




        }



      





        public string getnameuserindb(string id)
        {
            if (Users.Database.ContainsKey(Convert.ToUInt64(id)))
            {
                return Users.Database[Convert.ToUInt64(id)].Username;
            }

            return "Unckown [" + id + "]";
        }



        public string gentext(string steamid)
        {

            string ret = "";
            var datex = DateTimeTOsting(DB(steamid).TimePlayGame);


            var date = datex.Subtract(new DateTime(1, 1, 1, 0, 0, 0, 0));

            if (date.Days > 0) { ret += date.Days + " Дней "; }
            if (date.Hours > 0) { ret += date.Hours + " Часов "; }
            if (date.Minutes > 0) { ret += date.Minutes + " Минут "; }
            if (date.Seconds > 0) { ret += date.Seconds + " Секунд "; }



            return ret;
        }
        void LoadDefaultConfig() { }



        void Init()
        {
            LoadData();


        }
        void Plugininit()
        {
            Init();
        }




        public class Userstimegame
        {
            public string TimePlayGame { get; set; }
        }
        public static Dictionary<string, Userstimegame> data;
        public static Dictionary<string, DateTime> ustime = new Dictionary<string, DateTime>();
        void LoadData()
        {
            data = (Dictionary<string, Userstimegame>)Interface.GetMod().DataFileSystem.ReadObject<Dictionary<string, Userstimegame>>("FStats");


        }
        void SaveData()
        {
            Interface.GetMod().DataFileSystem.WriteObject("FStats", data, false);

        }
        public static string DateTimeTOsting(DateTime dt)
        {

            return dt.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        public static DateTime DateTimeTOsting(string dt)
        {
            try
            {


                return DateTime.ParseExact(dt, "yyyy-MM-dd HH:mm:ss.fff", null);
            }
            catch (Exception e)
            {
                return DateTime.Now;
            }

        }

        public class DBtim
        {
            public DateTime this[object instance]
            {
                get { return DBtimxx((string)instance); }   // get method
                set { DBtims((string)instance, value); }  // set method
            }

        }

        public class DBx
        {
            public Userstimegame this[object instance]
            {
                get { return DB((string)instance); }   // get method
                set { DBset((string)instance, value); }  // set method
            }

        }



        public static DateTime DBtims(string steamid, DateTime x)
        {


            if (!ustime.ContainsKey(steamid))
                ustime.Add(steamid, DateTime.Now);
            return ustime[steamid] = x;
        }

        public static DateTime DBtimxx(string steamid)
        {


            if (!ustime.ContainsKey(steamid))
                ustime.Add(steamid, DateTime.Now);
            return ustime[steamid];
        }
        public static Userstimegame DB(string steamid)
        {


            if (!data.ContainsKey(steamid))
                data.Add(steamid, new Userstimegame()
                {
                    TimePlayGame = DateTimeTOsting(new DateTime(1, 1, 1, 0, 0, 0, 0))
                });
            return (object)data[steamid] as Userstimegame;
        }



        public static Userstimegame DBset(string steamid, Userstimegame x)
        {


            if (!data.ContainsKey(steamid))
                data.Add(steamid, new Userstimegame()
                {
                    TimePlayGame = DateTimeTOsting(new DateTime(1, 1, 1, 0, 0, 0, 0))
                });
            return data[steamid] = x;
        }

        void OnServerSave() { SaveData(); }
        void Unload() { SaveData(); }

        void Loaded()
        {
            Init();
        }

















        private DBtim t = null;
        private DBx x = null;

        public void addtime(NetUser netUser)
        {
            if (t == null) t = new DBtim();

            if (x == null) x = new DBx();
            DateTime curentTime = DateTime.Now;
            if (curentTime.Subtract(t[netUser.userID.ToString()]).Seconds >= 5)
            {

                t[netUser.userID.ToString()] = DateTime.Now;

                var date = DateTimeTOsting(DB(netUser.userID.ToString()).TimePlayGame);
                DB(netUser.userID.ToString()).TimePlayGame = DateTimeTOsting(date.AddSeconds(5));
                //var date = DateTimeTOsting(x[netUser.userID.ToString()].TimePlayGame);
                //x[netUser.userID.ToString()].TimePlayGame = DateTimeTOsting(date.AddSeconds(5));

                //x[netUser.userID.ToString()] = x[netUser.userID.ToString()];

            }
            else
            {


            }
        }



        void OnGetClientMove(HumanController controller, Vector3 newPos)
        {
            DateTime CurTime = DateTime.Now;


            var netuser = controller.netUser;

            addtime(netuser);



        }








    }
}
