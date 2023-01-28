using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000893 RID: 2195
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/Tweens/Group")]
public class dfTweenGroup : global::dfTweenPlayableBase
{
	// Token: 0x06004BF7 RID: 19447 RVA: 0x0011DA0C File Offset: 0x0011BC0C
	public dfTweenGroup()
	{
	}

	// Token: 0x1400006A RID: 106
	// (add) Token: 0x06004BF8 RID: 19448 RVA: 0x0011DA2C File Offset: 0x0011BC2C
	// (remove) Token: 0x06004BF9 RID: 19449 RVA: 0x0011DA48 File Offset: 0x0011BC48
	public event global::TweenNotification TweenStarted
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.TweenStarted = (global::TweenNotification)global::System.Delegate.Combine(this.TweenStarted, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.TweenStarted = (global::TweenNotification)global::System.Delegate.Remove(this.TweenStarted, value);
		}
	}

	// Token: 0x1400006B RID: 107
	// (add) Token: 0x06004BFA RID: 19450 RVA: 0x0011DA64 File Offset: 0x0011BC64
	// (remove) Token: 0x06004BFB RID: 19451 RVA: 0x0011DA80 File Offset: 0x0011BC80
	public event global::TweenNotification TweenStopped
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.TweenStopped = (global::TweenNotification)global::System.Delegate.Combine(this.TweenStopped, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.TweenStopped = (global::TweenNotification)global::System.Delegate.Remove(this.TweenStopped, value);
		}
	}

	// Token: 0x1400006C RID: 108
	// (add) Token: 0x06004BFC RID: 19452 RVA: 0x0011DA9C File Offset: 0x0011BC9C
	// (remove) Token: 0x06004BFD RID: 19453 RVA: 0x0011DAB8 File Offset: 0x0011BCB8
	public event global::TweenNotification TweenReset
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.TweenReset = (global::TweenNotification)global::System.Delegate.Combine(this.TweenReset, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.TweenReset = (global::TweenNotification)global::System.Delegate.Remove(this.TweenReset, value);
		}
	}

	// Token: 0x1400006D RID: 109
	// (add) Token: 0x06004BFE RID: 19454 RVA: 0x0011DAD4 File Offset: 0x0011BCD4
	// (remove) Token: 0x06004BFF RID: 19455 RVA: 0x0011DAF0 File Offset: 0x0011BCF0
	public event global::TweenNotification TweenCompleted
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.TweenCompleted = (global::TweenNotification)global::System.Delegate.Combine(this.TweenCompleted, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.TweenCompleted = (global::TweenNotification)global::System.Delegate.Remove(this.TweenCompleted, value);
		}
	}

	// Token: 0x17000E2C RID: 3628
	// (get) Token: 0x06004C00 RID: 19456 RVA: 0x0011DB0C File Offset: 0x0011BD0C
	// (set) Token: 0x06004C01 RID: 19457 RVA: 0x0011DB14 File Offset: 0x0011BD14
	public override string TweenName
	{
		get
		{
			return this.groupName;
		}
		set
		{
			this.groupName = value;
		}
	}

	// Token: 0x17000E2D RID: 3629
	// (get) Token: 0x06004C02 RID: 19458 RVA: 0x0011DB20 File Offset: 0x0011BD20
	public override bool IsPlaying
	{
		get
		{
			for (int i = 0; i < this.Tweens.Count; i++)
			{
				if (!(this.Tweens[i] == null) && this.Tweens[i].enabled)
				{
					if (this.Tweens[i].IsPlaying)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	// Token: 0x06004C03 RID: 19459 RVA: 0x0011DB94 File Offset: 0x0011BD94
	private void Update()
	{
	}

	// Token: 0x06004C04 RID: 19460 RVA: 0x0011DB98 File Offset: 0x0011BD98
	public void EnableTween(string TweenName)
	{
		for (int i = 0; i < this.Tweens.Count; i++)
		{
			if (!(this.Tweens[i] == null))
			{
				if (this.Tweens[i].TweenName == TweenName)
				{
					this.Tweens[i].enabled = true;
					break;
				}
			}
		}
	}

	// Token: 0x06004C05 RID: 19461 RVA: 0x0011DC10 File Offset: 0x0011BE10
	public void DisableTween(string TweenName)
	{
		for (int i = 0; i < this.Tweens.Count; i++)
		{
			if (!(this.Tweens[i] == null))
			{
				if (this.Tweens[i].name == TweenName)
				{
					this.Tweens[i].enabled = false;
					break;
				}
			}
		}
	}

	// Token: 0x06004C06 RID: 19462 RVA: 0x0011DC88 File Offset: 0x0011BE88
	public override void Play()
	{
		if (this.IsPlaying)
		{
			this.Stop();
		}
		this.onStarted();
		if (this.Mode == global::dfTweenGroup.TweenGroupMode.Concurrent)
		{
			base.StartCoroutine(this.runConcurrent());
		}
		else
		{
			base.StartCoroutine(this.runSequence());
		}
	}

	// Token: 0x06004C07 RID: 19463 RVA: 0x0011DCD8 File Offset: 0x0011BED8
	public override void Stop()
	{
		if (!this.IsPlaying)
		{
			return;
		}
		base.StopAllCoroutines();
		for (int i = 0; i < this.Tweens.Count; i++)
		{
			if (!(this.Tweens[i] == null))
			{
				this.Tweens[i].Stop();
			}
		}
		this.onStopped();
	}

	// Token: 0x06004C08 RID: 19464 RVA: 0x0011DD48 File Offset: 0x0011BF48
	public override void Reset()
	{
		if (!this.IsPlaying)
		{
			return;
		}
		base.StopAllCoroutines();
		for (int i = 0; i < this.Tweens.Count; i++)
		{
			if (!(this.Tweens[i] == null))
			{
				this.Tweens[i].Reset();
			}
		}
		this.onReset();
	}

	// Token: 0x06004C09 RID: 19465 RVA: 0x0011DDB8 File Offset: 0x0011BFB8
	[global::UnityEngine.HideInInspector]
	private global::System.Collections.IEnumerator runSequence()
	{
		for (int i = 0; i < this.Tweens.Count; i++)
		{
			if (!(this.Tweens[i] == null) && this.Tweens[i].enabled)
			{
				global::dfTweenPlayableBase tween = this.Tweens[i];
				tween.Play();
				while (tween.IsPlaying)
				{
					yield return null;
				}
			}
		}
		this.onCompleted();
		yield break;
	}

	// Token: 0x06004C0A RID: 19466 RVA: 0x0011DDD4 File Offset: 0x0011BFD4
	[global::UnityEngine.HideInInspector]
	private global::System.Collections.IEnumerator runConcurrent()
	{
		for (int i = 0; i < this.Tweens.Count; i++)
		{
			if (!(this.Tweens[i] == null) && this.Tweens[i].enabled)
			{
				this.Tweens[i].Play();
			}
		}
		do
		{
			yield return null;
		}
		while (this.Tweens.Any((global::dfTweenPlayableBase tween) => tween != null && tween.IsPlaying));
		this.onCompleted();
		yield break;
	}

	// Token: 0x06004C0B RID: 19467 RVA: 0x0011DDF0 File Offset: 0x0011BFF0
	protected internal void onStarted()
	{
		base.SendMessage("TweenStarted", this, 1);
		if (this.TweenStarted != null)
		{
			this.TweenStarted();
		}
	}

	// Token: 0x06004C0C RID: 19468 RVA: 0x0011DE18 File Offset: 0x0011C018
	protected internal void onStopped()
	{
		base.SendMessage("TweenStopped", this, 1);
		if (this.TweenStopped != null)
		{
			this.TweenStopped();
		}
	}

	// Token: 0x06004C0D RID: 19469 RVA: 0x0011DE40 File Offset: 0x0011C040
	protected internal void onReset()
	{
		base.SendMessage("TweenReset", this, 1);
		if (this.TweenReset != null)
		{
			this.TweenReset();
		}
	}

	// Token: 0x06004C0E RID: 19470 RVA: 0x0011DE68 File Offset: 0x0011C068
	protected internal void onCompleted()
	{
		base.SendMessage("TweenCompleted", this, 1);
		if (this.TweenCompleted != null)
		{
			this.TweenCompleted();
		}
	}

	// Token: 0x04002868 RID: 10344
	[global::UnityEngine.SerializeField]
	protected string groupName = string.Empty;

	// Token: 0x04002869 RID: 10345
	public global::System.Collections.Generic.List<global::dfTweenPlayableBase> Tweens = new global::System.Collections.Generic.List<global::dfTweenPlayableBase>();

	// Token: 0x0400286A RID: 10346
	public global::dfTweenGroup.TweenGroupMode Mode;

	// Token: 0x0400286B RID: 10347
	private global::TweenNotification TweenStarted;

	// Token: 0x0400286C RID: 10348
	private global::TweenNotification TweenStopped;

	// Token: 0x0400286D RID: 10349
	private global::TweenNotification TweenReset;

	// Token: 0x0400286E RID: 10350
	private global::TweenNotification TweenCompleted;

	// Token: 0x02000894 RID: 2196
	public enum TweenGroupMode
	{
		// Token: 0x04002870 RID: 10352
		Concurrent,
		// Token: 0x04002871 RID: 10353
		Sequence
	}

	// Token: 0x02000895 RID: 2197
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <runSequence>c__Iterator57 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06004C0F RID: 19471 RVA: 0x0011DE90 File Offset: 0x0011C090
		public <runSequence>c__Iterator57()
		{
		}

		// Token: 0x17000E2E RID: 3630
		// (get) Token: 0x06004C10 RID: 19472 RVA: 0x0011DE98 File Offset: 0x0011C098
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000E2F RID: 3631
		// (get) Token: 0x06004C11 RID: 19473 RVA: 0x0011DEA0 File Offset: 0x0011C0A0
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06004C12 RID: 19474 RVA: 0x0011DEA8 File Offset: 0x0011C0A8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				i = 0;
				goto IL_D0;
			case 1U:
				IL_B2:
				if (tween.IsPlaying)
				{
					this.$current = null;
					this.$PC = 1;
					return true;
				}
				break;
			default:
				return false;
			}
			IL_C2:
			i++;
			IL_D0:
			if (i >= this.Tweens.Count)
			{
				base.onCompleted();
				this.$PC = -1;
			}
			else
			{
				if (this.Tweens[i] == null || !this.Tweens[i].enabled)
				{
					goto IL_C2;
				}
				tween = this.Tweens[i];
				tween.Play();
				goto IL_B2;
			}
			return false;
		}

		// Token: 0x06004C13 RID: 19475 RVA: 0x0011DFB8 File Offset: 0x0011C1B8
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06004C14 RID: 19476 RVA: 0x0011DFC4 File Offset: 0x0011C1C4
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04002872 RID: 10354
		internal int <i>__0;

		// Token: 0x04002873 RID: 10355
		internal global::dfTweenPlayableBase <tween>__1;

		// Token: 0x04002874 RID: 10356
		internal int $PC;

		// Token: 0x04002875 RID: 10357
		internal object $current;

		// Token: 0x04002876 RID: 10358
		internal global::dfTweenGroup <>f__this;
	}

	// Token: 0x02000896 RID: 2198
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <runConcurrent>c__Iterator58 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06004C15 RID: 19477 RVA: 0x0011DFCC File Offset: 0x0011C1CC
		public <runConcurrent>c__Iterator58()
		{
		}

		// Token: 0x17000E30 RID: 3632
		// (get) Token: 0x06004C16 RID: 19478 RVA: 0x0011DFD4 File Offset: 0x0011C1D4
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000E31 RID: 3633
		// (get) Token: 0x06004C17 RID: 19479 RVA: 0x0011DFDC File Offset: 0x0011C1DC
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06004C18 RID: 19480 RVA: 0x0011DFE4 File Offset: 0x0011C1E4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				for (i = 0; i < this.Tweens.Count; i++)
				{
					if (!(this.Tweens[i] == null) && this.Tweens[i].enabled)
					{
						this.Tweens[i].Play();
					}
				}
				break;
			case 1U:
				if (!this.Tweens.Any((global::dfTweenPlayableBase tween) => tween != null && tween.IsPlaying))
				{
					base.onCompleted();
					this.$PC = -1;
					return false;
				}
				break;
			default:
				return false;
			}
			this.$current = null;
			this.$PC = 1;
			return true;
		}

		// Token: 0x06004C19 RID: 19481 RVA: 0x0011E104 File Offset: 0x0011C304
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06004C1A RID: 19482 RVA: 0x0011E110 File Offset: 0x0011C310
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x06004C1B RID: 19483 RVA: 0x0011E118 File Offset: 0x0011C318
		private static bool <>m__33(global::dfTweenPlayableBase tween)
		{
			return tween != null && tween.IsPlaying;
		}

		// Token: 0x04002877 RID: 10359
		internal int <i>__0;

		// Token: 0x04002878 RID: 10360
		internal int $PC;

		// Token: 0x04002879 RID: 10361
		internal object $current;

		// Token: 0x0400287A RID: 10362
		internal global::dfTweenGroup <>f__this;

		// Token: 0x0400287B RID: 10363
		private static global::System.Func<global::dfTweenPlayableBase, bool> <>f__am$cache4;
	}
}
