using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Oxide.Core;
using Oxide.Core.Libraries;
using RustExtended;
using UnityEngine;

namespace Oxide.Plugins
{
	[Info("Skype", "REACT PLUGIN", 1.0)]
	[Description("Call me to skype")]

	class Skype : RustLegacyPlugin
	{
		public List<RustExtended.UserData> TargetUsers = new List<RustExtended.UserData>();

		void Init()
		{
			if (!Config.Exists())
			{
				LoadDefaultConfig();
			}
			else
			{
				Config.Load();
			}
		}

		[ChatCommand("skype")]
		void skype(NetUser netUser, string command, string[] args)
		{
			RustExtended.UserData us = RustExtended.Users.GetBySteamID(netUser.userID);
			if (args.Length > 0 && us.Rank >= (int)Config["MinAdminRank"])
			{
				RustExtended.UserData receiver = RustExtended.Users.Find(args[0]);
				if (receiver != null)
				{
					if (!TargetUsers.Contains(receiver))
					{
						PlayerClient reciverpl;
						if(PlayerClient.FindByUserID(receiver.SteamID, out reciverpl)){
						TargetUsers.Add(receiver);
						rust.Notice(reciverpl.netUser, (string)Config["NoticeText"], "!", float.Parse((string)Config["NoticeTime"]));
						rust.SendChatMessage(reciverpl.netUser, (string)Config["BotName"], (string)Config["MessageLine1"]);
						rust.SendChatMessage(reciverpl.netUser, (string)Config["BotName"], (string)Config["MessageLine2"]);
						SendReply(netUser, "[color green]Вы вызвали "+receiver.Username+" на проверку!");
						timer.Once(float.Parse((string)Config["BanTimer"]), () =>
							{
								if (TargetUsers.Contains(receiver))
								{
									TargetUsers.Remove(receiver);
									Users.Ban(receiver.SteamID, "Отказ от проверки!");
									reciverpl.netUser.Kick(0, true);
                                    SendReply(netUser, "[color green]Получил бан за отказ от проверки!");
								}

							});
						} else {
							SendReply(netUser, "[color green]Данный игрок оффлайн!");
						}
					}
					else
					{
						TargetUsers.Remove(receiver);
                        SendReply(netUser, "[color green]Вы отменили проверку!");
					}
				}
				else
				{
					SendReply(netUser, "[color red]Игрок не найден!");
				}
			}
			else
			{
				SendReply(netUser, "[color red]Не верная команда");
				SendReply(netUser, "[color red]Попробуй /skype <ник>");
			}
		}

		void OnPlayerDisconnected(uLink.NetworkPlayer networkPlayer)
		{
			NetUser pl = (NetUser)networkPlayer.GetLocalData();
			RustExtended.UserData receiver = RustExtended.Users.GetBySteamID(pl.playerClient.userID);
			if (TargetUsers.Contains(receiver))
			{
				TargetUsers.Remove(receiver);
				Users.Ban(receiver.SteamID, "Выход во время проверки!");
			}
		}

		protected override void LoadDefaultConfig()
		{
			PrintWarning("Creating a new configuration file");
			Config.Clear();
			Config["MinAdminRank"] = 2;
			Config["BanTimer"] = "60";
			Config["NoticeTime"] = "20";
			Config["BotName"] = "Admin";
			Config["NoticeText"] = "В skype на проверку";
			Config["MessageLine1"] = "[color green]Вас вызвали на проверку";
			Config["MessageLine2"] = "[color green]У вас есть минута что бы сообщить свой Skype в чат";
			SaveConfig();
		}

	}

}