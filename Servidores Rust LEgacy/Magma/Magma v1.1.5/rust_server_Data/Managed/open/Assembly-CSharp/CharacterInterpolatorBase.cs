using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200012E RID: 302
public abstract class CharacterInterpolatorBase : global::IDLocalCharacterAddon, global::IIDLocalInterpolator
{
	// Token: 0x0600076F RID: 1903 RVA: 0x000205B8 File Offset: 0x0001E7B8
	internal CharacterInterpolatorBase(global::IDLocalCharacterAddon.AddonFlags addonFlags) : base(addonFlags | global::IDLocalCharacterAddon.AddonFlags.FireOnAddonAwake)
	{
	}

	// Token: 0x1700017F RID: 383
	// (get) Token: 0x06000770 RID: 1904 RVA: 0x000205D8 File Offset: 0x0001E7D8
	global::IDMain global::IIDLocalInterpolator.idMain
	{
		get
		{
			return this.idMain;
		}
	}

	// Token: 0x17000180 RID: 384
	// (get) Token: 0x06000771 RID: 1905 RVA: 0x000205E0 File Offset: 0x0001E7E0
	global::IDLocal global::IIDLocalInterpolator.self
	{
		get
		{
			return this;
		}
	}

	// Token: 0x17000181 RID: 385
	// (get) Token: 0x06000772 RID: 1906
	protected abstract double __storedDuration { get; }

	// Token: 0x17000182 RID: 386
	// (get) Token: 0x06000773 RID: 1907
	protected abstract double __oldestTimeStamp { get; }

	// Token: 0x17000183 RID: 387
	// (get) Token: 0x06000774 RID: 1908
	protected abstract double __newestTimeStamp { get; }

	// Token: 0x06000775 RID: 1909
	protected abstract void __Clear();

	// Token: 0x17000184 RID: 388
	// (get) Token: 0x06000776 RID: 1910 RVA: 0x000205E4 File Offset: 0x0001E7E4
	public double storedDuration
	{
		get
		{
			return this.__storedDuration;
		}
	}

	// Token: 0x17000185 RID: 389
	// (get) Token: 0x06000777 RID: 1911 RVA: 0x000205EC File Offset: 0x0001E7EC
	public double oldestTimeStamp
	{
		get
		{
			return this.__oldestTimeStamp;
		}
	}

	// Token: 0x17000186 RID: 390
	// (get) Token: 0x06000778 RID: 1912 RVA: 0x000205F4 File Offset: 0x0001E7F4
	public double newestTimeStamp
	{
		get
		{
			return this.__newestTimeStamp;
		}
	}

	// Token: 0x06000779 RID: 1913 RVA: 0x000205FC File Offset: 0x0001E7FC
	protected override void OnAddonAwake()
	{
		global::CharacterInterpolatorTrait trait = base.idMain.GetTrait<global::CharacterInterpolatorTrait>();
		if (trait)
		{
			if (trait.bufferCapacity > 0)
			{
				this._bufferCapacity = trait.bufferCapacity;
			}
			this.extrapolate = trait.allowExtrapolation;
			this.allowableTimeSpan = trait.allowableTimeSpan;
		}
	}

	// Token: 0x0600077A RID: 1914 RVA: 0x00020650 File Offset: 0x0001E850
	public void Clear()
	{
		this.__Clear();
	}

	// Token: 0x0600077B RID: 1915 RVA: 0x00020658 File Offset: 0x0001E858
	internal static void SyncronizeAll()
	{
		global::CharacterInterpolatorBase.Interpolators.UpdateAll();
	}

