using System;
using System.Collections.Generic;
using Magma;
using uLink;
using UnityEngine;

// Token: 0x020000C1 RID: 193
public sealed class VoiceCom : global::IDLocalCharacter, global::IVoiceCom
{
	// Token: 0x060003C3 RID: 963 RVA: 0x00012194 File Offset: 0x00010394
	public VoiceCom()
	{
	}

	// Token: 0x060003C4 RID: 964 RVA: 0x0001219C File Offset: 0x0001039C
	// Note: this type is marked as 'beforefieldinit'.
	static VoiceCom()
	{
	}

	// Token: 0x060003C5 RID: 965 RVA: 0x000121B0 File Offset: 0x000103B0
	private void Awake()
	{
		global::UnityEngine.Object.Destroy(global::USpeaker.Get(this));
	}

	// Token: 0x060003C6 RID: 966 RVA: 0x000121C0 File Offset: 0x000103C0
	private void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x060003C7 RID: 967 RVA: 0x000121C4 File Offset: 0x000103C4
	[global::UnityEngine.RPC]
	private void clientspeak(int setupData, byte[] data)
	{
		global::PlayerClient playerClient;
		if (global::voice.distance > 0f && global::PlayerClient.Find(base.networkViewOwner, out playerClient) && playerClient.hasLastKnownPosition)
		{
			float num = global::voice.distance * global::voice.distance;
			global::UnityEngine.Vector3 lastKnownPosition = playerClient.lastKnownPosition;
			int num2 = 0;
			try
			{
				foreach (global::PlayerClient playerClient2 in global::PlayerClient.All)
				{
					if (playerClient2 && playerClient2.hasLastKnownPosition && !(playerClient2 == playerClient))
					{
						global::UnityEngine.Vector3 vector;
						vector.x = playerClient2.lastKnownPosition.x - lastKnownPosition.x;
						vector.y = playerClient2.lastKnownPosition.y - lastKnownPosition.y;
						vector.z = playerClient2.lastKnownPosition.z - lastKnownPosition.z;
						float num3 = vector.x * vector.x + vector.y * vector.y + vector.z * vector.z;
						if (num3 <= num)
						{
							num2++;
							global::Magma.Hooks.ShowTalker(playerClient2.netPlayer, playerClient);
							global::VoiceCom.playerList.Add(playerClient2.netPlayer);
						}
					}
				}
				if (num2 > 0)
				{
					base.networkView.RPC("VoiceCom:voiceplay", global::VoiceCom.playerList, new object[]
					{
						global::voice.distance,
						setupData,
						data
					});
				}
			}
			finally
			{
				if (num2 > 0)
				{
					global::VoiceCom.playerList.Clear();
				}
			}
		}
	}

	// Token: 0x060003C8 RID: 968 RVA: 0x000123B0 File Offset: 0x000105B0
	[global::UnityEngine.RPC]
	private void voiceplay(float hearDistance, int setupData, byte[] data)
	{
	}

	// Token: 0x060003C9 RID: 969 RVA: 0x000123B4 File Offset: 0x000105B4
	[global::UnityEngine.RPC]
	private void init(int data)
	{
	}

	// Token: 0x0400038C RID: 908
	private static readonly global::System.Collections.Generic.List<global::uLink.NetworkPlayer> playerList = new global::System.Collections.Generic.List<global::uLink.NetworkPlayer>(0xC8);
}
