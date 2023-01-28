using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustProto;
using System.Linq;
using Oxide.Core.Libraries.Covalence;
using Newtonsoft.Json;
using System.Text;

namespace Oxide.Plugins
{
    [Info("Essentials", "mcnovinho08", "0.1.0")]
    public class Essentials : RustLegacyPlugin
    {
		Dictionary<NetUser,bool> dano = new Dictionary<NetUser, bool>();
				
		static string Aviso = "[ ! ]";
		static string ChatPrefix = "Oxide";
		static bool MSGGlobal = true;
		
		static bool messagesSuicides     = true;
		static bool messagesDeaths       = true;
		static int maxTopsList           = 5;
		
		JsonSerializerSettings jsonsettings;
		private Core.Configuration.DynamicConfigFile Ess;
		void LoadData() {Ess = Interface.GetMod().DataFileSystem.GetDatafile("Essentials");}
		void SaveData() {Interface.GetMod().DataFileSystem.SaveDatafile("Essentials");}
		void Unload() { SaveData(); }
		Dictionary<string, object> GetPlayerdata(string userid)
        {
            if (Ess[userid] == null)
                Ess[userid] = new Dictionary<string, object>();
            return Ess[userid] as Dictionary<string, object>;
        }
		//
		
		static string GetPercentageString(double ratio){
		return ratio.ToString("0.0 [color clear]%");
		}

		static string DisplayPercentage(double ratio){
		return string.Format("{0:0.0%}", ratio);
		}
		
		void Init(){
			CheckCfg<string>("Settings: Chat Prefix ", ref ChatPrefix);
			CheckCfg<string>("Settings: Notice ", ref Aviso);
			CheckCfg<bool>("Settings: Global Notification ", ref MSGGlobal);
			permission.RegisterPermission("essentials.admin", this);
			SetupLang();
			SaveConfig();//
			
        }
		
	      protected override void LoadDefaultConfig()
        {
        }
		
		private void CheckCfg<T>(string Key, ref T var){
			if(Config[Key] is T)
			var = (T)Config[Key];  
			else
			Config[Key] = var;
		}
		
