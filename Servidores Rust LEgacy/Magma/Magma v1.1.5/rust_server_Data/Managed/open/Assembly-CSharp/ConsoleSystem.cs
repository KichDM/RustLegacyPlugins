using System;
using System.Collections.Generic;
using System.Reflection;
using Facepunch.Util;
using Facepunch.Utility;
using Magma;
using UnityEngine;

// Token: 0x020001B1 RID: 433
public class ConsoleSystem
{
	// Token: 0x06000CA7 RID: 3239 RVA: 0x000304C8 File Offset: 0x0002E6C8
	public ConsoleSystem()
	{
	}

	// Token: 0x06000CA8 RID: 3240 RVA: 0x000304D0 File Offset: 0x0002E6D0
	public static void RegisterLogCallback(global::UnityEngine.Application.LogCallback Callback, bool CallbackWritesToConsole = false)
	{
		if (global::ConsoleSystem.RegisteredLogCallback)
		{
			if (Callback != global::ConsoleSystem.LogCallback)
			{
				if (object.ReferenceEquals(Callback, null))
				{
					global::UnityEngine.Application.RegisterLogCallback(null);
					global::ConsoleSystem.LogCallbackWritesToConsole = (global::ConsoleSystem.RegisteredLogCallback = false);
					global::ConsoleSystem.LogCallback = null;
				}
				else
				{
					global::UnityEngine.Application.RegisterLogCallback(Callback);
					global::ConsoleSystem.LogCallback = Callback;
					global::ConsoleSystem.LogCallbackWritesToConsole = CallbackWritesToConsole;
				}
			}
			else
			{
				global::ConsoleSystem.LogCallbackWritesToConsole = CallbackWritesToConsole;
			}
		}
		else if (!object.ReferenceEquals(Callback, null))
		{
			global::UnityEngine.Application.RegisterLogCallback(Callback);
			global::ConsoleSystem.RegisteredLogCallback = true;
			global::ConsoleSystem.LogCallbackWritesToConsole = CallbackWritesToConsole;
			global::ConsoleSystem.LogCallback = Callback;
		}
	}

	// Token: 0x06000CA9 RID: 3241 RVA: 0x00030568 File Offset: 0x0002E768
	public static bool UnregisterLogCallback(global::UnityEngine.Application.LogCallback Callback)
	{
		if (global::ConsoleSystem.RegisteredLogCallback && Callback == global::ConsoleSystem.LogCallback)
		{
			global::ConsoleSystem.RegisterLogCallback(null, false);
			return true;
		}
		return false;
	}

	// Token: 0x06000CAA RID: 3242 RVA: 0x0003059C File Offset: 0x0002E79C
	public static void Print(object message, bool toLogFile = false)
	{
		global::ConsoleSystem.PrintLogType(3, message, toLogFile);
	}

	// Token: 0x06000CAB RID: 3243 RVA: 0x000305A8 File Offset: 0x0002E7A8
	public static void PrintWarning(object message, bool toLogFile = false)
	{
		global::ConsoleSystem.PrintLogType(2, message, toLogFile);
	}

	// Token: 0x06000CAC RID: 3244 RVA: 0x000305B4 File Offset: 0x0002E7B4
	public static void PrintError(object message, bool toLogFile = false)
	{
		global::ConsoleSystem.PrintLogType(0, message, toLogFile);
	}

	// Token: 0x06000CAD RID: 3245 RVA: 0x000305C0 File Offset: 0x0002E7C0
	public static void Log(object message)
	{
		global::UnityEngine.Debug.Log(message);
	}

	// Token: 0x06000CAE RID: 3246 RVA: 0x000305C8 File Offset: 0x0002E7C8
	public static void Log(object message, global::UnityEngine.Object context)
	{
		global::UnityEngine.Debug.Log(message, context);
	}

	// Token: 0x06000CAF RID: 3247 RVA: 0x000305D4 File Offset: 0x0002E7D4
	public static void LogWarning(object message)
	{
		global::UnityEngine.Debug.LogWarning(message);
	}

	// Token: 0x06000CB0 RID: 3248 RVA: 0x000305DC File Offset: 0x0002E7DC
	public static void LogWarning(object message, global::UnityEngine.Object context)
	{
		global::UnityEngine.Debug.LogWarning(message, context);
	}

	// Token: 0x06000CB1 RID: 3249 RVA: 0x000305E8 File Offset: 0x0002E7E8
	public static void LogError(object message)
	{
		global::UnityEngine.Debug.LogError(message);
	}

	// Token: 0x06000CB2 RID: 3250 RVA: 0x000305F0 File Offset: 0x0002E7F0
	public static void LogError(object message, global::UnityEngine.Object context)
	{
		global::UnityEngine.Debug.LogError(message, context);
	}

	// Token: 0x06000CB3 RID: 3251 RVA: 0x000305FC File Offset: 0x0002E7FC
	public static void LogException(global::System.Exception exception)
	{
		global::UnityEngine.Debug.LogException(exception);
	}

