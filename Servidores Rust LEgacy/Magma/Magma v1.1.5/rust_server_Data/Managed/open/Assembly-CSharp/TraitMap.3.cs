using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000221 RID: 545
public abstract class TraitMap<Key, Implementation> : global::TraitMap<Key> where Key : global::TraitKey where Implementation : global::TraitMap<Key, Implementation>
{
	// Token: 0x06000EAE RID: 3758 RVA: 0x0003804C File Offset: 0x0003624C
	protected TraitMap()
	{
	}

	// Token: 0x1700037D RID: 893
	// (get) Token: 0x06000EAF RID: 3759 RVA: 0x00038054 File Offset: 0x00036254
	internal sealed override global::TraitMap<Key> __baseMap
	{
		get
		{
			return this.B;
		}
	}

	// Token: 0x1700037E RID: 894
	// (get) Token: 0x06000EB0 RID: 3760 RVA: 0x00038064 File Offset: 0x00036264
	public static bool AnyRegistered
	{
		get
		{
			return global::TraitMap<Key, Implementation>.anyRegistry;
		}
	}

	// Token: 0x1700037F RID: 895
	// (get) Token: 0x06000EB1 RID: 3761 RVA: 0x0003806C File Offset: 0x0003626C
	public static global::System.Collections.Generic.ICollection<Implementation> AllRegistered
	{
		get
		{
			if (!global::TraitMap<Key, Implementation>.anyRegistry)
			{
				return new Implementation[0];
			}
			return global::TraitMap<Key, Implementation>.LookupRegister.dict.Values;
		}
	}

	// Token: 0x06000EB2 RID: 3762 RVA: 0x0003808C File Offset: 0x0003628C
	public static bool ByName(string name, out Implementation map)
	{
		if (!global::TraitMap<Key, Implementation>.anyRegistry)
		{
			map = (Implementation)((object)null);
			return false;
		}
		return global::TraitMap<Key, Implementation>.LookupRegister.dict.TryGetValue(name, out map);
	}

	// Token: 0x06000EB3 RID: 3763 RVA: 0x000380C0 File Offset: 0x000362C0
	public static Implementation ByName(string name)
	{
		Implementation implementation;
		return (!global::TraitMap<Key, Implementation>.anyRegistry || !global::TraitMap<Key, Implementation>.LookupRegister.dict.TryGetValue(name, out implementation)) ? ((Implementation)((object)null)) : implementation;
	}

	// Token: 0x06000EB4 RID: 3764 RVA: 0x000380F8 File Offset: 0x000362F8
	internal sealed override void BindToRegistry()
	{
		global::TraitMap<Key, Implementation>.LookupRegister.Add((Implementation)((object)this));
	}

	// Token: 0x04000957 RID: 2391
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private Implementation B;

	// Token: 0x04000958 RID: 2392
	private static bool anyRegistry;

	// Token: 0x02000222 RID: 546
	private static class LookupRegister
	{
		// Token: 0x06000EB5 RID: 3765 RVA: 0x00038108 File Offset: 0x00036308
		static LookupRegister()
		{
			global::TraitMap<Key, Implementation>.anyRegistry = true;
		}

		// Token: 0x06000EB6 RID: 3766 RVA: 0x00038120 File Offset: 0x00036320
		public static void Add(Implementation implementation)
		{
			global::TraitMap<Key, Implementation>.LookupRegister.dict[implementation.name] = implementation;
		}

		// Token: 0x04000959 RID: 2393
		public static readonly global::System.Collections.Generic.Dictionary<string, Implementation> dict = new global::System.Collections.Generic.Dictionary<string, Implementation>(global::System.StringComparer.InvariantCultureIgnoreCase);
	}
}
