using System;
using MoPhoGames.USpeak.Codec;
using UnityEngine;

// Token: 0x020000CE RID: 206
public class USpeakCodecManager : global::UnityEngine.ScriptableObject
{
	// Token: 0x06000407 RID: 1031 RVA: 0x00013434 File Offset: 0x00011634
	public USpeakCodecManager()
	{
	}

	// Token: 0x1700008C RID: 140
	// (get) Token: 0x06000408 RID: 1032 RVA: 0x00013454 File Offset: 0x00011654
	public static global::USpeakCodecManager Instance
	{
		get
		{
			if (global::USpeakCodecManager.instance == null)
			{
				global::USpeakCodecManager.instance = (global::USpeakCodecManager)global::Resources.Load("CodecManager");
				if (global::USpeakCodecManager.instance == null)
				{
					global::UnityEngine.Debug.LogError("Couldn't load Resources/CodecManager!");
				}
				if (global::UnityEngine.Application.isPlaying)
				{
					global::USpeakCodecManager.instance.Codecs = new global::MoPhoGames.USpeak.Codec.ICodec[global::USpeakCodecManager.instance.CodecNames.Length];
					for (int i = 0; i < global::USpeakCodecManager.instance.Codecs.Length; i++)
					{
						global::USpeakCodecManager.instance.Codecs[i] = (global::MoPhoGames.USpeak.Codec.ICodec)global::System.Activator.CreateInstance(global::System.Type.GetType(global::USpeakCodecManager.instance.CodecNames[i]));
					}
				}
			}
			return global::USpeakCodecManager.instance;
		}
	}

	// Token: 0x040003D5 RID: 981
	private static global::USpeakCodecManager instance;

	// Token: 0x040003D6 RID: 982
	public global::MoPhoGames.USpeak.Codec.ICodec[] Codecs;

	// Token: 0x040003D7 RID: 983
	public string[] CodecNames = new string[0];

	// Token: 0x040003D8 RID: 984
	public string[] FriendlyNames = new string[0];
}
