using System;
using UnityEngine;

// Token: 0x02000714 RID: 1812
public class LaserModRep : global::WeaponModRep
{
	// Token: 0x06003D8B RID: 15755 RVA: 0x000D7D10 File Offset: 0x000D5F10
	protected LaserModRep(global::ItemModRepresentation.Caps caps, bool defaultOn) : base(caps, defaultOn)
	{
	}

	// Token: 0x06003D8C RID: 15756 RVA: 0x000D7D1C File Offset: 0x000D5F1C
	public LaserModRep() : this(global::ItemModRepresentation.Caps.BindStateFlags, false)
	{
	}

	// Token: 0x06003D8D RID: 15757 RVA: 0x000D7D28 File Offset: 0x000D5F28
	protected LaserModRep(global::ItemModRepresentation.Caps caps) : this(caps, false)
	{
	}

	// Token: 0x06003D8E RID: 15758 RVA: 0x000D7D34 File Offset: 0x000D5F34
	// Note: this type is marked as 'beforefieldinit'.
	static LaserModRep()
	{
	}

	// Token: 0x06003D8F RID: 15759 RVA: 0x000D7D3C File Offset: 0x000D5F3C
	public override void SetAttached(global::UnityEngine.GameObject attached, bool vm)
	{
		this.is_vm = vm;
		base.SetAttached(attached, vm);
	}

	// Token: 0x06003D90 RID: 15760 RVA: 0x000D7D50 File Offset: 0x000D5F50
	protected override bool VerifyCompatible(global::UnityEngine.GameObject attachment)
	{
		return attachment.GetComponentInChildren<global::LaserBeam>();
	}

	// Token: 0x06003D91 RID: 15761 RVA: 0x000D7D60 File Offset: 0x000D5F60
	protected override void OnAddAttached()
	{
		this.beams = base.attached.GetComponentsInChildren<global::LaserBeam>();
	}

	// Token: 0x06003D92 RID: 15762 RVA: 0x000D7D74 File Offset: 0x000D5F74
	protected override void OnRemoveAttached()
	{
		this.beams = null;
	}

	// Token: 0x06003D93 RID: 15763 RVA: 0x000D7D80 File Offset: 0x000D5F80
	protected override void EnableMod(global::ItemModRepresentation.Reason reason)
	{
	}

	// Token: 0x06003D94 RID: 15764 RVA: 0x000D7D84 File Offset: 0x000D5F84
	protected override void DisableMod(global::ItemModRepresentation.Reason reason)
	{
	}

	// Token: 0x06003D95 RID: 15765 RVA: 0x000D7D88 File Offset: 0x000D5F88
	protected override void BindStateFlags(global::CharacterStateFlags flags, global::ItemModRepresentation.Reason reason)
	{
		base.BindStateFlags(flags, reason);
		base.SetOn(flags.laser, reason);
	}

	// Token: 0x06003D96 RID: 15766 RVA: 0x000D7DA0 File Offset: 0x000D5FA0
	private void PlaySound(global::LaserBeam anyBeam, global::UnityEngine.AudioClip clip)
	{
		if (anyBeam)
		{
			clip.PlayLocal(anyBeam.transform, global::UnityEngine.Vector3.zero, 1f, 0, 1f, 4f);
		}
		else
		{
			clip.PlayLocal(base.itemRep.transform, global::UnityEngine.Vector3.zero, 1f, 0, 1f, 4f);
		}
	}

	// Token: 0x04001F01 RID: 7937
	private const float kVolume = 1f;

	// Token: 0x04001F02 RID: 7938
	private const float kMinAudioDistance = 1f;

	// Token: 0x04001F03 RID: 7939
	private const float kMaxAudioDistance = 4f;

	// Token: 0x04001F04 RID: 7940
	private const global::UnityEngine.AudioRolloffMode kRolloffMode = 0;

	// Token: 0x04001F05 RID: 7941
	private bool is_vm;

	// Token: 0x04001F06 RID: 7942
	private global::LaserBeam[] beams;

	// Token: 0x04001F07 RID: 7943
	private static bool allow_3rd_lasers = true;
}
