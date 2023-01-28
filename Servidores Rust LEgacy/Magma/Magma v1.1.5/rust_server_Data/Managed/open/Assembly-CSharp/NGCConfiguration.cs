using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using Facepunch;
using Facepunch.Build;
using Facepunch.Hash;
using UnityEngine;

// Token: 0x020003E7 RID: 999
[global::Facepunch.Build.UniqueBundleScriptableObject]
public class NGCConfiguration : global::UnityEngine.ScriptableObject
{
	// Token: 0x06001F6B RID: 8043 RVA: 0x00078528 File Offset: 0x00076728
	public NGCConfiguration()
	{
	}

	// Token: 0x06001F6C RID: 8044 RVA: 0x00078530 File Offset: 0x00076730
	public static global::NGCConfiguration Load()
	{
		return global::Facepunch.Bundling.Load<global::NGCConfiguration>("content/network/NGCConf");
	}

	// Token: 0x06001F6D RID: 8045 RVA: 0x0007853C File Offset: 0x0007673C
	public void Install()
	{
		foreach (global::NGCConfiguration.PrefabEntry prefabEntry in this.entries)
		{
			if (prefabEntry != null && prefabEntry.ReadyToRegister)
			{
				global::NGC.Prefab.Register.Add(prefabEntry.Path, prefabEntry.HashCode, ";" + prefabEntry.Name);
			}
		}
	}

	// Token: 0x06001F6E RID: 8046 RVA: 0x0007859C File Offset: 0x0007679C
	protected void OnEnable()
	{
		if (this.entries == null)
		{
			this.entries = new global::NGCConfiguration.PrefabEntry[0];
		}
		else
		{
			global::System.Collections.Generic.HashSet<string> hashSet = new global::System.Collections.Generic.HashSet<string>();
			int num = 0;
			for (int i = 0; i < this.entries.Length; i++)
			{
				if (this.entries[i] != null)
				{
					if (!hashSet.Add(this.entries[i].Name))
					{
						global::UnityEngine.Debug.LogWarning(string.Format("Removing duplicate ngc prefab named '{0}' (path:{1})", this.entries[i].Name, this.entries[i].Path));
					}
					else
					{
						if (string.IsNullOrEmpty(this.entries[i].Path))
						{
							global::UnityEngine.Debug.LogWarning(string.Format("ngc prefab {0} has no path!", this.entries[i].Name), this);
						}
						this.entries[num++] = this.entries[i];
					}
				}
			}
			if (num < this.entries.Length)
			{
				global::System.Array.Resize<global::NGCConfiguration.PrefabEntry>(ref this.entries, num);
				global::UnityEngine.Debug.LogWarning("The entries of the ngcconfiguration were altered!", this);
			}
		}
	}

	// Token: 0x0400112A RID: 4394
	private const string bundledPath = "content/network/NGCConf";

	// Token: 0x0400112B RID: 4395
	[global::UnityEngine.SerializeField]
	private global::NGCConfiguration.PrefabEntry[] entries;

	// Token: 0x020003E8 RID: 1000
	[global::System.Serializable]
	public sealed class PrefabEntry
	{
		// Token: 0x06001F6F RID: 8047 RVA: 0x000786AC File Offset: 0x000768AC
		public PrefabEntry()
		{
		}

		// Token: 0x170007D6 RID: 2006
		// (get) Token: 0x06001F70 RID: 8048 RVA: 0x000786D8 File Offset: 0x000768D8
		public int HashCode
		{
			get
			{
				return (!this.calculatedHashCode) ? (this._hashCode = global::NGCConfiguration.PrefabEntry.hash(this.guidText)) : this._hashCode;
			}
		}

		// Token: 0x06001F71 RID: 8049 RVA: 0x00078710 File Offset: 0x00076910
		public override int GetHashCode()
		{
			return (!this.calculatedHashCode) ? (this._hashCode = global::NGCConfiguration.PrefabEntry.hash(this.guidText)) : this._hashCode;
		}

		// Token: 0x06001F72 RID: 8050 RVA: 0x00078748 File Offset: 0x00076948
		public override string ToString()
		{
			return string.Format("[PrefabEntry: Name=\"{1}\", HashCode={0:X}, Path=\"{2}\"]", this.HashCode, this.Name, this.Path);
		}

		// Token: 0x170007D7 RID: 2007
		// (get) Token: 0x06001F73 RID: 8051 RVA: 0x00078778 File Offset: 0x00076978
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x170007D8 RID: 2008
		// (get) Token: 0x06001F74 RID: 8052 RVA: 0x00078780 File Offset: 0x00076980
		public string Path
		{
			get
			{
				return this.path;
			}
		}

		// Token: 0x170007D9 RID: 2009
		// (get) Token: 0x06001F75 RID: 8053 RVA: 0x00078788 File Offset: 0x00076988
		public bool ReadyToRegister
		{
			get
			{
				return !string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.Path) && this.HashCode != 0;
			}
		}

