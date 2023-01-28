using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

// Token: 0x0200088C RID: 2188
[global::System.Serializable]
public abstract class dfTweenComponent<T> : global::dfTweenComponentBase
{
	// Token: 0x06004B9C RID: 19356 RVA: 0x0011C954 File Offset: 0x0011AB54
	protected dfTweenComponent()
	{
	}

	// Token: 0x14000064 RID: 100
	// (add) Token: 0x06004B9D RID: 19357 RVA: 0x0011C95C File Offset: 0x0011AB5C
	// (remove) Token: 0x06004B9E RID: 19358 RVA: 0x0011C978 File Offset: 0x0011AB78
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

	// Token: 0x14000065 RID: 101
	// (add) Token: 0x06004B9F RID: 19359 RVA: 0x0011C994 File Offset: 0x0011AB94
	// (remove) Token: 0x06004BA0 RID: 19360 RVA: 0x0011C9B0 File Offset: 0x0011ABB0
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

	// Token: 0x14000066 RID: 102
	// (add) Token: 0x06004BA1 RID: 19361 RVA: 0x0011C9CC File Offset: 0x0011ABCC
	// (remove) Token: 0x06004BA2 RID: 19362 RVA: 0x0011C9E8 File Offset: 0x0011ABE8
	public event global::TweenNotification TweenPaused
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.TweenPaused = (global::TweenNotification)global::System.Delegate.Combine(this.TweenPaused, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.TweenPaused = (global::TweenNotification)global::System.Delegate.Remove(this.TweenPaused, value);
		}
	}

	// Token: 0x14000067 RID: 103
	// (add) Token: 0x06004BA3 RID: 19363 RVA: 0x0011CA04 File Offset: 0x0011AC04
	// (remove) Token: 0x06004BA4 RID: 19364 RVA: 0x0011CA20 File Offset: 0x0011AC20
	public event global::TweenNotification TweenResumed
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.TweenResumed = (global::TweenNotification)global::System.Delegate.Combine(this.TweenResumed, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.TweenResumed = (global::TweenNotification)global::System.Delegate.Remove(this.TweenResumed, value);
		}
	}

	// Token: 0x14000068 RID: 104
	// (add) Token: 0x06004BA5 RID: 19365 RVA: 0x0011CA3C File Offset: 0x0011AC3C
	// (remove) Token: 0x06004BA6 RID: 19366 RVA: 0x0011CA58 File Offset: 0x0011AC58
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

	// Token: 0x14000069 RID: 105
	// (add) Token: 0x06004BA7 RID: 19367 RVA: 0x0011CA74 File Offset: 0x0011AC74
	// (remove) Token: 0x06004BA8 RID: 19368 RVA: 0x0011CA90 File Offset: 0x0011AC90
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

	// Token: 0x17000E1B RID: 3611
	// (get) Token: 0x06004BA9 RID: 19369 RVA: 0x0011CAAC File Offset: 0x0011ACAC
	// (set) Token: 0x06004BAA RID: 19370 RVA: 0x0011CAB4 File Offset: 0x0011ACB4
	public T StartValue
	{
		get
		{
			return this.startValue;
		}
		set
		{
			this.startValue = value;
			if (this.isRunning)
			{
				this.Stop();
				this.Play();
			}
		}
	}

	// Token: 0x17000E1C RID: 3612
	// (get) Token: 0x06004BAB RID: 19371 RVA: 0x0011CAD4 File Offset: 0x0011ACD4
	// (set) Token: 0x06004BAC RID: 19372 RVA: 0x0011CADC File Offset: 0x0011ACDC
	public T EndValue
	{
		get
		{
			return this.endValue;
		}
		set
		{
			this.endValue = value;
			if (this.isRunning)
			{
				this.Stop();
				this.Play();
			}
		}
	}

	// Token: 0x06004BAD RID: 19373 RVA: 0x0011CAFC File Offset: 0x0011ACFC
	public override void Play()
	{
		if (this.isRunning)
		{
			this.Stop();
		}
		if (!base.enabled || !base.gameObject.activeSelf || !base.gameObject.activeInHierarchy)
		{
			return;
		}
		if (this.target == null)
		{
			throw new global::System.NullReferenceException("Tween target is NULL");
		}
		if (!this.target.IsValid)
		{
			throw new global::System.InvalidOperationException(string.Concat(new object[]
			{
				"Invalid property binding configuration on ",
				this.getPath(base.gameObject.transform),
				" - ",
				this.target
			}));
		}
		global::dfObservableProperty property = this.target.GetProperty();
		base.StartCoroutine(this.Execute(property));
	}

	// Token: 0x06004BAE RID: 19374 RVA: 0x0011CBC4 File Offset: 0x0011ADC4
	public override void Stop()
	{
		if (!this.isRunning)
		{
			return;
		}
		if (this.skipToEndOnStop)
		{
			this.boundProperty.Value = this.actualEndValue;
		}
		base.StopAllCoroutines();
		this.isRunning = false;
		this.onStopped();
		this.easingFunction = null;
		this.boundProperty = null;
	}

	// Token: 0x06004BAF RID: 19375 RVA: 0x0011CC20 File Offset: 0x0011AE20
	public override void Reset()
	{
		if (!this.isRunning)
		{
			return;
		}
		this.boundProperty.Value = this.actualStartValue;
		base.StopAllCoroutines();
		this.isRunning = false;
		this.onReset();
		this.easingFunction = null;
		this.boundProperty = null;
	}

	// Token: 0x06004BB0 RID: 19376 RVA: 0x0011CC70 File Offset: 0x0011AE70
	public void Pause()
	{
		base.IsPaused = true;
	}

	// Token: 0x06004BB1 RID: 19377 RVA: 0x0011CC7C File Offset: 0x0011AE7C
	public void Resume()
	{
		base.IsPaused = false;
	}

	// Token: 0x06004BB2 RID: 19378 RVA: 0x0011CC88 File Offset: 0x0011AE88
	protected internal global::System.Collections.IEnumerator Execute(global::dfObservableProperty property)
	{
		this.isRunning = true;
		this.easingFunction = global::dfEasingFunctions.GetFunction(this.easingType);
		this.boundProperty = property;
		this.onStarted();
		float startTime = global::UnityEngine.Time.realtimeSinceStartup;
		float elapsed = 0f;
		float pingPongDirection = 0f;
		this.actualStartValue = this.startValue;
		this.actualEndValue = this.endValue;
		if (this.syncStartWhenRun)
		{
			this.actualStartValue = (T)((object)property.Value);
		}
		else if (this.startValueIsOffset)
		{
			this.actualStartValue = this.offset(this.startValue, (T)((object)property.Value));
		}
		if (this.syncEndWhenRun)
		{
			this.actualEndValue = (T)((object)property.Value);
		}
		else if (this.endValueIsOffset)
		{
			this.actualEndValue = this.offset(this.endValue, (T)((object)property.Value));
		}
		for (;;)
		{
			if (this.isPaused)
			{
				yield return null;
			}
			else
			{
				elapsed = global::UnityEngine.Mathf.Min(global::UnityEngine.Time.realtimeSinceStartup - startTime, this.length);
				float time = this.easingFunction(0f, 1f, global::UnityEngine.Mathf.Abs(pingPongDirection - elapsed / this.length));
				if (this.animCurve != null)
				{
					time = this.animCurve.Evaluate(time);
				}
				property.Value = this.evaluate(this.actualStartValue, this.actualEndValue, time);
				if (elapsed >= this.length)
				{
					if (this.loopType == global::dfTweenLoopType.Once)
					{
						break;
					}
					if (this.loopType == global::dfTweenLoopType.Loop)
					{
						startTime = global::UnityEngine.Time.realtimeSinceStartup;
					}
					else
					{
						if (this.loopType != global::dfTweenLoopType.PingPong)
						{
							goto IL_31A;
						}
						startTime = global::UnityEngine.Time.realtimeSinceStartup;
						if (pingPongDirection == 0f)
						{
							pingPongDirection = 1f;
						}
						else
						{
							pingPongDirection = 0f;
						}
					}
				}
				yield return null;
			}
		}
		this.boundProperty.Value = this.actualEndValue;
		this.isRunning = false;
		this.onCompleted();
		yield break;
		IL_31A:
		throw new global::System.NotImplementedException();
	}

	// Token: 0x06004BB3 RID: 19379
	public abstract T evaluate(T startValue, T endValue, float time);

	// Token: 0x06004BB4 RID: 19380
	public abstract T offset(T value, T offset);

	// Token: 0x06004BB5 RID: 19381 RVA: 0x0011CCB4 File Offset: 0x0011AEB4
	public override string ToString()
	{
		if (base.Target != null && base.Target.IsValid)
		{
			string name = this.target.Component.name;
			return string.Format("{0} ({1}.{2})", this.TweenName, name, this.target.MemberName);
		}
		return this.TweenName;
	}

	// Token: 0x06004BB6 RID: 19382 RVA: 0x0011CD10 File Offset: 0x0011AF10
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

	// Token: 0x06004BB7 RID: 19383 RVA: 0x0011CD7C File Offset: 0x0011AF7C
	protected internal static float Lerp(float startValue, float endValue, float time)
	{
		return startValue + (endValue - startValue) * time;
	}

	// Token: 0x06004BB8 RID: 19384 RVA: 0x0011CD88 File Offset: 0x0011AF88
	protected internal override void onPaused()
	{
		base.SendMessage("TweenPaused", this, 1);
		if (this.TweenPaused != null)
		{
			this.TweenPaused();
		}
	}

	// Token: 0x06004BB9 RID: 19385 RVA: 0x0011CDB0 File Offset: 0x0011AFB0
	protected internal override void onResumed()
	{
		base.SendMessage("TweenResumed", this, 1);
		if (this.TweenResumed != null)
		{
			this.TweenResumed();
		}
	}

	// Token: 0x06004BBA RID: 19386 RVA: 0x0011CDD8 File Offset: 0x0011AFD8
	protected internal override void onStarted()
	{
		base.SendMessage("TweenStarted", this, 1);
		if (this.TweenStarted != null)
		{
			this.TweenStarted();
		}
	}

	// Token: 0x06004BBB RID: 19387 RVA: 0x0011CE00 File Offset: 0x0011B000
	protected internal override void onStopped()
	{
		base.SendMessage("TweenStopped", this, 1);
		if (this.TweenStopped != null)
		{
			this.TweenStopped();
		}
	}

	// Token: 0x06004BBC RID: 19388 RVA: 0x0011CE28 File Offset: 0x0011B028
	protected internal override void onReset()
	{
		base.SendMessage("TweenReset", this, 1);
		if (this.TweenReset != null)
		{
			this.TweenReset();
		}
	}

	// Token: 0x06004BBD RID: 19389 RVA: 0x0011CE50 File Offset: 0x0011B050
	protected internal override void onCompleted()
	{
		base.SendMessage("TweenCompleted", this, 1);
		if (this.TweenCompleted != null)
		{
			this.TweenCompleted();
		}
	}

	// Token: 0x04002832 RID: 10290
	[global::UnityEngine.SerializeField]
	protected T startValue;

	// Token: 0x04002833 RID: 10291
	[global::UnityEngine.SerializeField]
	protected T endValue;

	// Token: 0x04002834 RID: 10292
	private T actualStartValue;

	// Token: 0x04002835 RID: 10293
	private T actualEndValue;

	// Token: 0x04002836 RID: 10294
	private global::TweenNotification TweenStarted;

	// Token: 0x04002837 RID: 10295
	private global::TweenNotification TweenStopped;

	// Token: 0x04002838 RID: 10296
	private global::TweenNotification TweenPaused;

	// Token: 0x04002839 RID: 10297
	private global::TweenNotification TweenResumed;

	// Token: 0x0400283A RID: 10298
	private global::TweenNotification TweenReset;

	// Token: 0x0400283B RID: 10299
	private global::TweenNotification TweenCompleted;

	// Token: 0x0200088D RID: 2189
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <Execute>c__Iterator56 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06004BBE RID: 19390 RVA: 0x0011CE78 File Offset: 0x0011B078
		public <Execute>c__Iterator56()
		{
		}

		// Token: 0x17000E1D RID: 3613
		// (get) Token: 0x06004BBF RID: 19391 RVA: 0x0011CE80 File Offset: 0x0011B080
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000E1E RID: 3614
		// (get) Token: 0x06004BC0 RID: 19392 RVA: 0x0011CE88 File Offset: 0x0011B088
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06004BC1 RID: 19393 RVA: 0x0011CE90 File Offset: 0x0011B090
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				this.isRunning = true;
				this.easingFunction = global::dfEasingFunctions.GetFunction(this.easingType);
				this.boundProperty = property;
				this.onStarted();
				startTime = global::UnityEngine.Time.realtimeSinceStartup;
				elapsed = 0f;
				pingPongDirection = 0f;
				this.actualStartValue = this.startValue;
				this.actualEndValue = this.endValue;
				if (this.syncStartWhenRun)
				{
					this.actualStartValue = (T)((object)property.Value);
				}
				else if (this.startValueIsOffset)
				{
					this.actualStartValue = this.offset(this.startValue, (T)((object)property.Value));
				}
				if (this.syncEndWhenRun)
				{
					this.actualEndValue = (T)((object)property.Value);
				}
				else if (this.endValueIsOffset)
				{
					this.actualEndValue = this.offset(this.endValue, (T)((object)property.Value));
				}
				break;
			case 1U:
				break;
			case 2U:
				break;
			default:
				return false;
			}
			if (this.isPaused)
			{
				this.$current = null;
				this.$PC = 1;
			}
			else
			{
				elapsed = global::UnityEngine.Mathf.Min(global::UnityEngine.Time.realtimeSinceStartup - startTime, this.length);
				time = this.easingFunction(0f, 1f, global::UnityEngine.Mathf.Abs(pingPongDirection - elapsed / this.length));
				if (this.animCurve != null)
				{
					time = this.animCurve.Evaluate(time);
				}
				property.Value = this.evaluate(this.actualStartValue, this.actualEndValue, time);
				if (elapsed >= this.length)
				{
					if (this.loopType == global::dfTweenLoopType.Once)
					{
						this.boundProperty.Value = this.actualEndValue;
						this.isRunning = false;
						this.onCompleted();
						this.$PC = -1;
						return false;
					}
					if (this.loopType == global::dfTweenLoopType.Loop)
					{
						startTime = global::UnityEngine.Time.realtimeSinceStartup;
					}
					else
					{
						if (this.loopType != global::dfTweenLoopType.PingPong)
						{
							throw new global::System.NotImplementedException();
						}
						startTime = global::UnityEngine.Time.realtimeSinceStartup;
						if (pingPongDirection == 0f)
						{
							pingPongDirection = 1f;
						}
						else
						{
							pingPongDirection = 0f;
						}
					}
				}
				this.$current = null;
				this.$PC = 2;
			}
			return true;
		}

		// Token: 0x06004BC2 RID: 19394 RVA: 0x0011D218 File Offset: 0x0011B418
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06004BC3 RID: 19395 RVA: 0x0011D224 File Offset: 0x0011B424
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x0400283C RID: 10300
		internal global::dfObservableProperty property;

		// Token: 0x0400283D RID: 10301
		internal float <startTime>__0;

		// Token: 0x0400283E RID: 10302
		internal float <elapsed>__1;

		// Token: 0x0400283F RID: 10303
		internal float <pingPongDirection>__2;

		// Token: 0x04002840 RID: 10304
		internal float <time>__3;

		// Token: 0x04002841 RID: 10305
		internal int $PC;

		// Token: 0x04002842 RID: 10306
		internal object $current;

		// Token: 0x04002843 RID: 10307
		internal global::dfObservableProperty <$>property;

		// Token: 0x04002844 RID: 10308
		internal global::dfTweenComponent<T> <>f__this;
	}
}
