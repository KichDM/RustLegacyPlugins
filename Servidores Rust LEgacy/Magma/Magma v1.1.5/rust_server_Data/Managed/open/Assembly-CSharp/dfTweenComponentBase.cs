using System;
using UnityEngine;

// Token: 0x0200088E RID: 2190
[global::System.Serializable]
public abstract class dfTweenComponentBase : global::dfTweenPlayableBase
{
	// Token: 0x06004BC4 RID: 19396 RVA: 0x0011D22C File Offset: 0x0011B42C
	protected dfTweenComponentBase()
	{
	}

	// Token: 0x17000E1F RID: 3615
	// (get) Token: 0x06004BC5 RID: 19397 RVA: 0x0011D2B0 File Offset: 0x0011B4B0
	// (set) Token: 0x06004BC6 RID: 19398 RVA: 0x0011D2D0 File Offset: 0x0011B4D0
	public override string TweenName
	{
		get
		{
			if (this.tweenName == null)
			{
				this.tweenName = base.ToString();
			}
			return this.tweenName;
		}
		set
		{
			this.tweenName = value;
		}
	}

	// Token: 0x17000E20 RID: 3616
	// (get) Token: 0x06004BC7 RID: 19399 RVA: 0x0011D2DC File Offset: 0x0011B4DC
	// (set) Token: 0x06004BC8 RID: 19400 RVA: 0x0011D2E4 File Offset: 0x0011B4E4
	public global::dfComponentMemberInfo Target
	{
		get
		{
			return this.target;
		}
		set
		{
			this.target = value;
		}
	}

	// Token: 0x17000E21 RID: 3617
	// (get) Token: 0x06004BC9 RID: 19401 RVA: 0x0011D2F0 File Offset: 0x0011B4F0
	// (set) Token: 0x06004BCA RID: 19402 RVA: 0x0011D2F8 File Offset: 0x0011B4F8
	public global::UnityEngine.AnimationCurve AnimationCurve
	{
		get
		{
			return this.animCurve;
		}
		set
		{
			this.animCurve = value;
		}
	}

	// Token: 0x17000E22 RID: 3618
	// (get) Token: 0x06004BCB RID: 19403 RVA: 0x0011D304 File Offset: 0x0011B504
	// (set) Token: 0x06004BCC RID: 19404 RVA: 0x0011D30C File Offset: 0x0011B50C
	public float Length
	{
		get
		{
			return this.length;
		}
		set
		{
			this.length = global::UnityEngine.Mathf.Max(0f, value);
		}
	}

	// Token: 0x17000E23 RID: 3619
	// (get) Token: 0x06004BCD RID: 19405 RVA: 0x0011D320 File Offset: 0x0011B520
	// (set) Token: 0x06004BCE RID: 19406 RVA: 0x0011D328 File Offset: 0x0011B528
	public global::dfEasingType Function
	{
		get
		{
			return this.easingType;
		}
		set
		{
			this.easingType = value;
			if (this.isRunning)
			{
				this.Stop();
				this.Play();
			}
		}
	}

	// Token: 0x17000E24 RID: 3620
	// (get) Token: 0x06004BCF RID: 19407 RVA: 0x0011D348 File Offset: 0x0011B548
	// (set) Token: 0x06004BD0 RID: 19408 RVA: 0x0011D350 File Offset: 0x0011B550
	public global::dfTweenLoopType LoopType
	{
		get
		{
			return this.loopType;
		}
		set
		{
			this.loopType = value;
			if (this.isRunning)
			{
				this.Stop();
				this.Play();
			}
		}
	}

	// Token: 0x17000E25 RID: 3621
	// (get) Token: 0x06004BD1 RID: 19409 RVA: 0x0011D370 File Offset: 0x0011B570
	// (set) Token: 0x06004BD2 RID: 19410 RVA: 0x0011D378 File Offset: 0x0011B578
	public bool SyncStartValueWhenRun
	{
		get
		{
			return this.syncStartWhenRun;
		}
		set
		{
			this.syncStartWhenRun = value;
		}
	}

	// Token: 0x17000E26 RID: 3622
	// (get) Token: 0x06004BD3 RID: 19411 RVA: 0x0011D384 File Offset: 0x0011B584
	// (set) Token: 0x06004BD4 RID: 19412 RVA: 0x0011D38C File Offset: 0x0011B58C
	public bool StartValueIsOffset
	{
		get
		{
			return this.startValueIsOffset;
		}
		set
		{
			this.startValueIsOffset = value;
		}
	}

	// Token: 0x17000E27 RID: 3623
	// (get) Token: 0x06004BD5 RID: 19413 RVA: 0x0011D398 File Offset: 0x0011B598
	// (set) Token: 0x06004BD6 RID: 19414 RVA: 0x0011D3A0 File Offset: 0x0011B5A0
	public bool SyncEndValueWhenRun
	{
		get
		{
			return this.syncEndWhenRun;
		}
		set
		{
			this.syncEndWhenRun = value;
		}
	}

