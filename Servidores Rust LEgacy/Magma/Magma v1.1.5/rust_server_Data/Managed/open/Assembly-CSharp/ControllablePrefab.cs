using System;
using System.Collections.Generic;
using Facepunch;
using uLink;

// Token: 0x0200015C RID: 348
public class ControllablePrefab : global::CharacterPrefab
{
	// Token: 0x0600097A RID: 2426 RVA: 0x00027CF4 File Offset: 0x00025EF4
	public ControllablePrefab() : this(typeof(global::Character), false, global::ControllablePrefab.minimalRequiredIDLocals, false)
	{
	}

	// Token: 0x0600097B RID: 2427 RVA: 0x00027D10 File Offset: 0x00025F10
	protected ControllablePrefab(global::System.Type characterType, params global::System.Type[] idlocalRequired) : this(characterType, true, idlocalRequired, idlocalRequired != null && idlocalRequired.Length > 0)
	{
	}

	// Token: 0x0600097C RID: 2428 RVA: 0x00027D2C File Offset: 0x00025F2C
	protected ControllablePrefab(global::System.Type characterType) : this(characterType, true, null, false)
	{
	}

	// Token: 0x0600097D RID: 2429 RVA: 0x00027D38 File Offset: 0x00025F38
	private ControllablePrefab(global::System.Type characterType, bool typeCheck, global::System.Type[] requiredIDLocalTypes, bool mergeTypes) : base(characterType, (!mergeTypes) ? global::ControllablePrefab.minimalRequiredIDLocals : global::CharacterPrefab.TypeArrayAppend(global::ControllablePrefab.minimalRequiredIDLocals, requiredIDLocalTypes))
	{
	}

	// Token: 0x0600097E RID: 2430 RVA: 0x00027D60 File Offset: 0x00025F60
	// Note: this type is marked as 'beforefieldinit'.
	static ControllablePrefab()
	{
	}

	// Token: 0x0600097F RID: 2431 RVA: 0x00027DA4 File Offset: 0x00025FA4
	protected override void StandardInitialization(bool didAppend, global::IDRemote appended, global::NetInstance instance, global::Facepunch.NetworkView view, ref global::uLink.NetworkMessageInfo info)
	{
		global::Character character = (global::Character)instance.idMain;
		global::Controllable controllable = character.controllable;
		controllable.PrepareInstantiate(view, ref info);
		base.StandardInitialization(false, appended, instance, view, ref info);
		if (didAppend)
		{
			global::NetMainPrefab.IssueLocallyAppended(appended, instance.idMain);
		}
		controllable.OnInstantiated();
	}

	// Token: 0x1700022E RID: 558
	// (get) Token: 0x06000980 RID: 2432 RVA: 0x00027DF4 File Offset: 0x00025FF4
	private bool playerRootComapatable
	{
		get
		{
			global::Controllable controllable = ((global::Character)base.serverPrefab).controllable;
			if (!controllable)
			{
				return false;
			}
			if (!controllable.classFlagsRootControllable)
			{
				return false;
			}
			if (!controllable.classFlagsPlayerSupport)
			{
				return false;
			}
			controllable = ((global::Character)base.proxyPrefab).controllable;
			return controllable && controllable.classFlagsRootControllable && controllable.classFlagsPlayerSupport;
		}
	}

	// Token: 0x1700022F RID: 559
	// (get) Token: 0x06000981 RID: 2433 RVA: 0x00027E74 File Offset: 0x00026074
	private bool aiRootComapatable
	{
		get
		{
			global::Controllable controllable = ((global::Character)base.serverPrefab).controllable;
			if (!controllable)
			{
				return false;
			}
			if (!controllable.classFlagsRootControllable)
			{
				return false;
			}
			if (!controllable.classFlagsAISupport)
			{
				return false;
			}
			controllable = ((global::Character)base.proxyPrefab).controllable;
			return controllable && controllable.classFlagsRootControllable && controllable.classFlagsAISupport;
		}
	}

	// Token: 0x17000230 RID: 560
	// (get) Token: 0x06000982 RID: 2434 RVA: 0x00027EF4 File Offset: 0x000260F4
	private global::ControllerClass.Merge mergedClasses
	{
		get
		{
			global::ControllerClass.Merge result = default(global::ControllerClass.Merge);
			global::Controllable.MergeClasses(base.serverPrefab, ref result);
			global::Controllable.MergeClasses(base.proxyPrefab, ref result);
			global::Controllable.MergeClasses(base.localPrefab, ref result);
			return result;
		}
	}

