using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Token: 0x020000FA RID: 250
public static class SoundPool
{
	// Token: 0x060004F1 RID: 1265 RVA: 0x00017C90 File Offset: 0x00015E90
	// Note: this type is marked as 'beforefieldinit'.
	static SoundPool()
	{
	}

	// Token: 0x170000BD RID: 189
	// (get) Token: 0x060004F2 RID: 1266 RVA: 0x00017D60 File Offset: 0x00015F60
	// (set) Token: 0x060004F3 RID: 1267 RVA: 0x00017D68 File Offset: 0x00015F68
	internal static bool enabled
	{
		get
		{
			return global::SoundPool._enabled;
		}
		set
		{
			if (value)
			{
				global::SoundPool._enabled = !global::SoundPool._quitting;
			}
			else
			{
				global::SoundPool._enabled = false;
			}
		}
	}

	// Token: 0x170000BE RID: 190
	// (set) Token: 0x060004F4 RID: 1268 RVA: 0x00017D88 File Offset: 0x00015F88
	internal static bool quitting
	{
		set
		{
			if (!global::SoundPool._quitting && value)
			{
				global::SoundPool._quitting = true;
				global::SoundPool._enabled = false;
				global::SoundPool.Drain();
			}
		}
	}

	// Token: 0x060004F5 RID: 1269 RVA: 0x00017DAC File Offset: 0x00015FAC
	private static global::SoundPool.Node NewNode()
	{
		global::SoundPool.Node node = new global::SoundPool.Node();
		global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject("zzz-soundpoolnode", global::SoundPool.goTypes);
		gameObject.hideFlags = 8;
		global::UnityEngine.Object.DontDestroyOnLoad(gameObject);
		node.audio = gameObject.audio;
		node.transform = gameObject.transform;
		node.audio.playOnAwake = false;
		node.audio.enabled = false;
		return node;
	}

	// Token: 0x060004F6 RID: 1270 RVA: 0x00017E10 File Offset: 0x00016010
	private static global::SoundPool.Node CreateNode()
	{
		if (global::SoundPool.reserved.first.has)
		{
			global::SoundPool.Node node = global::SoundPool.reserved.first.node;
			node.EnterLimbo();
			return node;
		}
		return global::SoundPool.NewNode();
	}

	// Token: 0x060004F7 RID: 1271 RVA: 0x00017E54 File Offset: 0x00016054
	private static global::UnityEngine.Object TARG(ref global::SoundPool.Settings settings)
	{
		return (!settings.parent) ? settings.clip : settings.parent;
	}

	// Token: 0x060004F8 RID: 1272 RVA: 0x00017E78 File Offset: 0x00016078
	[global::System.Diagnostics.Conditional("CLIENT")]
	private static void Play(ref global::SoundPool.Settings settings)
	{
		if (!global::SoundPool._enabled || settings.volume <= 0f || settings.pitch == 0f || !settings.clip)
		{
			return;
		}
		global::UnityEngine.Transform transform = null;
		global::SoundPool.Root root;
		global::SoundPool.RootID rootID;
		bool flag;
		switch (settings.SelectRoot)
		{
		default:
			root = global::SoundPool.playing;
			rootID = global::SoundPool.RootID.PLAYING;
			flag = false;
			break;
		case 1:
			if (!global::UnityEngine.Camera.main)
			{
				return;
			}
			transform = global::UnityEngine.Camera.main.transform;
			root = global::SoundPool.playingCamera;
			rootID = global::SoundPool.RootID.PLAYING_CAMERA;
			flag = false;
			break;
		case 2:
			if (!settings.parent)
			{
				return;
			}
			root = global::SoundPool.playingAttached;
			rootID = global::SoundPool.RootID.PLAYING_ATTACHED;
			flag = false;
			break;
		case 5:
			if (!global::UnityEngine.Camera.main)
			{
				return;
			}
			transform = global::UnityEngine.Camera.main.transform;
			root = global::SoundPool.playingCamera;
			rootID = global::SoundPool.RootID.PLAYING_CAMERA;
			flag = true;
			break;
		case 6:
			if (!settings.parent)
			{
				return;
			}
			root = global::SoundPool.playingAttached;
			rootID = global::SoundPool.RootID.PLAYING_ATTACHED;
			flag = true;
			break;
		}
		global::UnityEngine.Vector3 vector;
		global::UnityEngine.Quaternion quaternion;
		global::UnityEngine.Vector3 vector2;
		global::UnityEngine.Quaternion rotation;
		if (flag)
		{
			global::SoundPool.RootID rootID2 = rootID;
			if (rootID2 != global::SoundPool.RootID.PLAYING_ATTACHED)
			{
				if (rootID2 != global::SoundPool.RootID.PLAYING_CAMERA)
				{
					return;
				}
				vector = transform.InverseTransformPoint(settings.localPosition);
				quaternion = settings.localRotation * global::UnityEngine.Quaternion.Inverse(transform.rotation);
			}
			else
			{
				vector = settings.parent.InverseTransformPoint(settings.localPosition);
				quaternion = settings.localRotation * global::UnityEngine.Quaternion.Inverse(settings.parent.rotation);
			}
			vector2 = settings.localPosition;
			rotation = settings.localRotation;
		}
		else
		{
			vector = settings.localPosition;
			quaternion = settings.localRotation;
			global::SoundPool.RootID rootID2 = rootID;
			switch (rootID2 + 3)
			{
			case global::SoundPool.RootID.LIMBO:
				vector2 = settings.parent.TransformPoint(vector);
				rotation = settings.parent.rotation * quaternion;
				break;
			case global::SoundPool.RootID.RESERVED:
				vector2 = transform.TransformPoint(vector);
				rotation = transform.rotation * quaternion;
				break;
			case global::SoundPool.RootID.DISPOSED:
				vector2 = vector;
				rotation = quaternion;
				break;
			default:
				return;
			}
		}
		if (!transform)
		{
			global::UnityEngine.Camera main = global::UnityEngine.Camera.main;
			if (!main)
			{
				return;
			}
			transform = main.transform;
			float num = global::UnityEngine.Vector3.Distance(vector2, transform.position);
			switch (settings.mode)
			{
			case 0:
				if (num > settings.max * 2f)
				{
					return;
				}
				break;
			case 1:
			case 2:
				if (num > settings.max)
				{
					return;
				}
				break;
			}
		}
		global::SoundPool.Node node = global::SoundPool.CreateNode();
		if ((int)node.rootID != 0)
		{
			global::UnityEngine.Debug.LogWarning("Wasn't Limbo " + node.rootID);
		}
		node.root = root;
		node.rootID = rootID;
		node.audio.pan = settings.pan;
		node.audio.panLevel = settings.panLevel;
		node.audio.volume = settings.volume;
		node.audio.dopplerLevel = settings.doppler;
		node.audio.pitch = settings.pitch;
		node.audio.rolloffMode = settings.mode;
		node.audio.minDistance = settings.min;
		node.audio.maxDistance = settings.max;
		node.audio.spread = settings.spread;
		node.audio.bypassEffects = settings.bypassEffects;
		node.audio.priority = settings.priority;
		node.parent = settings.parent;
		node.transform.position = vector2;
		node.transform.rotation = rotation;
		node.translation = vector;
		node.rotation = quaternion;
		node.audio.clip = settings.clip;
		node.Bind();
		node.audio.enabled = true;
		node.audio.Play();
	}

	// Token: 0x060004F9 RID: 1273 RVA: 0x000182A4 File Offset: 0x000164A4
	public static void Pump()
	{
		if (global::SoundPool.firstLeak)
		{
			if (!global::SoundPool.hadFirstLeak)
			{
				global::UnityEngine.Debug.LogWarning("SoundPool node leaked for the first time. Though performance should still be good, from now on until application exit there will be extra processing in Pump to clean up game objects of leaked/gc'd nodes. [ie. a mutex is now being locked and unlocked]");
				global::SoundPool.hadFirstLeak = true;
			}
			global::SoundPool.NodeGC.JOIN();
		}
		global::SoundPool.Dir dir = global::SoundPool.playingCamera.first;
		if (dir.has)
		{
			global::UnityEngine.Camera main = global::UnityEngine.Camera.main;
			if (main)
			{
				global::UnityEngine.Transform transform = main.transform;
				global::UnityEngine.Quaternion rotation = transform.rotation;
				do
				{
					global::SoundPool.Node node = dir.node;
					dir = dir.node.way.next;
					if (node.audio.isPlaying)
					{
						node.transform.position = transform.TransformPoint(node.translation);
						node.transform.rotation = rotation * node.rotation;
					}
					else
					{
						node.Reserve();
					}
				}
				while (dir.has);
			}
			else
			{
				do
				{
					global::SoundPool.Node node2 = dir.node;
					dir = dir.node.way.next;
					node2.Reserve();
				}
				while (dir.has);
			}
		}
		dir = global::SoundPool.playingAttached.first;
		while (dir.has)
		{
			global::SoundPool.Node node3 = dir.node;
			dir = dir.node.way.next;
			if (node3.audio.isPlaying && node3.parent)
			{
				node3.transform.position = node3.parent.TransformPoint(node3.translation);
				node3.transform.rotation = node3.parent.rotation * node3.rotation;
			}
			else
			{
				node3.Reserve();
			}
		}
		dir = global::SoundPool.playing.first;
		while (dir.has)
		{
			global::SoundPool.Node node4 = dir.node;
			dir = dir.node.way.next;
			if (!node4.audio.isPlaying)
			{
				node4.Reserve();
			}
		}
	}

