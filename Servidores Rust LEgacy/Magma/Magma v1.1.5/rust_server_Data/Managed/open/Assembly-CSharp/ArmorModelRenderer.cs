using System;
using Facepunch.Actor;
using UnityEngine;

// Token: 0x0200062B RID: 1579
public sealed class ArmorModelRenderer : global::IDLocalCharacter
{
	// Token: 0x06003226 RID: 12838 RVA: 0x000BFF10 File Offset: 0x000BE110
	public ArmorModelRenderer()
	{
	}

	// Token: 0x06003227 RID: 12839 RVA: 0x000BFF18 File Offset: 0x000BE118
	// Note: this type is marked as 'beforefieldinit'.
	static ArmorModelRenderer()
	{
	}

	// Token: 0x17000A74 RID: 2676
	// (get) Token: 0x06003228 RID: 12840 RVA: 0x000BFF20 File Offset: 0x000BE120
	public global::ArmorModelGroup defaultArmorModelGroup
	{
		get
		{
			return ((!this.armorTrait) ? (this.armorTrait = base.GetTrait<global::CharacterArmorTrait>()) : this.armorTrait).defaultGroup;
		}
	}

	// Token: 0x06003229 RID: 12841 RVA: 0x000BFF5C File Offset: 0x000BE15C
	private void Awake()
	{
		if (this.originalRenderer)
		{
			this.originalRenderer.enabled = false;
		}
	}

	// Token: 0x17000A75 RID: 2677
	// (get) Token: 0x0600322A RID: 12842 RVA: 0x000BFF7C File Offset: 0x000BE17C
	public global::Facepunch.Actor.ActorRig actorRig
	{
		get
		{
			return this.boneStructure.actorRig;
		}
	}

	// Token: 0x17000A76 RID: 2678
	public global::ArmorModel this[global::ArmorModelSlot slot]
	{
		get
		{
			if (this.awake)
			{
				return this.models[slot];
			}
			global::ArmorModelGroup defaultArmorModelGroup = this.defaultArmorModelGroup;
			if (defaultArmorModelGroup)
			{
				return defaultArmorModelGroup[slot];
			}
			return null;
		}
	}

	// Token: 0x0600322C RID: 12844 RVA: 0x000BFFCC File Offset: 0x000BE1CC
	public global::ArmorModelMemberMap GetArmorModelMemberMapCopy()
	{
		if (this.awake)
		{
			return this.models;
		}
		global::ArmorModelGroup defaultArmorModelGroup = this.defaultArmorModelGroup;
		if (!defaultArmorModelGroup)
		{
			return default(global::ArmorModelMemberMap);
		}
		return defaultArmorModelGroup.armorModelMemberMap;
	}

	// Token: 0x0600322D RID: 12845 RVA: 0x000C0010 File Offset: 0x000BE210
	private bool BindArmorModel<TArmorModel>(TArmorModel model) where TArmorModel : global::ArmorModel, new()
	{
		if (model)
		{
			return this.BindArmorModelCheckedNonNull(model);
		}
		global::ArmorModel armorModel = this.defaultArmorModelGroup[global::ArmorModelSlotUtility.GetArmorModelSlotForClass<TArmorModel>()];
		return armorModel && this.BindArmorModelCheckedNonNull(armorModel);
	}

	// Token: 0x0600322E RID: 12846 RVA: 0x000C0060 File Offset: 0x000BE260
	private bool BindArmorModel(global::ArmorModel model, global::ArmorModelSlot slot)
	{
		if (!model)
		{
			global::ArmorModel armorModel = this.defaultArmorModelGroup[slot];
			return armorModel && this.BindArmorModelCheckedNonNull(armorModel);
		}
		if (model.slot != slot)
		{
			global::UnityEngine.Debug.LogError("model.slot != " + slot, model);
			return false;
		}
		return this.BindArmorModelCheckedNonNull(model);
	}

	// Token: 0x0600322F RID: 12847 RVA: 0x000C00C8 File Offset: 0x000BE2C8
	public global::ArmorModelSlotMask BindArmorModels(global::ArmorModelMemberMap map)
	{
		if (!this.awake)
		{
			return this.Initialize(map, global::ArmorModelSlotMask.Feet | global::ArmorModelSlotMask.Legs | global::ArmorModelSlotMask.Torso | global::ArmorModelSlotMask.Head);
		}
		global::ArmorModelSlotMask armorModelSlotMask = (global::ArmorModelSlotMask)0;
		for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
		{
			if (this.BindArmorModel(map[armorModelSlot], armorModelSlot))
			{
				armorModelSlotMask |= armorModelSlot.ToMask();
			}
		}
		return armorModelSlotMask;
	}

