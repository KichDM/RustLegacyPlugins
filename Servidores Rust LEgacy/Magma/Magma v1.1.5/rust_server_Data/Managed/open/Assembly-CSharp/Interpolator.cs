using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200034A RID: 842
[global::UnityEngine.RequireComponent(typeof(global::uLinkNetworkView))]
public class Interpolator : global::IDLocal, global::IIDLocalInterpolator
{
	// Token: 0x06001C39 RID: 7225 RVA: 0x00070DD8 File Offset: 0x0006EFD8
	public Interpolator()
	{
	}

	// Token: 0x170007C3 RID: 1987
	// (get) Token: 0x06001C3A RID: 7226 RVA: 0x00070DE0 File Offset: 0x0006EFE0
	global::IDLocal global::IIDLocalInterpolator.self
	{
		get
		{
			return this;
		}
	}

	// Token: 0x06001C3B RID: 7227 RVA: 0x00070DE4 File Offset: 0x0006EFE4
	internal static void SyncronizeAll()
	{
		global::Interpolator.Interpolators.UpdateAll();
	}

	// Token: 0x170007C4 RID: 1988
	// (get) Token: 0x06001C3C RID: 7228 RVA: 0x00070DEC File Offset: 0x0006EFEC
	// (set) Token: 0x06001C3D RID: 7229 RVA: 0x00070DF4 File Offset: 0x0006EFF4
	public bool running
	{
		get
		{
			return this._running;
		}
		set
		{
			if (this._destroying)
			{
				value = false;
			}
			if (this._running != value)
			{
				if (value)
				{
					this._running = global::Interpolator.Interpolators.SetEnabled(this);
				}
				else
				{
					this._running = !global::Interpolator.Interpolators.SetDisabled(this);
				}
			}
		}
	}

	// Token: 0x170007C5 RID: 1989
	// (get) Token: 0x06001C3E RID: 7230 RVA: 0x00070E44 File Offset: 0x0006F044
	// (set) Token: 0x06001C3F RID: 7231 RVA: 0x00070E4C File Offset: 0x0006F04C
	[global::System.Obsolete("Use .running for interpolators", true)]
	public bool enabled
	{
		get
		{
			return this.running;
		}
		set
		{
			this.running = value;
		}
	}

	// Token: 0x06001C40 RID: 7232 RVA: 0x00070E58 File Offset: 0x0006F058
	protected void OnDestroy()
	{
		this._destroying = true;
		if (this._running)
		{
			global::Interpolator.Interpolators.SetDisabled(this);
			this._running = false;
		}
	}

	// Token: 0x06001C41 RID: 7233 RVA: 0x00070E88 File Offset: 0x0006F088
	public virtual void SetGoals(global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, double timestamp)
	{
		if (!this.initialized)
		{
			base.transform.position = pos;
			if (this.idMain is global::Character)
			{
				global::Angle2 eyesAngles = global::Angle2.LookDirection(rot * global::UnityEngine.Vector3.forward);
				eyesAngles.pitch = global::UnityEngine.Mathf.DeltaAngle(0f, eyesAngles.pitch);
				((global::Character)this.idMain).eyesAngles = eyesAngles;
			}
			else
			{
				base.transform.rotation = rot;
			}
			this.initialized = true;
		}
		this.targetPos = pos;
		this.targetRot = rot;
		this.fromPos = base.transform.position;
		if (this.idMain is global::Character)
		{
			this.fromRot = ((global::Character)this.idMain).eyesAngles.quat;
		}
		else
		{
			this.fromRot = base.transform.rotation;
		}
		this.lerpStartTime = global::UnityEngine.Time.realtimeSinceStartup;
	}

	// Token: 0x06001C42 RID: 7234 RVA: 0x00070F7C File Offset: 0x0006F17C
	protected virtual void Syncronize()
	{
		float num = (global::UnityEngine.Time.realtimeSinceStartup - this.lerpStartTime) / global::Interpolation.@struct.totalDelaySecondsF;
		global::UnityEngine.Vector3 vector = global::UnityEngine.Vector3.Lerp(this.fromPos, this.targetPos, num);
		global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.Slerp(this.fromRot, this.targetRot, num);
		if (this.idMain is global::Character)
		{
			global::Character character = (global::Character)this.idMain;
			character.origin = vector;
			global::Angle2 eyesAngles = global::Angle2.LookDirection(quaternion * global::UnityEngine.Vector3.forward);
			eyesAngles.pitch = global::UnityEngine.Mathf.DeltaAngle(0f, eyesAngles.pitch);
			character.eyesAngles = eyesAngles;
		}
		else
		{
			base.transform.position = vector;
			base.transform.rotation = quaternion;
		}
	}

	// Token: 0x06001C43 RID: 7235 RVA: 0x00071040 File Offset: 0x0006F240
	virtual global::IDMain get_idMain()
	{
		return base.idMain;
	}

	// Token: 0x04001082 RID: 4226
	[global::System.NonSerialized]
	private global::UnityEngine.Vector3 targetPos;

	// Token: 0x04001083 RID: 4227
	[global::System.NonSerialized]
	private global::UnityEngine.Vector3 fromPos;

	// Token: 0x04001084 RID: 4228
	[global::System.NonSerialized]
	private global::UnityEngine.Quaternion targetRot;

	// Token: 0x04001085 RID: 4229
	[global::System.NonSerialized]
	private global::UnityEngine.Quaternion fromRot;

	// Token: 0x04001086 RID: 4230
	[global::System.NonSerialized]
	private float lerpStartTime;

