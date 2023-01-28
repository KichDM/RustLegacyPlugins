using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200073D RID: 1853
public class LightStylist : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003E81 RID: 16001 RVA: 0x000DCC20 File Offset: 0x000DAE20
	public LightStylist()
	{
	}

	// Token: 0x06003E82 RID: 16002 RVA: 0x000DCC30 File Offset: 0x000DAE30
	public void EnsureAwake()
	{
		this.Awake();
	}

	// Token: 0x17000BD0 RID: 3024
	// (get) Token: 0x06003E83 RID: 16003 RVA: 0x000DCC38 File Offset: 0x000DAE38
	public global::LightStylist ensuredAwake
	{
		get
		{
			this.Awake();
			return this;
		}
	}

	// Token: 0x06003E84 RID: 16004 RVA: 0x000DCC44 File Offset: 0x000DAE44
	private void Awake()
	{
		if (!this.awoke)
		{
			this.clips = new global::System.Collections.Generic.Dictionary<global::LightStyle, global::LightStylist.Clip>();
			this.awoke = true;
		}
	}

	// Token: 0x06003E85 RID: 16005 RVA: 0x000DCC64 File Offset: 0x000DAE64
	private void Start()
	{
		if (!this._lightStyle)
		{
			this._lightStyle = global::LightStyleDefault.Singleton;
		}
		this.simulationIdle = this._lightStyle.CreateSimulation(global::LightStyle.time, this);
	}

	// Token: 0x06003E86 RID: 16006 RVA: 0x000DCCA4 File Offset: 0x000DAEA4
	protected void LateUpdate()
	{
		if (this.crossfadeThisFrame)
		{
			this.crossfadeNextFrame = this.crossfadeThisFrame;
			this.crossfadeThisFrame = null;
		}
		else if (this.crossfadeNextFrame && !this.CrossFade(this.crossfadeNextFrame, this.crossfadeLength))
		{
			this.crossfadeNextFrame = this.crossfadeThisFrame;
			this.crossfadeThisFrame = null;
		}
		float num2;
		float num = this.CalculateSumWeight(true, out num2);
		global::LightStyle.Mod a;
		if (num == 0f)
		{
			while (this.clipsInSortingArray > 0)
			{
				this.sortingArray[--this.clipsInSortingArray] = null;
			}
			if (!this._lightStyle)
			{
				return;
			}
			a = this.simulationIdle.BindMod(this._mask);
		}
		else
		{
			int count = this.clips.Count;
			if (this.clipsInSortingArray != count)
			{
				if (this.clipsInSortingArray > count)
				{
					while (this.clipsInSortingArray > count)
					{
						this.sortingArray[--this.clipsInSortingArray] = null;
					}
				}
				else if (this.sortingArray == null || this.sortingArray.Length < count)
				{
					global::System.Array.Resize<global::LightStylist.Clip>(ref this.sortingArray, (count / 4 + ((count % 4 != 0) ? 1 : 2)) * 4);
				}
			}
			int num3 = 0;
			foreach (global::LightStylist.Clip clip in this.clips.Values)
			{
				if (clip.weight > 0f)
				{
					this.sortingArray[num3++] = clip;
				}
			}
			if (this.clipsInSortingArray < num3)
			{
				this.clipsInSortingArray = num3;
			}
			else
			{
				while (this.clipsInSortingArray > num3)
				{
					this.sortingArray[--this.clipsInSortingArray] = null;
				}
			}
			global::System.Array.Sort<global::LightStylist.Clip>(this.sortingArray, 0, this.clipsInSortingArray);
			float num4 = this.sortingArray[0].weight;
			a = this.sortingArray[0].simulation.BindMod(this._mask);
			for (int i = 1; i < this.clipsInSortingArray; i++)
			{
				global::LightStylist.Clip clip2 = this.sortingArray[i];
				num4 += clip2.weight;
				a = global::LightStyle.Mod.Lerp(a, clip2.simulation.BindMod(this._mask), clip2.weight / num4, this._mask);
			}
			if (this._lightStyle)
			{
				global::LightStyle.Mod b = this.simulationIdle.BindMod(this._mask);
				if (num < 1f)
				{
					a = global::LightStyle.Mod.Lerp(a, b, 1f - num, this._mask);
				}
				else
				{
					a |= b;
				}
			}
		}
		foreach (global::UnityEngine.Light light in this.lights)
		{
			if (light)
			{
				a.ApplyTo(light, this._mask);
			}
		}
	}

	// Token: 0x06003E87 RID: 16007 RVA: 0x000DD000 File Offset: 0x000DB200
	private void CrossFadeDone()
	{
		global::LightStylist.Clip clip;
		if (this.clips.TryGetValue(this.crossfadeThisFrame, out clip))
		{
			this.clips.Remove(this.style);
			this.GetOrMakeClip(this._lightStyle).weight = 0f;
			this._lightStyle = this.style;
			this.simulationIdle = clip.simulation;
		}
		this.crossfadeThisFrame = null;
		this.crossfadeNextFrame = null;
	}

	// Token: 0x17000BD1 RID: 3025
	// (get) Token: 0x06003E88 RID: 16008 RVA: 0x000DD074 File Offset: 0x000DB274
	// (set) Token: 0x06003E89 RID: 16009 RVA: 0x000DD07C File Offset: 0x000DB27C
	public global::LightStyle style
	{
		get
		{
			return this._lightStyle;
		}
		set
		{
			if (this._lightStyle == value)
			{
				if (value && (this.simulationIdle == null || this.simulationIdle.disposed))
				{
					this.simulationIdle = this._lightStyle.CreateSimulation(global::LightStyle.time, this);
				}
			}
			else
			{
				if (this._lightStyle)
				{
					this.simulationIdle.Dispose();
					this.simulationIdle = null;
				}
				else if (this.simulationIdle != null)
				{
					this.simulationIdle.Dispose();
					this.simulationIdle = null;
				}
				this._lightStyle = value;
				if (this._lightStyle)
				{
					this.simulationIdle = this._lightStyle.CreateSimulation(global::LightStyle.time, this);
				}
			}
		}
	}

	// Token: 0x06003E8A RID: 16010 RVA: 0x000DD150 File Offset: 0x000DB350
	protected void Reset()
	{
		this.lights = base.GetComponents<global::UnityEngine.Light>();
	}

	// Token: 0x06003E8B RID: 16011 RVA: 0x000DD160 File Offset: 0x000DB360
	private global::LightStylist.Clip GetOrMakeClip(global::LightStyle style)
	{
		global::LightStylist.Clip clip;
		if (this.clips.TryGetValue(style, out clip))
		{
			return clip;
		}
		clip = new global::LightStylist.Clip();
		clip.simulation = style.CreateSimulation(global::LightStyle.time, this);
		this.clips[style] = clip;
		return clip;
	}

	// Token: 0x06003E8C RID: 16012 RVA: 0x000DD1A8 File Offset: 0x000DB3A8
	public void Play(global::LightStyle style, double time)
	{
		if (style == this._lightStyle)
		{
			this.clips.Clear();
		}
		else
		{
			global::LightStylist.Clip orMakeClip = this.GetOrMakeClip(style);
			this.clips.Clear();
			this.clips[style] = orMakeClip;
			orMakeClip.weight = 1f;
			orMakeClip.simulation.ResetTime(time);
		}
	}

	// Token: 0x06003E8D RID: 16013 RVA: 0x000DD210 File Offset: 0x000DB410
	public void Play(global::LightStyle style)
	{
		if (style == this._lightStyle)
		{
			this.clips.Clear();
		}
		else
		{
			global::LightStylist.Clip orMakeClip = this.GetOrMakeClip(style);
			this.clips.Clear();
			this.clips[style] = orMakeClip;
			orMakeClip.weight = 1f;
			orMakeClip.simulation.ResetTime(global::LightStyle.time);
		}
	}

	// Token: 0x06003E8E RID: 16014 RVA: 0x000DD27C File Offset: 0x000DB47C
	private float CalculateSumWeight(bool normalize, out float maxWeight)
	{
		float num = 0f;
		maxWeight = 0f;
		foreach (global::LightStylist.Clip clip in this.clips.Values)
		{
			if (clip.weight > maxWeight)
			{
				maxWeight = clip.weight;
			}
			else if (clip.weight < 0f)
			{
				clip.weight = 0f;
			}
			num += clip.weight;
		}
		if (normalize && num > 1f)
		{
			float num2 = num;
			maxWeight /= num2;
			foreach (global::LightStylist.Clip clip2 in this.clips.Values)
			{
				clip2.weight /= num2;
			}
			num = 1f;
		}
		return num;
	}

	// Token: 0x06003E8F RID: 16015 RVA: 0x000DD3B0 File Offset: 0x000DB5B0
	public bool Blend(global::LightStyle style, float targetWeight, float fadeLength)
	{
		if (fadeLength <= 0f)
		{
			this.Play(style);
			return true;
		}
		targetWeight = global::UnityEngine.Mathf.Clamp01(targetWeight);
		if (style == this._lightStyle)
		{
			float num2;
			float num = this.CalculateSumWeight(true, out num2);
			if (global::UnityEngine.Mathf.Approximately(1f - num, targetWeight))
			{
				return true;
			}
			float num3 = global::UnityEngine.Mathf.MoveTowards(num, 1f - targetWeight, global::UnityEngine.Time.deltaTime / fadeLength);
			if (num3 <= 0f)
			{
				foreach (global::LightStylist.Clip clip in this.clips.Values)
				{
					clip.weight = 0f;
				}
			}
			else
			{
				float num4 = num3 / num;
				foreach (global::LightStylist.Clip clip2 in this.clips.Values)
				{
					clip2.weight *= num4;
				}
			}
		}
		else
		{
			global::LightStylist.Clip orMakeClip = this.GetOrMakeClip(style);
			if (global::UnityEngine.Mathf.Approximately(orMakeClip.weight, targetWeight))
			{
				return true;
			}
			orMakeClip.weight = global::UnityEngine.Mathf.MoveTowards(orMakeClip.weight, targetWeight, global::UnityEngine.Time.deltaTime / fadeLength);
			float num6;
			float num5 = this.CalculateSumWeight(false, out num6);
			if (num5 != orMakeClip.weight && num5 > 1f)
			{
				float num7 = num5 - orMakeClip.weight;
				foreach (global::LightStylist.Clip clip3 in this.clips.Values)
				{
					if (clip3 != orMakeClip)
					{
						clip3.weight /= num7;
						clip3.weight *= 1f - orMakeClip.weight;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06003E90 RID: 16016 RVA: 0x000DD600 File Offset: 0x000DB800
	public bool Blend(global::LightStyle style, float targetWeight)
	{
		return this.Blend(style, targetWeight, 0.3f);
	}

	// Token: 0x06003E91 RID: 16017 RVA: 0x000DD610 File Offset: 0x000DB810
	public bool Blend(global::LightStyle style)
	{
		return this.Blend(style, 1f, 0.3f);
	}

	// Token: 0x06003E92 RID: 16018 RVA: 0x000DD624 File Offset: 0x000DB824
	public bool CrossFade(global::LightStyle style, float fadeLength)
	{
		if (this.crossfadeThisFrame != style)
		{
			this.crossfadeThisFrame = style;
			this.crossfadeNextFrame = null;
			this.crossfadeLength = fadeLength;
			if (this.Blend(style, 1f, fadeLength))
			{
				this.CrossFadeDone();
				return true;
			}
		}
		return false;
	}

	// Token: 0x06003E93 RID: 16019 RVA: 0x000DD674 File Offset: 0x000DB874
	public bool CrossFade(global::LightStyle style)
	{
		return this.CrossFade(style, 0.3f);
	}

	// Token: 0x17000BD2 RID: 3026
	// (get) Token: 0x06003E94 RID: 16020 RVA: 0x000DD684 File Offset: 0x000DB884
	public global::System.Collections.Generic.IEnumerable<float> Weights
	{
		get
		{
			foreach (global::LightStylist.Clip clip in this.clips.Values)
			{
				yield return clip.weight;
			}
			yield break;
		}
	}

	// Token: 0x04001FF3 RID: 8179
	private const float kDefaultFadeLength = 0.3f;

	// Token: 0x04001FF4 RID: 8180
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Light[] lights;

	// Token: 0x04001FF5 RID: 8181
	[global::UnityEngine.SerializeField]
	protected global::LightStyle _lightStyle;

	// Token: 0x04001FF6 RID: 8182
	private global::LightStyle crossfadeThisFrame;

	// Token: 0x04001FF7 RID: 8183
	private global::LightStyle crossfadeNextFrame;

	// Token: 0x04001FF8 RID: 8184
	private float crossfadeLength;

	// Token: 0x04001FF9 RID: 8185
	protected global::LightStyle.Simulation simulationIdle;

	// Token: 0x04001FFA RID: 8186
	protected global::LightStyle.Simulation simulationPlaying;

	// Token: 0x04001FFB RID: 8187
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	protected global::LightStyle.Mod.Mask _mask = global::LightStyle.Mod.Mask.Red | global::LightStyle.Mod.Mask.Green | global::LightStyle.Mod.Mask.Blue | global::LightStyle.Mod.Mask.Alpha | global::LightStyle.Mod.Mask.Intensity | global::LightStyle.Mod.Mask.Range | global::LightStyle.Mod.Mask.SpotAngle;

	// Token: 0x04001FFC RID: 8188
	private global::System.Collections.Generic.Dictionary<global::LightStyle, global::LightStylist.Clip> clips;

	// Token: 0x04001FFD RID: 8189
	private global::LightStylist.Clip[] sortingArray;

	// Token: 0x04001FFE RID: 8190
	private int clipsInSortingArray;

	// Token: 0x04001FFF RID: 8191
	private bool awoke;

	// Token: 0x0200073E RID: 1854
	protected sealed class Clip : global::System.IComparable<global::LightStylist.Clip>
	{
		// Token: 0x06003E95 RID: 16021 RVA: 0x000DD6A8 File Offset: 0x000DB8A8
		public Clip()
		{
		}

		// Token: 0x06003E96 RID: 16022 RVA: 0x000DD6B0 File Offset: 0x000DB8B0
		public int CompareTo(global::LightStylist.Clip other)
		{
			return this.weight.CompareTo(other.weight);
		}

		// Token: 0x04002000 RID: 8192
		public float weight;

		// Token: 0x04002001 RID: 8193
		public global::LightStyle.Simulation simulation;
	}

	// Token: 0x0200073F RID: 1855
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <>c__Iterator4D : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<float>, global::System.Collections.Generic.IEnumerator<float>
	{
		// Token: 0x06003E97 RID: 16023 RVA: 0x000DD6C4 File Offset: 0x000DB8C4
		public <>c__Iterator4D()
		{
		}

		// Token: 0x17000BD3 RID: 3027
		// (get) Token: 0x06003E98 RID: 16024 RVA: 0x000DD6CC File Offset: 0x000DB8CC
		float global::System.Collections.Generic.IEnumerator<float>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000BD4 RID: 3028
		// (get) Token: 0x06003E99 RID: 16025 RVA: 0x000DD6D4 File Offset: 0x000DB8D4
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06003E9A RID: 16026 RVA: 0x000DD6E4 File Offset: 0x000DB8E4
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<float>.GetEnumerator();
		}

		// Token: 0x06003E9B RID: 16027 RVA: 0x000DD6EC File Offset: 0x000DB8EC
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<float> global::System.Collections.Generic.IEnumerable<float>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::LightStylist.<>c__Iterator4D <>c__Iterator4D = new global::LightStylist.<>c__Iterator4D();
			<>c__Iterator4D.<>f__this = this;
			return <>c__Iterator4D;
		}

		// Token: 0x06003E9C RID: 16028 RVA: 0x000DD720 File Offset: 0x000DB920
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				enumerator = this.clips.Values.GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					clip = enumerator.Current;
					this.$current = clip.weight;
					this.$PC = 1;
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06003E9D RID: 16029 RVA: 0x000DD804 File Offset: 0x000DBA04
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06003E9E RID: 16030 RVA: 0x000DD864 File Offset: 0x000DBA64
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04002002 RID: 8194
		internal global::System.Collections.Generic.Dictionary<global::LightStyle, global::LightStylist.Clip>.ValueCollection.Enumerator <$s_542>__0;

		// Token: 0x04002003 RID: 8195
		internal global::LightStylist.Clip <clip>__1;

		// Token: 0x04002004 RID: 8196
		internal int $PC;

		// Token: 0x04002005 RID: 8197
		internal float $current;

		// Token: 0x04002006 RID: 8198
		internal global::LightStylist <>f__this;
	}
}