	// Token: 0x06003230 RID: 12848 RVA: 0x000C011C File Offset: 0x000BE31C
	public global::ArmorModelSlotMask BindArmorModels(global::ArmorModelMemberMap map, global::ArmorModelSlotMask slotMask)
	{
		if (!this.awake)
		{
			return this.Initialize(map, slotMask);
		}
		global::ArmorModelSlotMask armorModelSlotMask = (global::ArmorModelSlotMask)0;
		foreach (global::ArmorModelSlot slot in slotMask.EnumerateSlots())
		{
			if (this.BindArmorModel(map[slot], slot))
			{
				armorModelSlotMask |= slot.ToMask();
			}
		}
		return armorModelSlotMask;
	}

	// Token: 0x06003231 RID: 12849 RVA: 0x000C017C File Offset: 0x000BE37C
	public global::ArmorModelSlotMask BindArmorGroup(global::ArmorModelGroup group, global::ArmorModelSlotMask slotMask)
	{
		if (this.awake)
		{
			global::ArmorModelSlotMask armorModelSlotMask = (global::ArmorModelSlotMask)0;
			foreach (global::ArmorModelSlot slot in slotMask.EnumerateSlots())
			{
				global::ArmorModel armorModel = group[slot];
				if (armorModel && this.BindArmorModelCheckedNonNull(armorModel))
				{
					armorModelSlotMask |= slot.ToMask();
				}
			}
			return armorModelSlotMask;
		}
		if (!group)
		{
			return (global::ArmorModelSlotMask)0;
		}
		return this.Initialize(group.armorModelMemberMap, slotMask);
	}

	// Token: 0x06003232 RID: 12850 RVA: 0x000C01FC File Offset: 0x000BE3FC
	public global::ArmorModelSlotMask BindArmorGroup(global::ArmorModelGroup group)
	{
		global::ArmorModelSlotMask armorModelSlotMask = (global::ArmorModelSlotMask)0;
		if (group)
		{
			for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
			{
				global::ArmorModel armorModel = group[armorModelSlot];
				if (armorModel && this.BindArmorModelCheckedNonNull(armorModel))
				{
					armorModelSlotMask |= armorModelSlot.ToMask();
				}
			}
		}
		return armorModelSlotMask;
	}

	// Token: 0x06003233 RID: 12851 RVA: 0x000C0254 File Offset: 0x000BE454
	public global::ArmorModelSlotMask BindDefaultArmorGroup()
	{
		global::ArmorModelGroup defaultArmorModelGroup = this.defaultArmorModelGroup;
		if (defaultArmorModelGroup)
		{
			return this.BindArmorGroup(this.defaultArmorModelGroup);
		}
		return (global::ArmorModelSlotMask)0;
	}

	// Token: 0x06003234 RID: 12852 RVA: 0x000C0284 File Offset: 0x000BE484
	public bool Contains(global::ArmorModel model)
	{
		if (!model)
		{
			return false;
		}
		if (!this.awake)
		{
			global::ArmorModelGroup defaultArmorModelGroup = this.defaultArmorModelGroup;
			return defaultArmorModelGroup && defaultArmorModelGroup[model.slot] == model;
		}
		return this.models[model.slot] == model;
	}

	// Token: 0x06003235 RID: 12853 RVA: 0x000C02E8 File Offset: 0x000BE4E8
	public bool Contains<TArmorModel>(TArmorModel model) where TArmorModel : global::ArmorModel, new()
	{
		if (!model)
		{
			return false;
		}
		if (!this.awake)
		{
			global::ArmorModelGroup defaultArmorModelGroup = this.defaultArmorModelGroup;
			return defaultArmorModelGroup && defaultArmorModelGroup.GetArmorModel<TArmorModel>() == model;
		}
		return this.models.GetArmorModel<TArmorModel>() == model;
	}

	// Token: 0x06003236 RID: 12854 RVA: 0x000C035C File Offset: 0x000BE55C
	public T GetArmorModel<T>() where T : global::ArmorModel, new()
	{
		if (this.awake)
		{
			return this.models.GetArmorModel<T>();
		}
		global::ArmorModelGroup defaultArmorModelGroup = this.defaultArmorModelGroup;
		if (defaultArmorModelGroup)
		{
			return defaultArmorModelGroup.GetArmorModel<T>();
		}
		return (T)((object)null);
	}

