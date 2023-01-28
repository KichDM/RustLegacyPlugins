using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000EE RID: 238
public class EngineSoundLoop : global::UnityEngine.ScriptableObject
{
	// Token: 0x060004B1 RID: 1201 RVA: 0x000161C0 File Offset: 0x000143C0
	public EngineSoundLoop()
	{
	}

	// Token: 0x170000AA RID: 170
	// (get) Token: 0x060004B2 RID: 1202 RVA: 0x000162E0 File Offset: 0x000144E0
	private float volumeD
	{
		get
		{
			return this._dUpper.volume * 0.4f;
		}
	}

	// Token: 0x170000AB RID: 171
	// (get) Token: 0x060004B3 RID: 1203 RVA: 0x000162F4 File Offset: 0x000144F4
	private float volumeF
	{
		get
		{
			return this._fMidHigh.volume * 0.4f;
		}
	}

	// Token: 0x170000AC RID: 172
	// (get) Token: 0x060004B4 RID: 1204 RVA: 0x00016308 File Offset: 0x00014508
	private float volumeE
	{
		get
		{
			return this._eMidLow.volume * 0.4f;
		}
	}

	// Token: 0x170000AD RID: 173
	// (get) Token: 0x060004B5 RID: 1205 RVA: 0x0001631C File Offset: 0x0001451C
	private float volumeK
	{
		get
		{
			return this._kPassing.volume * 0.7f;
		}
	}

	// Token: 0x170000AE RID: 174
	// (get) Token: 0x060004B6 RID: 1206 RVA: 0x00016330 File Offset: 0x00014530
	private float volumeL
	{
		get
		{
			return this._lLower.volume * 0.4f;
		}
	}

	// Token: 0x060004B7 RID: 1207 RVA: 0x00016344 File Offset: 0x00014544
	private sbyte VolumeFactor(float pitch, out float between)
	{
		between = (pitch - this._volumeFromPitchBase) / this._volumeFromPitchRange;
		if (between >= 1f)
		{
			between = 1f;
			return 1;
		}
		if (between <= 0f)
		{
			between = 0f;
			return -1;
		}
		return 0;
	}

	// Token: 0x060004B8 RID: 1208 RVA: 0x00016390 File Offset: 0x00014590
	private void GearLerp(byte gear, float factor, ref float pitch, ref bool pitchChanged, ref float volume, ref bool volumeChanged)
	{
		int num;
		if (this._gears == null || (num = this._gears.Length) == 0)
		{
			return;
		}
		int num2;
		if (this._topGear < num)
		{
			num2 = this._topGear;
		}
		else
		{
			num2 = num - 1;
		}
		if ((int)gear > num2)
		{
			this._gears[num2].CompareLerp(factor, ref pitch, ref pitchChanged, ref volume, ref volumeChanged);
		}
		else
		{
			this._gears[(int)gear].CompareLerp(factor, ref pitch, ref pitchChanged, ref volume, ref volumeChanged);
		}
	}

	// Token: 0x060004B9 RID: 1209 RVA: 0x0001640C File Offset: 0x0001460C
	public global::EngineSoundLoop.Instance Create(global::UnityEngine.Transform attachTo, global::UnityEngine.Vector3 localPosition)
	{
		if (!attachTo)
		{
			throw new global::UnityEngine.MissingReferenceException("attachTo must not be null or destroyed");
		}
		global::EngineSoundLoop.Instance instance;
		if (this.instances == null)
		{
			this.instances = new global::System.Collections.Generic.Dictionary<global::UnityEngine.Transform, global::EngineSoundLoop.Instance>();
		}
		else if (this.instances.TryGetValue(attachTo, out instance))
		{
			instance.localPosition = localPosition;
			return instance;
		}
		instance = new global::EngineSoundLoop.Instance(attachTo, localPosition, this);
		this.instances[attachTo] = instance;
		return instance;
	}

	// Token: 0x060004BA RID: 1210 RVA: 0x00016480 File Offset: 0x00014680
	public global::EngineSoundLoop.Instance Create(global::UnityEngine.Transform attachTo)
	{
		return this.Create(attachTo, global::UnityEngine.Vector3.zero);
	}

	// Token: 0x060004BB RID: 1211 RVA: 0x00016490 File Offset: 0x00014690
	public global::EngineSoundLoop.Instance CreateWorld(global::UnityEngine.Transform attachTo, global::UnityEngine.Vector3 worldPosition)
	{
		return this.Create(attachTo, attachTo.InverseTransformPoint(worldPosition));
	}

	// Token: 0x060004BC RID: 1212 RVA: 0x000164A0 File Offset: 0x000146A0
	private static float Sinerp(float start, float end, float value)
	{
		float num = global::UnityEngine.Mathf.Sin(value * 1.5707964f);
		return (num > 0f) ? ((num < 1f) ? (end * num + start * (1f - num)) : end) : start;
	}