		// Token: 0x06001F76 RID: 8054 RVA: 0x000787C4 File Offset: 0x000769C4
		private static int hash(string guid)
		{
			if (string.IsNullOrEmpty(guid))
			{
				return 0;
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			using (global::System.Collections.Generic.IEnumerator<int> enumerator = global::NGCConfiguration.PrefabEntry.ParseInts(guid))
			{
				if (enumerator.MoveNext())
				{
					num = enumerator.Current;
					if (enumerator.MoveNext())
					{
						num2 = enumerator.Current;
						if (enumerator.MoveNext())
						{
							num3 = enumerator.Current;
							if (enumerator.MoveNext())
							{
								num4 = enumerator.Current;
								if (enumerator.MoveNext())
								{
									num5 = enumerator.Current;
									if (enumerator.MoveNext())
									{
										num6 = enumerator.Current;
									}
								}
							}
						}
					}
				}
			}
			global::NGCConfiguration.PrefabEntry.hashwork.guid[0] = num;
			global::NGCConfiguration.PrefabEntry.hashwork.guid[1] = num6;
			global::NGCConfiguration.PrefabEntry.hashwork.guid[2] = num5;
			global::NGCConfiguration.PrefabEntry.hashwork.guid[3] = num3;
			global::NGCConfiguration.PrefabEntry.hashwork.guid[4] = num4;
			global::NGCConfiguration.PrefabEntry.hashwork.guid[5] = num2;
			return global::Facepunch.Hash.MurmurHash2.SINT(global::NGCConfiguration.PrefabEntry.hashwork.guid, global::NGCConfiguration.PrefabEntry.hashwork.guid.Length, 0x86C08F16U);
		}

		// Token: 0x06001F77 RID: 8055 RVA: 0x000788E8 File Offset: 0x00076AE8
		private static global::System.Collections.Generic.IEnumerator<int> ParseInts(string hex)
		{
			int start = hex.Length;
			while (start >= 8)
			{
				start -= 8;
				yield return int.Parse(hex.Substring(start, 8), global::System.Globalization.NumberStyles.HexNumber);
			}
			if (start > 0)
			{
				yield return int.Parse(hex.Remove(start), global::System.Globalization.NumberStyles.HexNumber);
			}
			yield break;
		}

		// Token: 0x0400112C RID: 4396
		private const uint peSeed = 0x86C08F16U;

		// Token: 0x0400112D RID: 4397
		[global::UnityEngine.SerializeField]
		private string name = "!unnamed";

		// Token: 0x0400112E RID: 4398
		[global::UnityEngine.SerializeField]
		private string path = string.Empty;

		// Token: 0x0400112F RID: 4399
		[global::UnityEngine.SerializeField]
		private string guidText = string.Empty;

		// Token: 0x04001130 RID: 4400
		[global::System.NonSerialized]
		private bool calculatedHashCode;

		// Token: 0x04001131 RID: 4401
		[global::System.NonSerialized]
		private int _hashCode;

		// Token: 0x020003E9 RID: 1001
		private static class hashwork
		{
			// Token: 0x06001F78 RID: 8056 RVA: 0x0007890C File Offset: 0x00076B0C
			// Note: this type is marked as 'beforefieldinit'.
			static hashwork()
			{
			}

			// Token: 0x04001132 RID: 4402
			public static readonly int[] guid = new int[6];
		}

		// Token: 0x020003EA RID: 1002
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <ParseInts>c__Iterator36 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<int>
		{
			// Token: 0x06001F79 RID: 8057 RVA: 0x0007891C File Offset: 0x00076B1C
			public <ParseInts>c__Iterator36()
			{
			}

			// Token: 0x170007DA RID: 2010
			// (get) Token: 0x06001F7A RID: 8058 RVA: 0x00078924 File Offset: 0x00076B24
			int global::System.Collections.Generic.IEnumerator<int>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x170007DB RID: 2011
			// (get) Token: 0x06001F7B RID: 8059 RVA: 0x0007892C File Offset: 0x00076B2C
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06001F7C RID: 8060 RVA: 0x0007893C File Offset: 0x00076B3C
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0U:
					start = hex.Length;
					break;
				case 1U:
					break;
				case 2U:
					goto IL_BC;
				default:
					return false;
				}
				if (start < 8)
				{
					if (start <= 0)
					{
						goto IL_BC;
					}
					this.$current = int.Parse(hex.Remove(start), global::System.Globalization.NumberStyles.HexNumber);
					this.$PC = 2;
				}
				else
				{
					start -= 8;
					this.$current = int.Parse(hex.Substring(start, 8), global::System.Globalization.NumberStyles.HexNumber);
					this.$PC = 1;
				}
				return true;
				IL_BC:
				this.$PC = -1;
				return false;
			}

			// Token: 0x06001F7D RID: 8061 RVA: 0x00078A14 File Offset: 0x00076C14
			[global::System.Diagnostics.DebuggerHidden]
			public void Dispose()
			{
				this.$PC = -1;
			}

			// Token: 0x06001F7E RID: 8062 RVA: 0x00078A20 File Offset: 0x00076C20
			[global::System.Diagnostics.DebuggerHidden]
			public void Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x04001133 RID: 4403
			internal string hex;

			// Token: 0x04001134 RID: 4404
			internal int <start>__0;

			// Token: 0x04001135 RID: 4405
			internal int $PC;

			// Token: 0x04001136 RID: 4406
			internal int $current;

			// Token: 0x04001137 RID: 4407
			internal string <$>hex;
		}
	}
}