	// Token: 0x060004FA RID: 1274 RVA: 0x000184B0 File Offset: 0x000166B0
	public static void DrainReserves()
	{
		global::SoundPool.Dir dir = global::SoundPool.reserved.first;
		while (dir.has)
		{
			global::SoundPool.Node node = dir.node;
			dir = dir.node.way.next;
			node.Dispose();
		}
	}

	// Token: 0x060004FB RID: 1275 RVA: 0x000184FC File Offset: 0x000166FC
	public static void Stop()
	{
		global::SoundPool.Dir dir = global::SoundPool.playing.first;
		while (dir.has)
		{
			global::SoundPool.Node node = dir.node;
			dir = dir.node.way.next;
			node.Reserve();
		}
		dir = global::SoundPool.playingAttached.first;
		while (dir.has)
		{
			global::SoundPool.Node node = dir.node;
			dir = dir.node.way.next;
			node.Reserve();
		}
		dir = global::SoundPool.playingCamera.first;
		while (dir.has)
		{
			global::SoundPool.Node node = dir.node;
			dir = dir.node.way.next;
			node.Reserve();
		}
	}

	// Token: 0x060004FC RID: 1276 RVA: 0x000185C0 File Offset: 0x000167C0
	public static void Drain()
	{
		global::SoundPool.Dir dir = global::SoundPool.playing.first;
		while (dir.has)
		{
			global::SoundPool.Node node = dir.node;
			dir = dir.node.way.next;
			node.Dispose();
		}
		dir = global::SoundPool.playingAttached.first;
		while (dir.has)
		{
			global::SoundPool.Node node = dir.node;
			dir = dir.node.way.next;
			node.Dispose();
		}
		dir = global::SoundPool.playingCamera.first;
		while (dir.has)
		{
			global::SoundPool.Node node = dir.node;
			dir = dir.node.way.next;
			node.Dispose();
		}
		dir = global::SoundPool.reserved.first;
		while (dir.has)
		{
			global::SoundPool.Node node = dir.node;
			dir = dir.node.way.next;
			node.Dispose();
		}
	}

	// Token: 0x170000BF RID: 191
	// (get) Token: 0x060004FD RID: 1277 RVA: 0x000186C0 File Offset: 0x000168C0
	public static int reserveCount
	{
		get
		{
			return global::SoundPool.reserved.count;
		}
	}

	// Token: 0x170000C0 RID: 192
	// (get) Token: 0x060004FE RID: 1278 RVA: 0x000186CC File Offset: 0x000168CC
	public static int playingCount
	{
		get
		{
			return global::SoundPool.playingCamera.count + global::SoundPool.playingAttached.count + global::SoundPool.playing.count;
		}
	}

	// Token: 0x170000C1 RID: 193
	// (get) Token: 0x060004FF RID: 1279 RVA: 0x000186FC File Offset: 0x000168FC
	public static int totalCount
	{
		get
		{
			return global::SoundPool.playingCamera.count + global::SoundPool.playingAttached.count + global::SoundPool.playing.count + global::SoundPool.reserved.count;
		}
	}