	// Token: 0x060004BD RID: 1213 RVA: 0x000164EC File Offset: 0x000146EC
	private static float Coserp(float start, float end, float value)
	{
		float num = global::UnityEngine.Mathf.Cos(value * 1.5707964f);
		return (num < 1f) ? ((num > 0f) ? (start * num + end * (1f - num)) : end) : start;
	}

	// Token: 0x04000449 RID: 1097
	private const float kPitchDefault_Idle = 0.7f;

	// Token: 0x0400044A RID: 1098
	private const float kPitchDefault_Start = 0.85f;

	// Token: 0x0400044B RID: 1099
	private const float kPitchDefault_Low = 1.17f;

	// Token: 0x0400044C RID: 1100
	private const float kPitchDefault_Medium = 1.25f;

	// Token: 0x0400044D RID: 1101
	private const float kPitchDefault_High1 = 1.65f;

	// Token: 0x0400044E RID: 1102
	private const float kPitchDefault_High2 = 1.76f;

	// Token: 0x0400044F RID: 1103
	private const float kPitchDefault_High3 = 1.8f;

	// Token: 0x04000450 RID: 1104
	private const float kPitchDefault_High4 = 1.86f;

	// Token: 0x04000451 RID: 1105
	private const float kPitchDefault_Shift = 1.44f;

	// Token: 0x04000452 RID: 1106
	private const float F_PITCH = 0.8f;

	// Token: 0x04000453 RID: 1107
	private const float F_THROTTLE = 0.7f;

	// Token: 0x04000454 RID: 1108
	private const float E_PITCH = 0.89f;

	// Token: 0x04000455 RID: 1109
	private const float E_THROTTLE = 0.8f;

	// Token: 0x04000456 RID: 1110
	private const float sD = 0.4f;

	// Token: 0x04000457 RID: 1111
	private const float sF = 0.4f;

	// Token: 0x04000458 RID: 1112
	private const float sE = 0.4f;

	// Token: 0x04000459 RID: 1113
	private const float sK = 0.7f;

	// Token: 0x0400045A RID: 1114
	private const float sL = 0.4f;

	// Token: 0x0400045B RID: 1115
	private const float F_PITCH_DELTA = 0.19999999f;

	// Token: 0x0400045C RID: 1116
	private const float F_THROTTLE_DELTA = 0.3f;

	// Token: 0x0400045D RID: 1117
	private const float E_PITCH_DELTA = 0.110000014f;

	// Token: 0x0400045E RID: 1118
	private const float E_THROTTLE_DELTA = 0.19999999f;

	// Token: 0x0400045F RID: 1119
	[global::UnityEngine.SerializeField]
	private global::EngineSoundLoop.Phrase _dUpper = new global::EngineSoundLoop.Phrase(0.565f);

	// Token: 0x04000460 RID: 1120
	[global::UnityEngine.SerializeField]
	private global::EngineSoundLoop.Phrase _fMidHigh = new global::EngineSoundLoop.Phrase(0.78f);

	// Token: 0x04000461 RID: 1121
	[global::UnityEngine.SerializeField]
	private global::EngineSoundLoop.Phrase _eMidLow = new global::EngineSoundLoop.Phrase(0.8f);

	// Token: 0x04000462 RID: 1122
	[global::UnityEngine.SerializeField]
	private global::EngineSoundLoop.Phrase _lLower = new global::EngineSoundLoop.Phrase(0.61f);

	// Token: 0x04000463 RID: 1123
	[global::UnityEngine.SerializeField]
	private global::EngineSoundLoop.Phrase _kPassing = new global::EngineSoundLoop.Phrase(0.565f);

	// Token: 0x04000464 RID: 1124
	[global::UnityEngine.SerializeField]
	private global::EngineSoundLoop.Gear _idleShiftUp = new global::EngineSoundLoop.Gear(1.17f, 1.65f);

	// Token: 0x04000465 RID: 1125
	[global::UnityEngine.SerializeField]
	private global::EngineSoundLoop.Gear _shiftUp = new global::EngineSoundLoop.Gear(1.17f, 1.76f);

	// Token: 0x04000466 RID: 1126
	[global::UnityEngine.SerializeField]
	private global::EngineSoundLoop.Gear[] _gears = new global::EngineSoundLoop.Gear[]
	{
		new global::EngineSoundLoop.Gear(0.7f, 1.65f),
		new global::EngineSoundLoop.Gear(0.85f, 1.76f),
		new global::EngineSoundLoop.Gear(1.17f, 1.8f),
		new global::EngineSoundLoop.Gear(1.25f, 1.86f)
	};

	// Token: 0x04000467 RID: 1127
	[global::UnityEngine.SerializeField]
	private global::EngineSoundLoop.Gear _shiftDown = new global::EngineSoundLoop.Gear(1.44f, 1.17f);

	// Token: 0x04000468 RID: 1128
	[global::UnityEngine.SerializeField]
	private float _shiftDuration = 0.1f;

