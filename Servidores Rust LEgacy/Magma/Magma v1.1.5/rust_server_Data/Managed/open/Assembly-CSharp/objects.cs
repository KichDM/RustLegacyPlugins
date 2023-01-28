using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using uLink;
using UnityEngine;

// Token: 0x020001C3 RID: 451
internal class objects : global::ConsoleSystem
{
	// Token: 0x06000D28 RID: 3368 RVA: 0x00033BB0 File Offset: 0x00031DB0
	public objects()
	{
	}

	// Token: 0x06000D29 RID: 3369 RVA: 0x00033BB8 File Offset: 0x00031DB8
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Logs object counts", "")]
	public static void count(ref global::ConsoleSystem.Arg arg)
	{
		global::System.Type type;
		if (arg.HasArgs(1))
		{
			type = null;
			foreach (string str in new string[]
			{
				string.Empty,
				", UnityEngine",
				", Assembly-CSharp-firstpass",
				", Assembly-CSharp"
			})
			{
				string text = arg.ArgsStr + str;
				try
				{
					type = global::System.Type.GetType(text, true, true);
					if (!typeof(global::UnityEngine.Object).IsAssignableFrom(type))
					{
						type = null;
						throw new global::System.InvalidOperationException();
					}
					break;
				}
				catch
				{
					try
					{
						type = global::System.Type.GetType("UnityEngine." + text, true, true);
						if (!typeof(global::UnityEngine.Object).IsAssignableFrom(type))
						{
							type = null;
							throw new global::System.InvalidOperationException();
						}
						break;
					}
					catch
					{
					}
				}
			}
			if (type == null)
			{
				arg.ReplyWith("No type or unassignable to UnityEngine.Object");
				return;
			}
		}
		else
		{
			type = typeof(global::UnityEngine.Object);
		}
		arg.ReplyWith(global::ManagedLeakDetector.Poll(type));
	}

	// Token: 0x06000D2A RID: 3370 RVA: 0x00033D04 File Offset: 0x00031F04
	private static global::System.Collections.Generic.IEnumerable<string> RuntimePrefabNames()
	{
		foreach (global::uLink.NetworkView view in global::uLink.Network.networkViews)
		{
			if (view)
			{
				string prefabName = view.serverPrefab;
				if (prefabName == "!Ng")
				{
					global::NGC ngc = ((global::NGCInternalView)view).GetNGC();
					if (ngc)
					{
						foreach (global::NGCView ngcView in ngc.GetViews())
						{
							if (ngcView)
							{
								yield return ngcView.prefab.handle;
							}
						}
					}
				}
				yield return prefabName;
			}
		}
		yield break;
	}

	// Token: 0x06000D2B RID: 3371 RVA: 0x00033D20 File Offset: 0x00031F20
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Logs prefab names by count", "")]
	public static void prefabs(ref global::ConsoleSystem.Arg arg)
	{
		global::System.Collections.Generic.Dictionary<string, int> dictionary = new global::System.Collections.Generic.Dictionary<string, int>();
		foreach (string key in global::objects.RuntimePrefabNames())
		{
			int num;
			if (dictionary.TryGetValue(key, out num))
			{
				dictionary[key] = num + 1;
			}
			else
			{
				dictionary[key] = 1;
			}
		}
		global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<string, int>> list = new global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<string, int>>(dictionary);
		list.Sort(delegate(global::System.Collections.Generic.KeyValuePair<string, int> a, global::System.Collections.Generic.KeyValuePair<string, int> b)
		{
			int num2 = b.Value.CompareTo(a.Value);
			if (num2 == 0)
			{
				return a.Key.CompareTo(b.Key);
			}
			return num2;
		});
		global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
		foreach (global::System.Collections.Generic.KeyValuePair<string, int> keyValuePair in list)
		{
			stringBuilder.AppendFormat("{1,-10} | \"{0}\"\n", keyValuePair.Key, keyValuePair.Value);
		}
		arg.ReplyWith(stringBuilder.ToString());
	}