	// Token: 0x17000231 RID: 561
	// (get) Token: 0x06000983 RID: 2435 RVA: 0x00027F38 File Offset: 0x00026138
	private byte vesselCompatibility
	{
		get
		{
			global::ControllerClass.Merge mergedClasses = this.mergedClasses;
			if (!mergedClasses.any)
			{
				return 0;
			}
			if (!mergedClasses.vessel)
			{
				return 0x40;
			}
			byte b;
			if (mergedClasses.vesselFree)
			{
				b = 7;
			}
			else if (mergedClasses.vesselDependant)
			{
				b = 5;
			}
			else
			{
				if (!mergedClasses.vesselStandalone)
				{
					throw new global::System.NotImplementedException();
				}
				b = 3;
			}
			if (mergedClasses[true])
			{
				b |= 8;
			}
			if (mergedClasses[false])
			{
				b |= 0x10;
			}
			if (mergedClasses.staticGroup)
			{
				b |= 0x20;
			}
			return b;
		}
	}

	// Token: 0x06000984 RID: 2436 RVA: 0x00027FE0 File Offset: 0x000261E0
	public static void EnsurePrefabIsPlayerRootCompatible(string name)
	{
		global::NetMainPrefab.EnsurePrefabName(name);
		byte b;
		if (!global::ControllablePrefab.playerRootCompatibilityCache.TryGetValue(name, out b))
		{
			global::ControllablePrefab controllablePrefab = global::NetMainPrefab.Lookup<global::ControllablePrefab>(name);
			if (!controllablePrefab)
			{
				b = 0;
			}
			else if (!controllablePrefab.playerRootComapatable)
			{
				b = 2;
			}
			else
			{
				b = 1;
			}
			global::ControllablePrefab.playerRootCompatibilityCache[name] = b;
		}
		if (b == 0)
		{
			throw new global::NonControllableException(name);
		}
		if (b == 2)
		{
			throw new global::NonPlayerRootControllableException(name);
		}
	}

	// Token: 0x06000985 RID: 2437 RVA: 0x0002805C File Offset: 0x0002625C
	private static byte GetVesselCompatibility(string name)
	{
		global::NetMainPrefab.EnsurePrefabName(name);
		byte b;
		if (global::ControllablePrefab.vesselCompatibilityCache.TryGetValue(name, out b))
		{
			return b;
		}
		global::ControllablePrefab controllablePrefab = global::NetMainPrefab.Lookup<global::ControllablePrefab>(name);
		if (!controllablePrefab)
		{
			b = 0;
		}
		else
		{
			b = controllablePrefab.vesselCompatibility;
		}
		global::ControllablePrefab.vesselCompatibilityCache[name] = b;
		return b;
	}

	// Token: 0x06000986 RID: 2438 RVA: 0x000280B0 File Offset: 0x000262B0
	public static void EnsurePrefabIsVessel(string name, out global::ControllablePrefab.VesselInfo vi)
	{
		byte vesselCompatibility = global::ControllablePrefab.GetVesselCompatibility(name);
		if ((vesselCompatibility & 1) != 1)
		{
			if ((vesselCompatibility & 0x40) == 0x40)
			{
				throw new global::NonVesselControllableException(name);
			}
			throw new global::NonControllableException(name);
		}
		else
		{
			if ((vesselCompatibility & 0x18) == 0)
			{
				throw new global::NonControllableException("The vessel has not been marked for either ai and/or player control. not bothering to spawn it.");
			}
			vi = new global::ControllablePrefab.VesselInfo(vesselCompatibility);
			return;
		}
	}

	// Token: 0x06000987 RID: 2439 RVA: 0x00028104 File Offset: 0x00026304
	public static void EnsurePrefabIsVessel(string name, global::Controllable forControllable, out global::ControllablePrefab.VesselInfo vi)
	{
		global::ControllablePrefab.EnsurePrefabIsVessel(name, out vi);
		if (forControllable && forControllable.controlled)
		{
			if (forControllable.aiControlled)
			{
				if (!vi.supportsAI)
				{
					throw new global::NonAIVesselControllableException(name);
				}
			}
			else if (forControllable.playerControlled && !vi.supportsPlayer)
			{
				throw new global::NonPlayerVesselControllableException(name);
			}
		}
	}