	// Token: 0x06000CB4 RID: 3252 RVA: 0x00030604 File Offset: 0x0002E804
	public static void LogException(global::System.Exception exception, global::UnityEngine.Object context)
	{
		global::UnityEngine.Debug.LogException(exception, context);
	}

	// Token: 0x06000CB5 RID: 3253 RVA: 0x00030610 File Offset: 0x0002E810
	private static void PrintLogType(global::UnityEngine.LogType logType, string message, bool log = false)
	{
		if (global::global.logprint)
		{
			switch (logType)
			{
			case 0:
				global::ConsoleSystem.LogError(message);
				return;
			case 2:
				global::ConsoleSystem.LogWarning(message);
				return;
			case 3:
				global::ConsoleSystem.Log(message);
				return;
			}
		}
		if (log && !global::ConsoleSystem.LogCallbackWritesToConsole)
		{
			try
			{
				((logType != 3) ? global::System.Console.Error : global::System.Console.Out).WriteLine("Print{0}:{1}", logType, message);
			}
			catch (global::System.Exception arg)
			{
				global::System.Console.Error.WriteLine("PrintLogType Log Exception\n:{0}", arg);
			}
		}
		if (global::ConsoleSystem.RegisteredLogCallback)
		{
			try
			{
				global::ConsoleSystem.LogCallback.Invoke(message, string.Empty, logType);
			}
			catch (global::System.Exception arg2)
			{
				global::System.Console.Error.WriteLine("PrintLogType Exception\n:{0}", arg2);
			}
		}
	}

	// Token: 0x06000CB6 RID: 3254 RVA: 0x00030718 File Offset: 0x0002E918
	private static void PrintLogType(global::UnityEngine.LogType logType, object obj, bool log = false)
	{
		global::ConsoleSystem.PrintLogType(logType, string.Concat(obj ?? "Null"), log);
	}