	// Token: 0x06000D2C RID: 3372 RVA: 0x00033E54 File Offset: 0x00032054
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static int <prefabs>m__4(global::System.Collections.Generic.KeyValuePair<string, int> a, global::System.Collections.Generic.KeyValuePair<string, int> b)
	{
		int num = b.Value.CompareTo(a.Value);
		if (num == 0)
		{
			return a.Key.CompareTo(b.Key);
		}
		return num;
	}

	// Token: 0x04000877 RID: 2167
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Comparison<global::System.Collections.Generic.KeyValuePair<string, int>> <>f__am$cache0;

	// Token: 0x020001C4 RID: 452
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <RuntimePrefabNames>c__Iterator2A : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<string>, global::System.Collections.Generic.IEnumerator<string>
	{
		// Token: 0x06000D2D RID: 3373 RVA: 0x00033E94 File Offset: 0x00032094
		public <RuntimePrefabNames>c__Iterator2A()
		{
		}

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x06000D2E RID: 3374 RVA: 0x00033E9C File Offset: 0x0003209C
		string global::System.Collections.Generic.IEnumerator<string>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x06000D2F RID: 3375 RVA: 0x00033EA4 File Offset: 0x000320A4
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000D30 RID: 3376 RVA: 0x00033EAC File Offset: 0x000320AC
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<string>.GetEnumerator();
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x00033EB4 File Offset: 0x000320B4
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<string> global::System.Collections.Generic.IEnumerable<string>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new global::objects.<RuntimePrefabNames>c__Iterator2A();
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x00033ED0 File Offset: 0x000320D0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				networkViews = global::uLink.Network.networkViews;
				i = 0;
				goto IL_176;
			case 1U:
				Block_5:
				try
				{
					switch (num)
					{
					}
					while (enumerator.MoveNext())
					{
						ngcView = enumerator.Current;
						if (ngcView)
						{
							this.$current = ngcView.prefab.handle;
							this.$PC = 1;
							flag = true;
							return true;
						}
					}
				}
				finally
				{
					if (!flag)
					{
						((global::System.IDisposable)enumerator).Dispose();
					}
				}
				break;
			case 2U:
				IL_168:
				i++;
				goto IL_176;
			default:
				return false;
			}
			IL_150:
			this.$current = prefabName;
			this.$PC = 2;
			return true;
			IL_176:
			if (i >= networkViews.Length)
			{
				this.$PC = -1;
			}
			else
			{
				view = networkViews[i];
				if (!view)
				{
					goto IL_168;
				}
				prefabName = view.serverPrefab;
				if (!(prefabName == "!Ng"))
				{
					goto IL_150;
				}
				ngc = ((global::NGCInternalView)view).GetNGC();
				if (ngc)
				{
					enumerator = ngc.GetViews().GetEnumerator();
					num = 0xFFFFFFFDU;
					goto Block_5;
				}
				goto IL_150;
			}
			return false;
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x00034090 File Offset: 0x00032290
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06000D34 RID: 3380 RVA: 0x000340F4 File Offset: 0x000322F4
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04000878 RID: 2168
		internal global::uLink.NetworkView[] <$s_248>__0;

		// Token: 0x04000879 RID: 2169
		internal int <$s_249>__1;

		// Token: 0x0400087A RID: 2170
		internal global::uLink.NetworkView <view>__2;

		// Token: 0x0400087B RID: 2171
		internal string <prefabName>__3;

		// Token: 0x0400087C RID: 2172
		internal global::NGC <ngc>__4;

		// Token: 0x0400087D RID: 2173
		internal global::System.Collections.Generic.Dictionary<ushort, global::NGCView>.ValueCollection.Enumerator <$s_250>__5;

		// Token: 0x0400087E RID: 2174
		internal global::NGCView <ngcView>__6;

		// Token: 0x0400087F RID: 2175
		internal int $PC;

		// Token: 0x04000880 RID: 2176
		internal string $current;
	}
}