	// Token: 0x06000988 RID: 2440 RVA: 0x00028170 File Offset: 0x00026370
	public static void EnsurePrefabIsAIRootCompatible(string name, out bool staticGroup)
	{
		global::NetMainPrefab.EnsurePrefabName(name);
		sbyte b;
		if (!global::ControllablePrefab.aiRootCompatibilityCache.TryGetValue(name, out b))
		{
			global::ControllablePrefab controllablePrefab = global::NetMainPrefab.Lookup<global::ControllablePrefab>(name);
			if (!controllablePrefab)
			{
				b = 0;
			}
			else if (!controllablePrefab.aiRootComapatable)
			{
				b = 2;
			}
			else
			{
				b = ((!((global::Character)controllablePrefab.serverPrefab).controllable.classFlagsStaticGroup) ? 1 : -1);
			}
			global::ControllablePrefab.aiRootCompatibilityCache[name] = b;
		}
		sbyte b2 = b;
		switch (b2 + 1)
		{
		case 0:
			staticGroup = true;
			return;
		case 2:
			staticGroup = false;
			return;
		case 3:
			throw new global::NonAIRootControllableException(name);
		}
		throw new global::NonControllableException(name);
	}

	// Token: 0x040006E7 RID: 1767
	private const byte kVesselFlag_Vessel = 1;

	// Token: 0x040006E8 RID: 1768
	private const byte kVesselFlag_Vessel_Standalone = 3;

	// Token: 0x040006E9 RID: 1769
	private const byte kVesselFlag_Vessel_Dependant = 5;

	// Token: 0x040006EA RID: 1770
	private const byte kVesselFlag_Vessel_Free = 7;

	// Token: 0x040006EB RID: 1771
	private const byte kVesselFlag_PlayerCanControl = 8;

	// Token: 0x040006EC RID: 1772
	private const byte kVesselFlag_AICanControl = 0x10;

	// Token: 0x040006ED RID: 1773
	private const byte kVesselFlag_StaticGroup = 0x20;

	// Token: 0x040006EE RID: 1774
	private const byte kVesselFlag_Missing = 0x40;

	// Token: 0x040006EF RID: 1775
	private const byte kVesselKindMask = 7;

	// Token: 0x040006F0 RID: 1776
	private static readonly global::System.Type[] minimalRequiredIDLocals = new global::System.Type[]
	{
		typeof(global::Controllable)
	};

	// Token: 0x040006F1 RID: 1777
	private static global::System.Collections.Generic.Dictionary<string, byte> playerRootCompatibilityCache = new global::System.Collections.Generic.Dictionary<string, byte>();

	// Token: 0x040006F2 RID: 1778
	private static global::System.Collections.Generic.Dictionary<string, sbyte> aiRootCompatibilityCache = new global::System.Collections.Generic.Dictionary<string, sbyte>();

	// Token: 0x040006F3 RID: 1779
	private static global::System.Collections.Generic.Dictionary<string, byte> vesselCompatibilityCache = new global::System.Collections.Generic.Dictionary<string, byte>();

	// Token: 0x0200015D RID: 349
	public struct VesselInfo
	{
		// Token: 0x06000989 RID: 2441 RVA: 0x0002822C File Offset: 0x0002642C
		internal VesselInfo(byte data)
		{
			this.data = data;
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x0600098A RID: 2442 RVA: 0x00028238 File Offset: 0x00026438
		public bool staticGroup
		{
			get
			{
				return (this.data & 0x20) == 0x20;
			}
		}

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x0600098B RID: 2443 RVA: 0x00028248 File Offset: 0x00026448
		public bool supportsAI
		{
			get
			{
				return (this.data & 0x10) == 0x10;
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x0600098C RID: 2444 RVA: 0x00028258 File Offset: 0x00026458
		public bool supportsPlayer
		{
			get
			{
				return (this.data & 8) == 8;
			}
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x0600098D RID: 2445 RVA: 0x00028268 File Offset: 0x00026468
		public bool canBind
		{
			get
			{
				switch (this.data & 7)
				{
				case 0:
					return false;
				case 3:
					return false;
				case 5:
					return true;
				case 7:
					return true;
				}
				throw new global::System.NotImplementedException();
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x0600098E RID: 2446 RVA: 0x000282B8 File Offset: 0x000264B8
		public bool mustBind
		{
			get
			{
				switch (this.data & 7)
				{
				case 0:
					return false;
				case 3:
					return false;
				case 5:
					return true;
				case 7:
					return false;
				}
				throw new global::System.NotImplementedException();
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x0600098F RID: 2447 RVA: 0x00028308 File Offset: 0x00026508
		public bool bindless
		{
			get
			{
				switch (this.data & 7)
				{
				case 0:
					return false;
				case 3:
					return true;
				case 5:
					return false;
				case 7:
					return true;
				}
				throw new global::System.NotImplementedException();
			}
		}

		// Token: 0x040006F4 RID: 1780
		private byte data;
	}
}