		bool hasAccess(NetUser netuser) {
            if (!netuser.CanAdmin())
                return true;
				return permission.UserHasPermission(netuser.playerClient.userID.ToString(), "essentials.admin");
        }
		
		
		string GetMessage(string key, string steamId = null) => lang.GetMessage(key, this, steamId);
		void SetupLang(){
			var message = new Dictionary<string, string>{
				{"NoPermission", "You do not have permission to run this command!"},
				{"InvalidCommand", "Invalid Command! Use: /cmdhelp"},
				{"InvalidPlayer", "Player not found"},
				{"GivePermission", "{0} gave the permission: {1} for you!"},
				{"YouGivePermission", "You gave the permission {0} to {1}."},
				{"UnGivePermission", "{0} has withdrawn the {1} permission from you!"},
				{"YouUnGivePermission", "You have removed the permission {0} from the player {1}."},
				{"CreateGroup", "You have created the group {0} !"},
				{"AddPlayerGroup", "You added {0} to group {1} !"},
				{"YouAddGroup", "You have been added to group {0} by {1}."},
				{"PlayerAddGroup", "Player {0} was added to group {1} by {2}."},
				{"RemPlayerGroup", "You removed {0} from {1}."},
				{"YouRemGroup", "You have been removed from group {0} by {1}."},
				{"PlayerRemGroup", "Player {0} has been removed from group {1} by {2}!"},
				{"AddGroupPermission", "You have added {0} permission on group {1}!"},
				{"RemGroupPermission", "You have removed the permission {0} from group {1}!"},
				{"InvalidGroup", "Invalid Group!"},
				{"ShowDmgOff", "Damage notification disabled"},
				{"ShowDmgOn", "Damage Notification Enabled"},
				
				{"YouSave", "You saved the server!"},
				{"GlobalSave", "Server Saved By: {0}"},
				
				{"Optimizedgame", "Optimized game"},
				
				{"YouFreeze", "You've been frozen! Wait"},
				{"YouUnFreeze", "You've been thawed!"},
				
				{"YouId", "Your id is: {0} "},
				{"TargetID", "Id: {0} , PlayerName: {1} !"},
				
				{"YouIP", "Your ip is: {0}"},
				{"TargetIP", "IP: {0} , PlayerName: {1}"},
				
				{"Suicide", "You committed suicide."},
				
				{"Aboutyou", "About you: {0} !"},
				{"IP", "IP: {0}"},
				{"StreamID", "StreamID: {0}"},
				{"YouLive", "Where do you live: {0}"},
				{"City", "City: {0}"},
				{"Country", "Country: {0}"},
				{"Provider", "Provider: {0}"},
				
				{"GlobalPVP", "PvP Server Has Been Shut Down By: {0}"},
				{"GlobalPVP1", "Server PvP Has Been Enabled By: {0}"},
				
				{"Spacer", "================== [color red][ ! ] [color white]=================="},
		    	{"Help", "Use: /oxide grant <playername> <permission> - Give some permission to the player"}, // completo
				{"Help1", "Use: /oxide revoke <playername> <permission> - Withdraw the player's permission"}, // completo
				{"Help2", "Use: /oxide grantgroup <permission> <group> - Add some group permission"}, // completo
				{"Help3", "Use: /oxide revokegroup <permission> <group> - Remove some group permission"}, // completo
				{"Help4", "Use: /oxide creategroup <group> - Create some group"}, // completo
				{"Help5", "Use: /oxide addgroup <playername> <group> - Give some player a group"}, // completo
				{"Help6", "Use: /oxide remgroup <playername> <group> - Remove the player from the group"}, // completo
				{"Help7", "Use: /fps - Decrease lag"}, // - completo
				{"Help8", "Use: /dmg - Enable or enable notification of damage"}, // completo
				{"Help9", "Use: /save - Save the server, all the data of the players, etc."}, // completo
				{"Help10", "Use: /freeze <playername> - Freeze the player."}, // completo
				{"Help11", "Use: /unfreeze <playername> - Defrost player"}, // completo
				{"Help12", "Use: /id <playername> - View your stream id"}, // completo
				{"Help13", "Use: /ip <playername> - View your ip"}, // completo
				{"Help14", "Use: /die - To commit suicide"}, // completo
				{"Help15", "Use: /unbanall - desbanir todo mundo"}, // completo
				{"Help16", "Use: /globalpvp - Send a Warning to All of the Server"}, // completo
				{"Help17", "Use: /popup <message> <duration> - Send a global message in the notice"}, // completo
				{"More", "Use: /cmdhelp 1/3"}, // completo
				{"More1", "Use: /cmdhelp 2/3"}, // completo
				{"More2", "Use: /cmdhelp 3/3"} // completo
				

				
			}; 
			lang.RegisterMessages(message, this);
		}
		
		[ChatCommand("cmdhelp")]	
        void cmdHelp(NetUser netuser, string command, string[] args)
		{
            
			HelpMSG(netuser);
			
		  switch(args[0]) {
                case "2":
			 HelpMSG1(netuser);
			 break;
                case "3":
			 HelpMSG2(netuser);
			 break;
			 }

		}
 
        [ChatCommand("unbanallsffdfdsfasd")]
        void cmdRcon(NetUser netUser, string command, string[] args)
		{
			if (!hasAccess(netUser)){ rust.SendChatMessage(netUser, ChatPrefix, GetMessage("NoPermission", netUser.userID.ToString())); return;}			
            rust.RunServerCommand("unbanall");
        }

