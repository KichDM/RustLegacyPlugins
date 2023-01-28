using System;
using UnityEngine;

// Token: 0x0200057C RID: 1404
public class CharacterItemAttachmentTrait : global::CharacterTrait
{
	// Token: 0x06002F25 RID: 12069 RVA: 0x000B3D54 File Offset: 0x000B1F54
	public CharacterItemAttachmentTrait()
	{
	}

	// Token: 0x17000A06 RID: 2566
	// (get) Token: 0x06002F26 RID: 12070 RVA: 0x000B3D5C File Offset: 0x000B1F5C
	public global::Socket.ConfigBodyPart socket
	{
		get
		{
			return this._socket;
		}
	}

	// Token: 0x040018FC RID: 6396
	[global::UnityEngine.SerializeField]
	private global::Socket.ConfigBodyPart _socket;
}