	// Token: 0x06000CB7 RID: 3255 RVA: 0x00030734 File Offset: 0x0002E934
	public static string CollectSavedFields(global::System.Type type)
	{
		string text = string.Empty;
		global::System.Reflection.FieldInfo[] fields = type.GetFields();
		for (int i = 0; i < fields.Length; i++)
		{
			if (fields[i].IsStatic)
			{
				if (global::Facepunch.Util.Reflection.HasAttribute(fields[i], typeof(global::ConsoleSystem.Saved)))
				{
					string text2 = type.Name + ".";
					if (text2 == "global.")
					{
						text2 = string.Empty;
					}
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						text2,
						fields[i].Name,
						" ",
						fields[i].GetValue(null).ToString(),
						"\n"
					});
				}
			}
		}
		return text;
	}

	// Token: 0x06000CB8 RID: 3256 RVA: 0x000307FC File Offset: 0x0002E9FC
	public static string CollectSavedProperties(global::System.Type type)
	{
		string text = string.Empty;
		global::System.Reflection.PropertyInfo[] properties = type.GetProperties();
		for (int i = 0; i < properties.Length; i++)
		{
			if (properties[i].GetGetMethod().IsStatic)
			{
				if (global::Facepunch.Util.Reflection.HasAttribute(properties[i], typeof(global::ConsoleSystem.Saved)))
				{
					string text2 = type.Name + ".";
					if (text2 == "global.")
					{
						text2 = string.Empty;
					}
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						text2,
						properties[i].Name,
						" ",
						properties[i].GetValue(null, null).ToString(),
						"\n"
					});
				}
			}
		}
		return text;
	}

	// Token: 0x06000CB9 RID: 3257 RVA: 0x000308CC File Offset: 0x0002EACC
	public static string CollectSavedFunctions(global::System.Type type)
	{
		string text = string.Empty;
		global::System.Reflection.MethodInfo[] methods = type.GetMethods();
		for (int i = 0; i < methods.Length; i++)
		{
			if (methods[i].IsStatic)
			{
				if (global::Facepunch.Util.Reflection.HasAttribute(methods[i], typeof(global::ConsoleSystem.Saved)))
				{
					if (methods[i].ReturnType == typeof(string))
					{
						text += methods[i].Invoke(null, null);
					}
				}
			}
		}
		return text;
	}

	// Token: 0x06000CBA RID: 3258 RVA: 0x00030958 File Offset: 0x0002EB58
	public static string SaveToConfigString()
	{
		string text = string.Empty;
		global::System.Reflection.Assembly[] assemblies = global::System.AppDomain.CurrentDomain.GetAssemblies();
		for (int i = 0; i < assemblies.Length; i++)
		{
			global::System.Type[] types = assemblies[i].GetTypes();
			for (int j = 0; j < types.Length; j++)
			{
				if (types[j].IsSubclassOf(typeof(global::ConsoleSystem)))
				{
					text += global::ConsoleSystem.CollectSavedFields(types[j]);
					text += global::ConsoleSystem.CollectSavedProperties(types[j]);
					text += global::ConsoleSystem.CollectSavedFunctions(types[j]);
				}
			}
		}
		return text;
	}

	// Token: 0x06000CBB RID: 3259 RVA: 0x000309FC File Offset: 0x0002EBFC
	public static void RunFile(string strFile)
	{
		string[] array = strFile.Split(new char[]
		{
			'\n'
		}, global::System.StringSplitOptions.RemoveEmptyEntries);
		foreach (string text in array)
		{
			if (text[0] != '#')
			{
				global::ConsoleSystem.Run(text, false);
			}
		}
	}

	// Token: 0x06000CBC RID: 3260 RVA: 0x00030A54 File Offset: 0x0002EC54
	public static bool Run(string strCommand, bool WantsFeedback = false)
	{
		global::ConsoleSystem.Arg arg = new global::ConsoleSystem.Arg(strCommand);
		if (arg.Invalid)
		{
			if (WantsFeedback)
			{
				global::UnityEngine.Debug.Log("Invalid command");
			}
			return false;
		}
		bool result = global::ConsoleSystem.RunCommand(ref arg, WantsFeedback);
		if (arg.Reply != null && arg.Reply.Length > 0)
		{
			global::UnityEngine.Debug.Log(arg.Reply);
		}
		return result;
	}

	// Token: 0x06000CBD RID: 3261 RVA: 0x00030AB8 File Offset: 0x0002ECB8
	public static bool RunCommand_Serverside(string strCommand, global::NetUser user, out string StrOutput)
	{
		StrOutput = string.Empty;
		global::ConsoleSystem.Arg arg = new global::ConsoleSystem.Arg(strCommand);
		arg.SetUser(user);
		if (arg.Invalid)
		{
			return false;
		}
		if (!global::ConsoleSystem.RunCommand(ref arg, true))
		{
			return false;
		}
		if (arg.Reply != null && arg.Reply.Length > 0)
		{
			StrOutput = arg.Reply;
		}
		return true;
	}

	// Token: 0x06000CBE RID: 3262 RVA: 0x00030B1C File Offset: 0x0002ED1C
	public static bool RunCommand(ref global::ConsoleSystem.Arg arg, bool bWantReply = true)
	{
		global::System.Type[] array = global::ConsoleSystem.FindTypes(arg.Class);
		if (array.Length == 0)
		{
			return bWantReply && global::Magma.Hooks.ConsoleReceived(ref arg);
		}
		if (bWantReply)
		{
			arg.ReplyWith(string.Concat(new string[]
			{
				"command ",
				arg.Class,
				".",
				arg.Function,
				" was executed"
			}));
		}
		global::System.Type[] array2 = array;
		int i = 0;
		while (i < array2.Length)
		{
			global::System.Type type = array2[i];
			global::System.Reflection.MethodInfo method = type.GetMethod(arg.Function);
			if (method != null && method.IsStatic)
			{
				if (!arg.CheckPermissions(method.GetCustomAttributes(true)))
				{
					if (bWantReply)
					{
						arg.ReplyWith("No permission: " + arg.Class + "." + arg.Function);
					}
					return false;
				}
				object[] array3 = new global::ConsoleSystem.Arg[]
				{
					arg
				};
				method.Invoke(null, array3);
				arg = (array3[0] as global::ConsoleSystem.Arg);
				return true;
			}
			else
			{
				global::System.Reflection.FieldInfo field = type.GetField(arg.Function);
				if (field != null && field.IsStatic)
				{
					if (!arg.CheckPermissions(field.GetCustomAttributes(true)))
					{
						if (bWantReply)
						{
							arg.ReplyWith("No permission: " + arg.Class + "." + arg.Function);
						}
						return false;
					}
					global::System.Type fieldType = field.FieldType;
					if (arg.HasArgs(1))
					{
						try
						{
							string str = field.GetValue(null).ToString();
							if (fieldType == typeof(float))
							{
								field.SetValue(null, float.Parse(arg.Args[0]));
							}
							if (fieldType == typeof(int))
							{
								field.SetValue(null, int.Parse(arg.Args[0]));
							}
							if (fieldType == typeof(string))
							{
								field.SetValue(null, arg.Args[0]);
							}
							if (fieldType == typeof(bool))
							{
								field.SetValue(null, bool.Parse(arg.Args[0]));
							}
							if (bWantReply)
							{
								arg.ReplyWith(string.Concat(new string[]
								{
									arg.Class,
									".",
									arg.Function,
									": changed ",
									global::Facepunch.Utility.String.QuoteSafe(str),
									" to ",
									global::Facepunch.Utility.String.QuoteSafe(field.GetValue(null).ToString()),
									" (",
									fieldType.Name,
									")"
								}));
							}
						}
						catch (global::System.Exception)
						{
							if (bWantReply)
							{
								arg.ReplyWith("error setting value: " + arg.Class + "." + arg.Function);
							}
						}
					}
					else if (bWantReply)
					{
						arg.ReplyWith(string.Concat(new string[]
						{
							arg.Class,
							".",
							arg.Function,
							": ",
							global::Facepunch.Utility.String.QuoteSafe(field.GetValue(null).ToString()),
							" (",
							fieldType.Name,
							")"
						}));
					}
					return true;
				}
				else
				{
					global::System.Reflection.PropertyInfo property = type.GetProperty(arg.Function);
					if (property != null && property.GetGetMethod().IsStatic && property.GetSetMethod().IsStatic)
					{
						if (!arg.CheckPermissions(property.GetCustomAttributes(true)))
						{
							if (bWantReply)
							{
								arg.ReplyWith("No permission: " + arg.Class + "." + arg.Function);
							}
							return false;
						}
						global::System.Type propertyType = property.PropertyType;
						if (arg.HasArgs(1))
						{
							try
							{
								string str2 = property.GetValue(null, null).ToString();
								if (propertyType == typeof(float))
								{
									property.SetValue(null, float.Parse(arg.Args[0]), null);
								}
								if (propertyType == typeof(int))
								{
									property.SetValue(null, int.Parse(arg.Args[0]), null);
								}
								if (propertyType == typeof(string))
								{
									property.SetValue(null, arg.Args[0], null);
								}
								if (propertyType == typeof(bool))
								{
									property.SetValue(null, bool.Parse(arg.Args[0]), null);
								}
								if (bWantReply)
								{
									arg.ReplyWith(string.Concat(new string[]
									{
										arg.Class,
										".",
										arg.Function,
										": changed ",
										global::Facepunch.Utility.String.QuoteSafe(str2),
										" to ",
										global::Facepunch.Utility.String.QuoteSafe(property.GetValue(null, null).ToString()),
										" (",
										propertyType.Name,
										")"
									}));
								}
							}
							catch (global::System.Exception)
							{
								if (bWantReply)
								{
									arg.ReplyWith("error setting value: " + arg.Class + "." + arg.Function);
								}
							}
						}
						else if (bWantReply)
						{
							arg.ReplyWith(string.Concat(new string[]
							{
								arg.Class,
								".",
								arg.Function,
								": ",
								global::Facepunch.Utility.String.QuoteSafe(property.GetValue(null, null).ToString()),
								" (",
								propertyType.Name,
								")"
							}));
						}
						return true;
					}
					else
					{
						i++;
					}
				}
			}
		}
		if (bWantReply)
		{
			arg.ReplyWith("Command not found: " + arg.Class + "." + arg.Function);
		}
		return false;
	}

	// Token: 0x06000CBF RID: 3263 RVA: 0x00031154 File Offset: 0x0002F354
	public static global::System.Type[] FindTypes(string className)
	{
		global::System.Collections.Generic.List<global::System.Type> list = new global::System.Collections.Generic.List<global::System.Type>();
		global::System.Reflection.Assembly[] assemblies = global::System.AppDomain.CurrentDomain.GetAssemblies();
		for (int i = 0; i < assemblies.Length; i++)
		{
			global::System.Type type = assemblies[i].GetType(className);
			if (type != null)
			{
				if (type.IsSubclassOf(typeof(global::ConsoleSystem)))
				{
					list.Add(type);
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x04000848 RID: 2120
	private static bool RegisteredLogCallback;

	// Token: 0x04000849 RID: 2121
	private static bool LogCallbackWritesToConsole;

	// Token: 0x0400084A RID: 2122
	private static global::UnityEngine.Application.LogCallback LogCallback;

	// Token: 0x020001B2 RID: 434
	public class Arg
	{
		// Token: 0x06000CC0 RID: 3264 RVA: 0x000311C4 File Offset: 0x0002F3C4
		public Arg(string rconCommand)
		{
			if (rconCommand.IndexOf('.') <= 0 || rconCommand.IndexOf(' ', 0, rconCommand.IndexOf('.')) != -1)
			{
				rconCommand = "global." + rconCommand;
			}
			if (rconCommand.IndexOf('.') <= 0)
			{
				return;
			}
			this.Class = rconCommand.Substring(0, rconCommand.IndexOf('.'));
			if (this.Class.Length <= 1)
			{
				return;
			}
			this.Class = this.Class.ToLower();
			this.Function = rconCommand.Substring(this.Class.Length + 1);
			if (this.Function.Length <= 1)
			{
				return;
			}
			this.Invalid = false;
			if (this.Function.IndexOf(' ') <= 0)
			{
				return;
			}
			this.ArgsStr = this.Function.Substring(this.Function.IndexOf(' '));
			this.ArgsStr = this.ArgsStr.Trim();
			this.Args = global::Facepunch.Utility.String.SplitQuotesStrings(this.ArgsStr);
			this.Function = this.Function.Substring(0, this.Function.IndexOf(' '));
			this.Function.ToLower();
		}

		// Token: 0x06000CC1 RID: 3265 RVA: 0x00031334 File Offset: 0x0002F534
		public bool CheckPermissions(object[] attributes)
		{
			foreach (object obj in attributes)
			{
				if (obj is global::ConsoleSystem.Admin)
				{
					if (this.argUser == null)
					{
						return true;
					}
					if (this.argUser != null && this.argUser.connected && this.argUser.CanAdmin())
					{
						return true;
					}
				}
				if (obj is global::ConsoleSystem.User && this.argUser != null && this.argUser.connected)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000CC2 RID: 3266 RVA: 0x000313CC File Offset: 0x0002F5CC
		public void ReplyWith(string strValue)
		{
			this.Reply = strValue;
		}

		// Token: 0x06000CC3 RID: 3267 RVA: 0x000313D8 File Offset: 0x0002F5D8
		public bool HasArgs(int iMinimum = 1)
		{
			return this.Args != null && this.Args.Length >= iMinimum;
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x000313F8 File Offset: 0x0002F5F8
		public void SetUser(global::NetUser usr)
		{
			if (usr.playerClient == null)
			{
				return;
			}
			if (!usr.connected)
			{
				return;
			}
			this.argUser = usr;
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x00031420 File Offset: 0x0002F620
		public global::PlayerClient playerClient()
		{
			return this.argUser.playerClient;
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x00031430 File Offset: 0x0002F630
		public global::Character playerCharacter()
		{
			if (this.argUser.playerClient.controllable)
			{
				return this.argUser.playerClient.controllable.idMain;
			}
			return null;
		}

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x06000CC7 RID: 3271 RVA: 0x00031470 File Offset: 0x0002F670
		public global::PlayerClient[] PlayerClients
		{
			get
			{
				global::PlayerClient playerClient = this.playerClient();
				if (playerClient)
				{
					return new global::PlayerClient[]
					{
						playerClient
					};
				}
				return global::EmptyArray<global::PlayerClient>.array;
			}
		}

		// Token: 0x06000CC8 RID: 3272 RVA: 0x000314A0 File Offset: 0x0002F6A0
		public string GetString(int iArg, string def = "")
		{
			if (this.HasArgs(iArg + 1))
			{
				return global::ConsoleSystem.Parse.DefaultString(this.Args[iArg], def);
			}
			return def;
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x000314C0 File Offset: 0x0002F6C0
		public int GetInt(int iArg, int def = 0)
		{
			return global::ConsoleSystem.Parse.DefaultInt(this.GetString(iArg, null), def);
		}

		// Token: 0x06000CCA RID: 3274 RVA: 0x000314D0 File Offset: 0x0002F6D0
		public ulong GetUInt64(int iArg, ulong def = 0UL)
		{
			return global::ConsoleSystem.Parse.DefaultUInt64(this.GetString(iArg, null), def);
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x000314E0 File Offset: 0x0002F6E0
		public float GetFloat(int iArg, float def = 0f)
		{
			return global::ConsoleSystem.Parse.DefaultFloat(this.GetString(iArg, null), def);
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x000314F0 File Offset: 0x0002F6F0
		public bool GetBool(int iArg, bool def = false)
		{
			return global::ConsoleSystem.Parse.DefaultBool(this.GetString(iArg, null), def);
		}

		// Token: 0x06000CCD RID: 3277 RVA: 0x00031500 File Offset: 0x0002F700
		public global::System.Enum GetEnum(global::System.Type enumType, int iArg, global::System.Enum def)
		{
			return global::ConsoleSystem.Parse.DefaultEnum(enumType, this.GetString(iArg, null), def);
		}

		// Token: 0x06000CCE RID: 3278 RVA: 0x00031514 File Offset: 0x0002F714
		public global::PlayerClient[] GetPlayerClients(int iArg)
		{
			return global::PlayerClient.FindAllWithString(this.GetString(iArg, string.Empty)).ToArray<global::PlayerClient>();
		}

		// Token: 0x06000CCF RID: 3279 RVA: 0x0003152C File Offset: 0x0002F72C
		public global::Controller[] GetPlayerControllers(int iArg)
		{
			return global::Controller.CurrentControllers(global::PlayerClient.FindAllWithString(this.GetString(iArg, string.Empty))).ToArray<global::Controller>();
		}

		// Token: 0x06000CD0 RID: 3280 RVA: 0x0003154C File Offset: 0x0002F74C
		public TController[] GetPlayerControllers<TController>(int iArg) where TController : global::Controller
		{
			return global::Controller.CurrentControllers<TController>(global::PlayerClient.FindAllWithString(this.GetString(iArg, string.Empty))).ToArray<TController>();
		}

		// Token: 0x06000CD1 RID: 3281 RVA: 0x0003156C File Offset: 0x0002F76C
		public global::Character[] GetPlayerCharacters(int iArg)
		{
			return global::Character.CurrentCharacters(global::PlayerClient.FindAllWithString(this.GetString(iArg, string.Empty))).ToArray<global::Character>();
		}

		// Token: 0x06000CD2 RID: 3282 RVA: 0x0003158C File Offset: 0x0002F78C
		public TCharacter[] GetPlayerCharacters<TCharacter>(int iArg) where TCharacter : global::Character
		{
			return global::Character.CurrentCharacters<TCharacter>(global::PlayerClient.FindAllWithString(this.GetString(iArg, string.Empty))).ToArray<TCharacter>();
		}

		// Token: 0x0400084B RID: 2123
		public string Class = string.Empty;

		// Token: 0x0400084C RID: 2124
		public string Function = string.Empty;

		// Token: 0x0400084D RID: 2125
		public string ArgsStr = string.Empty;

		// Token: 0x0400084E RID: 2126
		public string[] Args;

		// Token: 0x0400084F RID: 2127
		public bool Invalid = true;

		// Token: 0x04000850 RID: 2128
		public string Reply = string.Empty;

		// Token: 0x04000851 RID: 2129
		[global::System.NonSerialized]
		public global::NetUser argUser;
	}

	// Token: 0x020001B3 RID: 435
	public static class Parse
	{
		// Token: 0x06000CD3 RID: 3283 RVA: 0x000315AC File Offset: 0x0002F7AC
		public static float Float(string text)
		{
			return float.Parse(text);
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x000315B4 File Offset: 0x0002F7B4
		public static bool AttemptFloat(string text, out float value)
		{
			return float.TryParse(text, out value);
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x000315C0 File Offset: 0x0002F7C0
		public static float DefaultFloat(string text, float @default)
		{
			float result;
			if (object.ReferenceEquals(text, null) || !global::ConsoleSystem.Parse.AttemptFloat(text, out result))
			{
				result = @default;
			}
			return result;
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x000315EC File Offset: 0x0002F7EC
		public static float DefaultFloat(string text)
		{
			return global::ConsoleSystem.Parse.DefaultFloat(text, 0f);
		}

		// Token: 0x06000CD7 RID: 3287 RVA: 0x000315FC File Offset: 0x0002F7FC
		public static int Int(string text)
		{
			return int.Parse(text);
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x00031604 File Offset: 0x0002F804
		public static bool AttemptInt(string text, out int value)
		{
			return int.TryParse(text, out value);
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x00031610 File Offset: 0x0002F810
		public static int DefaultInt(string text, int @default)
		{
			int result;
			if (object.ReferenceEquals(text, null) || !global::ConsoleSystem.Parse.AttemptInt(text, out result))
			{
				result = @default;
			}
			return result;
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x0003163C File Offset: 0x0002F83C
		public static ulong DefaultUInt64(string text, ulong @default)
		{
			if (text == null)
			{
				return @default;
			}
			ulong result = @default;
			ulong.TryParse(text, out result);
			return result;
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x00031660 File Offset: 0x0002F860
		public static int DefaultInt(string text)
		{
			return global::ConsoleSystem.Parse.DefaultInt(text, 0);
		}

		// Token: 0x06000CDC RID: 3292 RVA: 0x0003166C File Offset: 0x0002F86C
		public static bool AttemptBool(string text, out bool value)
		{
			if (bool.TryParse(text, out value))
			{
				return true;
			}
			if (text.Length != 0)
			{
				decimal d2;
				if (char.IsLetter(text[0]))
				{
					decimal d;
					if (text.Length == 4)
					{
						if (string.Equals(text, "true", global::System.StringComparison.InvariantCultureIgnoreCase))
						{
							value = true;
							return true;
						}
					}
					else if (text.Length == 5)
					{
						if (string.Equals(text, "false", global::System.StringComparison.InvariantCultureIgnoreCase))
						{
							value = false;
							return true;
						}
					}
					else if (decimal.TryParse(text, out d))
					{
						value = (d != 0m);
						return true;
					}
				}
				else if (decimal.TryParse(text, out d2))
				{
					value = (d2 != 0m);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000CDD RID: 3293 RVA: 0x00031734 File Offset: 0x0002F934
		public static bool Bool(string text)
		{
			bool result;
			if (!global::ConsoleSystem.Parse.AttemptBool(text, out result))
			{
				throw new global::System.FormatException("not in the correct format.");
			}
			return result;
		}

		// Token: 0x06000CDE RID: 3294 RVA: 0x0003175C File Offset: 0x0002F95C
		public static bool DefaultBool(string text, bool @default)
		{
			bool result;
			if (object.ReferenceEquals(text, null) || !global::ConsoleSystem.Parse.AttemptBool(text, out result))
			{
				result = @default;
			}
			return result;
		}

		// Token: 0x06000CDF RID: 3295 RVA: 0x00031788 File Offset: 0x0002F988
		public static bool DefaultBool(string text)
		{
			return global::ConsoleSystem.Parse.DefaultBool(text, false);
		}

		// Token: 0x06000CE0 RID: 3296 RVA: 0x00031794 File Offset: 0x0002F994
		public static TEnum Enum<TEnum>(string text) where TEnum : struct, global::System.IComparable, global::System.IFormattable, global::System.IConvertible
		{
			return global::ConsoleSystem.Parse.VerifyEnum<TEnum>.Parse(text);
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x0003179C File Offset: 0x0002F99C
		public static bool AttemptEnum<TEnum>(string text, out TEnum value) where TEnum : struct, global::System.IComparable, global::System.IFormattable, global::System.IConvertible
		{
			return global::ConsoleSystem.Parse.VerifyEnum<TEnum>.TryParse(text, out value);
		}

		// Token: 0x06000CE2 RID: 3298 RVA: 0x000317A8 File Offset: 0x0002F9A8
		public static TEnum DefaultEnum<TEnum>(string text, TEnum @default) where TEnum : struct, global::System.IComparable, global::System.IFormattable, global::System.IConvertible
		{
			TEnum result;
			if (object.ReferenceEquals(text, null) || !global::ConsoleSystem.Parse.AttemptEnum<TEnum>(text, out result))
			{
				result = @default;
			}
			return result;
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x000317D4 File Offset: 0x0002F9D4
		public static TEnum DefaultEnum<TEnum>(string text) where TEnum : struct, global::System.IComparable, global::System.IFormattable, global::System.IConvertible
		{
			return global::ConsoleSystem.Parse.DefaultEnum<TEnum>(text, default(TEnum));
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x000317F0 File Offset: 0x0002F9F0
		public static global::System.Enum Enum(global::System.Type enumType, string text)
		{
			global::System.Enum result;
			try
			{
				result = (global::System.Enum)global::System.Enum.Parse(enumType, text, true);
			}
			catch (global::System.Exception ex)
			{
				try
				{
					result = (global::System.Enum)global::System.Enum.ToObject(enumType, long.Parse(text));
				}
				catch
				{
					throw ex;
				}
			}
			return result;
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x00031874 File Offset: 0x0002FA74
		public static bool AttemptEnum(global::System.Type enumType, string text, out global::System.Enum value)
		{
			bool result;
			try
			{
				value = (global::System.Enum)global::System.Enum.Parse(enumType, text, true);
				result = true;
			}
			catch
			{
				try
				{
					value = (global::System.Enum)global::System.Enum.ToObject(enumType, long.Parse(text));
					result = true;
				}
				catch
				{
					value = null;
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x00031908 File Offset: 0x0002FB08
		public static global::System.Enum DefaultEnum(global::System.Type enumType, string text, global::System.Enum @default)
		{
			global::System.Enum result;
			if (object.ReferenceEquals(text, null) || !global::ConsoleSystem.Parse.AttemptEnum(enumType, text, out result))
			{
				result = @default;
			}
			return result;
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x00031934 File Offset: 0x0002FB34
		public static global::System.Enum DefaultEnum(global::System.Type enumType, string text)
		{
			return global::ConsoleSystem.Parse.DefaultEnum(enumType, text, null);
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x00031940 File Offset: 0x0002FB40
		public static string String(string text)
		{
			if (object.ReferenceEquals(text, null))
			{
				throw new global::System.ArgumentNullException("text");
			}
			if (text.Length == 1)
			{
				throw new global::System.FormatException("Cannot use empty strings.");
			}
			return text;
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x00031974 File Offset: 0x0002FB74
		public static bool AttemptString(string text, out string value)
		{
			if (string.IsNullOrEmpty(text))
			{
				value = string.Empty;
				return false;
			}
			value = text;
			return true;
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x00031990 File Offset: 0x0002FB90
		public static string DefaultString(string text, string @default)
		{
			string result;
			if (!global::ConsoleSystem.Parse.AttemptString(text, out result))
			{
				result = @default;
			}
			return result;
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x000319B0 File Offset: 0x0002FBB0
		public static string DefaultString(string text)
		{
			return global::ConsoleSystem.Parse.DefaultString(text, string.Empty);
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x000319C0 File Offset: 0x0002FBC0
		public static bool IsSupported(global::System.Type type)
		{
			if (object.ReferenceEquals(type, null))
			{
				return false;
			}
			switch (global::System.Type.GetTypeCode(type))
			{
			case global::System.TypeCode.Boolean:
				return typeof(bool) == type;
			case global::System.TypeCode.SByte:
			case global::System.TypeCode.Byte:
			case global::System.TypeCode.Int16:
			case global::System.TypeCode.UInt16:
			case global::System.TypeCode.UInt32:
			case global::System.TypeCode.Int64:
			case global::System.TypeCode.UInt64:
				return type.IsEnum;
			case global::System.TypeCode.Int32:
				return typeof(int) == type || type.IsEnum;
			case global::System.TypeCode.Single:
				return typeof(float) == type;
			case global::System.TypeCode.String:
				return typeof(string) == type;
			}
			return false;
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x00031A7C File Offset: 0x0002FC7C
		public static bool IsSupported<T>()
		{
			return global::ConsoleSystem.Parse.PrecachedSupport<T>.IsSupported;
		}

		// Token: 0x06000CEE RID: 3310 RVA: 0x00031A84 File Offset: 0x0002FC84
		public static bool AttemptObject(global::System.Type type, string value, out object boxed)
		{
			try
			{
				switch (global::System.Type.GetTypeCode(type))
				{
				case global::System.TypeCode.Boolean:
					if (typeof(bool) == type)
					{
						boxed = global::ConsoleSystem.Parse.Bool(value);
						return true;
					}
					break;
				case global::System.TypeCode.SByte:
				case global::System.TypeCode.Byte:
				case global::System.TypeCode.Int16:
				case global::System.TypeCode.UInt16:
				case global::System.TypeCode.UInt32:
				case global::System.TypeCode.Int64:
				case global::System.TypeCode.UInt64:
					if (type.IsEnum)
					{
						boxed = global::ConsoleSystem.Parse.Enum(type, value);
						return true;
					}
					break;
				case global::System.TypeCode.Int32:
					if (type == typeof(int))
					{
						boxed = global::ConsoleSystem.Parse.Int(value);
					}
					else
					{
						if (!type.IsEnum)
						{
							break;
						}
						boxed = global::ConsoleSystem.Parse.Enum(type, value);
					}
					return true;
				case global::System.TypeCode.Single:
					if (typeof(float) == type)
					{
						boxed = global::ConsoleSystem.Parse.Float(value);
						return true;
					}
					break;
				case global::System.TypeCode.String:
					if (typeof(string) == type)
					{
						boxed = global::ConsoleSystem.Parse.String(value);
						return true;
					}
					break;
				}
			}
			catch (global::System.Exception ex)
			{
				boxed = ex;
				return false;
			}
			boxed = null;
			return false;
		}

		// Token: 0x04000852 RID: 2130
		private const bool kEnumCaseInsensitive = true;

		// Token: 0x020001B4 RID: 436
		private static class VerifyEnum<TEnum> where TEnum : struct, global::System.IComparable, global::System.IFormattable, global::System.IConvertible
		{
			// Token: 0x06000CEF RID: 3311 RVA: 0x00031C00 File Offset: 0x0002FE00
			static VerifyEnum()
			{
				if (!typeof(TEnum).IsEnum)
				{
					throw new global::System.ArgumentException("TEnum", "Is not a enum type");
				}
			}

			// Token: 0x06000CF0 RID: 3312 RVA: 0x00031C34 File Offset: 0x0002FE34
			public static bool TryParse(string text, out TEnum value)
			{
				bool result;
				try
				{
					value = (TEnum)((object)global::System.Enum.Parse(typeof(TEnum), text, true));
					result = true;
				}
				catch
				{
					try
					{
						value = (TEnum)((object)global::System.Enum.ToObject(typeof(TEnum), long.Parse(text)));
						result = true;
					}
					catch
					{
						value = default(TEnum);
						result = false;
					}
				}
				return result;
			}

			// Token: 0x06000CF1 RID: 3313 RVA: 0x00031CEC File Offset: 0x0002FEEC
			public static TEnum Parse(string text)
			{
				TEnum result;
				try
				{
					result = (TEnum)((object)global::System.Enum.Parse(typeof(TEnum), text, true));
				}
				catch (global::System.Exception ex)
				{
					try
					{
						result = (TEnum)((object)global::System.Enum.ToObject(typeof(TEnum), long.Parse(text)));
					}
					catch
					{
						throw ex;
					}
				}
				return result;
			}
		}

		// Token: 0x020001B5 RID: 437
		private static class PrecachedSupport<T>
		{
			// Token: 0x06000CF2 RID: 3314 RVA: 0x00031D84 File Offset: 0x0002FF84
			// Note: this type is marked as 'beforefieldinit'.
			static PrecachedSupport()
			{
			}

			// Token: 0x04000853 RID: 2131
			public static readonly bool IsSupported = global::ConsoleSystem.Parse.IsSupported(typeof(T));
		}
	}

	// Token: 0x020001B6 RID: 438
	[global::System.AttributeUsage(global::System.AttributeTargets.All)]
	public sealed class Admin : global::System.Attribute
	{
		// Token: 0x06000CF3 RID: 3315 RVA: 0x00031D9C File Offset: 0x0002FF9C
		public Admin()
		{
		}
	}

	// Token: 0x020001B7 RID: 439
	[global::System.AttributeUsage(global::System.AttributeTargets.All)]
	public sealed class User : global::System.Attribute
	{
		// Token: 0x06000CF4 RID: 3316 RVA: 0x00031DA4 File Offset: 0x0002FFA4
		public User()
		{
		}
	}

	// Token: 0x020001B8 RID: 440
	[global::System.AttributeUsage(global::System.AttributeTargets.All)]
	public sealed class Client : global::System.Attribute
	{
		// Token: 0x06000CF5 RID: 3317 RVA: 0x00031DAC File Offset: 0x0002FFAC
		public Client()
		{
		}
	}

	// Token: 0x020001B9 RID: 441
	[global::System.AttributeUsage(global::System.AttributeTargets.All)]
	public sealed class Saved : global::System.Attribute
	{
		// Token: 0x06000CF6 RID: 3318 RVA: 0x00031DB4 File Offset: 0x0002FFB4
		public Saved()
		{
		}
	}

	// Token: 0x020001BA RID: 442
	[global::System.AttributeUsage(global::System.AttributeTargets.All)]
	public sealed class Help : global::System.Attribute
	{
		// Token: 0x06000CF7 RID: 3319 RVA: 0x00031DBC File Offset: 0x0002FFBC
		public Help(string strHelp, string strArgs = "")
		{
			this.helpDescription = strHelp;
			this.argsDescription = strArgs;
		}

		// Token: 0x04000854 RID: 2132
		public string helpDescription;

		// Token: 0x04000855 RID: 2133
		public string argsDescription;
	}
}