	// Token: 0x06000500 RID: 1280 RVA: 0x0001872C File Offset: 0x0001692C
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
	}

	// Token: 0x06000501 RID: 1281 RVA: 0x00018758 File Offset: 0x00016958
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
	}

	// Token: 0x06000502 RID: 1282 RVA: 0x0001878C File Offset: 0x0001698C
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
	}

	// Token: 0x06000503 RID: 1283 RVA: 0x000187C8 File Offset: 0x000169C8
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float minDistance, float maxDistance)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.min = minDistance;
		def.max = maxDistance;
	}

	// Token: 0x06000504 RID: 1284 RVA: 0x00018810 File Offset: 0x00016A10
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.min = minDistance;
		def.max = maxDistance;
		def.mode = rolloffMode;
	}

	// Token: 0x06000505 RID: 1285 RVA: 0x00018860 File Offset: 0x00016A60
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, float minDistance, float maxDistance)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.min = minDistance;
		def.max = maxDistance;
	}

	// Token: 0x06000506 RID: 1286 RVA: 0x000188B0 File Offset: 0x00016AB0
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, float minDistance, float maxDistance, float dopplerLevel)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
	}

	// Token: 0x06000507 RID: 1287 RVA: 0x00018908 File Offset: 0x00016B08
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, float minDistance, float maxDistance, float dopplerLevel, float spread)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.spread = spread;
	}

	// Token: 0x06000508 RID: 1288 RVA: 0x00018968 File Offset: 0x00016B68
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, float minDistance, float maxDistance, float dopplerLevel, float spread, bool bypassEffects)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.spread = spread;
		def.bypassEffects = bypassEffects;
	}

	// Token: 0x06000509 RID: 1289 RVA: 0x000189D4 File Offset: 0x00016BD4
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float dopplerLevel)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.mode = rolloffMode;
	}

	// Token: 0x0600050A RID: 1290 RVA: 0x00018A34 File Offset: 0x00016C34
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float dopplerLevel, float spread)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.mode = rolloffMode;
		def.spread = spread;
	}

	// Token: 0x0600050B RID: 1291 RVA: 0x00018AA0 File Offset: 0x00016CA0
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float dopplerLevel, float spread, bool bypassEffects)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.spread = spread;
		def.bypassEffects = bypassEffects;
		def.mode = rolloffMode;
	}

	// Token: 0x0600050C RID: 1292 RVA: 0x00018B14 File Offset: 0x00016D14
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.clip = clip;
	}

	// Token: 0x0600050D RID: 1293 RVA: 0x00018B38 File Offset: 0x00016D38
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, float volume)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
	}

	// Token: 0x0600050E RID: 1294 RVA: 0x00018B64 File Offset: 0x00016D64
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, float volume, float pitch)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
	}

	// Token: 0x0600050F RID: 1295 RVA: 0x00018B98 File Offset: 0x00016D98
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, float volume, float minDistance, float maxDistance)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.min = minDistance;
		def.max = maxDistance;
	}

	// Token: 0x06000510 RID: 1296 RVA: 0x00018BD4 File Offset: 0x00016DD4
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, float volume, float minDistance, float maxDistance, int priority)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.min = minDistance;
		def.max = maxDistance;
		def.priority = priority;
	}

	// Token: 0x06000511 RID: 1297 RVA: 0x00018C1C File Offset: 0x00016E1C
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, float volume, float pitch, float minDistance, float maxDistance, int priority)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.min = minDistance;
		def.max = maxDistance;
		def.priority = priority;
		def.pitch = pitch;
	}

	// Token: 0x06000512 RID: 1298 RVA: 0x00018C6C File Offset: 0x00016E6C
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, float volume, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.min = minDistance;
		def.max = maxDistance;
		def.mode = rolloffMode;
	}

	// Token: 0x06000513 RID: 1299 RVA: 0x00018CB4 File Offset: 0x00016EB4
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, float volume, float pitch, float minDistance, float maxDistance)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.min = minDistance;
		def.max = maxDistance;
	}

	// Token: 0x06000514 RID: 1300 RVA: 0x00018CFC File Offset: 0x00016EFC
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, float volume, float pitch, float minDistance, float maxDistance, float dopplerLevel)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
	}

	// Token: 0x06000515 RID: 1301 RVA: 0x00018D4C File Offset: 0x00016F4C
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, float volume, float pitch, float minDistance, float maxDistance, float dopplerLevel, float spread)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.spread = spread;
	}

	// Token: 0x06000516 RID: 1302 RVA: 0x00018DA4 File Offset: 0x00016FA4
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, float volume, float pitch, float minDistance, float maxDistance, float dopplerLevel, float spread, bool bypassEffects)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.spread = spread;
		def.bypassEffects = bypassEffects;
	}

	// Token: 0x06000517 RID: 1303 RVA: 0x00018E04 File Offset: 0x00017004
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float dopplerLevel)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.mode = rolloffMode;
	}

	// Token: 0x06000518 RID: 1304 RVA: 0x00018E5C File Offset: 0x0001705C
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float dopplerLevel, float spread)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.mode = rolloffMode;
		def.spread = spread;
	}

	// Token: 0x06000519 RID: 1305 RVA: 0x00018EBC File Offset: 0x000170BC
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Vector3 position, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float dopplerLevel, float spread, bool bypassEffects)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.spread = spread;
		def.bypassEffects = bypassEffects;
		def.mode = rolloffMode;
	}

	// Token: 0x0600051A RID: 1306 RVA: 0x00018F28 File Offset: 0x00017128
	public static void Play(this global::UnityEngine.AudioClip clip)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 1;
		def.clip = clip;
	}

	// Token: 0x0600051B RID: 1307 RVA: 0x00018F4C File Offset: 0x0001714C
	public static void Play(this global::UnityEngine.AudioClip clip, float volume)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 1;
		def.clip = clip;
		def.volume = volume;
	}

	// Token: 0x0600051C RID: 1308 RVA: 0x00018F78 File Offset: 0x00017178
	public static void Play(this global::UnityEngine.AudioClip clip, float volume, float pan)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 1;
		def.clip = clip;
		def.volume = volume;
		def.pan = pan;
	}

	// Token: 0x0600051D RID: 1309 RVA: 0x00018FAC File Offset: 0x000171AC
	public static void Play(this global::UnityEngine.AudioClip clip, float volume, float pan, float pitch)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 1;
		def.clip = clip;
		def.volume = volume;
		def.pan = pan;
		def.pitch = pitch;
	}

	// Token: 0x0600051E RID: 1310 RVA: 0x00018FE8 File Offset: 0x000171E8
	public static void Play(this global::UnityEngine.AudioClip clip, float volume, float pan, global::UnityEngine.Vector3 worldPosition)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 5;
		def.clip = clip;
		def.volume = volume;
		def.pan = pan;
		def.localPosition = worldPosition;
	}

	// Token: 0x0600051F RID: 1311 RVA: 0x00019024 File Offset: 0x00017224
	public static void Play(this global::UnityEngine.AudioClip clip, float volume, float pan, global::UnityEngine.Vector3 worldPosition, global::UnityEngine.Quaternion worldRotation)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 5;
		def.clip = clip;
		def.volume = volume;
		def.pan = pan;
		def.localPosition = worldPosition;
		def.localRotation = worldRotation;
	}

	// Token: 0x06000520 RID: 1312 RVA: 0x00019068 File Offset: 0x00017268
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, float volume, float pan, global::UnityEngine.Vector3 worldPosition)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 1;
		def.clip = clip;
		def.volume = volume;
		def.pan = pan;
		def.localPosition = worldPosition;
	}

	// Token: 0x06000521 RID: 1313 RVA: 0x000190A4 File Offset: 0x000172A4
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, float volume, float pan, global::UnityEngine.Vector3 worldPosition, global::UnityEngine.Quaternion worldRotation)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 1;
		def.clip = clip;
		def.volume = volume;
		def.pan = pan;
		def.localPosition = worldPosition;
		def.localRotation = worldRotation;
	}

	// Token: 0x06000522 RID: 1314 RVA: 0x000190E8 File Offset: 0x000172E8
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.clip = clip;
	}

	// Token: 0x06000523 RID: 1315 RVA: 0x00019114 File Offset: 0x00017314
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, float volume)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.clip = clip;
	}

	// Token: 0x06000524 RID: 1316 RVA: 0x00019140 File Offset: 0x00017340
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
	}

	// Token: 0x06000525 RID: 1317 RVA: 0x0001917C File Offset: 0x0001737C
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
	}

	// Token: 0x06000526 RID: 1318 RVA: 0x000191C0 File Offset: 0x000173C0
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
	}

	// Token: 0x06000527 RID: 1319 RVA: 0x00019210 File Offset: 0x00017410
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float minDistance, float maxDistance)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.min = minDistance;
		def.max = maxDistance;
	}

	// Token: 0x06000528 RID: 1320 RVA: 0x00019268 File Offset: 0x00017468
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.min = minDistance;
		def.max = maxDistance;
		def.mode = rolloffMode;
	}

	// Token: 0x06000529 RID: 1321 RVA: 0x000192C8 File Offset: 0x000174C8
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, float minDistance, float maxDistance)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.min = minDistance;
		def.max = maxDistance;
	}

	// Token: 0x0600052A RID: 1322 RVA: 0x00019328 File Offset: 0x00017528
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, float minDistance, float maxDistance, float dopplerLevel)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
	}

	// Token: 0x0600052B RID: 1323 RVA: 0x00019390 File Offset: 0x00017590
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, float minDistance, float maxDistance, float dopplerLevel, float spread)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.spread = spread;
	}

	// Token: 0x0600052C RID: 1324 RVA: 0x00019404 File Offset: 0x00017604
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, float minDistance, float maxDistance, float dopplerLevel, float spread, bool bypassEffects)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.spread = spread;
		def.bypassEffects = bypassEffects;
	}

	// Token: 0x0600052D RID: 1325 RVA: 0x00019480 File Offset: 0x00017680
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float dopplerLevel)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.mode = rolloffMode;
	}

	// Token: 0x0600052E RID: 1326 RVA: 0x000194F4 File Offset: 0x000176F4
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float dopplerLevel, float spread)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.mode = rolloffMode;
		def.spread = spread;
	}

	// Token: 0x0600052F RID: 1327 RVA: 0x00019570 File Offset: 0x00017770
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float dopplerLevel, float spread, bool bypassEffects)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.spread = spread;
		def.bypassEffects = bypassEffects;
		def.mode = rolloffMode;
	}

	// Token: 0x06000530 RID: 1328 RVA: 0x000195F4 File Offset: 0x000177F4
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
	}

	// Token: 0x06000531 RID: 1329 RVA: 0x00019628 File Offset: 0x00017828
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
	}

	// Token: 0x06000532 RID: 1330 RVA: 0x00019664 File Offset: 0x00017864
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float pitch)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
	}

	// Token: 0x06000533 RID: 1331 RVA: 0x000196A8 File Offset: 0x000178A8
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float minDistance, float maxDistance)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.min = minDistance;
		def.max = maxDistance;
	}

	// Token: 0x06000534 RID: 1332 RVA: 0x000196F8 File Offset: 0x000178F8
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.min = minDistance;
		def.max = maxDistance;
		def.mode = rolloffMode;
	}

	// Token: 0x06000535 RID: 1333 RVA: 0x00019750 File Offset: 0x00017950
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float pitch, float minDistance, float maxDistance)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.min = minDistance;
		def.max = maxDistance;
	}

	// Token: 0x06000536 RID: 1334 RVA: 0x000197A8 File Offset: 0x000179A8
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float pitch, float minDistance, float maxDistance, float dopplerLevel)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
	}

	// Token: 0x06000537 RID: 1335 RVA: 0x00019808 File Offset: 0x00017A08
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float pitch, float minDistance, float maxDistance, float dopplerLevel, float spread)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.spread = spread;
	}

	// Token: 0x06000538 RID: 1336 RVA: 0x00019870 File Offset: 0x00017A70
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float pitch, float minDistance, float maxDistance, float dopplerLevel, float spread, bool bypassEffects)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.spread = spread;
		def.bypassEffects = bypassEffects;
	}

	// Token: 0x06000539 RID: 1337 RVA: 0x000198E4 File Offset: 0x00017AE4
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float dopplerLevel)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.mode = rolloffMode;
	}

	// Token: 0x0600053A RID: 1338 RVA: 0x0001994C File Offset: 0x00017B4C
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float dopplerLevel, float spread)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.mode = rolloffMode;
		def.spread = spread;
	}

	// Token: 0x0600053B RID: 1339 RVA: 0x000199C0 File Offset: 0x00017BC0
	public static void Play(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float dopplerLevel, float spread, bool bypassEffects)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 6;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.spread = spread;
		def.bypassEffects = bypassEffects;
		def.mode = rolloffMode;
	}

	// Token: 0x0600053C RID: 1340 RVA: 0x00019A3C File Offset: 0x00017C3C
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
	}

	// Token: 0x0600053D RID: 1341 RVA: 0x00019A78 File Offset: 0x00017C78
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
	}

	// Token: 0x0600053E RID: 1342 RVA: 0x00019ABC File Offset: 0x00017CBC
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
	}

	// Token: 0x0600053F RID: 1343 RVA: 0x00019B0C File Offset: 0x00017D0C
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float minDistance, float maxDistance)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.min = minDistance;
		def.max = maxDistance;
	}

	// Token: 0x06000540 RID: 1344 RVA: 0x00019B64 File Offset: 0x00017D64
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.min = minDistance;
		def.max = maxDistance;
		def.mode = rolloffMode;
	}

	// Token: 0x06000541 RID: 1345 RVA: 0x00019BC4 File Offset: 0x00017DC4
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, float minDistance, float maxDistance)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.min = minDistance;
		def.max = maxDistance;
	}

	// Token: 0x06000542 RID: 1346 RVA: 0x00019C24 File Offset: 0x00017E24
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, float minDistance, float maxDistance, float dopplerLevel)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
	}

	// Token: 0x06000543 RID: 1347 RVA: 0x00019C8C File Offset: 0x00017E8C
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, float minDistance, float maxDistance, float dopplerLevel, float spread)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.spread = spread;
	}

	// Token: 0x06000544 RID: 1348 RVA: 0x00019D00 File Offset: 0x00017F00
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, float minDistance, float maxDistance, float dopplerLevel, float spread, bool bypassEffects)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.spread = spread;
		def.bypassEffects = bypassEffects;
	}

	// Token: 0x06000545 RID: 1349 RVA: 0x00019D7C File Offset: 0x00017F7C
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float dopplerLevel)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.mode = rolloffMode;
	}

	// Token: 0x06000546 RID: 1350 RVA: 0x00019DF0 File Offset: 0x00017FF0
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float dopplerLevel, float spread)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.mode = rolloffMode;
		def.spread = spread;
	}

	// Token: 0x06000547 RID: 1351 RVA: 0x00019E6C File Offset: 0x0001806C
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float dopplerLevel, float spread, bool bypassEffects)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.localRotation = rotation;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.spread = spread;
		def.bypassEffects = bypassEffects;
		def.mode = rolloffMode;
	}

	// Token: 0x06000548 RID: 1352 RVA: 0x00019EF0 File Offset: 0x000180F0
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
	}

	// Token: 0x06000549 RID: 1353 RVA: 0x00019F24 File Offset: 0x00018124
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
	}

	// Token: 0x0600054A RID: 1354 RVA: 0x00019F60 File Offset: 0x00018160
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, int priority)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.priority = priority;
	}

	// Token: 0x0600054B RID: 1355 RVA: 0x00019FA4 File Offset: 0x000181A4
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float pitch)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
	}

	// Token: 0x0600054C RID: 1356 RVA: 0x00019FE8 File Offset: 0x000181E8
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float minDistance, float maxDistance)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.min = minDistance;
		def.max = maxDistance;
	}

	// Token: 0x0600054D RID: 1357 RVA: 0x0001A038 File Offset: 0x00018238
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.min = minDistance;
		def.max = maxDistance;
		def.mode = rolloffMode;
	}

	// Token: 0x0600054E RID: 1358 RVA: 0x0001A090 File Offset: 0x00018290
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float pitch, float minDistance, float maxDistance)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.min = minDistance;
		def.max = maxDistance;
	}

	// Token: 0x0600054F RID: 1359 RVA: 0x0001A0E8 File Offset: 0x000182E8
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float pitch, float minDistance, float maxDistance, int priority)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.min = minDistance;
		def.max = maxDistance;
		def.priority = priority;
	}

	// Token: 0x06000550 RID: 1360 RVA: 0x0001A148 File Offset: 0x00018348
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float pitch, float minDistance, float maxDistance, float dopplerLevel)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
	}

	// Token: 0x06000551 RID: 1361 RVA: 0x0001A1A8 File Offset: 0x000183A8
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float pitch, float minDistance, float maxDistance, float dopplerLevel, float spread)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.spread = spread;
	}

	// Token: 0x06000552 RID: 1362 RVA: 0x0001A210 File Offset: 0x00018410
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float pitch, float minDistance, float maxDistance, float dopplerLevel, float spread, bool bypassEffects)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.spread = spread;
		def.bypassEffects = bypassEffects;
	}

	// Token: 0x06000553 RID: 1363 RVA: 0x0001A284 File Offset: 0x00018484
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float dopplerLevel)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.mode = rolloffMode;
	}

	// Token: 0x06000554 RID: 1364 RVA: 0x0001A2EC File Offset: 0x000184EC
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float dopplerLevel, float spread)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.mode = rolloffMode;
		def.spread = spread;
	}

	// Token: 0x06000555 RID: 1365 RVA: 0x0001A360 File Offset: 0x00018560
	public static void PlayLocal(this global::UnityEngine.AudioClip clip, global::UnityEngine.Transform on, global::UnityEngine.Vector3 position, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float dopplerLevel, float spread, bool bypassEffects)
	{
		global::SoundPool.Settings def = global::SoundPool.DEF;
		def.SelectRoot = 2;
		def.parent = on;
		def.localPosition = position;
		def.clip = clip;
		def.volume = volume;
		def.pitch = pitch;
		def.doppler = dopplerLevel;
		def.min = minDistance;
		def.max = maxDistance;
		def.spread = spread;
		def.bypassEffects = bypassEffects;
		def.mode = rolloffMode;
	}

	// Token: 0x040004C7 RID: 1223
	private const sbyte SelectRoot_Attach = 2;

	// Token: 0x040004C8 RID: 1224
	private const sbyte SelectRoot_Camera = 1;

	// Token: 0x040004C9 RID: 1225
	private const sbyte SelectRoot_Default = 0;

	// Token: 0x040004CA RID: 1226
	private const sbyte SelectRoot_Camera_WorldOffset = 5;

	// Token: 0x040004CB RID: 1227
	private const sbyte SelectRoot_Attach_WorldOffset = 6;

	// Token: 0x040004CC RID: 1228
	private const string goName = "zzz-soundpoolnode";

	// Token: 0x040004CD RID: 1229
	private const float logarithmicMaxScale = 2f;

	// Token: 0x040004CE RID: 1230
	private static bool _enabled;

	// Token: 0x040004CF RID: 1231
	private static bool _quitting;

	// Token: 0x040004D0 RID: 1232
	private static readonly global::SoundPool.Root playingAttached = new global::SoundPool.Root(global::SoundPool.RootID.PLAYING_ATTACHED);

	// Token: 0x040004D1 RID: 1233
	private static readonly global::SoundPool.Root playingCamera = new global::SoundPool.Root(global::SoundPool.RootID.PLAYING_CAMERA);

	// Token: 0x040004D2 RID: 1234
	private static readonly global::SoundPool.Root playing = new global::SoundPool.Root(global::SoundPool.RootID.PLAYING);

	// Token: 0x040004D3 RID: 1235
	private static readonly global::SoundPool.Root reserved = new global::SoundPool.Root(global::SoundPool.RootID.RESERVED);

	// Token: 0x040004D4 RID: 1236
	private static bool firstLeak = false;

	// Token: 0x040004D5 RID: 1237
	private static bool hadFirstLeak;

	// Token: 0x040004D6 RID: 1238
	private static readonly global::System.Type[] goTypes = new global::System.Type[]
	{
		typeof(global::UnityEngine.AudioSource)
	};

	// Token: 0x040004D7 RID: 1239
	private static readonly global::SoundPool.Settings DEF = new global::SoundPool.Settings
	{
		volume = 1f,
		pitch = 1f,
		mode = 1,
		min = 1f,
		max = 500f,
		panLevel = 1f,
		doppler = 1f,
		priority = 0x80,
		localRotation = global::UnityEngine.Quaternion.identity
	};

	// Token: 0x020000FB RID: 251
	private struct Settings
	{
		// Token: 0x06000556 RID: 1366 RVA: 0x0001A3DC File Offset: 0x000185DC
		public static explicit operator global::SoundPool.Settings(global::SoundPool.PlayerShared player)
		{
			global::SoundPool.Settings def = global::SoundPool.DEF;
			def.clip = player.clip;
			def.volume = player.volume;
			def.pitch = player.pitch;
			def.priority = player.priority;
			return def;
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x0001A428 File Offset: 0x00018628
		public static explicit operator global::SoundPool.Settings(global::SoundPool.Player3D player)
		{
			global::SoundPool.Settings result = (global::SoundPool.Settings)player.super;
			result.doppler = player.dopplerLevel;
			result.min = player.minDistance;
			result.max = player.maxDistance;
			result.panLevel = player.panLevel;
			result.spread = player.spread;
			result.mode = player.rolloffMode;
			result.bypassEffects = player.bypassEffects;
			result.SelectRoot = ((!player.cameraSticky) ? 0 : 5);
			return result;
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x0001A4C0 File Offset: 0x000186C0
		public static explicit operator global::SoundPool.Settings(global::SoundPool.PlayerLocal player)
		{
			global::SoundPool.Settings result = (global::SoundPool.Settings)player.super;
			result.localPosition = player.localPosition;
			result.localRotation = player.localRotation;
			return result;
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x0001A4F8 File Offset: 0x000186F8
		public static explicit operator global::SoundPool.Settings(global::SoundPool.Player2D player)
		{
			global::SoundPool.Settings result = (global::SoundPool.Settings)player.super;
			result.pan = player.pan;
			return result;
		}

		// Token: 0x040004D8 RID: 1240
		public global::UnityEngine.AudioClip clip;

		// Token: 0x040004D9 RID: 1241
		public global::UnityEngine.Transform parent;

		// Token: 0x040004DA RID: 1242
		public global::UnityEngine.Quaternion localRotation;

		// Token: 0x040004DB RID: 1243
		public global::UnityEngine.Vector3 localPosition;

		// Token: 0x040004DC RID: 1244
		public float volume;

		// Token: 0x040004DD RID: 1245
		public float pitch;

		// Token: 0x040004DE RID: 1246
		public float pan;

		// Token: 0x040004DF RID: 1247
		public float panLevel;

		// Token: 0x040004E0 RID: 1248
		public float min;

		// Token: 0x040004E1 RID: 1249
		public float max;

		// Token: 0x040004E2 RID: 1250
		public float doppler;

		// Token: 0x040004E3 RID: 1251
		public float spread;

		// Token: 0x040004E4 RID: 1252
		public int priority;

		// Token: 0x040004E5 RID: 1253
		public global::UnityEngine.AudioRolloffMode mode;

		// Token: 0x040004E6 RID: 1254
		public sbyte SelectRoot;

		// Token: 0x040004E7 RID: 1255
		public bool bypassEffects;
	}

	// Token: 0x020000FC RID: 252
	public struct PlayerShared
	{
		// Token: 0x0600055A RID: 1370 RVA: 0x0001A524 File Offset: 0x00018724
		public PlayerShared(global::UnityEngine.AudioClip clip)
		{
			this.clip = clip;
			this.volume = global::SoundPool.DEF.volume;
			this.pitch = global::SoundPool.DEF.pitch;
			this.priority = global::SoundPool.DEF.priority;
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x0001A574 File Offset: 0x00018774
		static PlayerShared()
		{
		}

		// Token: 0x040004E8 RID: 1256
		public static readonly global::SoundPool.PlayerShared Default = new global::SoundPool.PlayerShared
		{
			volume = global::SoundPool.DEF.volume,
			pitch = global::SoundPool.DEF.pitch,
			priority = global::SoundPool.DEF.priority
		};

		// Token: 0x040004E9 RID: 1257
		public global::UnityEngine.AudioClip clip;

		// Token: 0x040004EA RID: 1258
		public float volume;

		// Token: 0x040004EB RID: 1259
		public float pitch;

		// Token: 0x040004EC RID: 1260
		public int priority;
	}

	// Token: 0x020000FD RID: 253
	public struct Player3D
	{
		// Token: 0x0600055C RID: 1372 RVA: 0x0001A5C4 File Offset: 0x000187C4
		public Player3D(global::UnityEngine.AudioClip clip)
		{
			this.super = new global::SoundPool.PlayerShared(clip);
			this.minDistance = global::SoundPool.DEF.min;
			this.maxDistance = global::SoundPool.DEF.max;
			this.spread = global::SoundPool.DEF.spread;
			this.dopplerLevel = global::SoundPool.DEF.doppler;
			this.panLevel = global::SoundPool.DEF.panLevel;
			this.rolloffMode = global::SoundPool.DEF.mode;
			this.bypassEffects = global::SoundPool.DEF.bypassEffects;
			this.cameraSticky = false;
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x0001A66C File Offset: 0x0001886C
		static Player3D()
		{
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x0600055E RID: 1374 RVA: 0x0001A70C File Offset: 0x0001890C
		// (set) Token: 0x0600055F RID: 1375 RVA: 0x0001A71C File Offset: 0x0001891C
		public float volume
		{
			get
			{
				return this.super.volume;
			}
			set
			{
				this.super.volume = value;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000560 RID: 1376 RVA: 0x0001A72C File Offset: 0x0001892C
		// (set) Token: 0x06000561 RID: 1377 RVA: 0x0001A73C File Offset: 0x0001893C
		public float pitch
		{
			get
			{
				return this.super.pitch;
			}
			set
			{
				this.super.pitch = value;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000562 RID: 1378 RVA: 0x0001A74C File Offset: 0x0001894C
		// (set) Token: 0x06000563 RID: 1379 RVA: 0x0001A75C File Offset: 0x0001895C
		public int priority
		{
			get
			{
				return this.super.priority;
			}
			set
			{
				this.super.priority = value;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000564 RID: 1380 RVA: 0x0001A76C File Offset: 0x0001896C
		// (set) Token: 0x06000565 RID: 1381 RVA: 0x0001A77C File Offset: 0x0001897C
		public global::UnityEngine.AudioClip clip
		{
			get
			{
				return this.super.clip;
			}
			set
			{
				this.super.clip = value;
			}
		}

		// Token: 0x040004ED RID: 1261
		public static readonly global::SoundPool.Player3D Default = new global::SoundPool.Player3D
		{
			super = global::SoundPool.PlayerShared.Default,
			minDistance = global::SoundPool.DEF.min,
			maxDistance = global::SoundPool.DEF.max,
			rolloffMode = global::SoundPool.DEF.mode,
			spread = global::SoundPool.DEF.spread,
			dopplerLevel = global::SoundPool.DEF.doppler,
			bypassEffects = global::SoundPool.DEF.bypassEffects,
			panLevel = global::SoundPool.DEF.panLevel
		};

		// Token: 0x040004EE RID: 1262
		public global::SoundPool.PlayerShared super;

		// Token: 0x040004EF RID: 1263
		public float minDistance;

		// Token: 0x040004F0 RID: 1264
		public float maxDistance;

		// Token: 0x040004F1 RID: 1265
		public float spread;

		// Token: 0x040004F2 RID: 1266
		public float dopplerLevel;

		// Token: 0x040004F3 RID: 1267
		public float panLevel;

		// Token: 0x040004F4 RID: 1268
		public global::UnityEngine.AudioRolloffMode rolloffMode;

		// Token: 0x040004F5 RID: 1269
		public bool cameraSticky;

		// Token: 0x040004F6 RID: 1270
		public bool bypassEffects;
	}

	// Token: 0x020000FE RID: 254
	public struct PlayerWorld
	{
		// Token: 0x06000566 RID: 1382 RVA: 0x0001A78C File Offset: 0x0001898C
		public PlayerWorld(global::UnityEngine.AudioClip clip)
		{
			this.super = new global::SoundPool.Player3D(clip);
			this.position = default(global::UnityEngine.Vector3);
			this.rotation = global::UnityEngine.Quaternion.identity;
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x0001A7C0 File Offset: 0x000189C0
		static PlayerWorld()
		{
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000568 RID: 1384 RVA: 0x0001A804 File Offset: 0x00018A04
		// (set) Token: 0x06000569 RID: 1385 RVA: 0x0001A814 File Offset: 0x00018A14
		public float volume
		{
			get
			{
				return this.super.volume;
			}
			set
			{
				this.super.volume = value;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x0600056A RID: 1386 RVA: 0x0001A824 File Offset: 0x00018A24
		// (set) Token: 0x0600056B RID: 1387 RVA: 0x0001A834 File Offset: 0x00018A34
		public float pitch
		{
			get
			{
				return this.super.pitch;
			}
			set
			{
				this.super.pitch = value;
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x0600056C RID: 1388 RVA: 0x0001A844 File Offset: 0x00018A44
		// (set) Token: 0x0600056D RID: 1389 RVA: 0x0001A854 File Offset: 0x00018A54
		public int priority
		{
			get
			{
				return this.super.priority;
			}
			set
			{
				this.super.priority = value;
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x0600056E RID: 1390 RVA: 0x0001A864 File Offset: 0x00018A64
		// (set) Token: 0x0600056F RID: 1391 RVA: 0x0001A874 File Offset: 0x00018A74
		public global::UnityEngine.AudioClip clip
		{
			get
			{
				return this.super.clip;
			}
			set
			{
				this.super.clip = value;
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000570 RID: 1392 RVA: 0x0001A884 File Offset: 0x00018A84
		// (set) Token: 0x06000571 RID: 1393 RVA: 0x0001A894 File Offset: 0x00018A94
		public float minDistance
		{
			get
			{
				return this.super.minDistance;
			}
			set
			{
				this.super.minDistance = value;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000572 RID: 1394 RVA: 0x0001A8A4 File Offset: 0x00018AA4
		// (set) Token: 0x06000573 RID: 1395 RVA: 0x0001A8B4 File Offset: 0x00018AB4
		public float maxDistance
		{
			get
			{
				return this.super.maxDistance;
			}
			set
			{
				this.super.maxDistance = value;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000574 RID: 1396 RVA: 0x0001A8C4 File Offset: 0x00018AC4
		// (set) Token: 0x06000575 RID: 1397 RVA: 0x0001A8D4 File Offset: 0x00018AD4
		public float spread
		{
			get
			{
				return this.super.spread;
			}
			set
			{
				this.super.spread = value;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000576 RID: 1398 RVA: 0x0001A8E4 File Offset: 0x00018AE4
		// (set) Token: 0x06000577 RID: 1399 RVA: 0x0001A8F4 File Offset: 0x00018AF4
		public float dopplerLevel
		{
			get
			{
				return this.super.dopplerLevel;
			}
			set
			{
				this.super.dopplerLevel = value;
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000578 RID: 1400 RVA: 0x0001A904 File Offset: 0x00018B04
		// (set) Token: 0x06000579 RID: 1401 RVA: 0x0001A914 File Offset: 0x00018B14
		public float panLevel
		{
			get
			{
				return this.super.panLevel;
			}
			set
			{
				this.super.panLevel = value;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x0600057A RID: 1402 RVA: 0x0001A924 File Offset: 0x00018B24
		// (set) Token: 0x0600057B RID: 1403 RVA: 0x0001A934 File Offset: 0x00018B34
		public global::UnityEngine.AudioRolloffMode rolloffMode
		{
			get
			{
				return this.super.rolloffMode;
			}
			set
			{
				this.super.rolloffMode = value;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600057C RID: 1404 RVA: 0x0001A944 File Offset: 0x00018B44
		// (set) Token: 0x0600057D RID: 1405 RVA: 0x0001A954 File Offset: 0x00018B54
		public bool bypassEffects
		{
			get
			{
				return this.super.bypassEffects;
			}
			set
			{
				this.super.bypassEffects = value;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x0600057E RID: 1406 RVA: 0x0001A964 File Offset: 0x00018B64
		// (set) Token: 0x0600057F RID: 1407 RVA: 0x0001A974 File Offset: 0x00018B74
		public bool cameraSticky
		{
			get
			{
				return this.super.cameraSticky;
			}
			set
			{
				this.super.cameraSticky = value;
			}
		}

		// Token: 0x040004F7 RID: 1271
		public static readonly global::SoundPool.PlayerWorld Default = new global::SoundPool.PlayerWorld
		{
			super = global::SoundPool.Player3D.Default,
			position = default(global::UnityEngine.Vector3),
			rotation = global::UnityEngine.Quaternion.identity
		};

		// Token: 0x040004F8 RID: 1272
		public global::SoundPool.Player3D super;

		// Token: 0x040004F9 RID: 1273
		public global::UnityEngine.Vector3 position;

		// Token: 0x040004FA RID: 1274
		public global::UnityEngine.Quaternion rotation;
	}

	// Token: 0x020000FF RID: 255
	public struct PlayerLocal
	{
		// Token: 0x06000580 RID: 1408 RVA: 0x0001A984 File Offset: 0x00018B84
		public PlayerLocal(global::UnityEngine.AudioClip clip)
		{
			this.super = new global::SoundPool.Player3D(clip);
			this.localPosition = default(global::UnityEngine.Vector3);
			this.localRotation = global::UnityEngine.Quaternion.identity;
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x0001A9B8 File Offset: 0x00018BB8
		static PlayerLocal()
		{
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000582 RID: 1410 RVA: 0x0001A9FC File Offset: 0x00018BFC
		// (set) Token: 0x06000583 RID: 1411 RVA: 0x0001AA0C File Offset: 0x00018C0C
		public float volume
		{
			get
			{
				return this.super.volume;
			}
			set
			{
				this.super.volume = value;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000584 RID: 1412 RVA: 0x0001AA1C File Offset: 0x00018C1C
		// (set) Token: 0x06000585 RID: 1413 RVA: 0x0001AA2C File Offset: 0x00018C2C
		public float pitch
		{
			get
			{
				return this.super.pitch;
			}
			set
			{
				this.super.pitch = value;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000586 RID: 1414 RVA: 0x0001AA3C File Offset: 0x00018C3C
		// (set) Token: 0x06000587 RID: 1415 RVA: 0x0001AA4C File Offset: 0x00018C4C
		public int priority
		{
			get
			{
				return this.super.priority;
			}
			set
			{
				this.super.priority = value;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000588 RID: 1416 RVA: 0x0001AA5C File Offset: 0x00018C5C
		// (set) Token: 0x06000589 RID: 1417 RVA: 0x0001AA6C File Offset: 0x00018C6C
		public global::UnityEngine.AudioClip clip
		{
			get
			{
				return this.super.clip;
			}
			set
			{
				this.super.clip = value;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600058A RID: 1418 RVA: 0x0001AA7C File Offset: 0x00018C7C
		// (set) Token: 0x0600058B RID: 1419 RVA: 0x0001AA8C File Offset: 0x00018C8C
		public float minDistance
		{
			get
			{
				return this.super.minDistance;
			}
			set
			{
				this.super.minDistance = value;
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600058C RID: 1420 RVA: 0x0001AA9C File Offset: 0x00018C9C
		// (set) Token: 0x0600058D RID: 1421 RVA: 0x0001AAAC File Offset: 0x00018CAC
		public float maxDistance
		{
			get
			{
				return this.super.maxDistance;
			}
			set
			{
				this.super.maxDistance = value;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600058E RID: 1422 RVA: 0x0001AABC File Offset: 0x00018CBC
		// (set) Token: 0x0600058F RID: 1423 RVA: 0x0001AACC File Offset: 0x00018CCC
		public float spread
		{
			get
			{
				return this.super.spread;
			}
			set
			{
				this.super.spread = value;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000590 RID: 1424 RVA: 0x0001AADC File Offset: 0x00018CDC
		// (set) Token: 0x06000591 RID: 1425 RVA: 0x0001AAEC File Offset: 0x00018CEC
		public float dopplerLevel
		{
			get
			{
				return this.super.dopplerLevel;
			}
			set
			{
				this.super.dopplerLevel = value;
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000592 RID: 1426 RVA: 0x0001AAFC File Offset: 0x00018CFC
		// (set) Token: 0x06000593 RID: 1427 RVA: 0x0001AB0C File Offset: 0x00018D0C
		public float panLevel
		{
			get
			{
				return this.super.panLevel;
			}
			set
			{
				this.super.panLevel = value;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000594 RID: 1428 RVA: 0x0001AB1C File Offset: 0x00018D1C
		// (set) Token: 0x06000595 RID: 1429 RVA: 0x0001AB2C File Offset: 0x00018D2C
		public global::UnityEngine.AudioRolloffMode rolloffMode
		{
			get
			{
				return this.super.rolloffMode;
			}
			set
			{
				this.super.rolloffMode = value;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000596 RID: 1430 RVA: 0x0001AB3C File Offset: 0x00018D3C
		// (set) Token: 0x06000597 RID: 1431 RVA: 0x0001AB4C File Offset: 0x00018D4C
		public bool bypassEffects
		{
			get
			{
				return this.super.bypassEffects;
			}
			set
			{
				this.super.bypassEffects = value;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000598 RID: 1432 RVA: 0x0001AB5C File Offset: 0x00018D5C
		// (set) Token: 0x06000599 RID: 1433 RVA: 0x0001AB6C File Offset: 0x00018D6C
		public bool cameraSticky
		{
			get
			{
				return this.super.cameraSticky;
			}
			set
			{
				this.super.cameraSticky = value;
			}
		}

		// Token: 0x040004FB RID: 1275
		public static readonly global::SoundPool.PlayerLocal Default = new global::SoundPool.PlayerLocal
		{
			super = global::SoundPool.Player3D.Default,
			localPosition = default(global::UnityEngine.Vector3),
			localRotation = global::UnityEngine.Quaternion.identity
		};

		// Token: 0x040004FC RID: 1276
		public global::SoundPool.Player3D super;

		// Token: 0x040004FD RID: 1277
		public global::UnityEngine.Vector3 localPosition;

		// Token: 0x040004FE RID: 1278
		public global::UnityEngine.Quaternion localRotation;
	}

	// Token: 0x02000100 RID: 256
	public struct PlayerChild
	{
		// Token: 0x0600059A RID: 1434 RVA: 0x0001AB7C File Offset: 0x00018D7C
		public PlayerChild(global::UnityEngine.AudioClip clip)
		{
			this.super = new global::SoundPool.PlayerLocal(clip);
			this.parent = null;
			this.unglue = false;
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x0001AB98 File Offset: 0x00018D98
		static PlayerChild()
		{
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x0001ABC0 File Offset: 0x00018DC0
		// (set) Token: 0x0600059D RID: 1437 RVA: 0x0001ABD0 File Offset: 0x00018DD0
		public float volume
		{
			get
			{
				return this.super.volume;
			}
			set
			{
				this.super.volume = value;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600059E RID: 1438 RVA: 0x0001ABE0 File Offset: 0x00018DE0
		// (set) Token: 0x0600059F RID: 1439 RVA: 0x0001ABF0 File Offset: 0x00018DF0
		public float pitch
		{
			get
			{
				return this.super.pitch;
			}
			set
			{
				this.super.pitch = value;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060005A0 RID: 1440 RVA: 0x0001AC00 File Offset: 0x00018E00
		// (set) Token: 0x060005A1 RID: 1441 RVA: 0x0001AC10 File Offset: 0x00018E10
		public int priority
		{
			get
			{
				return this.super.priority;
			}
			set
			{
				this.super.priority = value;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060005A2 RID: 1442 RVA: 0x0001AC20 File Offset: 0x00018E20
		// (set) Token: 0x060005A3 RID: 1443 RVA: 0x0001AC30 File Offset: 0x00018E30
		public global::UnityEngine.AudioClip clip
		{
			get
			{
				return this.super.clip;
			}
			set
			{
				this.super.clip = value;
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060005A4 RID: 1444 RVA: 0x0001AC40 File Offset: 0x00018E40
		// (set) Token: 0x060005A5 RID: 1445 RVA: 0x0001AC50 File Offset: 0x00018E50
		public float minDistance
		{
			get
			{
				return this.super.minDistance;
			}
			set
			{
				this.super.minDistance = value;
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060005A6 RID: 1446 RVA: 0x0001AC60 File Offset: 0x00018E60
		// (set) Token: 0x060005A7 RID: 1447 RVA: 0x0001AC70 File Offset: 0x00018E70
		public float maxDistance
		{
			get
			{
				return this.super.maxDistance;
			}
			set
			{
				this.super.maxDistance = value;
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060005A8 RID: 1448 RVA: 0x0001AC80 File Offset: 0x00018E80
		// (set) Token: 0x060005A9 RID: 1449 RVA: 0x0001AC90 File Offset: 0x00018E90
		public float spread
		{
			get
			{
				return this.super.spread;
			}
			set
			{
				this.super.spread = value;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060005AA RID: 1450 RVA: 0x0001ACA0 File Offset: 0x00018EA0
		// (set) Token: 0x060005AB RID: 1451 RVA: 0x0001ACB0 File Offset: 0x00018EB0
		public float dopplerLevel
		{
			get
			{
				return this.super.dopplerLevel;
			}
			set
			{
				this.super.dopplerLevel = value;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060005AC RID: 1452 RVA: 0x0001ACC0 File Offset: 0x00018EC0
		// (set) Token: 0x060005AD RID: 1453 RVA: 0x0001ACD0 File Offset: 0x00018ED0
		public global::UnityEngine.AudioRolloffMode rolloffMode
		{
			get
			{
				return this.super.rolloffMode;
			}
			set
			{
				this.super.rolloffMode = value;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060005AE RID: 1454 RVA: 0x0001ACE0 File Offset: 0x00018EE0
		// (set) Token: 0x060005AF RID: 1455 RVA: 0x0001ACF0 File Offset: 0x00018EF0
		public bool bypassEffects
		{
			get
			{
				return this.super.bypassEffects;
			}
			set
			{
				this.super.bypassEffects = value;
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x0001AD00 File Offset: 0x00018F00
		// (set) Token: 0x060005B1 RID: 1457 RVA: 0x0001AD10 File Offset: 0x00018F10
		public bool cameraSticky
		{
			get
			{
				return this.super.cameraSticky;
			}
			set
			{
				this.super.cameraSticky = value;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060005B2 RID: 1458 RVA: 0x0001AD20 File Offset: 0x00018F20
		// (set) Token: 0x060005B3 RID: 1459 RVA: 0x0001AD30 File Offset: 0x00018F30
		public global::UnityEngine.Vector3 localPosition
		{
			get
			{
				return this.super.localPosition;
			}
			set
			{
				this.super.localPosition = value;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060005B4 RID: 1460 RVA: 0x0001AD40 File Offset: 0x00018F40
		// (set) Token: 0x060005B5 RID: 1461 RVA: 0x0001AD50 File Offset: 0x00018F50
		public global::UnityEngine.Quaternion localRotation
		{
			get
			{
				return this.super.localRotation;
			}
			set
			{
				this.super.localRotation = value;
			}
		}

		// Token: 0x040004FF RID: 1279
		public static readonly global::SoundPool.PlayerChild Default = new global::SoundPool.PlayerChild
		{
			super = global::SoundPool.PlayerLocal.Default
		};

		// Token: 0x04000500 RID: 1280
		public global::SoundPool.PlayerLocal super;

		// Token: 0x04000501 RID: 1281
		public bool unglue;

		// Token: 0x04000502 RID: 1282
		public global::UnityEngine.Transform parent;
	}

	// Token: 0x02000101 RID: 257
	public struct Player2D
	{
		// Token: 0x060005B6 RID: 1462 RVA: 0x0001AD60 File Offset: 0x00018F60
		public Player2D(global::UnityEngine.AudioClip clip)
		{
			this.super = new global::SoundPool.PlayerShared(clip);
			this.pan = global::SoundPool.DEF.pan;
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x0001AD8C File Offset: 0x00018F8C
		static Player2D()
		{
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060005B8 RID: 1464 RVA: 0x0001ADC4 File Offset: 0x00018FC4
		// (set) Token: 0x060005B9 RID: 1465 RVA: 0x0001ADD4 File Offset: 0x00018FD4
		public float volume
		{
			get
			{
				return this.super.volume;
			}
			set
			{
				this.super.volume = value;
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060005BA RID: 1466 RVA: 0x0001ADE4 File Offset: 0x00018FE4
		// (set) Token: 0x060005BB RID: 1467 RVA: 0x0001ADF4 File Offset: 0x00018FF4
		public float pitch
		{
			get
			{
				return this.super.pitch;
			}
			set
			{
				this.super.pitch = value;
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x0001AE04 File Offset: 0x00019004
		// (set) Token: 0x060005BD RID: 1469 RVA: 0x0001AE14 File Offset: 0x00019014
		public int priority
		{
			get
			{
				return this.super.priority;
			}
			set
			{
				this.super.priority = value;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060005BE RID: 1470 RVA: 0x0001AE24 File Offset: 0x00019024
		// (set) Token: 0x060005BF RID: 1471 RVA: 0x0001AE34 File Offset: 0x00019034
		public global::UnityEngine.AudioClip clip
		{
			get
			{
				return this.super.clip;
			}
			set
			{
				this.super.clip = value;
			}
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0001AE44 File Offset: 0x00019044
		public void Play()
		{
			this.Play(this.clip);
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0001AE54 File Offset: 0x00019054
		public void Play(global::UnityEngine.AudioClip clip)
		{
			if (!clip)
			{
				return;
			}
		}

		// Token: 0x04000503 RID: 1283
		public static readonly global::SoundPool.Player2D Default = new global::SoundPool.Player2D
		{
			super = global::SoundPool.PlayerShared.Default,
			pan = global::SoundPool.DEF.pan
		};

		// Token: 0x04000504 RID: 1284
		public global::SoundPool.PlayerShared super;

		// Token: 0x04000505 RID: 1285
		public float pan;
	}

	// Token: 0x02000102 RID: 258
	private struct Dir
	{
		// Token: 0x04000506 RID: 1286
		public global::SoundPool.Node node;

		// Token: 0x04000507 RID: 1287
		public bool has;
	}

	// Token: 0x02000103 RID: 259
	private struct Way
	{
		// Token: 0x04000508 RID: 1288
		public global::SoundPool.Dir prev;

		// Token: 0x04000509 RID: 1289
		public global::SoundPool.Dir next;
	}

	// Token: 0x02000104 RID: 260
	private enum RootID : sbyte
	{
		// Token: 0x0400050B RID: 1291
		LIMBO,
		// Token: 0x0400050C RID: 1292
		PLAYING_ATTACHED = -3,
		// Token: 0x0400050D RID: 1293
		PLAYING_CAMERA,
		// Token: 0x0400050E RID: 1294
		PLAYING,
		// Token: 0x0400050F RID: 1295
		RESERVED = 1,
		// Token: 0x04000510 RID: 1296
		DISPOSED
	}

	// Token: 0x02000105 RID: 261
	private class Root
	{
		// Token: 0x060005C2 RID: 1474 RVA: 0x0001AE64 File Offset: 0x00019064
		public Root(global::SoundPool.RootID id)
		{
			this.id = id;
		}

		// Token: 0x04000511 RID: 1297
		public int count;

		// Token: 0x04000512 RID: 1298
		public global::SoundPool.Dir first;

		// Token: 0x04000513 RID: 1299
		public readonly global::SoundPool.RootID id;
	}

	// Token: 0x02000106 RID: 262
	private static class NodeGC
	{
		// Token: 0x060005C3 RID: 1475 RVA: 0x0001AE74 File Offset: 0x00019074
		public static void JOIN()
		{
			global::UnityEngine.Transform[] array = null;
			bool flag = false;
			object destroyNextPumpLock = global::SoundPool.NodeGC.GCDAT.destroyNextPumpLock;
			lock (destroyNextPumpLock)
			{
				if (global::SoundPool.NodeGC.GCDAT.destroyNextQueued)
				{
					flag = true;
					array = global::SoundPool.NodeGC.GCDAT.destroyTheseNextPump.ToArray();
					global::SoundPool.NodeGC.GCDAT.destroyTheseNextPump.Clear();
					global::SoundPool.NodeGC.GCDAT.destroyNextQueued = false;
				}
			}
			if (flag)
			{
				foreach (global::UnityEngine.Transform transform in array)
				{
					if (transform)
					{
						global::UnityEngine.Object.Destroy(transform.gameObject);
					}
				}
				global::UnityEngine.Debug.LogWarning("There were " + array.Length + " SoundPool nodes leaked!. Cleaned them up.");
			}
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0001AF3C File Offset: 0x0001913C
		public static void LEAK(global::UnityEngine.Transform transform)
		{
			object destroyNextPumpLock = global::SoundPool.NodeGC.GCDAT.destroyNextPumpLock;
			lock (destroyNextPumpLock)
			{
				global::SoundPool.NodeGC.GCDAT.destroyNextQueued = true;
				global::SoundPool.NodeGC.GCDAT.destroyTheseNextPump.Add(transform);
			}
		}

		// Token: 0x02000107 RID: 263
		private static class GCDAT
		{
			// Token: 0x060005C5 RID: 1477 RVA: 0x0001AF90 File Offset: 0x00019190
			static GCDAT()
			{
				global::SoundPool.firstLeak = true;
			}

			// Token: 0x04000514 RID: 1300
			public static readonly global::System.Collections.Generic.List<global::UnityEngine.Transform> destroyTheseNextPump = new global::System.Collections.Generic.List<global::UnityEngine.Transform>();

			// Token: 0x04000515 RID: 1301
			public static readonly object destroyNextPumpLock = new object();

			// Token: 0x04000516 RID: 1302
			public static bool destroyNextQueued;
		}
	}

	// Token: 0x02000108 RID: 264
	private sealed class Node : global::System.IDisposable
	{
		// Token: 0x060005C6 RID: 1478 RVA: 0x0001AFAC File Offset: 0x000191AC
		public Node()
		{
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x0001AFB4 File Offset: 0x000191B4
		public void Reserve()
		{
			switch (this.rootID)
			{
			case global::SoundPool.RootID.LIMBO:
				break;
			case global::SoundPool.RootID.RESERVED:
			case global::SoundPool.RootID.DISPOSED:
				return;
			default:
				this.audio.Stop();
				this.audio.enabled = false;
				this.audio.clip = null;
				this.parent = null;
				if (this.way.next.has)
				{
					this.way.next.node.way.prev = this.way.prev;
				}
				if (this.way.prev.has)
				{
					this.way.prev.node.way.next = this.way.next;
				}
				else
				{
					this.root.first = this.way.next;
				}
				this.root.count--;
				this.way = default(global::SoundPool.Way);
				break;
			}
			this.root = global::SoundPool.reserved;
			this.rootID = global::SoundPool.RootID.RESERVED;
			this.way.next = global::SoundPool.reserved.first;
			if (this.way.next.has)
			{
				this.way.next.node.way.prev.has = true;
				this.way.next.node.way.prev.node = this;
			}
			global::SoundPool.reserved.first.has = true;
			global::SoundPool.reserved.first.node = this;
			global::SoundPool.reserved.count++;
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x0001B174 File Offset: 0x00019374
		public void EnterLimbo()
		{
			switch (this.rootID)
			{
			case global::SoundPool.RootID.LIMBO:
			case global::SoundPool.RootID.DISPOSED:
				return;
			case global::SoundPool.RootID.RESERVED:
				break;
			default:
				this.audio.Stop();
				this.audio.enabled = false;
				this.audio.clip = null;
				this.parent = null;
				break;
			}
			if (this.way.prev.has)
			{
				this.way.prev.node.way.next = this.way.next;
			}
			else
			{
				this.root.first = this.way.next;
			}
			if (this.way.next.has)
			{
				this.way.next.node.way.prev = this.way.prev;
			}
			this.root.count--;
			this.way = default(global::SoundPool.Way);
			this.root = null;
			this.rootID = global::SoundPool.RootID.LIMBO;
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x0001B294 File Offset: 0x00019494
		public void Bind()
		{
			this.way.prev = default(global::SoundPool.Dir);
			this.way.next = this.root.first;
			this.root.first.has = true;
			this.root.first.node = this;
			if (this.way.next.has)
			{
				this.way.next.node.way.prev.has = true;
				this.way.next.node.way.prev.node = this;
			}
			this.root.count++;
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0001B358 File Offset: 0x00019558
		public void Dispose()
		{
			switch (this.rootID)
			{
			case global::SoundPool.RootID.LIMBO:
				goto IL_2F;
			case global::SoundPool.RootID.DISPOSED:
				return;
			}
			this.EnterLimbo();
			IL_2F:
			global::UnityEngine.Object.Destroy(this.transform.gameObject);
			this.transform = null;
			this.audio = null;
			this.rootID = global::SoundPool.RootID.DISPOSED;
			global::System.GC.SuppressFinalize(this);
			global::System.GC.KeepAlive(this);
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0001B3C8 File Offset: 0x000195C8
		~Node()
		{
			if ((int)this.rootID != 2)
			{
				global::SoundPool.NodeGC.LEAK(this.transform);
			}
			this.transform = null;
			this.audio = null;
		}

		// Token: 0x04000517 RID: 1303
		public global::UnityEngine.AudioSource audio;

		// Token: 0x04000518 RID: 1304
		public global::UnityEngine.Transform transform;

		// Token: 0x04000519 RID: 1305
		public global::SoundPool.Way way;

		// Token: 0x0400051A RID: 1306
		public global::SoundPool.RootID rootID;

		// Token: 0x0400051B RID: 1307
		public global::SoundPool.Root root;

		// Token: 0x0400051C RID: 1308
		public global::UnityEngine.Vector3 translation;

		// Token: 0x0400051D RID: 1309
		public global::UnityEngine.Quaternion rotation;

		// Token: 0x0400051E RID: 1310
		public global::UnityEngine.Transform parent;
	}
}
