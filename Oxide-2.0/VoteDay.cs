using UnityEngine;
using Facepunch;
using Facepunch.Utility;
using Facepunch.ID;
using Oxide.Plugins;
using Oxide.Game;
using System.Collections.Generic;
using System;
using player = NetUser;

namespace Oxide.Plugins
{
    [Info("VoteDay", "Trectar", 1.0)]

    class VoteDay : RustLegacyPlugin
    {
        List<player> votosdia = new List<player>();		
        List<player> votosnoche = new List<player>();
		
        string tag = "VoteDay";
		
        static bool abierto = false;
        int dia = 0;
        int noche = 0;

		void OnServerInitialized()
		{
			timer.Once(5f, () =>
			{
				Votacion();
			});
		}
		
		void Votacion()
		{
			timer.Once(30f, () =>
            {
            	Votacion();

				if (abierto)
				{
					return;
				}
			
                if ((Gettime() > 18) && (Gettime() < 18.3))
                {
                 
                    foreach (player x in rust.GetAllNetUsers())
                    {
						rust.SendChatMessage(x,"VoteDay", "[color cyan]Se abrio la votación de tiempo");
						rust.SendChatMessage(x,"VoteDay", "[color cyan]escribe tu elección.");
						rust.SendChatMessage(x,"VoteDay", "--------------------------------");
						rust.SendChatMessage(x,"VoteDay", "Escribe [color yellow]/voto dia");
						rust.SendChatMessage(x,"VoteDay", "Escribe [color yellow]/voto noche");
						rust.SendChatMessage(x,"VoteDay", "--------------------------------");
                    }

                    abierto = true;
                }
            });
		}
		
		float Gettime()
        {
            float time = EnvironmentControlCenter.Singleton.GetTime();
            return time;
        }
		
        void abrirvote(player user, string[] args)
        {
            timer.Once(30f,()=>{
				abierto = false;

                if (votosdia.Count > votosnoche.Count)
                {
                    rust.RunServerCommand("env.time 7");
                    foreach (player todos in rust.GetAllNetUsers())
                    {
                        rust.SendChatMessage(todos,"VoteDay", "[color cyan]La votación concluyó...");
						rust.SendChatMessage(todos,"VoteDay", "[color orange]Se hizo de dia.");
                    }
                }
                else if (votosnoche.Count > votosdia.Count)
                {
                    foreach (player todos in rust.GetAllNetUsers())
                    {
                        rust.SendChatMessage(todos,"VoteDay", "[color cyan]La votación concluyó...");
						rust.SendChatMessage(todos,"VoteDay", "[color orange]Se quedara de noche.");
                    }
                }
                votosnoche.Clear();
                votosdia.Clear();

            });
            if (votosnoche.Contains(user) || votosdia.Contains(user))
            {
                rust.SendChatMessage(user,"VoteDay", "[color red][!] [color orange]Ya votaste, espera a la siguiente votación.");
                return;
            }
            if (abierto == false)
            {
                rust.SendChatMessage(user,"VoteDay", "[color red][!] [color orange]Todavía no abrio la votación.");;
                return;
            }
            if (args.Length == 0)
            {
                rust.SendChatMessage(user,"VoteDay", "[color cyan][?] [color orange]Usa [color yellow]/voto dia [color orange]o [color yellow]/voto noche[color orange].");
                return;
            }
            if (args[0] == "dia")
            {
                votosdia.Add(user);
                object[] dat = { user.displayName.ToString(), votosdia.Count.ToString(), votosnoche.Count.ToString() };
                rust.BroadcastChat(tag, string.Format("[color yellow] {0} [color cyan]votó para dia [color purple]- [color orange]Dia: [color yellow]{1} [color purple]- [color orange]Noche: [color yellow]{2}",dat));
                
            }
            else
            {
                votosnoche.Add(user);
                object[] dat = { user.displayName.ToString(), votosdia.Count.ToString(), votosnoche.Count.ToString() };
                rust.BroadcastChat(tag, string.Format("[color yellow] {0} [color cyan]votó para noche [color purple]- [color orange]Dia: [color yellow]{1} [color purple]- [color orange]Noche: [color yellow]{2}",dat));
            }
        }
		
        [ChatCommand("voto")]
        void votar(NetUser netUser, string command, string[] args)
        {
            abrirvote(netUser, args);
        }
    }
}

