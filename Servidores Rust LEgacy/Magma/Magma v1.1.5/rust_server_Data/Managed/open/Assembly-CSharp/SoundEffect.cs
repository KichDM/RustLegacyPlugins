using System;
using UnityEngine;

// Token: 0x020000F3 RID: 243
public class SoundEffect : global::UnityEngine.ScriptableObject
{
	// Token: 0x060004E6 RID: 1254 RVA: 0x00017A14 File Offset: 0x00015C14
	public SoundEffect()
	{
	}

	// Token: 0x020000F4 RID: 244
	public enum ParentMode
	{
		// Token: 0x040004AA RID: 1194
		None,
		// Token: 0x040004AB RID: 1195
		RetainLocal,
		// Token: 0x040004AC RID: 1196
		RetainWorld = 3,
		// Token: 0x040004AD RID: 1197
		StartLocally = 5,
		// Token: 0x040004AE RID: 1198
		StartWorld,
		// Token: 0x040004AF RID: 1199
		CameraLocally = 9,
		// Token: 0x040004B0 RID: 1200
		CameraWorld
	}

	// Token: 0x020000F5 RID: 245
	public struct Parent
	{
		// Token: 0x040004B1 RID: 1201
		public global::UnityEngine.Transform transform;

		// Token: 0x040004B2 RID: 1202
		public global::SoundEffect.ParentMode mode;
	}

	// Token: 0x020000F6 RID: 246
	public struct Levels
	{
		// Token: 0x040004B3 RID: 1203
		public float volume;

		// Token: 0x040004B4 RID: 1204
		public float pitch;

		// Token: 0x040004B5 RID: 1205
		public float pan;

		// Token: 0x040004B6 RID: 1206
		public float doppler;

		// Token: 0x040004B7 RID: 1207
		public float spread;
	}

	// Token: 0x020000F7 RID: 247
	public struct MinMax
	{
		// Token: 0x040004B8 RID: 1208
		public float min;

		// Token: 0x040004B9 RID: 1209
		public float max;
	}

	// Token: 0x020000F8 RID: 248
	public struct Rolloff
	{
		// Token: 0x040004BA RID: 1210
		public const float kCutoffVolume = 0.001f;

		// Token: 0x040004BB RID: 1211
		public global::SoundEffect.MinMax distance;

		// Token: 0x040004BC RID: 1212
		public float? manualCutoffDistance;

		// Token: 0x040004BD RID: 1213
		public bool logarithmic;
	}