	// Token: 0x04000469 RID: 1129
	[global::UnityEngine.SerializeField]
	private float _volumeFromPitchBase = 0.85f;

	// Token: 0x0400046A RID: 1130
	[global::UnityEngine.SerializeField]
	private float _volumeFromPitchRange = 0.90999997f;

	// Token: 0x0400046B RID: 1131
	[global::UnityEngine.SerializeField]
	private int _topGear = 4;

	// Token: 0x0400046C RID: 1132
	[global::System.NonSerialized]
	private global::System.Collections.Generic.Dictionary<global::UnityEngine.Transform, global::EngineSoundLoop.Instance> instances;

	// Token: 0x020000EF RID: 239
	[global::System.Serializable]
	private class Phrase
	{
		// Token: 0x060004BE RID: 1214 RVA: 0x00016538 File Offset: 0x00014738
		public Phrase()
		{
			this.volume = 1f;
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0001654C File Offset: 0x0001474C
		public Phrase(float volume)
		{
			this.volume = volume;
		}

		// Token: 0x0400046D RID: 1133
		public global::UnityEngine.AudioClip clip;

		// Token: 0x0400046E RID: 1134
		public float volume;
	}

	// Token: 0x020000F0 RID: 240
	[global::System.Serializable]
	private class Gear
	{
		// Token: 0x060004C0 RID: 1216 RVA: 0x0001655C File Offset: 0x0001475C
		public Gear() : this(0.7f, 1.65f)
		{
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00016570 File Offset: 0x00014770
		public Gear(float lower, float upper)
		{
			this.lowVolume = lower;
			this.lowPitch = lower;
			this.highVolume = upper;
			this.highPitch = upper;
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x000165A4 File Offset: 0x000147A4
		public Gear(float lowerPitch, float lowerVolume, float upperPitch, float upperVolume)
		{
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x000165AC File Offset: 0x000147AC
		public void Lerp(float t, out float pitch, out float volume)
		{
			if (t <= 0f)
			{
				pitch = this.lowPitch;
				volume = this.lowVolume;
			}
			else if (t >= 1f)
			{
				pitch = this.highPitch;
				volume = this.highVolume;
			}
			else
			{
				float num = 1f - t;
				pitch = this.lowPitch * num + this.highPitch * t;
				volume = this.lowVolume * num + this.highVolume * t;
			}
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x00016628 File Offset: 0x00014828
		public void CompareLerp(float t, ref float pitch, ref bool pitchChanged, ref float volume, ref bool volumeChanged)
		{
			if (t <= 0f)
			{
				if (pitch != this.lowPitch)
				{
					pitchChanged = true;
					pitch = this.lowPitch;
				}
				if (volume != this.lowVolume)
				{
					volumeChanged = true;
					volume = this.lowVolume;
				}
			}
			else if (t >= 1f)
			{
				if (pitch != this.highPitch)
				{
					pitchChanged = true;
					pitch = this.highPitch;
				}
				if (volume != this.highVolume)
				{
					volumeChanged = true;
					volume = this.highVolume;
				}
			}
			else
			{
				float num = 1f - t;
				float num2 = this.lowPitch * num + this.highPitch * t;
				float num3 = this.lowVolume * num + this.highVolume * t;
				if (pitch != num2)
				{
					pitchChanged = true;
					pitch = num2;
				}
				if (volume != num3)
				{
					volumeChanged = true;
					volume = num3;
				}
			}
		}

		// Token: 0x0400046F RID: 1135
		public float lowPitch;

		// Token: 0x04000470 RID: 1136
		public float lowVolume;

		// Token: 0x04000471 RID: 1137
		public float highPitch;

		// Token: 0x04000472 RID: 1138
		public float highVolume;
	}

	// Token: 0x020000F1 RID: 241
	public class Instance : global::System.IDisposable
	{
		// Token: 0x060004C5 RID: 1221 RVA: 0x00016708 File Offset: 0x00014908
		internal Instance(global::UnityEngine.Transform parent, global::UnityEngine.Vector3 offset, global::EngineSoundLoop loop)
		{
			this.parent = parent;
			this.loop = loop;
			global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject("_EnginePlayer", new global::System.Type[]
			{
				typeof(global::EngineSoundLoopPlayer)
			});
			this.player = gameObject.GetComponent<global::EngineSoundLoopPlayer>();
			this.player.instance = this;
			global::EngineSoundLoop.Instance.Setup(gameObject, ref this.D, ref this.flags, 1, loop._dUpper, 1f);
			global::EngineSoundLoop.Instance.Setup(gameObject, ref this.F, ref this.flags, 2, loop._fMidHigh, 1f);
			global::EngineSoundLoop.Instance.Setup(gameObject, ref this.E, ref this.flags, 4, loop._eMidLow, 1f);
			global::EngineSoundLoop.Instance.Setup(gameObject, ref this.L, ref this.flags, 8, loop._lLower, 1f);
			global::EngineSoundLoop.Instance.Setup(gameObject, ref this.K, ref this.flags, 0x10, loop._kPassing, 0f);
			this._lastVolumeFactor = (this._lastClampedThrottle = (this._lastSinerp = (this._lastPitchFactor = float.NegativeInfinity)));
			this._lastVolumeFactorClamp = sbyte.MinValue;
			this._masterVolume = 1f;
			this._pitch = loop._idleShiftUp.lowVolume;
			this._shiftTime = -3000f;
			this._speedFactor = (this._dVol = (this._fVol = (this._eVol = (this._kVol = (this._throttle = 0f)))));
			this._gear = 0;
			global::UnityEngine.Transform transform = gameObject.transform;
			transform.parent = parent;
			transform.localPosition = offset;
			transform.localRotation = global::UnityEngine.Quaternion.identity;
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x000168AC File Offset: 0x00014AAC
		private static void Setup(global::UnityEngine.GameObject go, ref global::UnityEngine.AudioSource source, ref ushort flags, ushort flag, global::EngineSoundLoop.Phrase phrase, float volumeScalar)
		{
			if (phrase == null || !phrase.clip)
			{
				return;
			}
			source = go.AddComponent<global::UnityEngine.AudioSource>();
			source.playOnAwake = false;
			source.loop = true;
			source.clip = phrase.clip;
			source.volume = phrase.volume * volumeScalar;
			source.dopplerLevel = 0f;
			flags |= flag;
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060004C7 RID: 1223 RVA: 0x0001691C File Offset: 0x00014B1C
		// (set) Token: 0x060004C8 RID: 1224 RVA: 0x0001692C File Offset: 0x00014B2C
		public bool playing
		{
			get
			{
				return (this.flags & 0x60) == 0x40;
			}
			set
			{
				if (value)
				{
					if ((this.flags & 0x60) == 0)
					{
						this.PLAY();
					}
				}
				else if ((this.flags & 0x60) == 0x40)
				{
					this.PAUSE();
				}
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060004C9 RID: 1225 RVA: 0x00016964 File Offset: 0x00014B64
		// (set) Token: 0x060004CA RID: 1226 RVA: 0x0001697C File Offset: 0x00014B7C
		public bool paused
		{
			get
			{
				return (this.flags & 0xA0) == 0x80;
			}
			set
			{
				if (value)
				{
					if ((this.flags & 0xE0) == 0x40)
					{
						this.PAUSE();
					}
				}
				else if ((this.flags & 0xE0) == 0x80)
				{
					this.PLAY();
				}
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060004CB RID: 1227 RVA: 0x000169CC File Offset: 0x00014BCC
		public bool playingOrPaused
		{
			get
			{
				return (this.flags & 0x60) == 0x40 || (this.flags & 0xA0) == 0x80;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060004CC RID: 1228 RVA: 0x00016A00 File Offset: 0x00014C00
		public bool stopped
		{
			get
			{
				return (this.flags & 0xC0) == 0;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x00016A14 File Offset: 0x00014C14
		// (set) Token: 0x060004CE RID: 1230 RVA: 0x00016A1C File Offset: 0x00014C1C
		public float volume
		{
			get
			{
				return this._masterVolume;
			}
			set
			{
				if (value < 0f)
				{
					value = 0f;
				}
				if (this._masterVolume != value)
				{
					this._masterVolume = value;
					if ((this.flags & 0x20) == 0)
					{
						this.UPDATE_MASTER_VOLUME();
					}
				}
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x00016A58 File Offset: 0x00014C58
		public bool hasUpdated
		{
			get
			{
				return (this.flags & 0x400) == 0x400;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x00016A70 File Offset: 0x00014C70
		public bool disposed
		{
			get
			{
				return (this.flags & 0x20) == 0x20;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x00016A80 File Offset: 0x00014C80
		public bool anySounds
		{
			get
			{
				return (this.flags & 0x1F) != 0 && (this.flags & 0x20) == 0;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060004D2 RID: 1234 RVA: 0x00016AA0 File Offset: 0x00014CA0
		public float speedFactor
		{
			get
			{
				return this._speedFactor;
			}
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00016AA8 File Offset: 0x00014CA8
		public void Update(float speedFactor, float throttle)
		{
			int num = (int)(this.flags & 0x420);
			if (num != 0x20)
			{
				if (num != 0x400)
				{
					this.flags |= 0x400;
					this.UPDATE(speedFactor, throttle);
					if ((this.flags & 0xC0) == 0x40)
					{
						this.PLAY();
					}
				}
				else
				{
					this.UPDATE(speedFactor, throttle);
				}
			}
			else
			{
				this._speedFactor = speedFactor;
				this._throttle = throttle;
			}
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00016B34 File Offset: 0x00014D34
		public void Play()
		{
			if ((this.flags & 0x60) == 0)
			{
				this.PLAY();
			}
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x00016B4C File Offset: 0x00014D4C
		public void Stop()
		{
			if ((this.flags & 0x20) == 0 && (this.flags & 0xC0) != 0)
			{
				this.STOP();
			}
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x00016B74 File Offset: 0x00014D74
		public void Pause()
		{
			if ((this.flags & 0xE0) == 0x40)
			{
				this.PAUSE();
			}
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00016B90 File Offset: 0x00014D90
		public void Dispose()
		{
			this.Dispose(false);
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x00016B9C File Offset: 0x00014D9C
		internal void Dispose(bool fromPlayer)
		{
			if ((this.flags & 0x20) == 0x20)
			{
				return;
			}
			if (this.loop && this.loop.instances != null)
			{
				this.loop.instances.Remove(this.parent);
			}
			this.D = (this.E = (this.F = (this.L = (this.K = null))));
			if (!fromPlayer && this.player)
			{
				try
				{
					this.player.instance = null;
					global::UnityEngine.Object.Destroy(this.player.gameObject);
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogError(ex, this.player);
				}
			}
			this.player = null;
			this.flags = 0x20;
		}

		// Token: 0x170000B8 RID: 184
		// (set) Token: 0x060004D9 RID: 1241 RVA: 0x00016C90 File Offset: 0x00014E90
		internal global::UnityEngine.Vector3 localPosition
		{
			set
			{
				if ((this.flags & 0x20) == 0x20)
				{
					return;
				}
				this.player.transform.localPosition = value;
			}
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x00016CC0 File Offset: 0x00014EC0
		private void PLAY()
		{
			if ((this.flags & 0x400) == 0x400)
			{
				if ((this.flags & 1) == 1)
				{
					this.D.Play();
				}
				if ((this.flags & 2) == 2)
				{
					this.F.Play();
				}
				if ((this.flags & 4) == 4)
				{
					this.E.Play();
				}
				if ((this.flags & 8) == 8)
				{
					this.L.Play();
				}
				if ((this.flags & 0x10) == 0x10)
				{
					this.K.Play();
				}
			}
			this.flags |= 0x40;
			this.flags &= 0xFF7F;
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00016D88 File Offset: 0x00014F88
		private void STOP()
		{
			if ((this.flags & 1) == 1)
			{
				this.D.Stop();
			}
			if ((this.flags & 2) == 2)
			{
				this.F.Stop();
			}
			if ((this.flags & 4) == 4)
			{
				this.E.Stop();
			}
			if ((this.flags & 8) == 8)
			{
				this.L.Stop();
			}
			if ((this.flags & 0x10) == 0x10)
			{
				this.K.Stop();
			}
			this.flags &= 0xFF3F;
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00016E28 File Offset: 0x00015028
		private void PAUSE()
		{
			if ((this.flags & 1) == 1)
			{
				this.D.Pause();
			}
			if ((this.flags & 2) == 2)
			{
				this.F.Pause();
			}
			if ((this.flags & 4) == 4)
			{
				this.E.Pause();
			}
			if ((this.flags & 8) == 8)
			{
				this.L.Pause();
			}
			if ((this.flags & 0x10) == 0x10)
			{
				this.K.Pause();
			}
			this.flags |= 0x80;
			this.flags &= 0xFFBF;
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00016EDC File Offset: 0x000150DC
		private void UPDATE_PITCH_AND_OR_THROTTLE_VOLUME()
		{
			ushort num = this.flags;
			num &= 7;
			if (num != 0)
			{
				float num2;
				sbyte b = this.loop.VolumeFactor(this._volume, out num2);
				bool flag;
				if ((int)this._lastVolumeFactorClamp != (int)b || this._lastVolumeFactor != num2)
				{
					flag = true;
					this._lastVolumeFactor = num2;
					this._lastVolumeFactorClamp = b;
					if ((num & 1) == 1)
					{
						this.D.volume = (((int)b != -1) ? (this._masterVolume * (this._dVol = (((int)b != 1) ? (this.loop.volumeD * num2) : this.loop.volumeD))) : (this._dVol = 0f));
					}
				}
				else
				{
					flag = false;
				}
				num &= 0xFFFE;
				if (num != 0)
				{
					float num3 = global::UnityEngine.Mathf.Clamp01(this._throttle);
					if (num3 != this._lastClampedThrottle)
					{
						this._lastClampedThrottle = num3;
						flag = true;
					}
					if (flag)
					{
						sbyte b2 = b;
						switch (b2 + 1)
						{
						case 0:
							if ((num & 2) == 2)
							{
								this.F.volume = (this._fVol = this.loop.volumeF * 0.8f * (0.7f + 0.3f * num3)) * this._masterVolume;
							}
							if ((num & 4) == 4)
							{
								this.E.volume = (this._eVol = this.loop.volumeE * 0.89f * (0.8f + 0.19999999f * num3)) * this._masterVolume;
							}
							return;
						case 2:
							if ((num & 2) == 2)
							{
								this.F.volume = (this._fVol = this.loop.volumeF * (0.7f + 0.3f * num3)) * this._masterVolume;
							}
							if ((num & 4) == 4)
							{
								this.E.volume = (this._eVol = this.loop.volumeE * (0.8f + 0.19999999f * num3)) * this._masterVolume;
							}
							return;
						}
						if ((num & 2) == 2)
						{
							this.F.volume = (this._fVol = this.loop.volumeF * (0.8f + 0.19999999f * num2) * (0.7f + 0.3f * num3)) * this._masterVolume;
						}
						if ((num & 4) == 4)
						{
							this.E.volume = (this._eVol = this.loop.volumeE * (0.89f + 0.110000014f * num2) * (0.8f + 0.19999999f * num3)) * this._masterVolume;
						}
					}
				}
			}
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x000171B8 File Offset: 0x000153B8
		private void UPDATE_THROTTLE_VOLUME()
		{
			ushort num = this.flags;
			num &= 6;
			if (num != 0)
			{
				float num2 = global::UnityEngine.Mathf.Clamp01(this._throttle);
				if (num2 != this._lastClampedThrottle)
				{
					float lastVolumeFactor = this._lastVolumeFactor;
					this._lastClampedThrottle = num2;
					sbyte lastVolumeFactorClamp = this._lastVolumeFactorClamp;
					switch (lastVolumeFactorClamp + 1)
					{
					case 0:
						if ((num & 2) == 2)
						{
							this.F.volume = (this._fVol = this.loop.volumeF * 0.8f * (0.7f + 0.3f * num2)) * this._masterVolume;
						}
						if ((num & 4) == 4)
						{
							this.E.volume = (this._eVol = this.loop.volumeE * 0.89f * (0.8f + 0.19999999f * num2)) * this._masterVolume;
						}
						return;
					case 2:
						if ((num & 2) == 2)
						{
							this.F.volume = (this._fVol = this.loop.volumeF * (0.7f + 0.3f * num2)) * this._masterVolume;
						}
						if ((num & 4) == 4)
						{
							this.E.volume = (this._eVol = this.loop.volumeE * (0.8f + 0.19999999f * num2)) * this._masterVolume;
						}
						return;
					}
					if ((num & 2) == 2)
					{
						this.F.volume = (this._fVol = this.loop.volumeF * (0.8f + 0.19999999f * lastVolumeFactor) * (0.7f + 0.3f * num2)) * this._masterVolume;
					}
					if ((num & 4) == 4)
					{
						this.E.volume = (this._eVol = this.loop.volumeE * (0.89f + 0.110000014f * lastVolumeFactor) * (0.8f + 0.19999999f * num2)) * this._masterVolume;
					}
				}
			}
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x000173D0 File Offset: 0x000155D0
		private void UPDATE_PASSING_VOLUME()
		{
			if ((this.flags & 0x10) == 0x10)
			{
				this.K.volume = (this._kVol = this.loop.volumeK * this._speedFactor) * this._masterVolume;
			}
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x0001741C File Offset: 0x0001561C
		private void UPDATE_MASTER_VOLUME()
		{
			if ((this.flags & 1) == 1)
			{
				this.D.volume = this._dVol * this._masterVolume;
			}
			if ((this.flags & 2) == 2)
			{
				this.F.volume = this._fVol * this._masterVolume;
			}
			if ((this.flags & 4) == 4)
			{
				this.E.volume = this._eVol * this._masterVolume;
			}
			if ((this.flags & 8) == 8)
			{
				this.L.volume = this.loop.volumeL * this._masterVolume;
			}
			if ((this.flags & 0x10) == 0x10)
			{
				this.K.volume = this._kVol * this._masterVolume;
			}
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x000174F0 File Offset: 0x000156F0
		private void UPDATE_RATES()
		{
			if ((this.flags & 1) == 1)
			{
				this.D.pitch = this._pitch;
			}
			if ((this.flags & 2) == 2)
			{
				this.F.pitch = this._pitch;
			}
			if ((this.flags & 4) == 4)
			{
				this.E.pitch = this._pitch;
			}
			if ((this.flags & 8) == 8)
			{
				this.L.pitch = this._pitch;
			}
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x0001757C File Offset: 0x0001577C
		private bool UPDATE_SHIFTING(ref bool doPitchAdjust, ref bool doVolumeAdjust)
		{
			float num = global::UnityEngine.Time.time - this._shiftTime;
			if (num >= this.loop._shiftDuration)
			{
				if ((this.flags & 0x300) == 0x300)
				{
					this._gear += 1;
				}
				else if (this._gear > 0)
				{
					this._gear -= 1;
				}
				this.flags &= 0xFCFF;
				return true;
			}
			float num2 = num / this.loop._shiftDuration;
			float t;
			global::EngineSoundLoop.Gear gear;
			if ((this.flags & 0x300) == 0x300)
			{
				t = this._lastPitchFactor * num2;
				if (this._gear == 0)
				{
					gear = this.loop._idleShiftUp;
				}
				else
				{
					gear = this.loop._shiftUp;
				}
			}
			else
			{
				t = num2;
				gear = this.loop._shiftDown;
			}
			gear.CompareLerp(t, ref this._pitch, ref doPitchAdjust, ref this._volume, ref doVolumeAdjust);
			return false;
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00017680 File Offset: 0x00015880
		private void UPDATE(float speedFactor, float throttle)
		{
			bool flag;
			if (throttle != this._throttle)
			{
				this._throttle = throttle;
				flag = true;
			}
			else
			{
				flag = false;
			}
			float pitch = this._pitch;
			float volume = this._volume;
			float speedFactor2 = this._speedFactor;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = speedFactor != speedFactor2;
			if (flag4)
			{
				this._speedFactor = speedFactor;
			}
			bool flag6;
			bool flag5;
			if ((this.flags & 0x100) == 0x100)
			{
				flag5 = (flag6 = this.UPDATE_SHIFTING(ref flag2, ref flag3));
			}
			else
			{
				flag6 = true;
				flag5 = false;
			}
			if (flag6)
			{
				float num3;
				do
				{
					bool flag7;
					byte b;
					if (flag4 || flag5)
					{
						int topGear = this.loop._topGear;
						this._lastSinerp = global::EngineSoundLoop.Sinerp(0f, (float)topGear, speedFactor);
						int num = (int)this._lastSinerp;
						if (num == (int)this._gear)
						{
							flag7 = false;
							b = ((num != topGear) ? this._gear : ((byte)(topGear - 1)));
						}
						else if (num < (int)this._gear)
						{
							if (this._gear > 0)
							{
								if ((int)this._gear == topGear)
								{
									this._gear -= 1;
									flag7 = false;
									b = this._gear;
								}
								else
								{
									flag7 = true;
									b = this._gear - 1;
								}
							}
							else
							{
								flag7 = false;
								b = this._gear;
							}
						}
						else if (this._gear < 0xFF && (int)this._gear < topGear)
						{
							if ((int)this._gear < topGear - 1)
							{
								flag7 = true;
								b = this._gear + 1;
							}
							else
							{
								flag7 = false;
								b = this._gear;
								this._gear += 1;
							}
						}
						else
						{
							flag7 = false;
							b = this._gear;
						}
					}
					else
					{
						flag7 = false;
						b = (((int)this._gear != this.loop._topGear) ? this._gear : (this._gear - 1));
					}
					float num2 = this._lastSinerp - (float)b;
					if (num2 == 0f)
					{
						num3 = 0f;
					}
					else if (throttle >= 0.5f)
					{
						num3 = num2;
					}
					else if (throttle <= 0f)
					{
						num3 = num2 * 0.3f;
					}
					else
					{
						num3 = num2 * (0.3f + throttle * 0.7f);
					}
					if (!flag7)
					{
						goto IL_2C4;
					}
					if (b > this._gear)
					{
						this.flags |= 0x300;
					}
					else
					{
						this.flags |= 0x100;
					}
					this._lastPitchFactor = num3;
					this._shiftTime = global::UnityEngine.Time.time;
				}
				while (flag5 = this.UPDATE_SHIFTING(ref flag2, ref flag3));
				goto IL_2FF;
				IL_2C4:
				if (num3 != this._lastPitchFactor || flag5)
				{
					this._lastPitchFactor = num3;
					byte b;
					this.loop.GearLerp(b, num3, ref this._pitch, ref flag2, ref this._volume, ref flag3);
				}
			}
			IL_2FF:
			if (flag3 && this._volume != volume)
			{
				this.UPDATE_PITCH_AND_OR_THROTTLE_VOLUME();
			}
			else if (flag)
			{
				this.UPDATE_THROTTLE_VOLUME();
			}
			if (flag4)
			{
				this.UPDATE_PASSING_VOLUME();
			}
			if (flag2 && this._pitch != pitch)
			{
				this.UPDATE_RATES();
			}
		}

		// Token: 0x04000473 RID: 1139
		private const ushort kD = 1;

		// Token: 0x04000474 RID: 1140
		private const ushort kF = 2;

		// Token: 0x04000475 RID: 1141
		private const ushort kE = 4;

		// Token: 0x04000476 RID: 1142
		private const ushort kL = 8;

		// Token: 0x04000477 RID: 1143
		private const ushort kK = 0x10;

		// Token: 0x04000478 RID: 1144
		private const ushort kDisposed = 0x20;

		// Token: 0x04000479 RID: 1145
		private const ushort kPlaying = 0x40;

		// Token: 0x0400047A RID: 1146
		private const ushort kPaused = 0x80;

		// Token: 0x0400047B RID: 1147
		private const ushort kShifting = 0x100;

		// Token: 0x0400047C RID: 1148
		private const ushort kShiftingDown = 0x100;

		// Token: 0x0400047D RID: 1149
		private const ushort kShiftingUp = 0x300;

		// Token: 0x0400047E RID: 1150
		private const ushort kFlagOnceUpdate = 0x400;

		// Token: 0x0400047F RID: 1151
		private const ushort FLAGS_MASK = 0xFFFF;

		// Token: 0x04000480 RID: 1152
		private const ushort nD = 0xFFFE;

		// Token: 0x04000481 RID: 1153
		private const ushort nF = 0xFFFD;

		// Token: 0x04000482 RID: 1154
		private const ushort nE = 0xFFFB;

		// Token: 0x04000483 RID: 1155
		private const ushort nL = 0xFFF7;

		// Token: 0x04000484 RID: 1156
		private const ushort nK = 0xFFEF;

		// Token: 0x04000485 RID: 1157
		private const ushort nDisposed = 0xFFDF;

		// Token: 0x04000486 RID: 1158
		private const ushort nPlaying = 0xFFBF;

		// Token: 0x04000487 RID: 1159
		private const ushort nPaused = 0xFF7F;

		// Token: 0x04000488 RID: 1160
		private const ushort nShifting = 0xFEFF;

		// Token: 0x04000489 RID: 1161
		private const ushort nShiftingDown = 0xFEFF;

		// Token: 0x0400048A RID: 1162
		private const ushort nShiftingUp = 0xFCFF;

		// Token: 0x0400048B RID: 1163
		private const ushort kPlayingOrPaused = 0xC0;

		// Token: 0x0400048C RID: 1164
		private const ushort kShiftingUpOrDown = 0x300;

		// Token: 0x0400048D RID: 1165
		private const ushort nPlayingOrPaused = 0xFF3F;

		// Token: 0x0400048E RID: 1166
		private const ushort nShiftingUpOrDown = 0xFCFF;

		// Token: 0x0400048F RID: 1167
		[global::System.NonSerialized]
		private global::EngineSoundLoop loop;

		// Token: 0x04000490 RID: 1168
		[global::System.NonSerialized]
		private global::EngineSoundLoopPlayer player;

		// Token: 0x04000491 RID: 1169
		[global::System.NonSerialized]
		private global::UnityEngine.Transform parent;

		// Token: 0x04000492 RID: 1170
		[global::System.NonSerialized]
		private global::UnityEngine.AudioSource D;

		// Token: 0x04000493 RID: 1171
		[global::System.NonSerialized]
		private global::UnityEngine.AudioSource E;

		// Token: 0x04000494 RID: 1172
		[global::System.NonSerialized]
		private global::UnityEngine.AudioSource F;

		// Token: 0x04000495 RID: 1173
		[global::System.NonSerialized]
		private global::UnityEngine.AudioSource L;

		// Token: 0x04000496 RID: 1174
		[global::System.NonSerialized]
		private global::UnityEngine.AudioSource K;

		// Token: 0x04000497 RID: 1175
		[global::System.NonSerialized]
		private float _volume;

		// Token: 0x04000498 RID: 1176
		[global::System.NonSerialized]
		private float _pitch;

		// Token: 0x04000499 RID: 1177
		[global::System.NonSerialized]
		private float _masterVolume;

		// Token: 0x0400049A RID: 1178
		[global::System.NonSerialized]
		private float _speedFactor;

		// Token: 0x0400049B RID: 1179
		[global::System.NonSerialized]
		private float _shiftTime;

		// Token: 0x0400049C RID: 1180
		[global::System.NonSerialized]
		private float _throttle;

		// Token: 0x0400049D RID: 1181
		[global::System.NonSerialized]
		private float _lastPitchFactor;

		// Token: 0x0400049E RID: 1182
		[global::System.NonSerialized]
		private float _lastSinerp;

		// Token: 0x0400049F RID: 1183
		[global::System.NonSerialized]
		private float _lastVolumeFactor;

		// Token: 0x040004A0 RID: 1184
		[global::System.NonSerialized]
		private float _lastClampedThrottle;

		// Token: 0x040004A1 RID: 1185
		[global::System.NonSerialized]
		private float _dVol;

		// Token: 0x040004A2 RID: 1186
		[global::System.NonSerialized]
		private float _fVol;

		// Token: 0x040004A3 RID: 1187
		[global::System.NonSerialized]
		private float _eVol;

		// Token: 0x040004A4 RID: 1188
		[global::System.NonSerialized]
		private float _kVol;

		// Token: 0x040004A5 RID: 1189
		[global::System.NonSerialized]
		private ushort flags;

		// Token: 0x040004A6 RID: 1190
		[global::System.NonSerialized]
		private byte _gear;

		// Token: 0x040004A7 RID: 1191
		[global::System.NonSerialized]
		private sbyte _lastVolumeFactorClamp;
	}
}