	// Token: 0x04001087 RID: 4231
	[global::System.NonSerialized]
	private bool initialized;

	// Token: 0x04001088 RID: 4232
	[global::System.NonSerialized]
	private bool _running;

	// Token: 0x04001089 RID: 4233
	[global::System.NonSerialized]
	private bool _destroying;

	// Token: 0x0200034B RID: 843
	private static class Interpolators
	{
		// Token: 0x06001C44 RID: 7236 RVA: 0x00071048 File Offset: 0x0006F248
		static Interpolators()
		{
		}

		// Token: 0x06001C45 RID: 7237 RVA: 0x00071060 File Offset: 0x0006F260
		public static void UpdateAll()
		{
			if (global::Interpolator.Interpolators.iterating)
			{
				return;
			}
			global::System.Collections.Generic.HashSet<global::Interpolator> hashSet;
			if (global::Interpolator.Interpolators.swapped)
			{
				hashSet = global::Interpolator.Interpolators.hashset2;
			}
			else
			{
				hashSet = global::Interpolator.Interpolators.hashset1;
			}
			try
			{
				global::Interpolator.Interpolators.iterating = true;
				foreach (global::Interpolator interpolator in hashSet)
				{
					try
					{
						interpolator.Syncronize();
					}
					catch (global::System.Exception ex)
					{
						global::UnityEngine.Debug.LogError(ex);
					}
				}
			}
			finally
			{
				if (global::Interpolator.Interpolators.caughtIterating)
				{
					global::Interpolator.Interpolators.swapped = !global::Interpolator.Interpolators.swapped;
					if (global::Interpolator.Interpolators.swapped)
					{
						global::Interpolator.Interpolators.hashset1.Clear();
					}
					else
					{
						global::Interpolator.Interpolators.hashset2.Clear();
					}
				}
				global::Interpolator.Interpolators.iterating = false;
			}
		}

		// Token: 0x06001C46 RID: 7238 RVA: 0x00071174 File Offset: 0x0006F374
		public static bool SetEnabled(global::Interpolator interpolator)
		{
			if (!global::Interpolator.Interpolators.iterating)
			{
				return ((!global::Interpolator.Interpolators.swapped) ? global::Interpolator.Interpolators.hashset1 : global::Interpolator.Interpolators.hashset2).Add(interpolator);
			}
			if (global::Interpolator.Interpolators.caughtIterating)
			{
				return ((!global::Interpolator.Interpolators.swapped) ? global::Interpolator.Interpolators.hashset2 : global::Interpolator.Interpolators.hashset1).Add(interpolator);
			}
			global::System.Collections.Generic.HashSet<global::Interpolator> hashSet;
			global::System.Collections.Generic.HashSet<global::Interpolator> hashSet2;
			if (global::Interpolator.Interpolators.swapped)
			{
				hashSet = global::Interpolator.Interpolators.hashset2;
				hashSet2 = global::Interpolator.Interpolators.hashset1;
			}
			else
			{
				hashSet = global::Interpolator.Interpolators.hashset1;
				hashSet2 = global::Interpolator.Interpolators.hashset2;
			}
			if (hashSet.Contains(interpolator))
			{
				return false;
			}
			global::Interpolator.Interpolators.caughtIterating = true;
			hashSet2.UnionWith(hashSet);
			return hashSet2.Add(interpolator);
		}

		// Token: 0x06001C47 RID: 7239 RVA: 0x00071220 File Offset: 0x0006F420
		public static bool SetDisabled(global::Interpolator interpolator)
		{
			if (!global::Interpolator.Interpolators.iterating)
			{
				return ((!global::Interpolator.Interpolators.swapped) ? global::Interpolator.Interpolators.hashset1 : global::Interpolator.Interpolators.hashset2).Remove(interpolator);
			}
			if (global::Interpolator.Interpolators.caughtIterating)
			{
				return ((!global::Interpolator.Interpolators.swapped) ? global::Interpolator.Interpolators.hashset2 : global::Interpolator.Interpolators.hashset1).Remove(interpolator);
			}
			global::System.Collections.Generic.HashSet<global::Interpolator> hashSet;
			global::System.Collections.Generic.HashSet<global::Interpolator> hashSet2;
			if (global::Interpolator.Interpolators.swapped)
			{
				hashSet = global::Interpolator.Interpolators.hashset2;
				hashSet2 = global::Interpolator.Interpolators.hashset1;
			}
			else
			{
				hashSet = global::Interpolator.Interpolators.hashset1;
				hashSet2 = global::Interpolator.Interpolators.hashset2;
			}
			if (!hashSet.Contains(interpolator))
			{
				return false;
			}
			global::Interpolator.Interpolators.caughtIterating = true;
			hashSet2.UnionWith(hashSet);
			return hashSet2.Remove(interpolator);
		}

		// Token: 0x0400108A RID: 4234
		private static readonly global::System.Collections.Generic.HashSet<global::Interpolator> hashset1 = new global::System.Collections.Generic.HashSet<global::Interpolator>();

		// Token: 0x0400108B RID: 4235
		private static readonly global::System.Collections.Generic.HashSet<global::Interpolator> hashset2 = new global::System.Collections.Generic.HashSet<global::Interpolator>();

		// Token: 0x0400108C RID: 4236
		private static bool swapped;

		// Token: 0x0400108D RID: 4237
		private static bool iterating;

		// Token: 0x0400108E RID: 4238
		private static bool caughtIterating;
	}
}
