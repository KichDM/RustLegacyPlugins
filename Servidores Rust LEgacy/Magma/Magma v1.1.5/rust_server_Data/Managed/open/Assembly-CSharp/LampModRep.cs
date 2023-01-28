using System;
using UnityEngine;

// Token: 0x02000713 RID: 1811
public class LampModRep : global::WeaponModRep
{
	// Token: 0x06003D81 RID: 15745 RVA: 0x000D7BF0 File Offset: 0x000D5DF0
	protected LampModRep(global::ItemModRepresentation.Caps caps, bool defaultOn) : base(caps, defaultOn)
	{
	}

	// Token: 0x06003D82 RID: 15746 RVA: 0x000D7BFC File Offset: 0x000D5DFC
	public LampModRep() : this(global::ItemModRepresentation.Caps.BindStateFlags, false)
	{
	}

	// Token: 0x06003D83 RID: 15747 RVA: 0x000D7C08 File Offset: 0x000D5E08
	protected LampModRep(global::ItemModRepresentation.Caps caps) : this(caps, false)
	{
	}

	// Token: 0x06003D84 RID: 15748 RVA: 0x000D7C14 File Offset: 0x000D5E14
	protected override bool VerifyCompatible(global::UnityEngine.GameObject attachment)
	{
		return attachment.GetComponentInChildren<global::UnityEngine.Light>();
	}

	// Token: 0x06003D85 RID: 15749 RVA: 0x000D7C24 File Offset: 0x000D5E24
	protected override void OnAddAttached()
	{
		this.lights = base.attached.GetComponentsInChildren<global::UnityEngine.Light>();
	}

	// Token: 0x06003D86 RID: 15750 RVA: 0x000D7C38 File Offset: 0x000D5E38
	protected override void OnRemoveAttached()
	{
		this.lights = null;
	}

	// Token: 0x06003D87 RID: 15751 RVA: 0x000D7C44 File Offset: 0x000D5E44
	protected override void EnableMod(global::ItemModRepresentation.Reason reason)
	{
		global::UnityEngine.Light anyLight = null;
		if (reason == global::ItemModRepresentation.Reason.Explicit)
		{
			this.PlaySound(anyLight, base.modDataBlock.onSound);
		}
	}

	// Token: 0x06003D88 RID: 15752 RVA: 0x000D7C6C File Offset: 0x000D5E6C
	protected override void DisableMod(global::ItemModRepresentation.Reason reason)
	{
		global::UnityEngine.Light anyLight = null;
		if (reason == global::ItemModRepresentation.Reason.Explicit)
		{
			this.PlaySound(anyLight, base.modDataBlock.offSound);
		}
	}

	// Token: 0x06003D89 RID: 15753 RVA: 0x000D7C94 File Offset: 0x000D5E94
	protected override void BindStateFlags(global::CharacterStateFlags flags, global::ItemModRepresentation.Reason reason)
	{
		base.BindStateFlags(flags, reason);
		base.SetOn(flags.lamp, reason);
	}

	// Token: 0x06003D8A RID: 15754 RVA: 0x000D7CAC File Offset: 0x000D5EAC
	private void PlaySound(global::UnityEngine.Light anyLight, global::UnityEngine.AudioClip clip)
	{
		if (anyLight)
		{
			clip.PlayLocal(anyLight.transform, global::UnityEngine.Vector3.zero, 1f, 0, 1f, 4f);
		}
		else
		{
			clip.PlayLocal(base.itemRep.transform, global::UnityEngine.Vector3.zero, 1f, 0, 1f, 4f);
		}
	}

	// Token: 0x04001EFC RID: 7932
	private const float kVolume = 1f;

	// Token: 0x04001EFD RID: 7933
	private const float kMinAudioDistance = 1f;

	// Token: 0x04001EFE RID: 7934
	private const float kMaxAudioDistance = 4f;

	// Token: 0x04001EFF RID: 7935
	private const global::UnityEngine.AudioRolloffMode kRolloffMode = 0;

	// Token: 0x04001F00 RID: 7936
	private global::UnityEngine.Light[] lights;
}
