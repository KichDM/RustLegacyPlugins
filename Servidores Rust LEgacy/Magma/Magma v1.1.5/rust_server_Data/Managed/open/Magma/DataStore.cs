using System;
using System.Collections;
using System.IO;

namespace Magma
{
	// Token: 0x02000004 RID: 4
	public class DataStore
	{
		// Token: 0x0600001A RID: 26 RVA: 0x00002550 File Offset: 0x00000750
		public static global::Magma.DataStore GetInstance()
		{
			if (global::Magma.DataStore.instance == null)
			{
				global::Magma.DataStore.instance = new global::Magma.DataStore();
			}
			return global::Magma.DataStore.instance;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002568 File Offset: 0x00000768
		public void Add(string tablename, object key, object val)
		{
			global::System.Collections.Hashtable hashtable = (global::System.Collections.Hashtable)this.datastore[tablename];
			if (hashtable == null)
			{
				hashtable = new global::System.Collections.Hashtable();
				this.datastore.Add(tablename, hashtable);
			}
			if (hashtable.ContainsKey(key))
			{
				hashtable[key] = val;
				return;
			}
			hashtable.Add(key, val);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000025B8 File Offset: 0x000007B8
		public object Get(string tablename, object key)
		{
			global::System.Collections.Hashtable hashtable = (global::System.Collections.Hashtable)this.datastore[tablename];
			if (hashtable == null)
			{
				return null;
			}
			return hashtable[key];
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000025E4 File Offset: 0x000007E4
		public global::System.Collections.Hashtable GetTable(string tablename)
		{
			global::System.Collections.Hashtable hashtable = (global::System.Collections.Hashtable)this.datastore[tablename];
			if (hashtable == null)
			{
				return null;
			}
			return hashtable;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000260C File Offset: 0x0000080C
		public bool ContainsKey(string tablename, object key)
		{
			global::System.Collections.Hashtable hashtable = (global::System.Collections.Hashtable)this.datastore[tablename];
			if (hashtable != null)
			{
				foreach (object obj in hashtable.Keys)
				{
					if (obj == key)
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000267C File Offset: 0x0000087C
		public object[] Keys(string tablename)
		{
			global::System.Collections.Hashtable hashtable = (global::System.Collections.Hashtable)this.datastore[tablename];
			if (hashtable != null)
			{
				object[] array = new object[hashtable.Keys.Count];
				hashtable.Keys.CopyTo(array, 0);
				return array;
			}
			return null;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000026C0 File Offset: 0x000008C0
		public object[] Values(string tablename)
		{
			global::System.Collections.Hashtable hashtable = (global::System.Collections.Hashtable)this.datastore[tablename];
			if (hashtable != null)
			{
				object[] array = new object[hashtable.Values.Count];
				hashtable.Values.CopyTo(array, 0);
				return array;
			}
			return null;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002704 File Offset: 0x00000904
		public bool ContainsValue(string tablename, object val)
		{
			global::System.Collections.Hashtable hashtable = (global::System.Collections.Hashtable)this.datastore[tablename];
			if (hashtable != null)
			{
				foreach (object obj in hashtable.Values)
				{
					if (obj == val)
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002774 File Offset: 0x00000974
		public void Remove(string tablename, object key)
		{
			global::System.Collections.Hashtable hashtable = (global::System.Collections.Hashtable)this.datastore[tablename];
			if (hashtable != null)
			{
				hashtable.Remove(key);
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000027A0 File Offset: 0x000009A0
		public int Count(string tablename)
		{
			global::System.Collections.Hashtable hashtable = (global::System.Collections.Hashtable)this.datastore[tablename];
			if (hashtable == null)
			{
				return 0;
			}
			return hashtable.Count;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000027CC File Offset: 0x000009CC
		public void Flush(string tablename)
		{
			global::System.Collections.Hashtable hashtable = (global::System.Collections.Hashtable)this.datastore[tablename];
			if (hashtable != null)
			{
				this.datastore.Remove(tablename);
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000027FC File Offset: 0x000009FC
		public void Load()
		{
			if (global::System.IO.File.Exists(global::Magma.DataStore.PATH))
			{
				try
				{
					global::System.Collections.Hashtable hashtable = global::Magma.Util.HashtableFromFile(global::Magma.DataStore.PATH);
					this.datastore = hashtable;
					global::Magma.Util.GetUtil().ConsoleLog("Magma DataStore Loaded", false);
				}
				catch (global::System.Exception)
				{
				}
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000284C File Offset: 0x00000A4C
		public void Save()
		{
			if (this.datastore.Count != 0)
			{
				global::Magma.Util.HashtableToFile(this.datastore, global::Magma.DataStore.PATH);
				global::Magma.Util.GetUtil().ConsoleLog("Magma DataStore Saved", false);
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002891 File Offset: 0x00000A91
		public DataStore()
		{
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000287B File Offset: 0x00000A7B
		// Note: this type is marked as 'beforefieldinit'.
		static DataStore()
		{
		}

		// Token: 0x04000007 RID: 7
		public static string PATH = global::Magma.Util.GetServerFolder() + "..\\save\\MagmaDatastore.ds";

		// Token: 0x04000008 RID: 8
		public global::System.Collections.Hashtable datastore = new global::System.Collections.Hashtable();

		// Token: 0x04000009 RID: 9
		private static global::Magma.DataStore instance;
	}
}