	// Token: 0x020000F9 RID: 249
	public struct Parameters
	{
		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060004E7 RID: 1255 RVA: 0x00017A1C File Offset: 0x00015C1C
		// (set) Token: 0x060004E8 RID: 1256 RVA: 0x00017A60 File Offset: 0x00015C60
		public global::UnityEngine.Vector3 position
		{
			get
			{
				global::SoundEffect.ParentMode parentMode = this.parent.mode & global::SoundEffect.ParentMode.RetainWorld;
				if (parentMode != global::SoundEffect.ParentMode.RetainLocal)
				{
					return this.positionalValue;
				}
				return this.parent.transform.TransformPoint(this.positionalValue);
			}
			set
			{
				global::SoundEffect.ParentMode parentMode = this.parent.mode & global::SoundEffect.ParentMode.RetainWorld;
				if (parentMode != global::SoundEffect.ParentMode.RetainLocal)
				{
					this.positionalValue = value;
				}
				else
				{
					this.positionalValue = this.parent.transform.InverseTransformPoint(value);
				}
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060004E9 RID: 1257 RVA: 0x00017AB0 File Offset: 0x00015CB0
		// (set) Token: 0x060004EA RID: 1258 RVA: 0x00017AF4 File Offset: 0x00015CF4
		public global::UnityEngine.Vector3 localPosition
		{
			get
			{
				global::SoundEffect.ParentMode parentMode = this.parent.mode & global::SoundEffect.ParentMode.RetainWorld;
				if (parentMode != global::SoundEffect.ParentMode.RetainWorld)
				{
					return this.positionalValue;
				}
				return this.parent.transform.InverseTransformPoint(this.positionalValue);
			}
			set
			{
				global::SoundEffect.ParentMode parentMode = this.parent.mode & global::SoundEffect.ParentMode.RetainWorld;
				if (parentMode != global::SoundEffect.ParentMode.RetainWorld)
				{
					this.positionalValue = value;
				}
				else
				{
					this.positionalValue = this.parent.transform.TransformPoint(value);
				}
			}
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x00017B44 File Offset: 0x00015D44
		private static global::UnityEngine.Quaternion TransformQuaternion(global::UnityEngine.Transform transform, global::UnityEngine.Quaternion rotation)
		{
			return transform.rotation * rotation;
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x00017B54 File Offset: 0x00015D54
		private static global::UnityEngine.Quaternion InverseTransformQuaternion(global::UnityEngine.Transform transform, global::UnityEngine.Quaternion rotation)
		{
			return rotation * global::UnityEngine.Quaternion.Inverse(transform.rotation);
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x00017B68 File Offset: 0x00015D68
		// (set) Token: 0x060004EE RID: 1262 RVA: 0x00017BAC File Offset: 0x00015DAC
		public global::UnityEngine.Quaternion rotation
		{
			get
			{
				global::SoundEffect.ParentMode parentMode = this.parent.mode & global::SoundEffect.ParentMode.RetainWorld;
				if (parentMode != global::SoundEffect.ParentMode.RetainLocal)
				{
					return this.rotationalValue;
				}
				return global::SoundEffect.Parameters.TransformQuaternion(this.parent.transform, this.rotationalValue);
			}
			set
			{
				global::SoundEffect.ParentMode parentMode = this.parent.mode & global::SoundEffect.ParentMode.RetainWorld;
				if (parentMode != global::SoundEffect.ParentMode.RetainLocal)
				{
					this.rotationalValue = value;
				}
				else
				{
					this.rotationalValue = global::SoundEffect.Parameters.InverseTransformQuaternion(this.parent.transform, value);
				}
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x00017BFC File Offset: 0x00015DFC
		// (set) Token: 0x060004F0 RID: 1264 RVA: 0x00017C40 File Offset: 0x00015E40
		public global::UnityEngine.Quaternion localRotation
		{
			get
			{
				global::SoundEffect.ParentMode parentMode = this.parent.mode & global::SoundEffect.ParentMode.RetainWorld;
				if (parentMode != global::SoundEffect.ParentMode.RetainWorld)
				{
					return this.rotationalValue;
				}
				return global::SoundEffect.Parameters.InverseTransformQuaternion(this.parent.transform, this.rotationalValue);
			}
			set
			{
				global::SoundEffect.ParentMode parentMode = this.parent.mode & global::SoundEffect.ParentMode.RetainWorld;
				if (parentMode != global::SoundEffect.ParentMode.RetainWorld)
				{
					this.rotationalValue = value;
				}
				else
				{
					this.rotationalValue = global::SoundEffect.Parameters.TransformQuaternion(this.parent.transform, value);
				}
			}
		}

		// Token: 0x040004BE RID: 1214
		public global::UnityEngine.AudioClip clip;

		// Token: 0x040004BF RID: 1215
		public global::SoundEffect.Parent parent;

		// Token: 0x040004C0 RID: 1216
		public global::SoundEffect.Levels levels;

		// Token: 0x040004C1 RID: 1217
		public global::SoundEffect.Rolloff rolloff;

		// Token: 0x040004C2 RID: 1218
		public int priority;

		// Token: 0x040004C3 RID: 1219
		public bool bypassEffects;

		// Token: 0x040004C4 RID: 1220
		public bool bypassListenerVolume;

		// Token: 0x040004C5 RID: 1221
		public global::UnityEngine.Vector3 positionalValue;

		// Token: 0x040004C6 RID: 1222
		public global::UnityEngine.Quaternion rotationalValue;
	}
}