	// Token: 0x06003237 RID: 12855 RVA: 0x000C03A0 File Offset: 0x000BE5A0
	private global::ArmorModelSlotMask Initialize(global::ArmorModelMemberMap memberMap, global::ArmorModelSlotMask memberMask)
	{
		this.awake = true;
		global::ArmorModelSlotMask armorModelSlotMask = (global::ArmorModelSlotMask)0;
		global::ArmorModelGroup defaultArmorModelGroup = this.defaultArmorModelGroup;
		if (defaultArmorModelGroup)
		{
			global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet;
			while (armorModelSlot < (global::ArmorModelSlot)4)
			{
				if (!memberMask.Contains(armorModelSlot))
				{
					goto IL_5C;
				}
				global::ArmorModel armorModel = memberMap.GetArmorModel(armorModelSlot);
				if (!armorModel || !this.BindArmorModelCheckedNonNull(armorModel))
				{
					goto IL_5C;
				}
				armorModelSlotMask |= armorModelSlot.ToMask();
				IL_7A:
				armorModelSlot += 1;
				continue;
				IL_5C:
				global::ArmorModel armorModel2 = defaultArmorModelGroup[armorModelSlot];
				if (armorModel2)
				{
					this.BindArmorModelCheckedNonNull(armorModel2);
					goto IL_7A;
				}
				goto IL_7A;
			}
		}
		else
		{
			foreach (global::ArmorModelSlot slot in memberMask.EnumerateSlots())
			{
				global::ArmorModel armorModel3 = memberMap.GetArmorModel(slot);
				if (armorModel3 && this.BindArmorModelCheckedNonNull(armorModel3))
				{
					armorModelSlotMask |= slot.ToMask();
				}
			}
		}
		return armorModelSlotMask;
	}

	// Token: 0x06003238 RID: 12856 RVA: 0x000C0490 File Offset: 0x000BE690
	private bool BindArmorModelCheckedNonNull(global::ArmorModel model)
	{
		global::ArmorModelSlot slot = model.slot;
		if (!global::ArmorModelRenderer.rebindingCensorship)
		{
			global::ArmorModel armorModel = this.models[slot];
			if (armorModel == model)
			{
				return false;
			}
		}
		this.models[slot] = model;
		return true;
	}

	// Token: 0x06003239 RID: 12857 RVA: 0x000C04D8 File Offset: 0x000BE6D8
	private void OnDestroy()
	{
		if (!this.awake)
		{
			this.awake = true;
		}
	}

	// Token: 0x0600323A RID: 12858 RVA: 0x000C04F4 File Offset: 0x000BE6F4
	private void Start()
	{
		if (!this.awake)
		{
			this.Initialize(default(global::ArmorModelMemberMap), (global::ArmorModelSlotMask)0);
		}
	}

	// Token: 0x17000A77 RID: 2679
	// (get) Token: 0x0600323B RID: 12859 RVA: 0x000C0520 File Offset: 0x000BE720
	// (set) Token: 0x0600323C RID: 12860 RVA: 0x000C0528 File Offset: 0x000BE728
	public static bool Censored
	{
		get
		{
			return global::ArmorModelRenderer.censored;
		}
		set
		{
			if (global::ArmorModelRenderer.censored != value)
			{
				global::ArmorModelRenderer.censored = value;
				try
				{
					global::ArmorModelRenderer.rebindingCensorship = true;
					foreach (global::UnityEngine.Object @object in global::UnityEngine.Object.FindObjectsOfType(typeof(global::ArmorModelRenderer)))
					{
						global::ArmorModelRenderer armorModelRenderer = (global::ArmorModelRenderer)@object;
						if (armorModelRenderer)
						{
							for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
							{
								global::ArmorModel armorModel = armorModelRenderer[armorModelSlot];
								if (armorModel && armorModel.hasCensoredModel)
								{
									if (!armorModelRenderer.awake)
									{
										armorModelRenderer.Initialize(default(global::ArmorModelMemberMap), (global::ArmorModelSlotMask)0);
										break;
									}
									armorModelRenderer.BindArmorModelCheckedNonNull(armorModel);
								}
							}
						}
					}
				}
				finally
				{
					global::ArmorModelRenderer.rebindingCensorship = false;
				}
			}
		}
	}

	// Token: 0x04001BEF RID: 7151
	[global::PrefetchComponent]
	[global::UnityEngine.SerializeField]
	private global::Facepunch.Actor.BoneStructure boneStructure;

	// Token: 0x04001BF0 RID: 7152
	[global::PrefetchChildComponent]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.SkinnedMeshRenderer originalRenderer;

	// Token: 0x04001BF1 RID: 7153
	[global::System.NonSerialized]
	private global::ArmorModelMemberMap models;

	// Token: 0x04001BF2 RID: 7154
	[global::System.NonSerialized]
	private bool awake;

	// Token: 0x04001BF3 RID: 7155
	[global::System.NonSerialized]
	private global::CharacterArmorTrait armorTrait;

	// Token: 0x04001BF4 RID: 7156
	private static bool censored = true;

	// Token: 0x04001BF5 RID: 7157
	private static bool rebindingCensorship;
}