        [ChatCommand("globalpvp")]
        void cmdGlobalPVP(NetUser netuser, string command, string[] args)
        {
            if (!hasAccess(netuser)) { rust.SendChatMessage(netuser, ChatPrefix, GetMessage("NoPermission", netuser.userID.ToString())); return; }
            switch (args[0])
            {
                case "on":
                    {
                        rust.RunServerCommand("server.pvp true");
                        rust.BroadcastChat(ChatPrefix, string.Format(GetMessage("GlobalPVP1"), netuser.displayName));
                    }
                    break;
                case "off":
                    {
                        rust.RunServerCommand("server.pvp false");
                        rust.BroadcastChat(ChatPrefix, string.Format(GetMessage("GlobalPVP"), netuser.displayName));
                        return;
                    }
                    break;
            }
        }

        [ChatCommand("rconlogin")]
        void cmdLoginRcon(NetUser netuser, string command, string[] args){
            var login = (args[1]);
            rust.RunServerCommand("rcon.login "+args[1]);
        }
				
		[ChatCommand("ip")]
        void cmdIp(NetUser netuser, string command, string[] args)		
		{
			if(args.Length > 0)
			{
				NetUser targetuser = rust.FindPlayer(args[0]);
				var Ipt = targetuser.networkPlayer.externalIP;
				rust.SendChatMessage(netuser, ChatPrefix, string.Format(GetMessage("TargetIP", netuser.userID.ToString()), Ipt, targetuser.displayName));
			}
		    var Ip = netuser.networkPlayer.externalIP;
		    rust.SendChatMessage(netuser, ChatPrefix, string.Format(GetMessage("YouIP", netuser.userID.ToString()), Ip));
		}
		
		[ChatCommand("suicide")]
        void cmdDie(NetUser netUser, string command, string[] args)		
		{
			var rootControllable = netUser.playerClient.rootControllable;
			Metabolism metabolism = rootControllable.GetComponent<Metabolism>();
            metabolism.AddPoison(999999);
		    rust.SendChatMessage(netUser, ChatPrefix, GetMessage("Suicide", netUser.userID.ToString()));
		}
		
		[ChatCommand("id")]
        void cmdId(NetUser netuser, string command, string[] args)		
		{
			if (args.Length > 0)
			{
				NetUser targetuser = rust.FindPlayer(args[0]);
				rust.SendChatMessage(netuser, ChatPrefix, string.Format(GetMessage("TargetID", netuser.userID.ToString()), targetuser.userID.ToString(), targetuser.displayName));
				return;
			}
			else
			{
				rust.SendChatMessage(netuser, ChatPrefix, string.Format(GetMessage("YouId", netuser.userID.ToString()), netuser.userID.ToString()));
				return;
			}
		}
		
		//comandos de congelar;
		[ChatCommand("HGFHFGHFG")]
		void cmdCongelar(NetUser netUser, string command, string[] args)
        {
            ulong netUserID = netUser.userID;
			if (!hasAccess(netUser)){ rust.SendChatMessage(netUser, ChatPrefix, GetMessage("NoPermission", netUser.userID.ToString())); return;}
            else if (args.Length != 1)
            {
                rust.SendChatMessage(netUser, ChatPrefix, GetMessage("InvalidCommand", netUser.userID.ToString()));
            }
            else
            {
                NetUser targetuser = rust.FindPlayer(args[0]);
                if (targetuser != null) { rust.SendChatMessage(netUser, ChatPrefix, GetMessage("InvalidPlayer", netUser.userID.ToString())); }
                {
                    rust.RunClientCommand(targetuser, "input.bind Duck 1 None");
                    rust.RunClientCommand(targetuser, "input.bind Jump 3 None");
                    rust.RunClientCommand(targetuser, "input.bind Fire 3 None");
                    rust.RunClientCommand(targetuser, "input.bind AltFire 7 None");
                    rust.RunClientCommand(targetuser, "input.bind Up 6 RightArrow");
                    rust.RunClientCommand(targetuser, "input.bind Down 6 LeftArrow");
                    rust.RunClientCommand(targetuser, "input.bind Left 6 UpArrow");
                    rust.RunClientCommand(targetuser, "input.bind Right 7 DownArrow");
                    rust.RunClientCommand(targetuser, "input.bind Flashlight 8 Insert");
                    rust.Notice(targetuser, GetMessage("YouFreeze", targetuser.userID.ToString()));
     

                }
            }
        }
		
