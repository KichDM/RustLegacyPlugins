using System;
using System.Collections;
using System.IO;
using Jint;
using Jint.Expressions;

namespace Magma
{
	// Token: 0x0200002E RID: 46
	public class PluginEngine
	{
		// Token: 0x060001EB RID: 491 RVA: 0x0000748C File Offset: 0x0000568C
		private PluginEngine()
		{
		}

		// Token: 0x060001EC RID: 492 RVA: 0x000074D3 File Offset: 0x000056D3
		public static global::Magma.PluginEngine GetPluginEngine()
		{
			if (global::Magma.PluginEngine.PE == null)
			{
				global::Magma.PluginEngine.PE = new global::Magma.PluginEngine();
				global::Magma.PluginEngine.PE.Init();
			}
			return global::Magma.PluginEngine.PE;
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001ED RID: 493 RVA: 0x000074F5 File Offset: 0x000056F5
		// (set) Token: 0x060001EE RID: 494 RVA: 0x000074FD File Offset: 0x000056FD
		public global::System.Collections.ArrayList Plugins
		{
			get
			{
				return this.plugins;
			}
			set
			{
				this.plugins = value;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001EF RID: 495 RVA: 0x00007506 File Offset: 0x00005706
		// (set) Token: 0x060001F0 RID: 496 RVA: 0x0000750E File Offset: 0x0000570E
		public global::Jint.JintEngine Interpreter
		{
			get
			{
				return this.interpreter;
			}
			set
			{
				this.interpreter = value;
			}
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00007517 File Offset: 0x00005717
		public void Init()
		{
			this.ReloadPlugins(null);
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00007520 File Offset: 0x00005720
		public void LoadPlugins(global::Magma.Player p)
		{
			global::Magma.Hooks.ResetHooks();
			this.ParsePlugin();
			foreach (object obj in this.plugins)
			{
				global::Magma.Plugin plugin = (global::Magma.Plugin)obj;
				try
				{
					this.interpreter.Run(plugin.Code);
					global::Jint.Expressions.Program program = global::Jint.JintEngine.Compile(plugin.Code, false);
					foreach (global::Jint.Expressions.Statement statement in program.Statements)
					{
						if (statement.GetType() == typeof(global::Jint.Expressions.FunctionDeclarationStatement))
						{
							global::Jint.Expressions.FunctionDeclarationStatement functionDeclarationStatement = (global::Jint.Expressions.FunctionDeclarationStatement)statement;
							if (functionDeclarationStatement != null)
							{
								global::System.Console.WriteLine("Found Function: " + functionDeclarationStatement.Name);
								if (functionDeclarationStatement.Name == "On_ServerInit")
								{
									global::Magma.Hooks.OnServerInit += plugin.OnServerInit;
								}
								else if (functionDeclarationStatement.Name == "On_PluginInit")
								{
									global::Magma.Hooks.OnPluginInit += plugin.OnPluginInit;
								}
								else if (functionDeclarationStatement.Name == "On_ServerShutdown")
								{
									global::Magma.Hooks.OnServerShutdown += plugin.OnServerShutdown;
								}
								else if (functionDeclarationStatement.Name == "On_ItemsLoaded")
								{
									global::Magma.Hooks.OnItemsLoaded += plugin.OnItemsLoaded;
								}
								else if (functionDeclarationStatement.Name == "On_TablesLoaded")
								{
									global::Magma.Hooks.OnTablesLoaded += plugin.OnTablesLoaded;
								}
								else if (functionDeclarationStatement.Name == "On_Chat")
								{
									global::Magma.Hooks.OnChat += plugin.OnChat;
								}
								else if (functionDeclarationStatement.Name == "On_Console")
								{
									global::Magma.Hooks.OnConsoleReceived += plugin.OnConsole;
								}
								else if (functionDeclarationStatement.Name == "On_Command")
								{
									global::Magma.Hooks.OnCommand += plugin.OnCommand;
								}
								else if (functionDeclarationStatement.Name == "On_PlayerConnected")
								{
									global::Magma.Hooks.OnPlayerConnected += plugin.OnPlayerConnected;
								}
								else if (functionDeclarationStatement.Name == "On_PlayerDisconnected")
								{
									global::Magma.Hooks.OnPlayerDisconnected += plugin.OnPlayerDisconnected;
								}
								else if (functionDeclarationStatement.Name == "On_PlayerKilled")
								{
									global::Magma.Hooks.OnPlayerKilled += plugin.OnPlayerKilled;
								}
								else if (functionDeclarationStatement.Name == "On_PlayerHurt")
								{
									global::Magma.Hooks.OnPlayerHurt += plugin.OnPlayerHurt;
								}
								else if (functionDeclarationStatement.Name == "On_PlayerSpawning")
								{
									global::Magma.Hooks.OnPlayerSpawning += plugin.OnPlayerSpawn;
								}
								else if (functionDeclarationStatement.Name == "On_PlayerSpawned")
								{
									global::Magma.Hooks.OnPlayerSpawned += plugin.OnPlayerSpawned;
								}
								else if (functionDeclarationStatement.Name == "On_PlayerGathering")
								{
									global::Magma.Hooks.OnPlayerGathering += plugin.OnPlayerGathering;
								}
								else if (functionDeclarationStatement.Name == "On_EntityHurt")
								{
									global::Magma.Hooks.OnEntityHurt += plugin.OnEntityHurt;
								}
								else if (functionDeclarationStatement.Name == "On_EntityDecay")
								{
									global::Magma.Hooks.OnEntityDecay += plugin.OnEntityDecay;
								}
								else if (functionDeclarationStatement.Name == "On_EntityDeployed")
								{
									global::Magma.Hooks.OnEntityDeployed += plugin.OnEntityDeployed;
								}
								else if (functionDeclarationStatement.Name == "On_NPCHurt")
								{
									global::Magma.Hooks.OnNPCHurt += plugin.OnNPCHurt;
								}
								else if (functionDeclarationStatement.Name == "On_NPCKilled")
								{
									global::Magma.Hooks.OnNPCKilled += plugin.OnNPCKilled;
								}
								else if (functionDeclarationStatement.Name == "On_BlueprintUse")
								{
									global::Magma.Hooks.OnBlueprintUse += plugin.OnBlueprintUse;
								}
								else if (functionDeclarationStatement.Name == "On_DoorUse")
								{
									global::Magma.Hooks.OnDoorUse += plugin.OnDoorUse;
								}
							}
						}
					}
				}
				catch (global::System.Exception)
				{
					string arg = "Can't load plugin : " + plugin.Path.Remove(0, plugin.Path.LastIndexOf("\\") + 1);
					if (p != null)
					{
						p.Message(arg);
					}
					else
					{
						global::Magma.Server.GetServer().Broadcast(arg);
					}
				}
			}
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x000079FC File Offset: 0x00005BFC
		public void ParsePlugin()
		{
			this.plugins.Clear();
			foreach (string path in global::System.IO.Directory.GetDirectories(global::Magma.Util.GetMagmaFolder()))
			{
				string text = "";
				foreach (string text2 in global::System.IO.Directory.GetFiles(path))
				{
					if (global::System.IO.Path.GetFileName(text2).Contains(".js") && global::System.IO.Path.GetFileName(text2).Contains(global::System.IO.Path.GetFileName(path)))
					{
						text = text2;
					}
				}
				if (!(text == ""))
				{
					string[] array = global::System.IO.File.ReadAllLines(text);
					string text3 = "";
					foreach (string text4 in array)
					{
						string text5 = text4.Replace("toLowerCase(", "Data.ToLower(");
						text5 = text5.Replace("GetStaticField(", "Util.GetStaticField(");
						text5 = text5.Replace("SetStaticField(", "Util.SetStaticField(");
						text5 = text5.Replace("InvokeStatic(", "Util.InvokeStatic(");
						text5 = text5.Replace("IsNull(", "Util.IsNull(");
						text5 = text5.Replace("Datastore", "DataStore");
						try
						{
							if (text5.Contains("new "))
							{
								string[] array3 = text5.Split(new string[]
								{
									"new "
								}, global::System.StringSplitOptions.None);
								if ((array3[0].Contains("\"") || array3[0].Contains("'")) && (array3[1].Contains("\"") || array3[1].Contains("'")))
								{
									text3 = text3 + text5 + "\r\n";
									goto IL_391;
								}
								if (text5.Contains("];"))
								{
									string text6 = text5.Split(new string[]
									{
										"new "
									}, global::System.StringSplitOptions.None)[1].Split(new string[]
									{
										"];"
									}, global::System.StringSplitOptions.None)[0];
									text5 = text5.Replace("new " + text6, "");
									text5 = text5.Replace("];", "");
									string text7 = text6.Split(new char[]
									{
										'['
									})[1];
									text6 = text6.Split(new char[]
									{
										'['
									})[0];
									string text8 = text5;
									text5 = string.Concat(new string[]
									{
										text8,
										"Util.CreateArrayInstance('",
										text6,
										"', ",
										text7,
										");"
									});
								}
								else
								{
									string text9 = text5.Split(new string[]
									{
										"new "
									}, global::System.StringSplitOptions.None)[1].Split(new string[]
									{
										");"
									}, global::System.StringSplitOptions.None)[0];
									text5 = text5.Replace("new " + text9, "");
									text5 = text5.Replace(");", "");
									string text10 = text9.Split(new char[]
									{
										'('
									})[1];
									text9 = text9.Split(new char[]
									{
										'('
									})[0];
									text5 = text5 + "Util.CreateInstance('" + text9 + "'";
									if (text10 != "")
									{
										text5 = text5 + ", " + text10;
									}
									text5 += ");";
								}
							}
							text3 = text3 + text5 + "\r\n";
						}
						catch (global::System.Exception)
						{
							global::System.Console.WriteLine("Magma : Couln't create instance at line -> " + text4);
						}
						IL_391:;
					}
					if (this.FilterPlugin(text3))
					{
						global::System.Console.WriteLine("Loaded: " + text);
						global::Magma.Plugin plugin = new global::Magma.Plugin(text);
						plugin.Code = text3;
						this.plugins.Add(plugin);
					}
					else
					{
						global::System.Console.WriteLine("PERMISSION DENIED. Failed to load " + text + " due to restrictions on the API");
					}
				}
			}
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00007E28 File Offset: 0x00006028
		public void ReloadPlugins(global::Magma.Player p)
		{
			this.Secure();
			foreach (object obj in this.plugins)
			{
				global::Magma.Plugin plugin = (global::Magma.Plugin)obj;
				plugin.KillTimers();
			}
			this.LoadPlugins(p);
			global::Magma.Data.GetData().Load();
			global::Magma.Hooks.PluginInit();
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00007E9C File Offset: 0x0000609C
		public void Secure()
		{
			this.interpreter.AllowClr(true);
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00007EAC File Offset: 0x000060AC
		public bool FilterPlugin(string script)
		{
			string text = script.ToLower();
			foreach (string text2 in this.filters)
			{
				if (text.Contains(text2))
				{
					global::System.Console.WriteLine("Script cannot contain: " + text2);
					return false;
				}
			}
			return true;
		}

		// Token: 0x04000072 RID: 114
		private global::Jint.JintEngine interpreter = new global::Jint.JintEngine();

		// Token: 0x04000073 RID: 115
		private global::System.Collections.ArrayList plugins = new global::System.Collections.ArrayList();

		// Token: 0x04000074 RID: 116
		private static global::Magma.PluginEngine PE;

		// Token: 0x04000075 RID: 117
		private string[] filters = new string[]
		{
			"system.io",
			"system.xml"
		};
	}
}
