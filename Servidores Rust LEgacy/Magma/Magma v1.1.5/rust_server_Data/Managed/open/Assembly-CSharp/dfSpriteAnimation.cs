using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

// Token: 0x02000857 RID: 2135
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/Tweens/Sprite Animator")]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.BoxCollider))]
public class dfSpriteAnimation : global::dfTweenPlayableBase
{
	// Token: 0x060049D6 RID: 18902 RVA: 0x00114024 File Offset: 0x00112224
	public dfSpriteAnimation()
	{
	}

	// Token: 0x1400005B RID: 91
	// (add) Token: 0x060049D7 RID: 18903 RVA: 0x00114060 File Offset: 0x00112260
	// (remove) Token: 0x060049D8 RID: 18904 RVA: 0x0011407C File Offset: 0x0011227C
	public event global::TweenNotification AnimationStarted
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.AnimationStarted = (global::TweenNotification)global::System.Delegate.Combine(this.AnimationStarted, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.AnimationStarted = (global::TweenNotification)global::System.Delegate.Remove(this.AnimationStarted, value);
		}
	}

	// Token: 0x1400005C RID: 92
	// (add) Token: 0x060049D9 RID: 18905 RVA: 0x00114098 File Offset: 0x00112298
	// (remove) Token: 0x060049DA RID: 18906 RVA: 0x001140B4 File Offset: 0x001122B4
	public event global::TweenNotification AnimationStopped
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.AnimationStopped = (global::TweenNotification)global::System.Delegate.Combine(this.AnimationStopped, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.AnimationStopped = (global::TweenNotification)global::System.Delegate.Remove(this.AnimationStopped, value);
		}
	}

	// Token: 0x1400005D RID: 93
	// (add) Token: 0x060049DB RID: 18907 RVA: 0x001140D0 File Offset: 0x001122D0
	// (remove) Token: 0x060049DC RID: 18908 RVA: 0x001140EC File Offset: 0x001122EC
	public event global::TweenNotification AnimationPaused
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.AnimationPaused = (global::TweenNotification)global::System.Delegate.Combine(this.AnimationPaused, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.AnimationPaused = (global::TweenNotification)global::System.Delegate.Remove(this.AnimationPaused, value);
		}
	}

	// Token: 0x1400005E RID: 94
	// (add) Token: 0x060049DD RID: 18909 RVA: 0x00114108 File Offset: 0x00112308
	// (remove) Token: 0x060049DE RID: 18910 RVA: 0x00114124 File Offset: 0x00112324
	public event global::TweenNotification AnimationResumed
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.AnimationResumed = (global::TweenNotification)global::System.Delegate.Combine(this.AnimationResumed, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.AnimationResumed = (global::TweenNotification)global::System.Delegate.Remove(this.AnimationResumed, value);
		}
	}

	// Token: 0x1400005F RID: 95
	// (add) Token: 0x060049DF RID: 18911 RVA: 0x00114140 File Offset: 0x00112340
	// (remove) Token: 0x060049E0 RID: 18912 RVA: 0x0011415C File Offset: 0x0011235C
	public event global::TweenNotification AnimationReset
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.AnimationReset = (global::TweenNotification)global::System.Delegate.Combine(this.AnimationReset, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.AnimationReset = (global::TweenNotification)global::System.Delegate.Remove(this.AnimationReset, value);
		}
	}

	// Token: 0x14000060 RID: 96
	// (add) Token: 0x060049E1 RID: 18913 RVA: 0x00114178 File Offset: 0x00112378
	// (remove) Token: 0x060049E2 RID: 18914 RVA: 0x00114194 File Offset: 0x00112394
	public event global::TweenNotification AnimationCompleted
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.AnimationCompleted = (global::TweenNotification)global::System.Delegate.Combine(this.AnimationCompleted, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.AnimationCompleted = (global::TweenNotification)global::System.Delegate.Remove(this.AnimationCompleted, value);
		}
	}

	// Token: 0x17000DD2 RID: 3538
	// (get) Token: 0x060049E3 RID: 18915 RVA: 0x001141B0 File Offset: 0x001123B0
	// (set) Token: 0x060049E4 RID: 18916 RVA: 0x001141B8 File Offset: 0x001123B8
	public global::dfAnimationClip Clip
	{
		get
		{
			return this.clip;
		}
		set
		{
			this.clip = value;
		}
	}

	// Token: 0x17000DD3 RID: 3539
	// (get) Token: 0x060049E5 RID: 18917 RVA: 0x001141C4 File Offset: 0x001123C4
	// (set) Token: 0x060049E6 RID: 18918 RVA: 0x001141CC File Offset: 0x001123CC
	public global::dfComponentMemberInfo Target
	{
		get
		{
			return this.memberInfo;
		}
		set
		{
			this.memberInfo = value;
		}
	}

	// Token: 0x17000DD4 RID: 3540
	// (get) Token: 0x060049E7 RID: 18919 RVA: 0x001141D8 File Offset: 0x001123D8
	// (set) Token: 0x060049E8 RID: 18920 RVA: 0x001141E0 File Offset: 0x001123E0
	public bool AutoRun
	{
		get
		{
			return this.autoStart;
		}
		set
		{
			this.autoStart = value;
		}
	}

	// Token: 0x17000DD5 RID: 3541
	// (get) Token: 0x060049E9 RID: 18921 RVA: 0x001141EC File Offset: 0x001123EC
	// (set) Token: 0x060049EA RID: 18922 RVA: 0x001141F4 File Offset: 0x001123F4
	public float Length
	{
		get
		{
			return this.length;
		}
		set
		{
			this.length = global::UnityEngine.Mathf.Max(value, 0.03f);
		}
	}

	// Token: 0x17000DD6 RID: 3542
	// (get) Token: 0x060049EB RID: 18923 RVA: 0x00114208 File Offset: 0x00112408
	// (set) Token: 0x060049EC RID: 18924 RVA: 0x00114210 File Offset: 0x00112410
	public global::dfTweenLoopType LoopType
	{
		get
		{
			return this.loopType;
		}
		set
		{
			this.loopType = value;
		}
	}

	// Token: 0x17000DD7 RID: 3543
	// (get) Token: 0x060049ED RID: 18925 RVA: 0x0011421C File Offset: 0x0011241C
	// (set) Token: 0x060049EE RID: 18926 RVA: 0x00114224 File Offset: 0x00112424
	public global::dfSpriteAnimation.PlayDirection Direction
	{
		get
		{
			return this.playDirection;
		}
		set
		{
			this.playDirection = value;
			if (this.IsPlaying)
			{
				this.Play();
			}
		}
	}

	// Token: 0x17000DD8 RID: 3544
	// (get) Token: 0x060049EF RID: 18927 RVA: 0x00114240 File Offset: 0x00112440
	// (set) Token: 0x060049F0 RID: 18928 RVA: 0x00114258 File Offset: 0x00112458
	public bool IsPaused
	{
		get
		{
			return this.isRunning && this.isPaused;
		}
		set
		{
			if (value != this.IsPaused)
			{
				if (value)
				{
					this.Pause();
				}
				else
				{
					this.Resume();
				}
			}
		}
	}

	// Token: 0x060049F1 RID: 18929 RVA: 0x00114280 File Offset: 0x00112480
	public void Awake()
	{
	}

	// Token: 0x060049F2 RID: 18930 RVA: 0x00114284 File Offset: 0x00112484
	public void Start()
	{
	}

	// Token: 0x060049F3 RID: 18931 RVA: 0x00114288 File Offset: 0x00112488
	public void LateUpdate()
	{
		if (this.AutoRun && !this.IsPlaying && !this.autoRunStarted)
		{
			this.autoRunStarted = true;
			this.Play();
		}
	}

	// Token: 0x060049F4 RID: 18932 RVA: 0x001142C4 File Offset: 0x001124C4
	public void PlayForward()
	{
		this.playDirection = global::dfSpriteAnimation.PlayDirection.Forward;
		this.Play();
	}

	// Token: 0x060049F5 RID: 18933 RVA: 0x001142D4 File Offset: 0x001124D4
	public void PlayReverse()
	{
		this.playDirection = global::dfSpriteAnimation.PlayDirection.Reverse;
		this.Play();
	}

	// Token: 0x060049F6 RID: 18934 RVA: 0x001142E4 File Offset: 0x001124E4
	public void Pause()
	{
		if (this.isRunning)
		{
			this.isPaused = true;
			this.onPaused();
		}
	}

	// Token: 0x060049F7 RID: 18935 RVA: 0x00114300 File Offset: 0x00112500
	public void Resume()
	{
		if (this.isRunning && this.isPaused)
		{
			this.isPaused = false;
			this.onResumed();
		}
	}

	// Token: 0x17000DD9 RID: 3545
	// (get) Token: 0x060049F8 RID: 18936 RVA: 0x00114328 File Offset: 0x00112528
	public override bool IsPlaying
	{
		get
		{
			return this.isRunning;
		}
	}

	// Token: 0x060049F9 RID: 18937 RVA: 0x00114330 File Offset: 0x00112530
	public override void Play()
	{
		if (this.IsPlaying)
		{
			this.Stop();
		}
		if (!base.enabled || !base.gameObject.activeSelf || !base.gameObject.activeInHierarchy)
		{
			return;
		}
		if (this.memberInfo == null)
		{
			throw new global::System.NullReferenceException("Animation target is NULL");
		}
		if (!this.memberInfo.IsValid)
		{
			throw new global::System.InvalidOperationException(string.Concat(new object[]
			{
				"Invalid property binding configuration on ",
				this.getPath(base.gameObject.transform),
				" - ",
				this.target
			}));
		}
		this.target = this.memberInfo.GetProperty();
		base.StartCoroutine(this.Execute());
	}

	// Token: 0x060049FA RID: 18938 RVA: 0x001143FC File Offset: 0x001125FC
	public override void Reset()
	{
		global::System.Collections.Generic.List<string> list = (!(this.clip != null)) ? null : this.clip.Sprites;
		if (this.memberInfo.IsValid && list != null && list.Count > 0)
		{
			this.memberInfo.Component.SetProperty(this.memberInfo.MemberName, list[0]);
		}
		if (!this.isRunning)
		{
			return;
		}
		base.StopAllCoroutines();
		this.isRunning = false;
		this.isPaused = false;
		this.onReset();
		this.target = null;
	}

	// Token: 0x060049FB RID: 18939 RVA: 0x001144A0 File Offset: 0x001126A0
	public override void Stop()
	{
		if (!this.isRunning)
		{
			return;
		}
		global::System.Collections.Generic.List<string> list = (!(this.clip != null)) ? null : this.clip.Sprites;
		if (this.skipToEndOnStop && list != null)
		{
			this.setFrame(global::UnityEngine.Mathf.Max(list.Count - 1, 0));
		}
		base.StopAllCoroutines();
		this.isRunning = false;
		this.isPaused = false;
		this.onStopped();
		this.target = null;
	}

	// Token: 0x17000DDA RID: 3546
	// (get) Token: 0x060049FC RID: 18940 RVA: 0x00114524 File Offset: 0x00112724
	// (set) Token: 0x060049FD RID: 18941 RVA: 0x0011452C File Offset: 0x0011272C
	public override string TweenName
	{
		get
		{
			return this.animationName;
		}
		set
		{
			this.animationName = value;
		}
	}

	// Token: 0x060049FE RID: 18942 RVA: 0x00114538 File Offset: 0x00112738
	protected void onPaused()
	{
		base.SendMessage("AnimationPaused", this, 1);
		if (this.AnimationPaused != null)
		{
			this.AnimationPaused();
		}
	}

	// Token: 0x060049FF RID: 18943 RVA: 0x00114560 File Offset: 0x00112760
	protected void onResumed()
	{
		base.SendMessage("AnimationResumed", this, 1);
		if (this.AnimationResumed != null)
		{
			this.AnimationResumed();
		}
	}

	// Token: 0x06004A00 RID: 18944 RVA: 0x00114588 File Offset: 0x00112788
	protected void onStarted()
	{
		base.SendMessage("AnimationStarted", this, 1);
		if (this.AnimationStarted != null)
		{
			this.AnimationStarted();
		}
	}

	// Token: 0x06004A01 RID: 18945 RVA: 0x001145B0 File Offset: 0x001127B0
	protected void onStopped()
	{
		base.SendMessage("AnimationStopped", this, 1);
		if (this.AnimationStopped != null)
		{
			this.AnimationStopped();
		}
	}

	// Token: 0x06004A02 RID: 18946 RVA: 0x001145D8 File Offset: 0x001127D8
	protected void onReset()
	{
		base.SendMessage("AnimationReset", this, 1);
		if (this.AnimationReset != null)
		{
			this.AnimationReset();
		}
	}

	// Token: 0x06004A03 RID: 18947 RVA: 0x00114600 File Offset: 0x00112800
	protected void onCompleted()
	{
		base.SendMessage("AnimationCompleted", this, 1);
		if (this.AnimationCompleted != null)
		{
			this.AnimationCompleted();
		}
	}

	// Token: 0x06004A04 RID: 18948 RVA: 0x00114628 File Offset: 0x00112828
	private global::System.Collections.IEnumerator Execute()
	{
		if (this.clip == null || this.clip.Sprites == null || this.clip.Sprites.Count == 0)
		{
			yield break;
		}
		this.isRunning = true;
		this.isPaused = false;
		this.onStarted();
		float startTime = global::UnityEngine.Time.realtimeSinceStartup;
		int direction = (this.playDirection != global::dfSpriteAnimation.PlayDirection.Forward) ? -1 : 1;
		int lastFrameIndex = (direction != 1) ? (this.clip.Sprites.Count - 1) : 0;
		this.setFrame(lastFrameIndex);
		for (;;)
		{
			yield return null;
			if (!this.IsPaused)
			{
				global::System.Collections.Generic.List<string> sprites = this.clip.Sprites;
				int maxFrameIndex = sprites.Count - 1;
				float timeNow = global::UnityEngine.Time.realtimeSinceStartup;
				float elapsed = timeNow - startTime;
				int frameIndex = global::UnityEngine.Mathf.RoundToInt(global::UnityEngine.Mathf.Clamp01(elapsed / this.length) * (float)maxFrameIndex);
				if (elapsed >= this.length)
				{
					switch (this.loopType)
					{
					case global::dfTweenLoopType.Once:
						goto IL_1C8;
					case global::dfTweenLoopType.Loop:
						startTime = timeNow;
						frameIndex = 0;
						break;
					case global::dfTweenLoopType.PingPong:
						startTime = timeNow;
						direction *= -1;
						frameIndex = 0;
						break;
					}
				}
				if (direction == -1)
				{
					frameIndex = maxFrameIndex - frameIndex;
				}
				if (lastFrameIndex != frameIndex)
				{
					lastFrameIndex = frameIndex;
					this.setFrame(frameIndex);
				}
			}
		}
		IL_1C8:
		this.isRunning = false;
		this.onCompleted();
		yield break;
		yield break;
	}

	// Token: 0x06004A05 RID: 18949 RVA: 0x00114644 File Offset: 0x00112844
	private string getPath(global::UnityEngine.Transform obj)
	{
		global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
		while (obj != null)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Insert(0, "\\");
				stringBuilder.Insert(0, obj.name);
			}
			else
			{
				stringBuilder.Append(obj.name);
			}
			obj = obj.parent;
		}
		return stringBuilder.ToString();
	}

	// Token: 0x06004A06 RID: 18950 RVA: 0x001146B0 File Offset: 0x001128B0
	private void setFrame(int frameIndex)
	{
		global::System.Collections.Generic.List<string> sprites = this.clip.Sprites;
		if (sprites.Count == 0)
		{
			return;
		}
		frameIndex = global::UnityEngine.Mathf.Max(0, global::UnityEngine.Mathf.Min(frameIndex, sprites.Count - 1));
		if (this.target != null)
		{
			this.target.Value = sprites[frameIndex];
		}
	}

	// Token: 0x04002746 RID: 10054
	[global::UnityEngine.SerializeField]
	private string animationName = "ANIMATION";

	// Token: 0x04002747 RID: 10055
	[global::UnityEngine.SerializeField]
	private global::dfAnimationClip clip;

	// Token: 0x04002748 RID: 10056
	[global::UnityEngine.SerializeField]
	private global::dfComponentMemberInfo memberInfo = new global::dfComponentMemberInfo();

	// Token: 0x04002749 RID: 10057
	[global::UnityEngine.SerializeField]
	private global::dfTweenLoopType loopType = global::dfTweenLoopType.Loop;

	// Token: 0x0400274A RID: 10058
	[global::UnityEngine.SerializeField]
	private float length = 1f;

	// Token: 0x0400274B RID: 10059
	[global::UnityEngine.SerializeField]
	private bool autoStart;

	// Token: 0x0400274C RID: 10060
	[global::UnityEngine.SerializeField]
	private bool skipToEndOnStop;

	// Token: 0x0400274D RID: 10061
	[global::UnityEngine.SerializeField]
	private global::dfSpriteAnimation.PlayDirection playDirection;

	// Token: 0x0400274E RID: 10062
	private bool autoRunStarted;

	// Token: 0x0400274F RID: 10063
	private bool isRunning;

	// Token: 0x04002750 RID: 10064
	private bool isPaused;

	// Token: 0x04002751 RID: 10065
	private global::dfObservableProperty target;

	// Token: 0x04002752 RID: 10066
	private global::TweenNotification AnimationStarted;

	// Token: 0x04002753 RID: 10067
	private global::TweenNotification AnimationStopped;

	// Token: 0x04002754 RID: 10068
	private global::TweenNotification AnimationPaused;

	// Token: 0x04002755 RID: 10069
	private global::TweenNotification AnimationResumed;

	// Token: 0x04002756 RID: 10070
	private global::TweenNotification AnimationReset;

	// Token: 0x04002757 RID: 10071
	private global::TweenNotification AnimationCompleted;

	// Token: 0x02000858 RID: 2136
	public enum PlayDirection
	{
		// Token: 0x04002759 RID: 10073
		Forward,
		// Token: 0x0400275A RID: 10074
		Reverse
	}

	// Token: 0x02000859 RID: 2137
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <Execute>c__Iterator55 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06004A07 RID: 18951 RVA: 0x00114708 File Offset: 0x00112908
		public <Execute>c__Iterator55()
		{
		}

		// Token: 0x17000DDB RID: 3547
		// (get) Token: 0x06004A08 RID: 18952 RVA: 0x00114710 File Offset: 0x00112910
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000DDC RID: 3548
		// (get) Token: 0x06004A09 RID: 18953 RVA: 0x00114718 File Offset: 0x00112918
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06004A0A RID: 18954 RVA: 0x00114720 File Offset: 0x00112920
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				if (this.clip == null || this.clip.Sprites == null || this.clip.Sprites.Count == 0)
				{
					return false;
				}
				this.isRunning = true;
				this.isPaused = false;
				base.onStarted();
				startTime = global::UnityEngine.Time.realtimeSinceStartup;
				direction = ((this.playDirection != global::dfSpriteAnimation.PlayDirection.Forward) ? -1 : 1);
				lastFrameIndex = ((direction != 1) ? (this.clip.Sprites.Count - 1) : 0);
				base.setFrame(lastFrameIndex);
				break;
			case 1U:
				if (!base.IsPaused)
				{
					sprites = this.clip.Sprites;
					maxFrameIndex = sprites.Count - 1;
					timeNow = global::UnityEngine.Time.realtimeSinceStartup;
					elapsed = timeNow - startTime;
					frameIndex = global::UnityEngine.Mathf.RoundToInt(global::UnityEngine.Mathf.Clamp01(elapsed / this.length) * (float)maxFrameIndex);
					if (elapsed >= this.length)
					{
						switch (this.loopType)
						{
						case global::dfTweenLoopType.Once:
							this.isRunning = false;
							base.onCompleted();
							return false;
						case global::dfTweenLoopType.Loop:
							startTime = timeNow;
							frameIndex = 0;
							break;
						case global::dfTweenLoopType.PingPong:
							startTime = timeNow;
							direction *= -1;
							frameIndex = 0;
							break;
						}
					}
					if (direction == -1)
					{
						frameIndex = maxFrameIndex - frameIndex;
					}
					if (lastFrameIndex != frameIndex)
					{
						lastFrameIndex = frameIndex;
						base.setFrame(frameIndex);
					}
				}
				break;
			default:
				return false;
			}
			this.$current = null;
			this.$PC = 1;
			return true;
		}

		// Token: 0x06004A0B RID: 18955 RVA: 0x001149AC File Offset: 0x00112BAC
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06004A0C RID: 18956 RVA: 0x001149B8 File Offset: 0x00112BB8
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x0400275B RID: 10075
		internal float <startTime>__0;

		// Token: 0x0400275C RID: 10076
		internal int <direction>__1;

		// Token: 0x0400275D RID: 10077
		internal int <lastFrameIndex>__2;

		// Token: 0x0400275E RID: 10078
		internal global::System.Collections.Generic.List<string> <sprites>__3;

		// Token: 0x0400275F RID: 10079
		internal int <maxFrameIndex>__4;

		// Token: 0x04002760 RID: 10080
		internal float <timeNow>__5;

		// Token: 0x04002761 RID: 10081
		internal float <elapsed>__6;

		// Token: 0x04002762 RID: 10082
		internal int <frameIndex>__7;

		// Token: 0x04002763 RID: 10083
		internal int $PC;

		// Token: 0x04002764 RID: 10084
		internal object $current;

		// Token: 0x04002765 RID: 10085
		internal global::dfSpriteAnimation <>f__this;
	}
}
