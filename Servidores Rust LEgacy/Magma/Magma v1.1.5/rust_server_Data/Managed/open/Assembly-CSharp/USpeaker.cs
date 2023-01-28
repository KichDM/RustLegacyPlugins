using System;
using System.Collections.Generic;
using System.Linq;
using MoPhoGames.USpeak.Core;
using MoPhoGames.USpeak.Core.Utils;
using MoPhoGames.USpeak.Interface;
using UnityEngine;

// Token: 0x020000CB RID: 203
[global::UnityEngine.AddComponentMenu("USpeak/USpeaker")]
public class USpeaker : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060003E6 RID: 998 RVA: 0x00012A30 File Offset: 0x00010C30
	public USpeaker()
	{
	}

	// Token: 0x060003E7 RID: 999 RVA: 0x00012AB0 File Offset: 0x00010CB0
	// Note: this type is marked as 'beforefieldinit'.
	static USpeaker()
	{
	}

	// Token: 0x17000089 RID: 137
	// (get) Token: 0x060003E8 RID: 1000 RVA: 0x00012AF4 File Offset: 0x00010CF4
	// (set) Token: 0x060003E9 RID: 1001 RVA: 0x00012B00 File Offset: 0x00010D00
	[global::System.Obsolete("Use USpeaker._3DMode instead")]
	public bool Is3D
	{
		get
		{
			return this._3DMode == global::ThreeDMode.SpeakerPan;
		}
		set
		{
			if (value)
			{
				this._3DMode = global::ThreeDMode.SpeakerPan;
			}
			else
			{
				this._3DMode = global::ThreeDMode.None;
			}
		}
	}

	// Token: 0x1700008A RID: 138
	// (get) Token: 0x060003EA RID: 1002 RVA: 0x00012B1C File Offset: 0x00010D1C
	public bool IsTalking
	{
		get
		{
			return this.talkTimer > 0f;
		}
	}

	// Token: 0x060003EB RID: 1003 RVA: 0x00012B2C File Offset: 0x00010D2C
	public bool HasSettings()
	{
		return this.settings != null;
	}

	// Token: 0x1700008B RID: 139
	// (get) Token: 0x060003EC RID: 1004 RVA: 0x00012B3C File Offset: 0x00010D3C
	private int audioFrequency
	{
		get
		{
			if (this.recFreq == 0)
			{
				switch (this.BandwidthMode)
				{
				case global::BandMode.Narrow:
					this.recFreq = 0x1F40;
					break;
				case global::BandMode.Wide:
					this.recFreq = 0x3E80;
					break;
				case global::BandMode.UltraWide:
					this.recFreq = 0x7D00;
					break;
				default:
					this.recFreq = 0x1F40;
					break;
				}
			}
			return this.recFreq;
		}
	}

	// Token: 0x060003ED RID: 1005 RVA: 0x00012BB8 File Offset: 0x00010DB8
	public void SetInputDevice(int deviceID)
	{
		global::USpeaker.InputDeviceID = deviceID;
	}

	// Token: 0x060003EE RID: 1006 RVA: 0x00012BC0 File Offset: 0x00010DC0
	public static global::USpeaker Get(global::UnityEngine.Object source)
	{
		if (source is global::UnityEngine.GameObject)
		{
			return (source as global::UnityEngine.GameObject).GetComponent<global::USpeaker>();
		}
		if (source is global::UnityEngine.Transform)
		{
			return (source as global::UnityEngine.Transform).GetComponent<global::USpeaker>();
		}
		if (source is global::UnityEngine.Component)
		{
			return (source as global::UnityEngine.Component).GetComponent<global::USpeaker>();
		}
		return null;
	}

	// Token: 0x060003EF RID: 1007 RVA: 0x00012C14 File Offset: 0x00010E14
	public void GetInputHandler()
	{
		this.talkController = (global::MoPhoGames.USpeak.Interface.IUSpeakTalkController)this.FindInputHandler();
	}

	// Token: 0x060003F0 RID: 1008 RVA: 0x00012C28 File Offset: 0x00010E28
	public void DrawTalkControllerUI()
	{
		if (this.talkController != null)
		{
			this.talkController.OnInspectorGUI();
		}
		else
		{
			global::UnityEngine.GUILayout.Label("No component available which implements IUSpeakTalkController\nReverting to default behavior - data is always sent", new global::UnityEngine.GUILayoutOption[0]);
		}
	}

	// Token: 0x060003F1 RID: 1009 RVA: 0x00012C58 File Offset: 0x00010E58
	public void ReceiveAudio(byte[] data)
	{
		if (this.settings == null)
		{
			global::UnityEngine.Debug.LogWarning("Trying to receive remote audio data without calling InitializeSettings!\nIncoming packet will be ignored");
			return;
		}
		if (global::USpeaker.MuteAll || this.Mute || (this.SpeakerMode == global::SpeakerMode.Local && !this.DebugPlayback))
		{
			return;
		}
		if (this.SpeakerMode == global::SpeakerMode.Remote)
		{
			this.talkTimer = 1f;
		}
		byte[] @byte;
		for (int i = 0; i < data.Length; i += @byte.Length)
		{
			int num = global::System.BitConverter.ToInt32(data, i);
			@byte = global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.GetByte(num + 6);
			global::System.Array.Copy(data, i, @byte, 0, @byte.Length);
			global::MoPhoGames.USpeak.Core.USpeakFrameContainer uspeakFrameContainer = default(global::MoPhoGames.USpeak.Core.USpeakFrameContainer);
			uspeakFrameContainer.LoadFrom(@byte);
			global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.Return(@byte);
			float[] array = global::MoPhoGames.USpeak.Core.USpeakAudioClipCompressor.DecompressAudio(uspeakFrameContainer.encodedData, (int)uspeakFrameContainer.Samples, 1, false, this.settings.bandMode, this.codecMgr.Codecs[this.Codec], global::USpeaker.RemoteGain);
			float num2 = (float)array.Length / (float)this.audioFrequency;
			this.received += (double)num2;
			global::System.Array.Copy(array, 0, this.receivedData, this.index, array.Length);
			global::MoPhoGames.USpeak.Core.Utils.USpeakPoolUtils.Return(array);
			this.index += array.Length;
			if (this.index >= base.audio.clip.samples)
			{
				this.index = 0;
			}
			base.audio.clip.SetData(this.receivedData, 0);
			if (!base.audio.isPlaying)
			{
				this.shouldPlay = true;
				if (this.playDelay <= 0f)
				{
					this.playDelay = num2 * 2f;
				}
			}
		}
	}

	// Token: 0x060003F2 RID: 1010 RVA: 0x00012E00 File Offset: 0x00011000
	public void InitializeSettings(int data)
	{
		global::UnityEngine.MonoBehaviour.print("Settings changed");
		this.settings = new global::MoPhoGames.USpeak.Core.USpeakSettingsData((byte)data);
		this.Codec = this.settings.Codec;
	}

	// Token: 0x060003F3 RID: 1011 RVA: 0x00012E38 File Offset: 0x00011038
	private void StopPlaying()
	{
		base.audio.Stop();
		base.audio.time = 0f;
		this.index = 0;
		this.played = 0.0;
		this.received = 0.0;
		this.lastTime = 0f;
	}

	// Token: 0x060003F4 RID: 1012 RVA: 0x00012E90 File Offset: 0x00011090
	private void UpdateSettings()
	{
		if (!global::UnityEngine.Application.isPlaying)
		{
			return;
		}
		this.settings = new global::MoPhoGames.USpeak.Core.USpeakSettingsData();
		this.settings.bandMode = this.BandwidthMode;
		this.settings.Codec = this.Codec;
		this.audioHandler.USpeakInitializeSettings((int)this.settings.ToByte());
	}

	// Token: 0x060003F5 RID: 1013 RVA: 0x00012EEC File Offset: 0x000110EC
	private global::UnityEngine.Component FindSpeechHandler()
	{
		global::UnityEngine.Component[] components = base.GetComponents<global::UnityEngine.Component>();
		foreach (global::UnityEngine.Component component in components)
		{
			if (component is global::MoPhoGames.USpeak.Interface.ISpeechDataHandler)
			{
				return component;
			}
		}
		return null;
	}

	// Token: 0x060003F6 RID: 1014 RVA: 0x00012F28 File Offset: 0x00011128
	private global::UnityEngine.Component FindInputHandler()
	{
		global::UnityEngine.Component[] components = base.GetComponents<global::UnityEngine.Component>();
		foreach (global::UnityEngine.Component component in components)
		{
			if (component is global::MoPhoGames.USpeak.Interface.IUSpeakTalkController)
			{
				return component;
			}
		}
		return null;
	}

	// Token: 0x060003F7 RID: 1015 RVA: 0x00012F64 File Offset: 0x00011164
	private void OnAudioAvailable(float[] pcmData)
	{
		if (this.UseVAD && !this.CheckVAD(pcmData))
		{
			return;
		}
		global::USpeaker.CurrentVolume = 0f;
		if (pcmData.Length > 0)
		{
			foreach (float num in pcmData)
			{
				global::USpeaker.CurrentVolume += global::UnityEngine.Mathf.Abs(num);
			}
			global::USpeaker.CurrentVolume /= (float)pcmData.Length;
		}
		int size = 0x500;
		global::System.Collections.Generic.List<float[]> list = this.SplitArray(pcmData, size);
		foreach (float[] item in list)
		{
			this.pendingEncode.Add(item);
		}
	}

	// Token: 0x060003F8 RID: 1016 RVA: 0x00013048 File Offset: 0x00011248
	private global::System.Collections.Generic.List<float[]> SplitArray(float[] array, int size)
	{
		global::System.Collections.Generic.List<float[]> list = new global::System.Collections.Generic.List<float[]>();
		float[] array2;
		for (int i = 0; i < array.Length; i += array2.Length)
		{
			array2 = array.Skip(i).Take(size).ToArray<float>();
			list.Add(array2);
		}
		return list;
	}

	// Token: 0x060003F9 RID: 1017 RVA: 0x0001308C File Offset: 0x0001128C
	private void ProcessPendingEncodeBuffer()
	{
		int num = 0xA;
		float num2 = (float)num / 1000f;
		float realtimeSinceStartup = global::UnityEngine.Time.realtimeSinceStartup;
		while (global::UnityEngine.Time.realtimeSinceStartup <= realtimeSinceStartup + num2 && this.pendingEncode.Count > 0)
		{
			float[] pcm = this.pendingEncode[0];
			this.pendingEncode.RemoveAt(0);
			this.ProcessPendingEncode(pcm);
		}
	}

	// Token: 0x060003FA RID: 1018 RVA: 0x000130F0 File Offset: 0x000112F0
	private void ProcessPendingEncode(float[] pcm)
	{
		int num;
		byte[] encodedData = global::MoPhoGames.USpeak.Core.USpeakAudioClipCompressor.CompressAudioData(pcm, 1, out num, this.lastBandMode, this.codecMgr.Codecs[this.lastCodec], global::USpeaker.LocalGain);
		global::MoPhoGames.USpeak.Core.USpeakFrameContainer item = default(global::MoPhoGames.USpeak.Core.USpeakFrameContainer);
		item.Samples = (ushort)num;
		item.encodedData = encodedData;
		this.sendBuffer.Add(item);
	}

	// Token: 0x060003FB RID: 1019 RVA: 0x0001314C File Offset: 0x0001134C
	private int CalculateSamplesRead(int readPos)
	{
		if (readPos >= this.lastReadPos)
		{
			return readPos - this.lastReadPos;
		}
		return this.audioFrequency * 0xA - this.lastReadPos + readPos;
	}

	// Token: 0x060003FC RID: 1020 RVA: 0x00013178 File Offset: 0x00011378
	private float[] normalize(float[] samples, float magnitude)
	{
		float[] array = new float[samples.Length];
		for (int i = 0; i < samples.Length; i++)
		{
			array[i] = samples[i] / magnitude;
		}
		return array;
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x000131AC File Offset: 0x000113AC
	private float amplitude(float[] x)
	{
		float num = 0f;
		for (int i = 0; i < x.Length; i++)
		{
			num = global::UnityEngine.Mathf.Max(num, global::UnityEngine.Mathf.Abs(x[i]));
		}
		return num;
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x000131E4 File Offset: 0x000113E4
	private bool CheckVAD(float[] samples)
	{
		if (global::UnityEngine.Time.realtimeSinceStartup < this.lastVTime + this.vadHangover)
		{
			return true;
		}
		float num = 0f;
		foreach (float num2 in samples)
		{
			num = global::UnityEngine.Mathf.Max(num, global::UnityEngine.Mathf.Abs(num2));
		}
		bool flag = num >= this.VolumeThreshold;
		if (flag)
		{
			this.lastVTime = global::UnityEngine.Time.realtimeSinceStartup;
		}
		return flag;
	}

	// Token: 0x040003A5 RID: 933
	public static float CurrentVolume = 0f;

	// Token: 0x040003A6 RID: 934
	public static float RemoteGain = 1f;

	// Token: 0x040003A7 RID: 935
	public static float LocalGain = 1f;

	// Token: 0x040003A8 RID: 936
	public static bool MuteAll = false;

	// Token: 0x040003A9 RID: 937
	public static global::System.Collections.Generic.List<global::USpeaker> USpeakerList = new global::System.Collections.Generic.List<global::USpeaker>();

	// Token: 0x040003AA RID: 938
	private static int InputDeviceID = 0;

	// Token: 0x040003AB RID: 939
	public global::SpeakerMode SpeakerMode;

	// Token: 0x040003AC RID: 940
	public global::BandMode BandwidthMode;

	// Token: 0x040003AD RID: 941
	public float SendRate = 16f;

	// Token: 0x040003AE RID: 942
	public global::SendBehavior SendingMode;

	// Token: 0x040003AF RID: 943
	public bool UseVAD;

	// Token: 0x040003B0 RID: 944
	public global::ThreeDMode _3DMode;

	// Token: 0x040003B1 RID: 945
	public bool DebugPlayback;

	// Token: 0x040003B2 RID: 946
	public bool AskPermission = true;

	// Token: 0x040003B3 RID: 947
	public bool Mute;

	// Token: 0x040003B4 RID: 948
	public float SpeakerVolume = 1f;

	// Token: 0x040003B5 RID: 949
	public float VolumeThreshold = 0.01f;

	// Token: 0x040003B6 RID: 950
	public int Codec;

	// Token: 0x040003B7 RID: 951
	private global::USpeakCodecManager codecMgr;

	// Token: 0x040003B8 RID: 952
	private global::UnityEngine.AudioClip recording;

	// Token: 0x040003B9 RID: 953
	private int recFreq;

	// Token: 0x040003BA RID: 954
	private int lastReadPos;

	// Token: 0x040003BB RID: 955
	private float sendTimer;

	// Token: 0x040003BC RID: 956
	private float sendt = 1f;

	// Token: 0x040003BD RID: 957
	private global::System.Collections.Generic.List<global::MoPhoGames.USpeak.Core.USpeakFrameContainer> sendBuffer = new global::System.Collections.Generic.List<global::MoPhoGames.USpeak.Core.USpeakFrameContainer>();

	// Token: 0x040003BE RID: 958
	private global::System.Collections.Generic.List<byte> tempSendBytes = new global::System.Collections.Generic.List<byte>();

	// Token: 0x040003BF RID: 959
	private global::MoPhoGames.USpeak.Interface.ISpeechDataHandler audioHandler;

	// Token: 0x040003C0 RID: 960
	private global::MoPhoGames.USpeak.Interface.IUSpeakTalkController talkController;

	// Token: 0x040003C1 RID: 961
	private int overlap;

	// Token: 0x040003C2 RID: 962
	private global::MoPhoGames.USpeak.Core.USpeakSettingsData settings;

	// Token: 0x040003C3 RID: 963
	private string currentDeviceName = string.Empty;

	// Token: 0x040003C4 RID: 964
	private float talkTimer;

	// Token: 0x040003C5 RID: 965
	private float vadHangover = 0.5f;

	// Token: 0x040003C6 RID: 966
	private float lastVTime;

	// Token: 0x040003C7 RID: 967
	private global::System.Collections.Generic.List<float[]> pendingEncode = new global::System.Collections.Generic.List<float[]>();

	// Token: 0x040003C8 RID: 968
	private double played;

	// Token: 0x040003C9 RID: 969
	private int index;

	// Token: 0x040003CA RID: 970
	private double received;

	// Token: 0x040003CB RID: 971
	private float[] receivedData;

	// Token: 0x040003CC RID: 972
	private float playDelay;

	// Token: 0x040003CD RID: 973
	private bool shouldPlay;

	// Token: 0x040003CE RID: 974
	private float lastTime;

	// Token: 0x040003CF RID: 975
	private global::BandMode lastBandMode;

	// Token: 0x040003D0 RID: 976
	private int lastCodec;

	// Token: 0x040003D1 RID: 977
	private global::ThreeDMode last3DMode;

	// Token: 0x040003D2 RID: 978
	private string[] devicesCached;
}