		[ChatCommand("unfreezedfsfdsf")]
		void cmdUnFreeze(NetUser netUser, string command, string[] args)
        {
			if (!hasAccess(netUser)){ rust.SendChatMessage(netUser, ChatPrefix, GetMessage("NoPermission", netUser.userID.ToString())); return;}
            else if (args.Length != 1)
            {
                rust.SendChatMessage(netUser, ChatPrefix, GetMessage("InvalidCommand", netUser.userID.ToString()));
            }
            else
            {
                NetUser targetuser = rust.FindPlayer(args[0]);
                if (targetuser != null)
                {
                    rust.RunClientCommand(targetuser, "input.bind Up W None");
                    rust.RunClientCommand(targetuser, "input.bind Down S None");
                    rust.RunClientCommand(targetuser, "input.bind Left A None");
                    rust.RunClientCommand(targetuser, "input.bind Right D None");
                    rust.RunClientCommand(targetuser, "input.bind Fire Mouse0 None");
                    rust.RunClientCommand(targetuser, "input.bind AltFire Mouse1 none");
                    rust.RunClientCommand(targetuser, "input.bind Sprint LeftShift none");
                    rust.RunClientCommand(targetuser, "input.bind Duck LeftControl None");
                    rust.RunClientCommand(targetuser, "input.bind Jump Space None");
                    rust.RunClientCommand(targetuser, "input.bind Inventory Tab None");
                    rust.RunClientCommand(targetuser, "config.save");
                    rust.Notice(targetuser, GetMessage("YouUnFreeze", targetuser.userID.ToString()));
                }
            }
        }
		
		//optimiza o fps - completo
		[ChatCommand("fps")]
		void cmdFPS(NetUser netuser, string command, string[] args)
		{
			rust.RunClientCommand(netuser,"grass.on false");
		    rust.RunClientCommand(netuser,"grass.forceredraw False");
		    rust.RunClientCommand(netuser,"grass.displacement True");
		    rust.RunClientCommand(netuser,"grass.disp_trail_seconds 0");
		    rust.RunClientCommand(netuser,"grass.shadowcast False");
		    rust.RunClientCommand(netuser,"grass.shadowreceive False");
		    rust.RunClientCommand(netuser,"render.level 0");
		    rust.RunClientCommand(netuser,"render.vsync False");
		    rust.RunClientCommand(netuser,"footsteps.quality 2");
		    rust.RunClientCommand(netuser,"gfx.ssaa False");
		    rust.RunClientCommand(netuser,"gfx.bloom False");
		    rust.RunClientCommand(netuser,"gfx.grain False");
		    rust.RunClientCommand(netuser,"gfx.ssao False");
		    rust.RunClientCommand(netuser,"gfx.tonemap False");
		    rust.Notice(netuser, GetMessage("Optimizedgame"));
		}
		
