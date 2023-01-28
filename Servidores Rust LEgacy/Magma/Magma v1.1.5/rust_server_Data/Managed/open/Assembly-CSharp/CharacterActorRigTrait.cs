using System;
using Facepunch.Actor;
using UnityEngine;

// Token: 0x02000128 RID: 296
public class CharacterActorRigTrait : global::CharacterTrait
{
	// Token: 0x0600074F RID: 1871 RVA: 0x00020300 File Offset: 0x0001E500
	public CharacterActorRigTrait()
	{
	}

	// Token: 0x17000168 RID: 360
	// (get) Token: 0x06000750 RID: 1872 RVA: 0x00020308 File Offset: 0x0001E508
	public global::Facepunch.Actor.ActorRig actorRig
	{
		get
		{
			return this._actorRig;
		}
	}

	// Token: 0x040005D6 RID: 1494
	[global::UnityEngine.SerializeField]
	private global::Facepunch.Actor.ActorRig _actorRig;
}
