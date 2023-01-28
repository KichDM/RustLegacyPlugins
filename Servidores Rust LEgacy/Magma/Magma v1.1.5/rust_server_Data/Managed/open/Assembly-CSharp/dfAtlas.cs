using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020007D4 RID: 2004
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Texture Atlas")]
[global::UnityEngine.ExecuteInEditMode]
public class dfAtlas : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004238 RID: 16952 RVA: 0x000F0BCC File Offset: 0x000EEDCC
	public dfAtlas()
	{
	}

	// Token: 0x17000C29 RID: 3113
	// (get) Token: 0x06004239 RID: 16953 RVA: 0x000F0BEC File Offset: 0x000EEDEC
	public global::UnityEngine.Texture2D Texture
	{
		get
		{
			return (!(this.replacementAtlas != null)) ? (this.material.mainTexture as global::UnityEngine.Texture2D) : this.replacementAtlas.Texture;
		}
	}

	// Token: 0x17000C2A RID: 3114
	// (get) Token: 0x0600423A RID: 16954 RVA: 0x000F0C20 File Offset: 0x000EEE20
	public int Count
	{
		get
		{
			return (!(this.replacementAtlas != null)) ? this.items.Count : this.replacementAtlas.Count;
		}
	}

	// Token: 0x17000C2B RID: 3115
	// (get) Token: 0x0600423B RID: 16955 RVA: 0x000F0C5C File Offset: 0x000EEE5C
	public global::System.Collections.Generic.List<global::dfAtlas.ItemInfo> Items
	{
		get
		{
			return (!(this.replacementAtlas != null)) ? this.items : this.replacementAtlas.Items;
		}
	}

	// Token: 0x17000C2C RID: 3116
	// (get) Token: 0x0600423C RID: 16956 RVA: 0x000F0C88 File Offset: 0x000EEE88
	// (set) Token: 0x0600423D RID: 16957 RVA: 0x000F0CB4 File Offset: 0x000EEEB4
	public global::UnityEngine.Material Material
	{
		get
		{
			return (!(this.replacementAtlas != null)) ? this.material : this.replacementAtlas.Material;
		}
		set
		{
			if (this.replacementAtlas != null)
			{
				this.replacementAtlas.Material = value;
			}
			else
			{
				this.material = value;
			}
		}
	}

	// Token: 0x17000C2D RID: 3117
	// (get) Token: 0x0600423E RID: 16958 RVA: 0x000F0CE0 File Offset: 0x000EEEE0
	// (set) Token: 0x0600423F RID: 16959 RVA: 0x000F0CE8 File Offset: 0x000EEEE8
	public global::dfAtlas Replacement
	{
		get
		{
			return this.replacementAtlas;
		}
		set
		{
			this.replacementAtlas = value;
		}
	}

	// Token: 0x17000C2E RID: 3118
	public global::dfAtlas.ItemInfo this[string key]
	{
		get
		{
			if (this.replacementAtlas != null)
			{
				return this.replacementAtlas[key];
			}
			if (string.IsNullOrEmpty(key))
			{
				return null;
			}
			if (this.map.Count == 0)
			{
				this.RebuildIndexes();
			}
			global::dfAtlas.ItemInfo result = null;
			if (this.map.TryGetValue(key, out result))
			{
				return result;
			}
			return null;
		}
	}

	// Token: 0x06004241 RID: 16961 RVA: 0x000F0D5C File Offset: 0x000EEF5C
	internal static bool Equals(global::dfAtlas lhs, global::dfAtlas rhs)
	{
		return object.ReferenceEquals(lhs, rhs) || (!(lhs == null) && !(rhs == null) && lhs.material == rhs.material);
	}

	// Token: 0x06004242 RID: 16962 RVA: 0x000F0D98 File Offset: 0x000EEF98
	public void AddItem(global::dfAtlas.ItemInfo item)
	{
		this.items.Add(item);
		this.RebuildIndexes();
	}

	// Token: 0x06004243 RID: 16963 RVA: 0x000F0DAC File Offset: 0x000EEFAC
	public void AddItems(global::System.Collections.Generic.IEnumerable<global::dfAtlas.ItemInfo> items)
	{
		this.items.AddRange(items);
		this.RebuildIndexes();
	}

	// Token: 0x06004244 RID: 16964 RVA: 0x000F0DC0 File Offset: 0x000EEFC0
	public void Remove(string name)
	{
		for (int i = this.items.Count - 1; i >= 0; i--)
		{
			if (this.items[i].name == name)
			{
				this.items.RemoveAt(i);
			}
		}
		this.RebuildIndexes();
	}

	// Token: 0x06004245 RID: 16965 RVA: 0x000F0E1C File Offset: 0x000EF01C
	public void RebuildIndexes()
	{
		if (this.map == null)
		{
			this.map = new global::System.Collections.Generic.Dictionary<string, global::dfAtlas.ItemInfo>();
		}
		else
		{
			this.map.Clear();
		}
		for (int i = 0; i < this.items.Count; i++)
		{
			global::dfAtlas.ItemInfo itemInfo = this.items[i];
			this.map[itemInfo.name] = itemInfo;
		}
	}

	// Token: 0x04002369 RID: 9065
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Material material;

	// Token: 0x0400236A RID: 9066
	[global::UnityEngine.SerializeField]
	protected global::System.Collections.Generic.List<global::dfAtlas.ItemInfo> items = new global::System.Collections.Generic.List<global::dfAtlas.ItemInfo>();

	// Token: 0x0400236B RID: 9067
	private global::System.Collections.Generic.Dictionary<string, global::dfAtlas.ItemInfo> map = new global::System.Collections.Generic.Dictionary<string, global::dfAtlas.ItemInfo>();

	// Token: 0x0400236C RID: 9068
	private global::dfAtlas replacementAtlas;

	// Token: 0x020007D5 RID: 2005
	[global::System.Serializable]
	public class ItemInfo : global::System.IComparable<global::dfAtlas.ItemInfo>, global::System.IEquatable<global::dfAtlas.ItemInfo>
	{
		// Token: 0x06004246 RID: 16966 RVA: 0x000F0E8C File Offset: 0x000EF08C
		public ItemInfo()
		{
		}

		// Token: 0x06004247 RID: 16967 RVA: 0x000F0EB8 File Offset: 0x000EF0B8
		public int CompareTo(global::dfAtlas.ItemInfo other)
		{
			return this.name.CompareTo(other.name);
		}

		// Token: 0x06004248 RID: 16968 RVA: 0x000F0ECC File Offset: 0x000EF0CC
		public override int GetHashCode()
		{
			return this.name.GetHashCode();
		}

		// Token: 0x06004249 RID: 16969 RVA: 0x000F0EDC File Offset: 0x000EF0DC
		public override bool Equals(object obj)
		{
			return obj is global::dfAtlas.ItemInfo && this.name.Equals(((global::dfAtlas.ItemInfo)obj).name);
		}

		// Token: 0x0600424A RID: 16970 RVA: 0x000F0F04 File Offset: 0x000EF104
		public bool Equals(global::dfAtlas.ItemInfo other)
		{
			return this.name.Equals(other.name);
		}

		// Token: 0x0600424B RID: 16971 RVA: 0x000F0F18 File Offset: 0x000EF118
		public static bool operator ==(global::dfAtlas.ItemInfo lhs, global::dfAtlas.ItemInfo rhs)
		{
			return object.ReferenceEquals(lhs, rhs) || (lhs != null && rhs != null && lhs.name.Equals(rhs.name));
		}

		// Token: 0x0600424C RID: 16972 RVA: 0x000F0F48 File Offset: 0x000EF148
		public static bool operator !=(global::dfAtlas.ItemInfo lhs, global::dfAtlas.ItemInfo rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x0400236D RID: 9069
		public string name;

		// Token: 0x0400236E RID: 9070
		public global::UnityEngine.Rect region;

		// Token: 0x0400236F RID: 9071
		public global::UnityEngine.RectOffset border = new global::UnityEngine.RectOffset();

		// Token: 0x04002370 RID: 9072
		public bool rotated;

		// Token: 0x04002371 RID: 9073
		public global::UnityEngine.Vector2 sizeInPixels = global::UnityEngine.Vector2.zero;

		// Token: 0x04002372 RID: 9074
		[global::UnityEngine.SerializeField]
		public string textureGUID = string.Empty;

		// Token: 0x04002373 RID: 9075
		public bool deleted;

		// Token: 0x04002374 RID: 9076
		[global::UnityEngine.SerializeField]
		public global::UnityEngine.Texture2D texture;
	}
}