		//salva o jogo - completo
		[ChatCommand("savefdsfdsfs")]
		void cmdSave(NetUser netUser, string command, string[] args)
        {
			var Id = netUser.userID.ToString();
			ulong netUserID = netUser.userID;
			if (!hasAccess(netUser)){ rust.SendChatMessage(netUser, ChatPrefix, GetMessage("NoPermission", Id)); return;}
			rust.RunServerCommand("save.all");
			rust.Notice(netUser, GetMessage("YouSave", Id));
			rust.BroadcastChat(ChatPrefix, string.Format(GetMessage("GlobalSave", Id), netUser.displayName));

            return;
        }
	 // comando oxide - completo
	    [ChatCommand("oxide")]
		void cmdOxideCommands(NetUser netuser, string command, string[] args) {
			
			var id = netuser.userID.ToString();
			
			if (!hasAccess(netuser)){rust.SendChatMessage(netuser, ChatPrefix, GetMessage("NoPermission", id)); return;}
			if (args.Length == 0) { rust.SendChatMessage(netuser, ChatPrefix, GetMessage("InvalidCommand", id)); return; }
			
			NetUser targetuser = rust.FindPlayer(args[1]);
			var permission = (args[2]);
			var addgroup = (args[3]);
			
			switch(args[0]) {
				case "grant": {
					if (targetuser == null) { rust.SendChatMessage(netuser, ChatPrefix, GetMessage("InvalidPlayer", id)); return;}
					else
					 {
						rust.RunServerCommand("oxide.grant user "+targetuser.displayName+" "+args[2]);
                        rust.SendChatMessage(targetuser, ChatPrefix, string.Format(GetMessage("GivePermission", targetuser.userID.ToString()), netuser.displayName, permission)); 
                     	rust.SendChatMessage(netuser, ChatPrefix, string.Format(GetMessage("YouGivePermission", netuser.userID.ToString()), permission, targetuser.displayName)); 
					}
				}
				break;
				case "revoke":{
					if (targetuser == null) { rust.SendChatMessage(netuser, ChatPrefix, GetMessage("InvalidPlayer", id)); return;}
					else
					 {
						rust.RunServerCommand("oxide.revoke user "+targetuser.displayName+" "+args[2]);
                        rust.SendChatMessage(targetuser, ChatPrefix, string.Format(GetMessage("UnGivePermission", targetuser.userID.ToString()), netuser.displayName, permission)); 
                     	rust.SendChatMessage(netuser, ChatPrefix, string.Format(GetMessage("YouUnGivePermission", netuser.userID.ToString()), permission, targetuser.displayName)); 
					}
				}
				break;
				case "grantgroup":{
					if (addgroup == null) { rust.SendChatMessage(netuser, ChatPrefix, GetMessage("InvalidGroup", id)); return;}
					else
					 {
						rust.RunServerCommand("oxide.grant group "+args[3]+" "+args[2]);
                        rust.SendChatMessage(netuser, ChatPrefix, string.Format(GetMessage("AddGroupPermission", netuser.userID.ToString()), permission, addgroup)); 
					}
				}
				break;
				case "revokegroup":{
					if (addgroup == null) { rust.SendChatMessage(netuser, ChatPrefix, GetMessage("InvalidGroup", id)); return;}
					else
					 {
						rust.RunServerCommand("oxide.revoke group "+args[3]+" "+args[2]);
                        rust.SendChatMessage(netuser, ChatPrefix, string.Format(GetMessage("RemGroupPermission", netuser.userID.ToString()), permission, addgroup)); 
					}
				}
				break;
				case "creategroup":{
						rust.RunServerCommand("oxide.group add "+args[3]);
                     	rust.SendChatMessage(netuser, ChatPrefix, string.Format(GetMessage("CreateGroup", netuser.userID.ToString()), addgroup)); 
				}
				break;
				case "addgroup":{
					if (addgroup == null) { rust.SendChatMessage(netuser, ChatPrefix, GetMessage("InvalidGroup", id)); return;}
					if (targetuser == null) { rust.SendChatMessage(netuser, ChatPrefix, GetMessage("InvalidPlayer", id)); return;}
					else
					 {
						rust.RunServerCommand("oxide.usergroup add "+args[1]+" "+args[3]);
                     	rust.SendChatMessage(netuser, ChatPrefix, string.Format(GetMessage("AddPlayerGroup", netuser.userID.ToString()), targetuser.displayName, addgroup)); 
                     	rust.SendChatMessage(netuser, ChatPrefix, string.Format(GetMessage("YouAddGroup", netuser.userID.ToString()), addgroup, netuser.displayName));
					    if (!MSGGlobal) { rust.BroadcastChat(ChatPrefix, string.Format(GetMessage("PlayerAddGroup"), targetuser.displayName, addgroup, netuser.displayName)); return; }
						
					}
				}
				break;
				case "remgroup":{
					if (targetuser == null) { rust.SendChatMessage(netuser, ChatPrefix, GetMessage("InvalidPlayer", id)); return;}
					else
					 {
						rust.RunServerCommand("oxide.usergroup remove "+args[1]+" "+args[3]);
                     	rust.SendChatMessage(netuser, ChatPrefix, string.Format(GetMessage("RemPlayerGroup", netuser.userID.ToString()), targetuser.displayName, addgroup)); 
                     	rust.SendChatMessage(netuser, ChatPrefix, string.Format(GetMessage("YouRemGroup", netuser.userID.ToString()), addgroup, netuser.displayName));
					    if (!MSGGlobal) { rust.BroadcastChat(ChatPrefix, string.Format(GetMessage("PlayerRemGroup"), targetuser.displayName, addgroup, netuser.displayName)); return; }
						
					}
				}
				break;
				default: {
					rust.SendChatMessage(netuser, ChatPrefix, GetMessage("InvalidCommand", netuser.userID.ToString())); 
					break;
				}
			}
		} // fim
		// ver dano - completo
		[ChatCommand("dmg")]
		void cmdVerDMG(NetUser netuser, string command, string[] args)
		{
			if (dano.ContainsKey(netuser)) 
			{
				if (dano[netuser])
				{
					dano[netuser] = false;
					rust.Notice(netuser, GetMessage("ShowDmgOff", netuser.userID.ToString()));
				} 
				else 
				{
					dano[netuser] = true;
					rust.Notice(netuser, GetMessage("ShowDmgOn", netuser.userID.ToString()));
				}
			} 
			else 
			{
				dano[netuser] = true;
				rust.Notice(netuser, GetMessage("ShowDmgOn", netuser.userID.ToString()));
			}
		} // fim
		
