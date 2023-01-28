using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200047C RID: 1148
public class ShaderMod : global::UnityEngine.ScriptableObject
{
	// Token: 0x06002829 RID: 10281 RVA: 0x00099A84 File Offset: 0x00097C84
	public ShaderMod()
	{
	}

	// Token: 0x170008E5 RID: 2277
	public global::ShaderMod.DICT this[global::ShaderMod.Replacement replacement]
	{
		get
		{
			switch (replacement)
			{
			case global::ShaderMod.Replacement.Include:
				return this.replaceIncludes;
			case global::ShaderMod.Replacement.Queue:
				return this.replaceQueues;
			case global::ShaderMod.Replacement.Define:
				return this.macroDefines;
			default:
				return null;
			}
		}
	}

	// Token: 0x0600282B RID: 10283 RVA: 0x00099AC8 File Offset: 0x00097CC8
	public bool Replace(global::ShaderMod.Replacement replacement, string incoming, ref string outgoing)
	{
		global::ShaderMod.DICT dict = this[replacement];
		return dict != null && dict.Replace(replacement, incoming, ref outgoing);
	}

	// Token: 0x040013F9 RID: 5113
	public global::ShaderMod.DICT replaceIncludes;

	// Token: 0x040013FA RID: 5114
	public global::ShaderMod.DICT replaceQueues;

	// Token: 0x040013FB RID: 5115
	public global::ShaderMod.DICT macroDefines;

	// Token: 0x040013FC RID: 5116
	public string[] preIncludes;

	// Token: 0x040013FD RID: 5117
	public string[] postIncludes;

	// Token: 0x0200047D RID: 1149
	[global::System.Serializable]
	public class KV
	{
		// Token: 0x0600282C RID: 10284 RVA: 0x00099AF0 File Offset: 0x00097CF0
		public KV()
		{
			this.key = string.Empty;
			this.value = string.Empty;
		}

		// Token: 0x0600282D RID: 10285 RVA: 0x00099B10 File Offset: 0x00097D10
		public KV(string key, string value)
		{
			this.key = key;
			this.value = value;
		}

		// Token: 0x0600282E RID: 10286 RVA: 0x00099B28 File Offset: 0x00097D28
		public override int GetHashCode()
		{
			return (this.key != null) ? this.key.GetHashCode() : 0;
		}

		// Token: 0x040013FE RID: 5118
		public string key;

		// Token: 0x040013FF RID: 5119
		public string value;
	}

	// Token: 0x0200047E RID: 1150
	public static class QueueCompare
	{
		// Token: 0x0600282F RID: 10287 RVA: 0x00099B48 File Offset: 0x00097D48
		// Note: this type is marked as 'beforefieldinit'.
		static QueueCompare()
		{
		}

		// Token: 0x06002830 RID: 10288 RVA: 0x00099B60 File Offset: 0x00097D60
		public static int ToInt32(string queue)
		{
			if (queue == null || queue.Length == 0)
			{
				return 0x7D0;
			}
			int num = queue.IndexOfAny(global::ShaderMod.QueueCompare.signChars);
			int num2;
			if (num != -1)
			{
				queue = queue.Substring(0, num);
				num2 = int.Parse(queue.Substring(num));
			}
			else
			{
				num2 = 0;
			}
			string text = (queue = queue.Trim()).ToLowerInvariant();
			switch (text)
			{
			case "geometry":
				return 0x7D0 + num2;
			case "alphatest":
				return 0x992 + num2;
			case "transparent":
				return 0xBB8 + num2;
			case "background":
				return 0x3E8 + num2;
			case "overlay":
				return 0xFA0 + num2;
			}
			return (!int.TryParse(queue, out num2)) ? 0x7D0 : num2;
		}

		// Token: 0x06002831 RID: 10289 RVA: 0x00099C90 File Offset: 0x00097E90
		public static bool Equals(string queue1, string queue2)
		{
			return global::ShaderMod.QueueCompare.ToInt32(queue1) == global::ShaderMod.QueueCompare.ToInt32(queue2);
		}

		// Token: 0x04001400 RID: 5120
		public const int kBackground = 0x3E8;

		// Token: 0x04001401 RID: 5121
		public const int kGeometry = 0x7D0;

		// Token: 0x04001402 RID: 5122
		public const int kAlphaTest = 0x992;

		// Token: 0x04001403 RID: 5123
		public const int kTransparent = 0xBB8;

		// Token: 0x04001404 RID: 5124
		public const int kOverlay = 0xFA0;

		// Token: 0x04001405 RID: 5125
		public const int kDefault = 0x7D0;

		// Token: 0x04001406 RID: 5126
		private static readonly char[] signChars = new char[]
		{
			'-',
			'+'
		};

		// Token: 0x04001407 RID: 5127
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Collections.Generic.Dictionary<string, int> <>f__switch$map7;
	}

	// Token: 0x0200047F RID: 1151
	[global::System.Serializable]
	public class DICT
	{
		// Token: 0x06002832 RID: 10290 RVA: 0x00099CA0 File Offset: 0x00097EA0
		public DICT()
		{
		}

		// Token: 0x170008E6 RID: 2278
		public string this[string key]
		{
			get
			{
				foreach (global::ShaderMod.KV kv in this.keyValues)
				{
					if (kv.key == key)
					{
						return kv.value;
					}
				}
				return null;
			}
			set
			{
				int num = -1;
				while (++num < this.keyValues.Length)
				{
					if (this.keyValues[num].key == key)
					{
						if (value == null)
						{
							this.keyValues[num] = this.keyValues[this.keyValues.Length - 1];
							global::System.Array.Resize<global::ShaderMod.KV>(ref this.keyValues, this.keyValues.Length - 1);
						}
						else
						{
							this.keyValues[num].value = value;
						}
					}
				}
				if (key == null)
				{
					throw new global::System.ArgumentNullException("key");
				}
				global::System.Array.Resize<global::ShaderMod.KV>(ref this.keyValues, this.keyValues.Length + 1);
				this.keyValues[this.keyValues.Length - 1] = new global::ShaderMod.KV(key, value);
			}
		}

		// Token: 0x06002835 RID: 10293 RVA: 0x00099DC0 File Offset: 0x00097FC0
		public bool Replace(global::ShaderMod.Replacement replacement, string incoming, ref string outgoing)
		{
			if (this.keyValues != null)
			{
				if (replacement != global::ShaderMod.Replacement.Queue)
				{
					for (int i = 0; i < this.keyValues.Length; i++)
					{
						if (string.Equals(this.keyValues[i].key, incoming, global::System.StringComparison.InvariantCultureIgnoreCase))
						{
							outgoing = this.keyValues[i].value;
							return true;
						}
					}
				}
				else
				{
					for (int j = 0; j < this.keyValues.Length; j++)
					{
						if (global::ShaderMod.QueueCompare.Equals(this.keyValues[j].key, incoming))
						{
							outgoing = this.keyValues[j].value;
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x04001408 RID: 5128
		public global::ShaderMod.KV[] keyValues;
	}

	// Token: 0x02000480 RID: 1152
	public enum Replacement
	{
		// Token: 0x0400140A RID: 5130
		Include,
		// Token: 0x0400140B RID: 5131
		Queue,
		// Token: 0x0400140C RID: 5132
		Define
	}
}