	// Token: 0x17000187 RID: 391
	// (get) Token: 0x0600077C RID: 1916 RVA: 0x00020660 File Offset: 0x0001E860
	// (set) Token: 0x0600077D RID: 1917 RVA: 0x00020668 File Offset: 0x0001E868
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
					this._running = global::CharacterInterpolatorBase.Interpolators.SetEnabled(this);
				}
				else
				{
					this._running = !global::CharacterInterpolatorBase.Interpolators.SetDisabled(this);
				}
			}
		}
	}

	// Token: 0x17000188 RID: 392
	// (get) Token: 0x0600077E RID: 1918 RVA: 0x000206B8 File Offset: 0x0001E8B8
	// (set) Token: 0x0600077F RID: 1919 RVA: 0x000206C0 File Offset: 0x0001E8C0
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

	// Token: 0x06000780 RID: 1920 RVA: 0x000206CC File Offset: 0x0001E8CC
	protected void OnDestroy()
	{
		this._destroying = true;
		if (this._running)
		{
			global::CharacterInterpolatorBase.Interpolators.SetDisabled(this);
			this._running = false;
		}
	}

	// Token: 0x06000781 RID: 1921 RVA: 0x000206FC File Offset: 0x0001E8FC
	public virtual void SetGoals(global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, double timestamp)
	{
		if (!this.initialized)
		{
			base.transform.position = pos;
			if (base.idMain is global::Character)
			{
				global::Angle2 eyesAngles = global::Angle2.LookDirection(rot * global::UnityEngine.Vector3.forward);
				eyesAngles.pitch = global::UnityEngine.Mathf.DeltaAngle(0f, eyesAngles.pitch);
				base.idMain.eyesAngles = eyesAngles;
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
		if (base.idMain is global::Character)
		{
			this.fromRot = base.idMain.eyesAngles.quat;
		}
		else
		{
			this.fromRot = base.transform.rotation;
		}
		this.lerpStartTime = global::UnityEngine.Time.realtimeSinceStartup;
	}

	// Token: 0x06000782 RID: 1922 RVA: 0x000207E8 File Offset: 0x0001E9E8
	protected virtual void Syncronize()
	{
		float num = (global::UnityEngine.Time.realtimeSinceStartup - this.lerpStartTime) / global::Interpolation.@struct.totalDelaySecondsF;
		global::UnityEngine.Vector3 vector = global::UnityEngine.Vector3.Lerp(this.fromPos, this.targetPos, num);
		global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.Slerp(this.fromRot, this.targetRot, num);
		if (base.idMain is global::Character)
		{
			global::Character idMain = base.idMain;
			idMain.origin = vector;
			global::Angle2 eyesAngles = global::Angle2.LookDirection(quaternion * global::UnityEngine.Vector3.forward);
			eyesAngles.pitch = global::UnityEngine.Mathf.DeltaAngle(0f, eyesAngles.pitch);
			idMain.eyesAngles = eyesAngles;
		}
		else
		{
			base.transform.position = vector;
			base.transform.rotation = quaternion;
		}
	}

	// Token: 0x040005EB RID: 1515
	protected const int kDefaultBufferCapacity = 0x20;

	// Token: 0x040005EC RID: 1516
	private const global::IDLocalCharacterAddon.AddonFlags kRequiredAddonFlags = global::IDLocalCharacterAddon.AddonFlags.FireOnAddonAwake;

	// Token: 0x040005ED RID: 1517
	[global::System.NonSerialized]
	private global::UnityEngine.Vector3 targetPos;

	// Token: 0x040005EE RID: 1518
	[global::System.NonSerialized]
	private global::UnityEngine.Vector3 fromPos;

	// Token: 0x040005EF RID: 1519
	[global::System.NonSerialized]
	private global::UnityEngine.Quaternion targetRot;

	// Token: 0x040005F0 RID: 1520
	[global::System.NonSerialized]
	private global::UnityEngine.Quaternion fromRot;

	// Token: 0x040005F1 RID: 1521
	[global::System.NonSerialized]
	private float lerpStartTime;

	// Token: 0x040005F2 RID: 1522
	[global::System.NonSerialized]
	private bool initialized;

	// Token: 0x040005F3 RID: 1523
	[global::System.NonSerialized]
	protected int _bufferCapacity = 0x20;

	// Token: 0x040005F4 RID: 1524
	[global::System.NonSerialized]
	protected bool extrapolate;

	// Token: 0x040005F5 RID: 1525
	[global::System.NonSerialized]
	protected float allowableTimeSpan = 0.1f;

	// Token: 0x040005F6 RID: 1526
	[global::System.NonSerialized]
	protected int len;

	// Token: 0x040005F7 RID: 1527
	[global::System.NonSerialized]
	private bool _running;

	// Token: 0x040005F8 RID: 1528
	[global::System.NonSerialized]
	private bool _destroying;

	// Token: 0x0200012F RID: 303
	private static class Interpolators
	{
		// Token: 0x06000783 RID: 1923 RVA: 0x000208A4 File Offset: 0x0001EAA4
		static Interpolators()
		{
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x000208BC File Offset: 0x0001EABC
		public static void UpdateAll()
		{
			if (global::CharacterInterpolatorBase.Interpolators.iterating)
			{
				return;
			}
			global::System.Collections.Generic.HashSet<global::CharacterInterpolatorBase> hashSet;
			if (global::CharacterInterpolatorBase.Interpolators.swapped)
			{
				hashSet = global::CharacterInterpolatorBase.Interpolators.hashset2;
			}
			else
			{
				hashSet = global::CharacterInterpolatorBase.Interpolators.hashset1;
			}
			try
			{
				global::CharacterInterpolatorBase.Interpolators.iterating = true;
				foreach (global::CharacterInterpolatorBase characterInterpolatorBase in hashSet)
				{
					try
					{
						characterInterpolatorBase.Syncronize();
					}
					catch (global::System.Exception ex)
					{
						global::UnityEngine.Debug.LogError(ex);
					}
				}
			}
			finally
			{
				if (global::CharacterInterpolatorBase.Interpolators.caughtIterating)
				{
					global::CharacterInterpolatorBase.Interpolators.swapped = !global::CharacterInterpolatorBase.Interpolators.swapped;
					if (global::CharacterInterpolatorBase.Interpolators.swapped)
					{
						global::CharacterInterpolatorBase.Interpolators.hashset1.Clear();
					}
					else
					{
						global::CharacterInterpolatorBase.Interpolators.hashset2.Clear();
					}
				}
				global::CharacterInterpolatorBase.Interpolators.iterating = false;
			}
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x000209D0 File Offset: 0x0001EBD0
		public static bool SetEnabled(global::CharacterInterpolatorBase interpolator)
		{
			if (!global::CharacterInterpolatorBase.Interpolators.iterating)
			{
				return ((!global::CharacterInterpolatorBase.Interpolators.swapped) ? global::CharacterInterpolatorBase.Interpolators.hashset1 : global::CharacterInterpolatorBase.Interpolators.hashset2).Add(interpolator);
			}
			if (global::CharacterInterpolatorBase.Interpolators.caughtIterating)
			{
				return ((!global::CharacterInterpolatorBase.Interpolators.swapped) ? global::CharacterInterpolatorBase.Interpolators.hashset2 : global::CharacterInterpolatorBase.Interpolators.hashset1).Add(interpolator);
			}
			global::System.Collections.Generic.HashSet<global::CharacterInterpolatorBase> hashSet;
			global::System.Collections.Generic.HashSet<global::CharacterInterpolatorBase> hashSet2;
			if (global::CharacterInterpolatorBase.Interpolators.swapped)
			{
				hashSet = global::CharacterInterpolatorBase.Interpolators.hashset2;
				hashSet2 = global::CharacterInterpolatorBase.Interpolators.hashset1;
			}
			else
			{
				hashSet = global::CharacterInterpolatorBase.Interpolators.hashset1;
				hashSet2 = global::CharacterInterpolatorBase.Interpolators.hashset2;
			}
			if (hashSet.Contains(interpolator))
			{
				return false;
			}
			global::CharacterInterpolatorBase.Interpolators.caughtIterating = true;
			hashSet2.UnionWith(hashSet);
			return hashSet2.Add(interpolator);
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x00020A7C File Offset: 0x0001EC7C
		public static bool SetDisabled(global::CharacterInterpolatorBase interpolator)
		{
			if (!global::CharacterInterpolatorBase.Interpolators.iterating)
			{
				return ((!global::CharacterInterpolatorBase.Interpolators.swapped) ? global::CharacterInterpolatorBase.Interpolators.hashset1 : global::CharacterInterpolatorBase.Interpolators.hashset2).Remove(interpolator);
			}
			if (global::CharacterInterpolatorBase.Interpolators.caughtIterating)
			{
				return ((!global::CharacterInterpolatorBase.Interpolators.swapped) ? global::CharacterInterpolatorBase.Interpolators.hashset2 : global::CharacterInterpolatorBase.Interpolators.hashset1).Remove(interpolator);
			}
			global::System.Collections.Generic.HashSet<global::CharacterInterpolatorBase> hashSet;
			global::System.Collections.Generic.HashSet<global::CharacterInterpolatorBase> hashSet2;
			if (global::CharacterInterpolatorBase.Interpolators.swapped)
			{
				hashSet = global::CharacterInterpolatorBase.Interpolators.hashset2;
				hashSet2 = global::CharacterInterpolatorBase.Interpolators.hashset1;
			}
			else
			{
				hashSet = global::CharacterInterpolatorBase.Interpolators.hashset1;
				hashSet2 = global::CharacterInterpolatorBase.Interpolators.hashset2;
			}
			if (!hashSet.Contains(interpolator))
			{
				return false;
			}
			global::CharacterInterpolatorBase.Interpolators.caughtIterating = true;
			hashSet2.UnionWith(hashSet);
			return hashSet2.Remove(interpolator);
		}

		// Token: 0x040005F9 RID: 1529
		private static readonly global::System.Collections.Generic.HashSet<global::CharacterInterpolatorBase> hashset1 = new global::System.Collections.Generic.HashSet<global::CharacterInterpolatorBase>();

		// Token: 0x040005FA RID: 1530
		private static readonly global::System.Collections.Generic.HashSet<global::CharacterInterpolatorBase> hashset2 = new global::System.Collections.Generic.HashSet<global::CharacterInterpolatorBase>();

		// Token: 0x040005FB RID: 1531
		private static bool swapped;

		// Token: 0x040005FC RID: 1532
		private static bool iterating;

		// Token: 0x040005FD RID: 1533
		private static bool caughtIterating;
	}
}