		void OnPlayerConnected(NetUser netuser)
		{
			dano[netuser] = true;
		}
		
		
		void OnPlayerDisconected(uLink.NetworkPlayer networkPlayer)
		{
			NetUser netuser = (NetUser)networkPlayer.GetLocalData();
			dano[netuser] = false;
		}
		
		void HelpMSG(NetUser netuser)
		{
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Spacer", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help1", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help2", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help3", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help4", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help5", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("More", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Spacer", netuser.userID.ToString())); 
			
		}
		
		void HelpMSG1(NetUser netuser)
		{
			rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Spacer", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help6", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help7", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help8", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help9", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help10", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help11", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help12", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help13", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("More1", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Spacer", netuser.userID.ToString())); 
			
		}

		void HelpMSG2(NetUser netuser)
		{
			rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Spacer", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help14", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help15", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help16", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help17", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help18", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Help19", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("More2", netuser.userID.ToString())); 
           	rust.SendChatMessage(netuser, ChatPrefix, GetMessage("Spacer", netuser.userID.ToString())); 
			
		}

       		void OnHurt(TakeDamage takeDamage, DamageEvent damage)
		{
			if (takeDamage is HumanBodyTakeDamage)
			{
				if (damage.attacker.client == null) return;
				if (damage.victim.client == null) return;
				NetUser attacker = damage.attacker.client?.netUser;
				NetUser victim = damage.victim.client?.netUser;
				if (attacker == null || victim == null) return;
				if (damage.attacker.client == damage.victim.client) return;

				double dmg = Math.Floor(damage.amount);
				double vida = Math.Floor(victim.playerClient.controllable.health);
				if (dmg == 0) return;
			
				if (dano.ContainsKey(attacker) && dano[attacker]) rust.Notice(attacker, "Player:"+ " " + victim.displayName+ " "+ "Life:" + " " + "[" + vida+ "/"+ "100]");
				if (dano.ContainsKey(victim) && dano[victim]) rust.Notice(victim, "" + " "+ attacker.displayName);
			}
			else
			{
				if (damage.attacker.client == null) return;
	            if (damage.attacker.client == damage.victim.client) return;
    	        if (damage.amount == 0) return;
				NetUser attacker = damage.attacker.client?.netUser;
        	    string message = string.Format("Daño: {0}/{1}", Convert.ToInt32(takeDamage.health), takeDamage.maxHealth);
          	    if (dano.ContainsKey(attacker) && dano[attacker]) rust.Notice(attacker, message);
			}
		}
		
	}
}