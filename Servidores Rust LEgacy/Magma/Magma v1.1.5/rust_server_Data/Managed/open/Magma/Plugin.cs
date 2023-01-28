using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Magma.Events;

namespace Magma
{
	// Token: 0x02000063 RID: 99
	public class Plugin
	{
		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x0000E292 File Offset: 0x0000C492
		// (set) Token: 0x060002C4 RID: 708 RVA: 0x0000E29A File Offset: 0x0000C49A
		public string Path
		{
			get
			{
				return this.path;
			}
			set
			{
				this.path = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x0000E2A3 File Offset: 0x0000C4A3
		// (set) Token: 0x060002C6 RID: 710 RVA: 0x0000E2AB File Offset: 0x0000C4AB
		public string Code
		{
			get
			{
				return this.code;
			}
			set
			{
				this.code = value;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060002C7 RID: 711 RVA: 0x0000E2B4 File Offset: 0x0000C4B4
		// (set) Token: 0x060002C8 RID: 712 RVA: 0x0000E2BC File Offset: 0x0000C4BC
		public global::System.Collections.ArrayList Commands
		{
			get
			{
				return this.commands;
			}
			set
			{
				this.commands = value;
			}
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0000E2C5 File Offset: 0x0000C4C5
		public Plugin(string path)
		{
			this.Path = path;
			this.timers = new global::System.Collections.Generic.List<global::Magma.Events.TimedEvent>();
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0000E2DF File Offset: 0x0000C4DF
		public void OnServerInit()
		{
			this.Invoke("On_ServerInit", new object[0]);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000E2F2 File Offset: 0x0000C4F2
		public void OnPluginInit()
		{
			this.Invoke("On_PluginInit", new object[0]);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0000E305 File Offset: 0x0000C505
		public void OnServerShutdown()
		{
			this.Invoke("On_ServerShutdown", new object[0]);
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0000E318 File Offset: 0x0000C518
		public void OnItemsLoaded(global::Magma.ItemsBlocks items)
		{
			this.Invoke("On_ItemsLoaded", new object[]
			{
				items
			});
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000E33C File Offset: 0x0000C53C
		public void OnTablesLoaded(global::System.Collections.Generic.Dictionary<string, global::LootSpawnList> lists)
		{
			this.Invoke("On_TablesLoaded", new object[]
			{
				lists
			});
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0000E360 File Offset: 0x0000C560
		public void OnChat(global::Magma.Player player, ref global::Magma.ChatString text)
		{
			this.Invoke("On_Chat", new object[]
			{
				player,
				text
			});
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000E38C File Offset: 0x0000C58C
		public void OnConsole(ref global::ConsoleSystem.Arg arg, bool external)
		{
			if (!external)
			{
				this.Invoke("On_Console", new object[]
				{
					global::Magma.Player.FindByPlayerClient(arg.argUser.playerClient),
					arg
				});
				return;
			}
			this.Invoke("On_Console", new object[]
			{
				null,
				arg
			});
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000E3E4 File Offset: 0x0000C5E4
		public void OnCommand(global::Magma.Player player, string command, string[] args)
		{
			this.Invoke("On_Command", new object[]
			{
				player,
				command,
				args
			});
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000E410 File Offset: 0x0000C610
		public void OnPlayerConnected(global::Magma.Player player)
		{
			this.Invoke("On_PlayerConnected", new object[]
			{
				player
			});
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000E434 File Offset: 0x0000C634
		public void OnPlayerDisconnected(global::Magma.Player player)
		{
			this.Invoke("On_PlayerDisconnected", new object[]
			{
				player
			});
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000E458 File Offset: 0x0000C658
		public void OnPlayerKilled(global::Magma.Events.DeathEvent de)
		{
			this.Invoke("On_PlayerKilled", new object[]
			{
				de
			});
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0000E47C File Offset: 0x0000C67C
		public void OnPlayerHurt(global::Magma.Events.HurtEvent he)
		{
			this.Invoke("On_PlayerHurt", new object[]
			{
				he
			});
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000E4A0 File Offset: 0x0000C6A0
		public void OnPlayerSpawn(global::Magma.Player p, global::Magma.Events.SpawnEvent se)
		{
			this.Invoke("On_PlayerSpawning", new object[]
			{
				p,
				se
			});
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000E4C8 File Offset: 0x0000C6C8
		public void OnPlayerSpawned(global::Magma.Player p, global::Magma.Events.SpawnEvent se)
		{
			this.Invoke("On_PlayerSpawned", new object[]
			{
				p,
				se
			});
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0000E4F0 File Offset: 0x0000C6F0
		public void OnPlayerGathering(global::Magma.Player p, global::Magma.Events.GatherEvent ge)
		{
			this.Invoke("On_PlayerGathering", new object[]
			{
				p,
				ge
			});
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000E518 File Offset: 0x0000C718
		public void OnEntityHurt(global::Magma.Events.HurtEvent he)
		{
			this.Invoke("On_EntityHurt", new object[]
			{
				he
			});
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0000E53C File Offset: 0x0000C73C
		public void OnEntityDecay(global::Magma.Events.DecayEvent de)
		{
			this.Invoke("On_EntityDecay", new object[]
			{
				de
			});
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000E560 File Offset: 0x0000C760
		public void OnEntityDeployed(global::Magma.Player p, global::Magma.Entity e)
		{
			this.Invoke("On_EntityDeployed", new object[]
			{
				p,
				e
			});
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000E588 File Offset: 0x0000C788
		public void OnBlueprintUse(global::Magma.Player p, global::Magma.Events.BPUseEvent ae)
		{
			this.Invoke("On_BlueprintUse", new object[]
			{
				p,
				ae
			});
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0000E5B0 File Offset: 0x0000C7B0
		public void OnNPCHurt(global::Magma.Events.HurtEvent he)
		{
			this.Invoke("On_NPCHurt", new object[]
			{
				he
			});
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000E5D4 File Offset: 0x0000C7D4
		public void OnNPCKilled(global::Magma.Events.DeathEvent de)
		{
			this.Invoke("On_NPCKilled", new object[]
			{
				de
			});
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000E5F8 File Offset: 0x0000C7F8
		public void OnDoorUse(global::Magma.Player p, global::Magma.Events.DoorEvent de)
		{
			this.Invoke("On_DoorUse", new object[]
			{
				p,
				de
			});
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0000E620 File Offset: 0x0000C820
		public void OnTimerCB(string name)
		{
			if (this.Code.Contains(name + "Callback"))
			{
				this.Invoke(name + "Callback", new object[0]);
			}
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000E654 File Offset: 0x0000C854
		public void OnTimerCBArgs(string name, global::ParamsList args)
		{
			if (this.Code.Contains(name + "Callback"))
			{
				this.Invoke(name + "Callback", new object[]
				{
					args
				});
			}
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000E698 File Offset: 0x0000C898
		private void Invoke(string name, params object[] obj)
		{
			try
			{
				global::Magma.PluginEngine.GetPluginEngine().Interpreter.Run(this.Code);
				global::Magma.PluginEngine.GetPluginEngine().Interpreter.SetParameter("Server", global::Magma.Server.GetServer());
				global::Magma.PluginEngine.GetPluginEngine().Interpreter.SetParameter("Data", global::Magma.Data.GetData());
				global::Magma.PluginEngine.GetPluginEngine().Interpreter.SetParameter("DataStore", global::Magma.DataStore.GetInstance());
				global::Magma.PluginEngine.GetPluginEngine().Interpreter.SetParameter("Util", global::Magma.Util.GetUtil());
				global::Magma.PluginEngine.GetPluginEngine().Interpreter.SetParameter("Web", new global::Magma.Web());
				global::Magma.PluginEngine.GetPluginEngine().Interpreter.SetParameter("Time", this);
				global::Magma.PluginEngine.GetPluginEngine().Interpreter.SetParameter("World", global::Magma.World.GetWorld());
				global::Magma.PluginEngine.GetPluginEngine().Interpreter.SetParameter("Plugin", this);
				if (obj != null)
				{
					global::Magma.PluginEngine.GetPluginEngine().Interpreter.CallFunction(name, obj);
				}
				else
				{
					global::Magma.PluginEngine.GetPluginEngine().Interpreter.CallFunction(name, new object[0]);
				}
			}
			catch (global::System.Exception ex)
			{
				global::System.Console.Write(string.Concat(new string[]
				{
					"Error invoking function : ",
					name,
					"\nFrom : ",
					this.path,
					"\n\n",
					ex.ToString()
				}));
			}
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000E814 File Offset: 0x0000CA14
		public global::IniParser CreateIni(string name)
		{
			try
			{
				if (name.Contains(".."))
				{
					return null;
				}
				string text = global::System.IO.Path.GetFileName(this.Path).Replace(".js", "");
				string iniPath = string.Concat(new string[]
				{
					global::Magma.Data.PATH,
					text,
					"\\",
					name,
					".ini"
				});
				global::System.IO.File.WriteAllText(iniPath, "");
				return new global::IniParser(iniPath);
			}
			catch (global::System.Exception ex)
			{
				global::System.Console.WriteLine(ex.ToString());
			}
			return null;
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000E8BC File Offset: 0x0000CABC
		public global::IniParser GetIni(string name)
		{
			if (name.Contains(".."))
			{
				return null;
			}
			string text = global::System.IO.Path.GetFileName(this.Path).Replace(".js", "");
			string iniPath = string.Concat(new string[]
			{
				global::Magma.Data.PATH,
				text,
				"\\",
				name,
				".ini"
			});
			if (global::System.IO.File.Exists(iniPath))
			{
				return new global::IniParser(iniPath);
			}
			return null;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000E934 File Offset: 0x0000CB34
		public bool IniExists(string name)
		{
			string text = global::System.IO.Path.GetFileName(this.Path).Replace(".js", "");
			string text2 = string.Concat(new string[]
			{
				global::Magma.Data.PATH,
				text,
				"\\",
				name,
				".ini"
			});
			return global::System.IO.File.Exists(text2);
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000E998 File Offset: 0x0000CB98
		public global::System.Collections.Generic.List<global::IniParser> GetInis(string name)
		{
			string str = global::System.IO.Path.GetFileName(this.Path).Replace(".js", "");
			string text = global::Magma.Data.PATH + str + "\\" + name;
			global::System.Collections.Generic.List<global::IniParser> list = new global::System.Collections.Generic.List<global::IniParser>();
			foreach (string iniPath in global::System.IO.Directory.GetFiles(text))
			{
				list.Add(new global::IniParser(iniPath));
			}
			return list;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0000EA08 File Offset: 0x0000CC08
		public bool CreateDir(string name)
		{
			if (name.Contains(".."))
			{
				return false;
			}
			string str = global::System.IO.Path.GetFileName(this.Path).Replace(".js", "");
			string text = global::Magma.Data.PATH + str + "\\" + name;
			if (global::System.IO.Directory.Exists(text))
			{
				return false;
			}
			global::System.IO.Directory.CreateDirectory(text);
			return true;
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0000EA64 File Offset: 0x0000CC64
		public void Log(string file, string text)
		{
			string text2 = global::System.IO.Path.GetFileName(this.Path).Replace(".js", "");
			string text3 = string.Concat(new string[]
			{
				global::Magma.Data.PATH,
				text2,
				"\\",
				file,
				".ini"
			});
			global::System.IO.File.AppendAllText(text3, string.Concat(new string[]
			{
				"[",
				global::System.DateTime.Now.ToShortDateString(),
				" ",
				global::System.DateTime.Now.ToShortTimeString(),
				"] ",
				text,
				"\r\n"
			}));
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000EB14 File Offset: 0x0000CD14
		public void DeleteLog(string file)
		{
			string text = global::System.IO.Path.GetFileName(this.Path).Replace(".js", "");
			string text2 = string.Concat(new string[]
			{
				global::Magma.Data.PATH,
				text,
				"\\",
				file,
				".ini"
			});
			if (global::System.IO.File.Exists(text2))
			{
				global::System.IO.File.Delete(text2);
			}
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000EB78 File Offset: 0x0000CD78
		public global::Magma.Events.TimedEvent CreateTimer(string name, int timeoutDelay)
		{
			global::Magma.Events.TimedEvent timedEvent = this.GetTimer(name);
			if (timedEvent == null)
			{
				timedEvent = new global::Magma.Events.TimedEvent(name, (double)timeoutDelay);
				timedEvent.OnFire += this.OnTimerCB;
				this.timers.Add(timedEvent);
				return timedEvent;
			}
			return timedEvent;
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0000EBBC File Offset: 0x0000CDBC
		public global::Magma.Events.TimedEvent CreateTimer(string name, int timeoutDelay, global::ParamsList args)
		{
			global::Magma.Events.TimedEvent timedEvent = this.CreateTimer(name, timeoutDelay);
			timedEvent.Args = args;
			timedEvent.OnFire -= this.OnTimerCB;
			timedEvent.OnFireArgs += this.OnTimerCBArgs;
			return timedEvent;
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000EC00 File Offset: 0x0000CE00
		public global::Magma.Events.TimedEvent GetTimer(string name)
		{
			foreach (global::Magma.Events.TimedEvent timedEvent in this.timers)
			{
				if (timedEvent.Name == name)
				{
					return timedEvent;
				}
			}
			return null;
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0000EC64 File Offset: 0x0000CE64
		public void KillTimer(string name)
		{
			global::Magma.Events.TimedEvent timer = this.GetTimer(name);
			if (timer != null)
			{
				timer.Stop();
				this.timers.Remove(timer);
			}
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0000EC90 File Offset: 0x0000CE90
		public void KillTimers()
		{
			foreach (global::Magma.Events.TimedEvent timedEvent in this.timers)
			{
				timedEvent.Stop();
			}
			this.timers.Clear();
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0000ECF0 File Offset: 0x0000CEF0
		public string GetDate()
		{
			return global::System.DateTime.Now.ToShortDateString();
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0000ED0C File Offset: 0x0000CF0C
		public string GetTime()
		{
			return global::System.DateTime.Now.ToShortTimeString();
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0000ED28 File Offset: 0x0000CF28
		public long GetTimestamp()
		{
			return (long)(global::System.DateTime.UtcNow - new global::System.DateTime(0x7B2, 1, 1, 0, 0, 0)).TotalSeconds;
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x0000ED57 File Offset: 0x0000CF57
		public int GetTicks()
		{
			return global::System.Environment.TickCount;
		}

		// Token: 0x0400009F RID: 159
		private global::System.Collections.ArrayList commands;

		// Token: 0x040000A0 RID: 160
		private global::System.Collections.Generic.List<global::Magma.Events.TimedEvent> timers;

		// Token: 0x040000A1 RID: 161
		private string path;

		// Token: 0x040000A2 RID: 162
		private string code;
	}
}
