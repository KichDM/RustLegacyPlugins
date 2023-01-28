using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using Facepunch.Utility;
using uLink;
using UnityEngine;

namespace Magma
{
	// Token: 0x02000064 RID: 100
	public class Util
	{
		// Token: 0x060002F3 RID: 755 RVA: 0x0000ED5E File Offset: 0x0000CF5E
		public Util()
		{
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0000ED71 File Offset: 0x0000CF71
		public static global::Magma.Util GetUtil()
		{
			if (global::Magma.Util.util == null)
			{
				global::Magma.Util.util = new global::Magma.Util();
			}
			return global::Magma.Util.util;
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x0000ED89 File Offset: 0x0000CF89
		public global::System.Text.RegularExpressions.Match Regex(string input, string match)
		{
			return new global::System.Text.RegularExpressions.Regex(input).Match(match);
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0000ED98 File Offset: 0x0000CF98
		public static global::System.Collections.Hashtable HashtableFromFile(string path)
		{
			global::System.IO.FileStream stream = new global::System.IO.FileStream(path, global::System.IO.FileMode.Open);
			global::System.IO.StreamReader streamReader = new global::System.IO.StreamReader(stream);
			global::System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new global::System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			return (global::System.Collections.Hashtable)binaryFormatter.Deserialize(streamReader.BaseStream);
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0000EDD0 File Offset: 0x0000CFD0
		public static void HashtableToFile(global::System.Collections.Hashtable ht, string path)
		{
			global::System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new global::System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			global::System.IO.FileStream stream = new global::System.IO.FileStream(path, global::System.IO.FileMode.Create);
			global::System.IO.StreamWriter streamWriter = new global::System.IO.StreamWriter(stream);
			binaryFormatter.Serialize(streamWriter.BaseStream, ht);
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0000EDFF File Offset: 0x0000CFFF
		public static string GetAbsoluteFilePath(string fileName)
		{
			return global::Magma.Util.GetMagmaFolder() + fileName;
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0000EE0C File Offset: 0x0000D00C
		public static string GetRustPPDirectory()
		{
			return global::System.IO.Path.GetDirectoryName(global::System.IO.Path.GetDirectoryName(global::System.IO.Path.GetDirectoryName(global::System.Reflection.Assembly.GetExecutingAssembly().Location))) + "\\save\\RustPP\\";
		}

		// Token: 0x060002FA RID: 762 RVA: 0x0000EE31 File Offset: 0x0000D031
		public static string GetMagmaFolder()
		{
			return global::Magma.Data.PATH;
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0000EE38 File Offset: 0x0000D038
		public static string GetServerFolder()
		{
			return global::System.IO.Path.GetDirectoryName(global::System.IO.Path.GetDirectoryName(global::System.IO.Path.GetDirectoryName(global::System.Reflection.Assembly.GetExecutingAssembly().Location))) + "\\rust_server_Data\\";
		}

		// Token: 0x060002FC RID: 764 RVA: 0x0000EE5D File Offset: 0x0000D05D
		public static string GetRootFolder()
		{
			return global::System.IO.Path.GetDirectoryName(global::System.IO.Path.GetDirectoryName(global::System.IO.Path.GetDirectoryName(global::System.Reflection.Assembly.GetExecutingAssembly().Location)));
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0000EE78 File Offset: 0x0000D078
		public static void sayAll(string arg)
		{
			string str = global::Facepunch.Utility.String.QuoteSafe(global::Magma.Server.GetServer().server_message_name);
			string str2 = global::Facepunch.Utility.String.QuoteSafe(arg);
			global::ConsoleNetworker.Broadcast("chat.add " + str + " " + str2);
		}

		// Token: 0x060002FE RID: 766 RVA: 0x0000EEB4 File Offset: 0x0000D0B4
		public static void sayUser(global::uLink.NetworkPlayer player, string arg)
		{
			string str = global::Facepunch.Utility.String.QuoteSafe(global::Magma.Server.GetServer().server_message_name);
			string str2 = global::Facepunch.Utility.String.QuoteSafe(arg);
			global::ConsoleNetworker.SendClientCommand(player, "chat.add " + str + " " + str2);
		}

		// Token: 0x060002FF RID: 767 RVA: 0x0000EEF0 File Offset: 0x0000D0F0
		public static void sayUser(global::uLink.NetworkPlayer player, string customName, string arg)
		{
			string str = global::Facepunch.Utility.String.QuoteSafe(customName);
			string str2 = global::Facepunch.Utility.String.QuoteSafe(arg);
			global::ConsoleNetworker.SendClientCommand(player, "chat.add " + str + " " + str2);
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0000EF24 File Offset: 0x0000D124
		public static void say(global::uLink.NetworkPlayer player, string playername, string arg)
		{
			global::ConsoleNetworker.SendClientCommand(player, "chat.add " + playername + " " + arg);
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0000EF4C File Offset: 0x0000D14C
		public object CreateInstance(string name, params object[] args)
		{
			global::System.Type type;
			if (!this.TryFindType(name.Replace('.', '+'), out type))
			{
				return null;
			}
			if (type.BaseType.Name == "ScriptableObject")
			{
				return global::UnityEngine.ScriptableObject.CreateInstance(name);
			}
			return global::System.Activator.CreateInstance(type, args);
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0000EF94 File Offset: 0x0000D194
		public object CreateArrayInstance(string name, int size)
		{
			global::System.Type type;
			if (!this.TryFindType(name.Replace('.', '+'), out type))
			{
				return null;
			}
			if (type.BaseType.Name == "ScriptableObject")
			{
				return global::UnityEngine.ScriptableObject.CreateInstance(name);
			}
			return global::System.Array.CreateInstance(type, size);
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0000EFDC File Offset: 0x0000D1DC
		public object GetStaticField(string className, string field)
		{
			global::System.Type type;
			if (!this.TryFindType(className.Replace('.', '+'), out type))
			{
				return null;
			}
			global::System.Reflection.FieldInfo field2 = type.GetField(field, global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public);
			if (field2 != null)
			{
				return field2.GetValue(null);
			}
			return null;
		}

		// Token: 0x06000304 RID: 772 RVA: 0x0000F018 File Offset: 0x0000D218
		public void SetStaticField(string className, string field, object val)
		{
			global::System.Type type;
			if (this.TryFindType(className.Replace('.', '+'), out type))
			{
				global::System.Reflection.FieldInfo field2 = type.GetField(field, global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public);
				if (field2 != null)
				{
					field2.SetValue(null, global::System.Convert.ChangeType(val, field2.FieldType));
				}
			}
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0000F05C File Offset: 0x0000D25C
		public object InvokeStatic(string className, string method, global::ParamsList args)
		{
			global::System.Type type;
			if (!this.TryFindType(className.Replace('.', '+'), out type))
			{
				return null;
			}
			global::System.Reflection.MethodInfo method2 = type.GetMethod(method, global::System.Reflection.BindingFlags.Static);
			if (method2 == null)
			{
				return null;
			}
			if (method2.ReturnType == typeof(void))
			{
				method2.Invoke(null, args.ToArray());
				return true;
			}
			return method2.Invoke(null, args.ToArray());
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0000F0C4 File Offset: 0x0000D2C4
		public bool TryFindType(string typeName, out global::System.Type t)
		{
			lock (this.typeCache)
			{
				if (!this.typeCache.TryGetValue(typeName, out t))
				{
					foreach (global::System.Reflection.Assembly assembly in global::System.AppDomain.CurrentDomain.GetAssemblies())
					{
						t = assembly.GetType(typeName);
						if (t != null)
						{
							break;
						}
					}
					this.typeCache[typeName] = t;
				}
			}
			return t != null;
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0000F148 File Offset: 0x0000D348
		public bool IsNull(object obj)
		{
			return obj == null;
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0000F14E File Offset: 0x0000D34E
		public void DestroyObject(global::UnityEngine.GameObject go)
		{
			global::NetCull.Destroy(go);
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000F156 File Offset: 0x0000D356
		public global::UnityEngine.Vector3 CreateVector(float x, float y, float z)
		{
			return new global::UnityEngine.Vector3(x, y, z);
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000F160 File Offset: 0x0000D360
		public global::UnityEngine.Quaternion CreateQuat(float x, float y, float z, float w)
		{
			return new global::UnityEngine.Quaternion(x, y, z, w);
		}

		// Token: 0x0600030B RID: 779 RVA: 0x0000F16C File Offset: 0x0000D36C
		public global::UnityEngine.Vector3 Infront(global::Magma.Player p, float length)
		{
			return p.PlayerClient.controllable.transform.position + p.PlayerClient.controllable.transform.forward * length;
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0000F1A3 File Offset: 0x0000D3A3
		public global::UnityEngine.Quaternion RotateX(global::UnityEngine.Quaternion q, float angle)
		{
			return q *= global::UnityEngine.Quaternion.Euler(angle, 0f, 0f);
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0000F1BE File Offset: 0x0000D3BE
		public global::UnityEngine.Quaternion RotateY(global::UnityEngine.Quaternion q, float angle)
		{
			return q *= global::UnityEngine.Quaternion.Euler(0f, angle, 0f);
		}

		// Token: 0x0600030E RID: 782 RVA: 0x0000F1D9 File Offset: 0x0000D3D9
		public global::UnityEngine.Quaternion RotateZ(global::UnityEngine.Quaternion q, float angle)
		{
			return q *= global::UnityEngine.Quaternion.Euler(0f, 0f, angle);
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0000F1F4 File Offset: 0x0000D3F4
		public float GetVectorsDistance(global::UnityEngine.Vector3 v1, global::UnityEngine.Vector3 v2)
		{
			return global::TransformHelpers.Dist2D(v1, v2);
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0000F1FD File Offset: 0x0000D3FD
		public void Log(string str)
		{
			global::System.Console.WriteLine(str);
		}

		// Token: 0x06000311 RID: 785 RVA: 0x0000F208 File Offset: 0x0000D408
		public void ConsoleLog(string str, bool adminOnly = false)
		{
			foreach (global::Magma.Player player in global::Magma.Server.GetServer().Players)
			{
				if (!adminOnly)
				{
					global::ConsoleNetworker.singleton.networkView.RPC<string>("CL_ConsoleMessage", player.PlayerClient.netPlayer, str);
				}
				else if (player.Admin)
				{
					global::ConsoleNetworker.singleton.networkView.RPC<string>("CL_ConsoleMessage", player.PlayerClient.netPlayer, str);
				}
			}
		}

		// Token: 0x040000A3 RID: 163
		private static global::Magma.Util util;

		// Token: 0x040000A4 RID: 164
		private global::System.Collections.Generic.Dictionary<string, global::System.Type> typeCache = new global::System.Collections.Generic.Dictionary<string, global::System.Type>();
	}
}
