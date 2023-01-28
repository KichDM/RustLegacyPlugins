using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using RustPP.Commands;
using RustPP.Permissions;

namespace RustPP
{
	// Token: 0x02000058 RID: 88
	public static class Helper
	{
		// Token: 0x06000267 RID: 615 RVA: 0x0000C3E8 File Offset: 0x0000A5E8
		public static T ObjectFromFile<T>(string path)
		{
			global::System.IO.FileStream stream = new global::System.IO.FileStream(path, global::System.IO.FileMode.Open);
			global::System.IO.StreamReader streamReader = new global::System.IO.StreamReader(stream);
			global::System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new global::System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			return (T)((object)binaryFormatter.Deserialize(streamReader.BaseStream));
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000C420 File Offset: 0x0000A620
		public static void ObjectToFile<T>(T ht, string path)
		{
			global::System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new global::System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			global::System.IO.FileStream stream = new global::System.IO.FileStream(path, global::System.IO.FileMode.Create);
			global::System.IO.StreamWriter streamWriter = new global::System.IO.StreamWriter(stream);
			binaryFormatter.Serialize(streamWriter.BaseStream, ht);
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000C454 File Offset: 0x0000A654
		public static T ObjectFromXML<T>(string path)
		{
			global::System.Xml.Serialization.XmlSerializer xmlSerializer = new global::System.Xml.Serialization.XmlSerializer(typeof(T));
			global::System.IO.TextReader textReader = new global::System.IO.StreamReader(path);
			T result = (T)((object)xmlSerializer.Deserialize(textReader));
			textReader.Close();
			return result;
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0000C48C File Offset: 0x0000A68C
		public static void ObjectToXML<T>(T obj, string path)
		{
			global::System.Xml.Serialization.XmlSerializer xmlSerializer = new global::System.Xml.Serialization.XmlSerializer(typeof(T));
			global::System.IO.TextWriter textWriter = new global::System.IO.StreamWriter(path);
			xmlSerializer.Serialize(textWriter, obj);
			textWriter.Close();
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000C4C3 File Offset: 0x0000A6C3
		public static string GetAbsoluteFilePath(string fileName)
		{
			return global::System.IO.Path.GetDirectoryName(global::System.IO.Path.GetDirectoryName(global::System.IO.Path.GetDirectoryName(global::System.Reflection.Assembly.GetExecutingAssembly().Location))) + "\\save\\Magma\\Rust++\\" + fileName;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000C4EC File Offset: 0x0000A6EC
		public static void CreateSaves()
		{
			try
			{
				global::RustPP.Commands.ShareCommand shareCommand = (global::RustPP.Commands.ShareCommand)global::RustPP.Commands.ChatCommand.GetCommand("share");
				global::RustPP.Commands.FriendsCommand friendsCommand = (global::RustPP.Commands.FriendsCommand)global::RustPP.Commands.ChatCommand.GetCommand("friends");
				if (shareCommand.GetSharedDoors().Count != 0)
				{
					global::RustPP.Helper.ObjectToFile<global::System.Collections.Hashtable>(shareCommand.GetSharedDoors(), global::RustPP.Helper.GetAbsoluteFilePath("doorsSave.rpp"));
				}
				else if (global::System.IO.File.Exists(global::RustPP.Helper.GetAbsoluteFilePath("doorsSave.rpp")))
				{
					global::System.IO.File.Delete(global::RustPP.Helper.GetAbsoluteFilePath("doorsSave.rpp"));
				}
				if (friendsCommand.GetFriendsLists().Count != 0)
				{
					global::RustPP.Helper.ObjectToFile<global::System.Collections.Hashtable>(friendsCommand.GetFriendsLists(), global::RustPP.Helper.GetAbsoluteFilePath("friendsSave.rpp"));
				}
				else if (global::System.IO.File.Exists(global::RustPP.Helper.GetAbsoluteFilePath("friendsSave.rpp")))
				{
					global::System.IO.File.Delete(global::RustPP.Helper.GetAbsoluteFilePath("friendsSave.rpp"));
				}
				if (global::RustPP.Permissions.Administrator.AdminList.Count != 0)
				{
					global::RustPP.Helper.ObjectToXML<global::System.Collections.Generic.List<global::RustPP.Permissions.Administrator>>(global::RustPP.Permissions.Administrator.AdminList, global::RustPP.Helper.GetAbsoluteFilePath("admins.xml"));
				}
				else if (global::System.IO.File.Exists(global::RustPP.Helper.GetAbsoluteFilePath("admins.xml")))
				{
					global::System.IO.File.Delete(global::RustPP.Helper.GetAbsoluteFilePath("admins.xml"));
				}
				if (global::RustPP.Core.userCache.Count != 0)
				{
					global::RustPP.Helper.ObjectToFile<global::System.Collections.Generic.Dictionary<ulong, string>>(global::RustPP.Core.userCache, global::RustPP.Helper.GetAbsoluteFilePath("cache.rpp"));
				}
				else if (global::System.IO.File.Exists(global::RustPP.Helper.GetAbsoluteFilePath("cache.rpp")))
				{
					global::System.IO.File.Delete(global::RustPP.Helper.GetAbsoluteFilePath("cache.rpp"));
				}
				if (global::RustPP.Core.whiteList.Count != 0)
				{
					global::RustPP.Helper.ObjectToXML<global::System.Collections.Generic.List<global::RustPP.PList.Player>>(global::RustPP.Core.whiteList.PlayerList, global::RustPP.Helper.GetAbsoluteFilePath("whitelist.xml"));
				}
				else if (global::System.IO.File.Exists(global::RustPP.Helper.GetAbsoluteFilePath("whitelist.xml")))
				{
					global::System.IO.File.Delete(global::RustPP.Helper.GetAbsoluteFilePath("whitelist.xml"));
				}
				if (global::RustPP.Core.blackList.Count != 0)
				{
					global::RustPP.Helper.ObjectToXML<global::System.Collections.Generic.List<global::RustPP.PList.Player>>(global::RustPP.Core.blackList.PlayerList, global::RustPP.Helper.GetAbsoluteFilePath("bans.xml"));
				}
				else if (global::System.IO.File.Exists(global::RustPP.Helper.GetAbsoluteFilePath("bans.xml")))
				{
					global::System.IO.File.Delete(global::RustPP.Helper.GetAbsoluteFilePath("bans.xml"));
				}
			}
			catch (global::System.Exception)
			{
				throw;
			}
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000C6D4 File Offset: 0x0000A8D4
		public static void Log(string logName, string msg)
		{
			global::System.IO.File.AppendAllText(global::RustPP.Helper.GetAbsoluteFilePath(logName), string.Concat(new string[]
			{
				"[",
				global::System.DateTime.Now.ToShortDateString(),
				" ",
				global::System.DateTime.Now.ToShortTimeString(),
				"] ",
				msg,
				"\r\n"
			}));
		}
	}
}
