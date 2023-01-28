using System;
using UnityEngine;

// Token: 0x0200005E RID: 94
public class KillZone : global::IDRemote
{
	// Token: 0x060002AB RID: 683 RVA: 0x0000D884 File Offset: 0x0000BA84
	public KillZone()
	{
	}

	// Token: 0x060002AC RID: 684 RVA: 0x0000D88C File Offset: 0x0000BA8C
	private void OnTriggerEnter(global::UnityEngine.Collider collider)
	{
		global::Character character;
		if (global::IDBase.GetMain<global::Character>(collider, ref character) && character.playerControlled && character.alive)
		{
			global::NetUser netUser = character.netUser;
			global::DamageEvent damageEvent;
			if (global::TakeDamage.Kill(base.idMain, character, out damageEvent, null) == global::LifeStatus.WasKilled)
			{
				global::UnityEngine.Debug.Log(string.Format("{0} squished", netUser.user.Displayname), this);
			}
		}
	}
}