	// Token: 0x17000E28 RID: 3624
	// (get) Token: 0x06004BD7 RID: 19415 RVA: 0x0011D3AC File Offset: 0x0011B5AC
	// (set) Token: 0x06004BD8 RID: 19416 RVA: 0x0011D3B4 File Offset: 0x0011B5B4
	public bool EndValueIsOffset
	{
		get
		{
			return this.endValueIsOffset;
		}
		set
		{
			this.endValueIsOffset = value;
		}
	}

	// Token: 0x17000E29 RID: 3625
	// (get) Token: 0x06004BD9 RID: 19417 RVA: 0x0011D3C0 File Offset: 0x0011B5C0
	// (set) Token: 0x06004BDA RID: 19418 RVA: 0x0011D3C8 File Offset: 0x0011B5C8
	public bool AutoRun
	{
		get
		{
			return this.autoRun;
		}
		set
		{
			this.autoRun = value;
		}
	}

	// Token: 0x17000E2A RID: 3626
	// (get) Token: 0x06004BDB RID: 19419 RVA: 0x0011D3D4 File Offset: 0x0011B5D4
	public override bool IsPlaying
	{
		get
		{
			return base.enabled && this.isRunning;
		}
	}

	// Token: 0x17000E2B RID: 3627
	// (get) Token: 0x06004BDC RID: 19420 RVA: 0x0011D3EC File Offset: 0x0011B5EC
	// (set) Token: 0x06004BDD RID: 19421 RVA: 0x0011D3F4 File Offset: 0x0011B5F4
	public bool IsPaused
	{
		get
		{
			return this.isPaused;
		}
		set
		{
			if (value != this.isPaused)
			{
				if (value && !this.isRunning)
				{
					this.isPaused = false;
					return;
				}
				this.isPaused = value;
				if (value)
				{
					this.onPaused();
				}
				else
				{
					this.onResumed();
				}
			}
		}
	}

	// Token: 0x06004BDE RID: 19422
	protected internal abstract void onPaused();

	// Token: 0x06004BDF RID: 19423
	protected internal abstract void onResumed();

	// Token: 0x06004BE0 RID: 19424
	protected internal abstract void onStarted();

	// Token: 0x06004BE1 RID: 19425
	protected internal abstract void onStopped();

	// Token: 0x06004BE2 RID: 19426
	protected internal abstract void onReset();

	// Token: 0x06004BE3 RID: 19427
	protected internal abstract void onCompleted();

	// Token: 0x06004BE4 RID: 19428 RVA: 0x0011D444 File Offset: 0x0011B644
	public void LateUpdate()
	{
		if (this.autoRun && !this.wasAutoStarted)
		{
			this.wasAutoStarted = true;
			this.Play();
		}
	}

	// Token: 0x06004BE5 RID: 19429 RVA: 0x0011D46C File Offset: 0x0011B66C
	public override string ToString()
	{
		if (this.Target != null && this.Target.IsValid)
		{
			string name = this.target.Component.name;
			return string.Format("{0} ({1}.{2})", this.TweenName, name, this.target.MemberName);
		}
		return this.TweenName;
	}

	// Token: 0x04002845 RID: 10309
	[global::UnityEngine.SerializeField]
	protected string tweenName = string.Empty;

	// Token: 0x04002846 RID: 10310
	[global::UnityEngine.SerializeField]
	protected global::dfComponentMemberInfo target;

	// Token: 0x04002847 RID: 10311
	[global::UnityEngine.SerializeField]
	protected global::dfEasingType easingType;

	// Token: 0x04002848 RID: 10312
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.AnimationCurve animCurve = new global::UnityEngine.AnimationCurve(new global::UnityEngine.Keyframe[]
	{
		new global::UnityEngine.Keyframe(0f, 0f, 0f, 1f),
		new global::UnityEngine.Keyframe(1f, 1f, 1f, 0f)
	});

	// Token: 0x04002849 RID: 10313
	[global::UnityEngine.SerializeField]
	protected float length = 1f;

	// Token: 0x0400284A RID: 10314
	[global::UnityEngine.SerializeField]
	protected bool syncStartWhenRun;

	// Token: 0x0400284B RID: 10315
	[global::UnityEngine.SerializeField]
	protected bool startValueIsOffset;

	// Token: 0x0400284C RID: 10316
	[global::UnityEngine.SerializeField]
	protected bool syncEndWhenRun;

	// Token: 0x0400284D RID: 10317
	[global::UnityEngine.SerializeField]
	protected bool endValueIsOffset;

	// Token: 0x0400284E RID: 10318
	[global::UnityEngine.SerializeField]
	protected global::dfTweenLoopType loopType;

	// Token: 0x0400284F RID: 10319
	[global::UnityEngine.SerializeField]
	protected bool autoRun;

	// Token: 0x04002850 RID: 10320
	[global::UnityEngine.SerializeField]
	protected bool skipToEndOnStop;

	// Token: 0x04002851 RID: 10321
	protected bool isRunning;

	// Token: 0x04002852 RID: 10322
	protected bool isPaused;

	// Token: 0x04002853 RID: 10323
	protected global::dfEasingFunctions.EasingFunction easingFunction;

	// Token: 0x04002854 RID: 10324
	protected global::dfObservableProperty boundProperty;

	// Token: 0x04002855 RID: 10325
	protected bool wasAutoStarted;
}
