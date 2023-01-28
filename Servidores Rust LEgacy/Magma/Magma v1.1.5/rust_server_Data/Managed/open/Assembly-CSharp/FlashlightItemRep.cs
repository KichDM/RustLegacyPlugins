using System;
using UnityEngine;

// Token: 0x020006C3 RID: 1731
public class FlashlightItemRep : global::ItemRepresentation
{
	// Token: 0x06003B43 RID: 15171 RVA: 0x000D2668 File Offset: 0x000D0868
	public FlashlightItemRep()
	{
	}

	// Token: 0x06003B44 RID: 15172 RVA: 0x000D2670 File Offset: 0x000D0870
	protected override void StateSignalReceive(global::Character character, bool treatedAsFirst)
	{
		this.SetLightOn(character.stateFlags.lamp);
	}

	// Token: 0x06003B45 RID: 15173 RVA: 0x000D2684 File Offset: 0x000D0884
	public virtual void SetLightOn(bool on)
	{
		bool flag = base.networkViewOwner == global::NetCull.player;
		if (on)
		{
			if (!flag)
			{
				global::UnityEngine.Vector3 position = base.transform.position;
				global::UnityEngine.Quaternion rotation = base.transform.rotation;
				this.lightEffect = (global::UnityEngine.Object.Instantiate(this.lightEffectPrefab3P, position, rotation) as global::UnityEngine.GameObject);
				this.lightEffect.transform.localPosition = position;
				this.lightEffect.transform.localRotation = rotation;
			}
		}
		else
		{
			global::UnityEngine.Object.Destroy(this.lightEffect);
		}
	}

	// Token: 0x04001E4C RID: 7756
	private global::UnityEngine.GameObject lightEffect;

	// Token: 0x04001E4D RID: 7757
	public global::UnityEngine.GameObject lightEffectPrefab1P;

	// Token: 0x04001E4E RID: 7758
	public global::UnityEngine.GameObject lightEffectPrefab3P;
}
