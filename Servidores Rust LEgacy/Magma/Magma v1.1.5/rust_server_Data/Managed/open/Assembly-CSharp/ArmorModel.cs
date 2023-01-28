using System;
using Facepunch.Actor;
using UnityEngine;

// Token: 0x0200061D RID: 1565
public abstract class ArmorModel : global::UnityEngine.ScriptableObject
{
	// Token: 0x060031BD RID: 12733 RVA: 0x000BF0A0 File Offset: 0x000BD2A0
	internal ArmorModel(global::ArmorModelSlot slot)
	{
		this.slot = slot;
	}

	// Token: 0x17000A57 RID: 2647
	// (get) Token: 0x060031BE RID: 12734 RVA: 0x000BF0B0 File Offset: 0x000BD2B0
	public global::ArmorModel censoredModel
	{
		get
		{
			return this._censored;
		}
	}

	// Token: 0x17000A58 RID: 2648
	// (get) Token: 0x060031BF RID: 12735
	protected abstract global::ArmorModel _censored { get; }

	// Token: 0x17000A59 RID: 2649
	// (get) Token: 0x060031C0 RID: 12736 RVA: 0x000BF0B8 File Offset: 0x000BD2B8
	public bool hasCensoredModel
	{
		get
		{
			return this._censored;
		}
	}

	// Token: 0x17000A5A RID: 2650
	// (get) Token: 0x060031C1 RID: 12737 RVA: 0x000BF0C8 File Offset: 0x000BD2C8
	public global::ArmorModelSlotMask slotMask
	{
		get
		{
			return this.slot.ToMask();
		}
	}

	// Token: 0x17000A5B RID: 2651
	// (get) Token: 0x060031C2 RID: 12738 RVA: 0x000BF0D8 File Offset: 0x000BD2D8
	public global::UnityEngine.Mesh sharedMesh
	{
		get
		{
			return (!this._actorMeshInfo) ? null : this._actorMeshInfo.sharedMesh;
		}
	}

	// Token: 0x17000A5C RID: 2652
	// (get) Token: 0x060031C3 RID: 12739 RVA: 0x000BF0FC File Offset: 0x000BD2FC
	public global::Facepunch.Actor.ActorMeshInfo actorMeshInfo
	{
		get
		{
			return this._actorMeshInfo;
		}
	}

	// Token: 0x17000A5D RID: 2653
	// (get) Token: 0x060031C4 RID: 12740 RVA: 0x000BF104 File Offset: 0x000BD304
	public global::Facepunch.Actor.ActorRig actorRig
	{
		get
		{
			return (!this._actorMeshInfo) ? null : this._actorMeshInfo.actorRig;
		}
	}

	// Token: 0x17000A5E RID: 2654
	// (get) Token: 0x060031C5 RID: 12741 RVA: 0x000BF128 File Offset: 0x000BD328
	public global::UnityEngine.Material[] sharedMaterials
	{
		get
		{
			return this._materials;
		}
	}

	// Token: 0x04001BD2 RID: 7122
	[global::System.NonSerialized]
	public readonly global::ArmorModelSlot slot;

	// Token: 0x04001BD3 RID: 7123
	[global::UnityEngine.SerializeField]
	private global::Facepunch.Actor.ActorMeshInfo _actorMeshInfo;

	// Token: 0x04001BD4 RID: 7124
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Material[] _materials;
}
