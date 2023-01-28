using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000280 RID: 640
public static class AnimationBlender
{
	// Token: 0x06001740 RID: 5952 RVA: 0x000557F0 File Offset: 0x000539F0
	private static void ZeroWeight(ref global::AnimationBlender.WeightUnit weight)
	{
		weight.raw = (weight.scaled = (weight.normalized = 0f));
	}

	// Token: 0x06001741 RID: 5953 RVA: 0x0005581C File Offset: 0x00053A1C
	private static void OneWeight(ref global::AnimationBlender.WeightUnit weight)
	{
		weight.raw = (weight.scaled = (weight.normalized = 1f));
	}

	// Token: 0x06001742 RID: 5954 RVA: 0x00055848 File Offset: 0x00053A48
	private static void OneWeightScale(ref global::AnimationBlender.WeightUnit weight)
	{
		weight.scaled = (weight.normalized = 1f);
	}

	// Token: 0x06001743 RID: 5955 RVA: 0x0005586C File Offset: 0x00053A6C
	private static void SetWeight(ref global::AnimationBlender.WeightUnit weight)
	{
		weight.scaled = weight.raw;
		weight.normalized = 1f;
	}

	// Token: 0x06001744 RID: 5956 RVA: 0x00055888 File Offset: 0x00053A88
	private static global::AnimationBlender.Weighted<T>[] WeightArray<T>(int size)
	{
		return new global::AnimationBlender.Weighted<T>[size];
	}

	// Token: 0x06001745 RID: 5957 RVA: 0x000558A0 File Offset: 0x00053AA0
	private static global::AnimationBlender.Weighted<T>[] WeightArray<T>(T[] source)
	{
		if (object.ReferenceEquals(source, null))
		{
			return null;
		}
		int num = source.Length;
		global::AnimationBlender.Weighted<T>[] array = global::AnimationBlender.WeightArray<T>(num);
		for (int i = 0; i < num; i++)
		{
			array[i].value = source[i];
		}
		return array;
	}

	// Token: 0x06001746 RID: 5958 RVA: 0x000558EC File Offset: 0x00053AEC
	private static bool WeightOf<T>(global::AnimationBlender.Weighted<T>[] items, int[] index, out global::AnimationBlender.WeightResult result)
	{
		float num = 0f;
		float num2 = 0f;
		int num3 = -1;
		int num4 = 0;
		int i = 0;
		int num5 = index.Length - 1;
		while (i <= num5)
		{
			float num6;
			if ((num6 = items[index[i]].weight.raw) <= 0f)
			{
				global::AnimationBlender.ZeroWeight(ref items[index[i]].weight);
				int num7 = index[num5];
				index[num5--] = index[i];
				index[i] = num7;
			}
			else
			{
				num4++;
				if (num6 >= 1f)
				{
					num6 = 1f;
					global::AnimationBlender.OneWeight(ref items[index[i]].weight);
				}
				else
				{
					global::AnimationBlender.SetWeight(ref items[index[i]].weight);
				}
				num += num6;
				if (num6 > num2)
				{
					num2 = num6;
					num3 = i;
				}
				i++;
			}
		}
		float num8;
		float num9;
		bool result2;
		if (num3 == -1)
		{
			num8 = 0f;
			num9 = 0f;
			result2 = false;
		}
		else
		{
			result2 = true;
			if (num4 == 1)
			{
				num8 = 1f;
				num9 = 1f;
				global::AnimationBlender.OneWeightScale(ref items[index[0]].weight);
			}
			else
			{
				if (num2 < 1f)
				{
					num8 = 0f;
					float num10 = 1f / num2;
					for (int j = 0; j < num4; j++)
					{
						num8 += items[index[j]].weight.SetScaledRecip(num10);
					}
				}
				else
				{
					num8 = num;
				}
				if (num8 == 1f)
				{
					num9 = 1f;
				}
				else
				{
					num9 = 0f;
					float num10 = 1f / num8;
					for (int k = 0; k < num4; k++)
					{
						num9 += items[index[k]].weight.SetNormalizedRecip(num10);
					}
				}
			}
		}
		result.count = num4;
		result.winner = num3;
		result.sum.raw = num;
		result.sum.scaled = num8;
		result.sum.normalized = num9;
		return result2;
	}

	// Token: 0x06001747 RID: 5959 RVA: 0x00055B00 File Offset: 0x00053D00
	private static int GetClear(ref int value)
	{
		int result = value;
		value = 0;
		return result;
	}

	// Token: 0x06001748 RID: 5960 RVA: 0x00055B14 File Offset: 0x00053D14
	private static void ArrayResize<T>(ref T[] array, int size)
	{
		global::System.Array.Resize<T>(ref array, size);
	}

	// Token: 0x06001749 RID: 5961 RVA: 0x00055B20 File Offset: 0x00053D20
	private static global::AnimationBlender.opt<T> to_opt<T>(T? nullable) where T : struct
	{
		return (nullable != null) ? nullable.Value : global::AnimationBlender.opt<T>.none;
	}

	// Token: 0x0600174A RID: 5962 RVA: 0x00055B50 File Offset: 0x00053D50
	public static global::AnimationBlender.ChannelConfig Alias(this global::AnimationBlender.ChannelField Field, string Name)
	{
		return new global::AnimationBlender.ChannelConfig(Name, Field);
	}

	// Token: 0x0600174B RID: 5963 RVA: 0x00055B5C File Offset: 0x00053D5C
	public static global::AnimationBlender.ChannelConfig[] Alias(this global::AnimationBlender.ChannelField Field, global::AnimationBlender.ChannelConfig[] Array, int Index, string Name)
	{
		Array[Index] = Field.Alias(Name);
		return Array;
	}

	// Token: 0x0600174C RID: 5964 RVA: 0x00055B74 File Offset: 0x00053D74
	public static global::AnimationBlender.ChannelConfig[] Define(this global::AnimationBlender.ChannelConfig[] Array, int Index, string Name, global::AnimationBlender.ChannelField Field)
	{
		return Field.Alias(Array, Index, Name);
	}

	// Token: 0x0600174D RID: 5965 RVA: 0x00055B80 File Offset: 0x00053D80
	public static global::AnimationBlender.MixerConfig Alias(this global::AnimationBlender.ResidualField ResidualField, global::UnityEngine.Animation Animation, params global::AnimationBlender.ChannelConfig[] ChannelAliases)
	{
		return new global::AnimationBlender.MixerConfig(Animation, ResidualField, ChannelAliases);
	}

	// Token: 0x0600174E RID: 5966 RVA: 0x00055B8C File Offset: 0x00053D8C
	public static global::AnimationBlender.MixerConfig Alias(this global::AnimationBlender.ResidualField ResidualField, global::UnityEngine.Animation Animation, int ChannelCount)
	{
		return new global::AnimationBlender.MixerConfig(Animation, ResidualField, new global::AnimationBlender.ChannelConfig[ChannelCount]);
	}

	// Token: 0x0600174F RID: 5967 RVA: 0x00055B9C File Offset: 0x00053D9C
	public static global::AnimationBlender.Mixer Create(this global::AnimationBlender.MixerConfig Config)
	{
		return new global::AnimationBlender.Mixer(Config);
	}

	// Token: 0x02000281 RID: 641
	private struct Channel
	{
		// Token: 0x06001750 RID: 5968 RVA: 0x00055BA4 File Offset: 0x00053DA4
		public Channel(int index, int animationIndex, string name, global::AnimationBlender.ChannelField field)
		{
			this.index = index;
			this.animationIndex = animationIndex;
			this.name = name;
			this.field = field;
			this.induce = new global::AnimationBlender.ChannelCurve(field.inCurveInfo, default(global::AnimationBlender.State), default(global::AnimationBlender.Influence), field, true);
			this.reduce = new global::AnimationBlender.ChannelCurve(field.outCurveInfo, default(global::AnimationBlender.State), default(global::AnimationBlender.Influence), field, false);
			this.active = false;
			this.wasActive = false;
			this.startedTransition = false;
			this.valid = (animationIndex != -1);
			this.maxBlend = ((field.residualBlend > 0f) ? ((field.residualBlend < 1f) ? (1f - field.residualBlend) : 0f) : 1f);
			this.startTime = field.startFrame;
			this.playbackRate = field.playbackRate;
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x00055CA4 File Offset: 0x00053EA4
		private bool StartTransition(ref global::AnimationBlender.ChannelCurve from, ref global::AnimationBlender.ChannelCurve to, ref float dt, bool startNow)
		{
			if (to.state.delay == 0f && startNow)
			{
				to.state.delay = to.delayDuration;
			}
			if (to.state.delay > dt)
			{
				to.state.delay = to.state.delay - dt;
				return false;
			}
			dt -= to.state.delay;
			to.state.delay = 0f;
			to.influence.percent = 0f;
			to.influence.duration = from.state.percent * to.info.duration;
			to.influence.value = from.state.value;
			to.influence.active = (from.state.percent > 0f);
			to.influence.timeleft = to.influence.duration;
			from.state.delay = to.delayDuration;
			from.state.active = false;
			to.state.active = true;
			if (to.induces)
			{
				from.state.time = from.info.start;
				from.state.percent = 0f;
			}
			return true;
		}

		// Token: 0x06001752 RID: 5970 RVA: 0x00055DFC File Offset: 0x00053FFC
		private float Step(bool transitioning, ref global::AnimationBlender.ChannelCurve from, ref global::AnimationBlender.ChannelCurve to, ref float dt)
		{
			if (transitioning && to.state.delay > 0f)
			{
				return from.state.value;
			}
			float num = dt;
			float num2 = dt;
			float time = to.state.time;
			if (to.induces)
			{
				to.state.time = to.state.time + dt;
				if (to.state.time >= to.info.end)
				{
					num = to.state.time - to.info.end;
					to.state.time = to.info.end;
					to.state.percent = 1f;
					from.state.delay = from.delayDuration;
				}
				else
				{
					num = 0f;
					to.state.percent = to.info.TimeToPercent(to.state.time);
				}
			}
			else if (to.influence.duration == 0f)
			{
				num = dt;
				to.state.percent = 1f;
				to.state.time = to.info.end;
			}
			else
			{
				float num3 = from.info.duration / to.influence.duration;
				to.state.time = to.state.time + dt * num3;
				if (to.state.time >= to.info.end)
				{
					num = (to.state.time - to.info.end) / num3;
					to.state.percent = 1f;
					to.state.time = to.info.end;
				}
				else
				{
					num = 0f;
					to.state.percent = to.info.TimeToPercent(to.state.time);
				}
			}
			float num4 = to.info.SampleTime(to.state.time);
			if (to.influence.active)
			{
				if (to.induces)
				{
					if (to.influence.timeleft > dt)
					{
						to.influence.timeleft = to.influence.timeleft - dt;
						num2 = 0f;
						to.influence.percent = to.influence.timeleft / to.influence.duration;
					}
					else
					{
						num2 = dt - to.influence.timeleft;
						to.influence.timeleft = 0f;
						to.influence.percent = 0f;
						to.influence.active = false;
					}
				}
				else if (to.state.percent >= 1f && to.influence.active)
				{
					to.influence.active = false;
					from.state = default(global::AnimationBlender.State);
				}
			}
			if (to.induces)
			{
				to.state.value = ((!to.influence.active) ? num4 : (num4 + (to.influence.value - num4) * to.influence.percent));
			}
			else
			{
				to.state.value = to.influence.value * num4;
			}
			if (num2 < num)
			{
				dt = num2;
			}
			else
			{
				dt = num;
			}
			return to.state.value;
		}

		// Token: 0x06001753 RID: 5971 RVA: 0x0005618C File Offset: 0x0005438C
		public float Update(float dt)
		{
			bool flag = this.active != this.wasActive;
			if (flag)
			{
				bool startNow = this.startedTransition != this.active;
				this.startedTransition = this.active;
				bool flag2;
				if (this.active)
				{
					flag2 = this.StartTransition(ref this.reduce, ref this.induce, ref dt, startNow);
				}
				else
				{
					flag2 = this.StartTransition(ref this.induce, ref this.reduce, ref dt, startNow);
				}
				if (flag2)
				{
					flag = false;
					this.wasActive = this.active;
				}
			}
			if (this.wasActive)
			{
				return this.Step(flag, ref this.reduce, ref this.induce, ref dt);
			}
			return this.Step(flag, ref this.induce, ref this.reduce, ref dt);
		}

		// Token: 0x04000BDB RID: 3035
		[global::System.NonSerialized]
		public global::AnimationBlender.ChannelField field;

		// Token: 0x04000BDC RID: 3036
		[global::System.NonSerialized]
		public string name;

		// Token: 0x04000BDD RID: 3037
		[global::System.NonSerialized]
		public bool active;

		// Token: 0x04000BDE RID: 3038
		[global::System.NonSerialized]
		public bool valid;

		// Token: 0x04000BDF RID: 3039
		[global::System.NonSerialized]
		public bool wasActive;

		// Token: 0x04000BE0 RID: 3040
		[global::System.NonSerialized]
		public bool startedTransition;

		// Token: 0x04000BE1 RID: 3041
		[global::System.NonSerialized]
		public global::AnimationBlender.ChannelCurve induce;

		// Token: 0x04000BE2 RID: 3042
		[global::System.NonSerialized]
		public global::AnimationBlender.ChannelCurve reduce;

		// Token: 0x04000BE3 RID: 3043
		[global::System.NonSerialized]
		public int index;

		// Token: 0x04000BE4 RID: 3044
		[global::System.NonSerialized]
		public int animationIndex;

		// Token: 0x04000BE5 RID: 3045
		[global::System.NonSerialized]
		public float maxBlend;

		// Token: 0x04000BE6 RID: 3046
		[global::System.NonSerialized]
		public float playbackRate;

		// Token: 0x04000BE7 RID: 3047
		[global::System.NonSerialized]
		public float startTime;
	}

	// Token: 0x02000282 RID: 642
	private struct ChannelCurve
	{
		// Token: 0x06001754 RID: 5972 RVA: 0x00056258 File Offset: 0x00054458
		public ChannelCurve(global::AnimationBlender.CurveInfo info, global::AnimationBlender.State state, global::AnimationBlender.Influence influence, global::AnimationBlender.ChannelField field, bool induces)
		{
			this.info = info;
			this.state = state;
			this.influence = influence;
			this.induces = induces;
			this.delayDuration = ((!induces) ? field.outDelay : field.inDelay);
		}

		// Token: 0x04000BE8 RID: 3048
		[global::System.NonSerialized]
		public global::AnimationBlender.CurveInfo info;

		// Token: 0x04000BE9 RID: 3049
		[global::System.NonSerialized]
		public global::AnimationBlender.State state;

		// Token: 0x04000BEA RID: 3050
		[global::System.NonSerialized]
		public global::AnimationBlender.Influence influence;

		// Token: 0x04000BEB RID: 3051
		[global::System.NonSerialized]
		public float delayDuration;

		// Token: 0x04000BEC RID: 3052
		[global::System.NonSerialized]
		public bool induces;
	}

	// Token: 0x02000283 RID: 643
	private struct Influence
	{
		// Token: 0x04000BED RID: 3053
		[global::System.NonSerialized]
		public bool active;

		// Token: 0x04000BEE RID: 3054
		[global::System.NonSerialized]
		public float value;

		// Token: 0x04000BEF RID: 3055
		[global::System.NonSerialized]
		public float percent;

		// Token: 0x04000BF0 RID: 3056
		[global::System.NonSerialized]
		public float timeleft;

		// Token: 0x04000BF1 RID: 3057
		[global::System.NonSerialized]
		public float duration;
	}

	// Token: 0x02000284 RID: 644
	private struct State
	{
		// Token: 0x04000BF2 RID: 3058
		[global::System.NonSerialized]
		public bool active;

		// Token: 0x04000BF3 RID: 3059
		[global::System.NonSerialized]
		public float time;

		// Token: 0x04000BF4 RID: 3060
		[global::System.NonSerialized]
		public float percent;

		// Token: 0x04000BF5 RID: 3061
		[global::System.NonSerialized]
		public float delay;

		// Token: 0x04000BF6 RID: 3062
		[global::System.NonSerialized]
		public float value;
	}

	// Token: 0x02000285 RID: 645
	private struct Tracker
	{
		// Token: 0x04000BF7 RID: 3063
		[global::System.NonSerialized]
		public global::UnityEngine.AnimationClip clip;

		// Token: 0x04000BF8 RID: 3064
		[global::System.NonSerialized]
		public global::UnityEngine.AnimationState state;

		// Token: 0x04000BF9 RID: 3065
		[global::System.NonSerialized]
		public int[] channels;

		// Token: 0x04000BFA RID: 3066
		[global::System.NonSerialized]
		public int channelCount;

		// Token: 0x04000BFB RID: 3067
		[global::System.NonSerialized]
		public global::AnimationBlender.WeightResult channelWeight;

		// Token: 0x04000BFC RID: 3068
		[global::System.NonSerialized]
		public float playbackRate;

		// Token: 0x04000BFD RID: 3069
		[global::System.NonSerialized]
		public float blendFraction;

		// Token: 0x04000BFE RID: 3070
		[global::System.NonSerialized]
		public float startTime;

		// Token: 0x04000BFF RID: 3071
		[global::System.NonSerialized]
		public bool enabled;

		// Token: 0x04000C00 RID: 3072
		[global::System.NonSerialized]
		public bool wasEnabled;
	}

	// Token: 0x02000286 RID: 646
	private struct TrackerBlender
	{
		// Token: 0x06001755 RID: 5973 RVA: 0x00056298 File Offset: 0x00054498
		public TrackerBlender(int count)
		{
			this.trackers = new int[count];
			this.trackerCount = count;
			this.trackerWeight = default(global::AnimationBlender.WeightResult);
			for (int i = 0; i < count; i++)
			{
				this.trackers[i] = i;
			}
		}

		// Token: 0x04000C01 RID: 3073
		[global::System.NonSerialized]
		public int[] trackers;

		// Token: 0x04000C02 RID: 3074
		[global::System.NonSerialized]
		public int trackerCount;

		// Token: 0x04000C03 RID: 3075
		[global::System.NonSerialized]
		public global::AnimationBlender.WeightResult trackerWeight;
	}

	// Token: 0x02000287 RID: 647
	private struct opt<T>
	{
		// Token: 0x06001756 RID: 5974 RVA: 0x000562E4 File Offset: 0x000544E4
		private opt(T value, bool defined)
		{
			this.value = value;
			this.defined = defined;
		}

		// Token: 0x06001757 RID: 5975 RVA: 0x000562F4 File Offset: 0x000544F4
		// Note: this type is marked as 'beforefieldinit'.
		static opt()
		{
		}

		// Token: 0x06001758 RID: 5976 RVA: 0x00056310 File Offset: 0x00054510
		public bool check(out T value)
		{
			value = this.value;
			return this.defined;
		}

		// Token: 0x1700067B RID: 1659
		public T this[T fallback]
		{
			get
			{
				return (!this.defined) ? fallback : this.value;
			}
		}

		// Token: 0x0600175A RID: 5978 RVA: 0x00056340 File Offset: 0x00054540
		public static implicit operator global::AnimationBlender.opt<T>(T value)
		{
			return new global::AnimationBlender.opt<T>(value, true);
		}

		// Token: 0x04000C04 RID: 3076
		[global::System.NonSerialized]
		public readonly T value;

		// Token: 0x04000C05 RID: 3077
		[global::System.NonSerialized]
		public readonly bool defined;

		// Token: 0x04000C06 RID: 3078
		public static readonly global::AnimationBlender.opt<T> none = default(global::AnimationBlender.opt<T>);
	}

	// Token: 0x02000288 RID: 648
	private struct WeightUnit
	{
		// Token: 0x1700067C RID: 1660
		// (get) Token: 0x0600175B RID: 5979 RVA: 0x0005634C File Offset: 0x0005454C
		public bool any
		{
			get
			{
				return this.raw > 0f;
			}
		}

		// Token: 0x0600175C RID: 5980 RVA: 0x0005635C File Offset: 0x0005455C
		public float SetScaledRecip(float recip)
		{
			return this.normalized = (this.scaled = this.raw * recip);
		}

		// Token: 0x0600175D RID: 5981 RVA: 0x00056384 File Offset: 0x00054584
		public float SetNormalizedRecip(float recip)
		{
			return this.normalized = this.scaled * recip;
		}

		// Token: 0x04000C07 RID: 3079
		[global::System.NonSerialized]
		public float raw;

		// Token: 0x04000C08 RID: 3080
		[global::System.NonSerialized]
		public float scaled;

		// Token: 0x04000C09 RID: 3081
		[global::System.NonSerialized]
		public float normalized;
	}

	// Token: 0x02000289 RID: 649
	private struct WeightResult
	{
		// Token: 0x04000C0A RID: 3082
		[global::System.NonSerialized]
		public int count;

		// Token: 0x04000C0B RID: 3083
		[global::System.NonSerialized]
		public int winner;

		// Token: 0x04000C0C RID: 3084
		public global::AnimationBlender.WeightUnit sum;
	}

	// Token: 0x0200028A RID: 650
	private struct Weighted<T>
	{
		// Token: 0x04000C0D RID: 3085
		[global::System.NonSerialized]
		public global::AnimationBlender.WeightUnit weight;

		// Token: 0x04000C0E RID: 3086
		[global::System.NonSerialized]
		public T value;
	}

	// Token: 0x0200028B RID: 651
	public struct CurveInfo
	{
		// Token: 0x0600175E RID: 5982 RVA: 0x000563A4 File Offset: 0x000545A4
		public CurveInfo(global::UnityEngine.AnimationCurve curve)
		{
			this.curve = curve;
			if ((this.length = curve.length) == 0)
			{
				this.start = (this.firstTime = (this.end = (this.lastTime = (this.duration = 0f))));
				this.percentRate = float.PositiveInfinity;
			}
			else
			{
				this.firstTime = curve[0].time;
				this.end = (this.lastTime = ((this.length != 1) ? curve[this.length - 1].time : this.firstTime));
				this.start = ((this.firstTime >= 0f) ? 0f : this.firstTime);
				if (this.end < this.start)
				{
					this.end = this.start;
					this.start = this.lastTime;
				}
				this.duration = this.end - this.start;
				this.percentRate = 1f / this.duration;
			}
		}

		// Token: 0x0600175F RID: 5983 RVA: 0x000564D0 File Offset: 0x000546D0
		public float TimeToPercentClamped(float time)
		{
			return (time < this.end) ? ((time > this.start) ? ((time - this.start) / this.duration) : 1f) : 1f;
		}

		// Token: 0x06001760 RID: 5984 RVA: 0x00056510 File Offset: 0x00054710
		public float TimeToPercent(float time)
		{
			return (time - this.start) / this.duration;
		}

		// Token: 0x06001761 RID: 5985 RVA: 0x00056524 File Offset: 0x00054724
		public float PercentToTimeClamped(float percent)
		{
			return (percent > 0f) ? ((percent < 1f) ? (this.start + this.duration * percent) : this.end) : this.start;
		}

		// Token: 0x06001762 RID: 5986 RVA: 0x00056564 File Offset: 0x00054764
		public float PercentToTime(float percent)
		{
			return this.start + this.duration * percent;
		}

		// Token: 0x06001763 RID: 5987 RVA: 0x00056578 File Offset: 0x00054778
		public float TimeClamp(float time)
		{
			return (time < this.end) ? ((time > this.start) ? time : this.start) : this.end;
		}

		// Token: 0x06001764 RID: 5988 RVA: 0x000565AC File Offset: 0x000547AC
		public float PercentClamp(float percent)
		{
			return (percent > 0f) ? ((percent < 1f) ? percent : 1f) : 0f;
		}

		// Token: 0x06001765 RID: 5989 RVA: 0x000565DC File Offset: 0x000547DC
		public float SampleTime(float time)
		{
			return this.curve.Evaluate(time);
		}

		// Token: 0x06001766 RID: 5990 RVA: 0x000565EC File Offset: 0x000547EC
		public float SamplePercent(float percent)
		{
			return this.SampleTime(this.PercentToTime(percent));
		}

		// Token: 0x06001767 RID: 5991 RVA: 0x000565FC File Offset: 0x000547FC
		public float SampleTimeClamped(float time)
		{
			return this.SampleTime(this.TimeClamp(time));
		}

		// Token: 0x06001768 RID: 5992 RVA: 0x0005660C File Offset: 0x0005480C
		public float SamplePercentClamped(float percent)
		{
			return this.SamplePercent(this.PercentToTimeClamped(percent));
		}

		// Token: 0x04000C0F RID: 3087
		[global::System.NonSerialized]
		public global::UnityEngine.AnimationCurve curve;

		// Token: 0x04000C10 RID: 3088
		[global::System.NonSerialized]
		public int length;

		// Token: 0x04000C11 RID: 3089
		[global::System.NonSerialized]
		public float start;

		// Token: 0x04000C12 RID: 3090
		[global::System.NonSerialized]
		public float firstTime;

		// Token: 0x04000C13 RID: 3091
		[global::System.NonSerialized]
		public float end;

		// Token: 0x04000C14 RID: 3092
		[global::System.NonSerialized]
		public float lastTime;

		// Token: 0x04000C15 RID: 3093
		[global::System.NonSerialized]
		public float duration;

		// Token: 0x04000C16 RID: 3094
		[global::System.NonSerialized]
		public float percentRate;
	}

	// Token: 0x0200028C RID: 652
	public struct MixerConfig
	{
		// Token: 0x06001769 RID: 5993 RVA: 0x0005661C File Offset: 0x0005481C
		public MixerConfig(global::UnityEngine.Animation animation, global::AnimationBlender.ResidualField residual, params global::AnimationBlender.ChannelConfig[] channels)
		{
			this.animation = animation;
			this.residual = residual;
			this.channels = channels;
		}

		// Token: 0x04000C17 RID: 3095
		[global::System.NonSerialized]
		public readonly global::UnityEngine.Animation animation;

		// Token: 0x04000C18 RID: 3096
		[global::System.NonSerialized]
		public readonly global::AnimationBlender.ResidualField residual;

		// Token: 0x04000C19 RID: 3097
		[global::System.NonSerialized]
		public readonly global::AnimationBlender.ChannelConfig[] channels;
	}

	// Token: 0x0200028D RID: 653
	public struct ChannelConfig
	{
		// Token: 0x0600176A RID: 5994 RVA: 0x00056634 File Offset: 0x00054834
		public ChannelConfig(string name, global::AnimationBlender.ChannelField field)
		{
			this.name = name;
			this.field = field;
		}

		// Token: 0x04000C1A RID: 3098
		[global::System.NonSerialized]
		public readonly string name;

		// Token: 0x04000C1B RID: 3099
		[global::System.NonSerialized]
		public readonly global::AnimationBlender.ChannelField field;
	}

	// Token: 0x0200028E RID: 654
	[global::System.Serializable]
	public class Field
	{
		// Token: 0x0600176B RID: 5995 RVA: 0x00056644 File Offset: 0x00054844
		public Field()
		{
		}

		// Token: 0x1700067D RID: 1661
		// (get) Token: 0x0600176C RID: 5996 RVA: 0x0005664C File Offset: 0x0005484C
		public bool defined
		{
			get
			{
				return !string.IsNullOrEmpty(this.clipName);
			}
		}

		// Token: 0x04000C1C RID: 3100
		[global::UnityEngine.SerializeField]
		public string clipName;

		// Token: 0x04000C1D RID: 3101
		[global::UnityEngine.SerializeField]
		public float startFrame;

		// Token: 0x04000C1E RID: 3102
		[global::UnityEngine.SerializeField]
		public float playbackRate;
	}

	// Token: 0x0200028F RID: 655
	[global::System.Serializable]
	public sealed class ResidualField : global::AnimationBlender.Field
	{
		// Token: 0x0600176D RID: 5997 RVA: 0x0005665C File Offset: 0x0005485C
		public ResidualField()
		{
			this.clipName = string.Empty;
			this.playbackRate = 1f;
			this.changeAnimLayer = false;
			this.channelBlend = (this.residualBlend = 0);
		}

		// Token: 0x1700067E RID: 1662
		// (get) Token: 0x0600176E RID: 5998 RVA: 0x0005669C File Offset: 0x0005489C
		public global::AnimationBlender.CurveInfo introCurveInfo
		{
			get
			{
				return new global::AnimationBlender.CurveInfo(this.introCurve);
			}
		}

		// Token: 0x04000C1F RID: 3103
		[global::UnityEngine.SerializeField]
		public global::UnityEngine.AnimationCurve introCurve;

		// Token: 0x04000C20 RID: 3104
		[global::UnityEngine.SerializeField]
		public global::UnityEngine.AnimationBlendMode residualBlend;

		// Token: 0x04000C21 RID: 3105
		[global::UnityEngine.SerializeField]
		public global::UnityEngine.AnimationBlendMode channelBlend;

		// Token: 0x04000C22 RID: 3106
		[global::UnityEngine.SerializeField]
		public int animLayer;

		// Token: 0x04000C23 RID: 3107
		[global::UnityEngine.SerializeField]
		public bool changeAnimLayer;
	}

	// Token: 0x02000290 RID: 656
	[global::System.Serializable]
	public sealed class ChannelField : global::AnimationBlender.Field
	{
		// Token: 0x0600176F RID: 5999 RVA: 0x000566AC File Offset: 0x000548AC
		public ChannelField()
		{
			this.clipName = string.Empty;
			this.playbackRate = 1f;
			this.inCurve = global::UnityEngine.AnimationCurve.Linear(0f, 0f, 1f, 1f);
			this.outCurve = global::UnityEngine.AnimationCurve.Linear(0f, 1f, 1f, 0f);
		}

		// Token: 0x1700067F RID: 1663
		// (get) Token: 0x06001770 RID: 6000 RVA: 0x00056714 File Offset: 0x00054914
		public global::AnimationBlender.CurveInfo inCurveInfo
		{
			get
			{
				return new global::AnimationBlender.CurveInfo(this.inCurve);
			}
		}

		// Token: 0x17000680 RID: 1664
		// (get) Token: 0x06001771 RID: 6001 RVA: 0x00056724 File Offset: 0x00054924
		public global::AnimationBlender.CurveInfo outCurveInfo
		{
			get
			{
				return new global::AnimationBlender.CurveInfo(this.outCurve);
			}
		}

		// Token: 0x04000C24 RID: 3108
		[global::UnityEngine.SerializeField]
		public float inDelay;

		// Token: 0x04000C25 RID: 3109
		[global::UnityEngine.SerializeField]
		public float outDelay;

		// Token: 0x04000C26 RID: 3110
		[global::UnityEngine.SerializeField]
		public float residualBlend;

		// Token: 0x04000C27 RID: 3111
		[global::UnityEngine.SerializeField]
		public bool blockedByAnimation;

		// Token: 0x04000C28 RID: 3112
		[global::UnityEngine.SerializeField]
		public global::UnityEngine.AnimationCurve inCurve;

		// Token: 0x04000C29 RID: 3113
		[global::UnityEngine.SerializeField]
		public global::UnityEngine.AnimationCurve outCurve;
	}

	// Token: 0x02000291 RID: 657
	public sealed class Mixer
	{
		// Token: 0x06001772 RID: 6002 RVA: 0x00056734 File Offset: 0x00054934
		public Mixer(global::AnimationBlender.MixerConfig config)
		{
			if (!config.animation)
			{
				throw new global::System.ArgumentException("null or missing", "config.animation");
			}
			this.animation = config.animation;
			this.residualField = config.residual;
			this.hasResidual = (!object.ReferenceEquals(config.residual, null) && config.residual.defined && this.animation.GetClip(config.residual.clipName));
			this.oneShotBlendIn = ((!this.hasResidual || object.ReferenceEquals(config.residual.introCurve, null)) ? default(global::AnimationBlender.CurveInfo) : config.residual.introCurveInfo);
			this.hasOneShotBlendIn = (this.oneShotBlendIn.duration > 0f);
			this.residualState = ((!this.hasResidual) ? null : this.animation[config.residual.clipName]);
			this.channelCount = config.channels.Length;
			this.channels = new global::AnimationBlender.Weighted<global::AnimationBlender.Channel>[this.channelCount];
			this.trackers = new global::AnimationBlender.Weighted<global::AnimationBlender.Tracker>[this.channelCount];
			this.trackerCount = 0;
			this.nameToChannel = new global::System.Collections.Generic.Dictionary<string, int>(this.channelCount);
			for (int i = 0; i < this.channelCount; i++)
			{
				global::AnimationBlender.ChannelField field = config.channels[i].field;
				string name = config.channels[i].name;
				this.nameToChannel.Add(name, i);
				int num = -1;
				global::UnityEngine.AnimationClip clip;
				if (field.defined && (clip = this.animation.GetClip(field.clipName)))
				{
					bool flag = false;
					while (!flag)
					{
						if (flag = (++num == this.trackerCount))
						{
							this.trackers[num].value.clip = clip;
							this.trackers[num].value.state = this.animation[field.clipName];
							this.trackers[num].value.channelCount = 1;
							this.trackerCount++;
						}
						else if (flag = (this.trackers[num].value.clip == clip))
						{
							global::AnimationBlender.Weighted<global::AnimationBlender.Tracker>[] array = this.trackers;
							int num2 = num;
							array[num2].value.channelCount = array[num2].value.channelCount + 1;
						}
					}
					this.definedChannelCount++;
				}
				this.channels[i].value = new global::AnimationBlender.Channel(i, num, name, field);
			}
			for (int j = 0; j < this.trackerCount; j++)
			{
				this.trackers[j].value.channels = new int[global::AnimationBlender.GetClear(ref this.trackers[j].value.channelCount)];
			}
			this.definedChannels = new int[global::AnimationBlender.GetClear(ref this.definedChannelCount)];
			for (int k = 0; k < this.channelCount; k++)
			{
				if (this.channels[k].value.animationIndex != -1)
				{
					int[] array2 = this.trackers[this.channels[k].value.animationIndex].value.channels;
					global::AnimationBlender.Weighted<global::AnimationBlender.Tracker>[] array3 = this.trackers;
					int animationIndex = this.channels[k].value.animationIndex;
					int num3;
					array3[animationIndex].value.channelCount = (num3 = array3[animationIndex].value.channelCount) + 1;
					array2[num3] = (this.definedChannels[this.definedChannelCount++] = k);
				}
			}
			global::AnimationBlender.ArrayResize<global::AnimationBlender.Weighted<global::AnimationBlender.Tracker>>(ref this.trackers, this.trackerCount);
			global::AnimationBlender.ArrayResize<global::AnimationBlender.Weighted<global::AnimationBlender.Channel>>(ref this.channels, this.channelCount);
			global::AnimationBlender.ArrayResize<int>(ref this.definedChannels, this.definedChannelCount);
			for (int l = 0; l < this.trackerCount; l++)
			{
				global::AnimationBlender.ArrayResize<int>(ref this.trackers[l].value.channels, this.trackers[l].value.channelCount);
			}
			this.blender = new global::AnimationBlender.TrackerBlender(this.trackerCount);
			if (this.hasResidual)
			{
				if (this.residualField.changeAnimLayer)
				{
					this.residualState.layer = this.residualField.animLayer;
					for (int m = 0; m < this.trackerCount; m++)
					{
						this.trackers[m].value.state.layer = this.residualField.animLayer;
					}
				}
				this.residualState.blendMode = (this.residualBlendMode = this.residualField.residualBlend);
				this.channelBlendMode = this.residualField.channelBlend;
				for (int n = 0; n < this.trackerCount; n++)
				{
					this.trackers[n].value.state.blendMode = this.channelBlendMode;
				}
			}
		}

		// Token: 0x17000681 RID: 1665
		// (get) Token: 0x06001773 RID: 6003 RVA: 0x00056CB0 File Offset: 0x00054EB0
		public bool isPlayingManualAnimation
		{
			get
			{
				return this.ManualAnimationsPlaying(false);
			}
		}

		// Token: 0x06001774 RID: 6004 RVA: 0x00056CBC File Offset: 0x00054EBC
		private bool PlayQueuedDirect(string animationName, global::AnimationBlender.opt<global::UnityEngine.QueueMode> queueMode, global::AnimationBlender.opt<global::UnityEngine.PlayMode> playMode)
		{
			global::UnityEngine.PlayMode playMode2;
			if (playMode.check(out playMode2))
			{
				return this.animation.PlayQueued(animationName, queueMode[0], playMode2);
			}
			global::UnityEngine.QueueMode queueMode2;
			if (queueMode.check(out queueMode2))
			{
				return this.animation.PlayQueued(animationName, queueMode2);
			}
			return this.animation.PlayQueued(animationName);
		}

		// Token: 0x06001775 RID: 6005 RVA: 0x00056D24 File Offset: 0x00054F24
		private bool PlayDirect(string animationName, global::AnimationBlender.opt<global::UnityEngine.PlayMode> playMode)
		{
			global::UnityEngine.PlayMode playMode2;
			if (playMode.check(out playMode2))
			{
				return this.animation.Play(animationName, playMode2);
			}
			return this.animation.Play(animationName);
		}

		// Token: 0x06001776 RID: 6006 RVA: 0x00056D5C File Offset: 0x00054F5C
		private void CrossFadeDirect(string animationName, global::AnimationBlender.opt<float> fadeLength, global::AnimationBlender.opt<global::UnityEngine.PlayMode> playMode)
		{
			if (playMode.defined)
			{
				this.animation.CrossFade(animationName, fadeLength[0.3f], playMode.value);
			}
			else if (fadeLength.defined)
			{
				this.animation.CrossFade(animationName, fadeLength.value);
			}
			else
			{
				this.animation.CrossFade(animationName);
			}
		}

		// Token: 0x06001777 RID: 6007 RVA: 0x00056DCC File Offset: 0x00054FCC
		private void StopBlendingNow()
		{
			for (int i = 0; i < this.trackerCount; i++)
			{
				this.trackers[i].value.state.enabled = false;
			}
		}

		// Token: 0x06001778 RID: 6008 RVA: 0x00056E0C File Offset: 0x0005500C
		private bool PlayQueuedOpt(string animationName, global::AnimationBlender.opt<global::UnityEngine.QueueMode> queueMode, global::AnimationBlender.opt<global::UnityEngine.PlayMode> playMode)
		{
			if (string.IsNullOrEmpty(animationName) || !this.PlayQueuedDirect(animationName, queueMode, playMode))
			{
				return false;
			}
			this.StopBlendingNow();
			if (queueMode.defined && queueMode.value == 2)
			{
				this.queuedAnimations.Clear();
				this.playingOneShot = false;
				this.oneShotAnimation = null;
				this.SetOneShotAnimation(animationName);
			}
			else if (this.playingOneShot)
			{
				this.queuedAnimations.Enqueue(animationName);
			}
			else
			{
				this.SetOneShotAnimation(animationName);
			}
			return true;
		}

		// Token: 0x06001779 RID: 6009 RVA: 0x00056EA0 File Offset: 0x000550A0
		private bool PlayOpt(string animationName, global::AnimationBlender.opt<global::UnityEngine.PlayMode> playMode, global::AnimationBlender.opt<float> speed, global::AnimationBlender.opt<float> startTime)
		{
			global::UnityEngine.AnimationState animationState;
			if (string.IsNullOrEmpty(animationName) || (animationState = this.animation[animationName]) == null)
			{
				return false;
			}
			if (!playMode.defined)
			{
				this.animation.Stop();
			}
			float speed2;
			if (speed.defined)
			{
				speed2 = animationState.speed;
				animationState.speed = speed.value;
			}
			else
			{
				speed2 = 0f;
			}
			if (!this.PlayDirect(animationName, playMode))
			{
				if (speed.defined)
				{
					animationState.speed = speed2;
				}
				return false;
			}
			this.queuedAnimations.Clear();
			this.playingOneShot = true;
			this.oneShotAnimation = animationState;
			if (startTime.defined)
			{
				animationState.time = startTime.value;
			}
			return true;
		}

		// Token: 0x0600177A RID: 6010 RVA: 0x00056F6C File Offset: 0x0005516C
		private bool CrossFadeOpt(string animationName, global::AnimationBlender.opt<float> fadeLength, global::AnimationBlender.opt<global::UnityEngine.PlayMode> playMode, global::AnimationBlender.opt<float> speed, global::AnimationBlender.opt<float> startTime)
		{
			global::UnityEngine.AnimationState animationState;
			if (string.IsNullOrEmpty(animationName) || (animationState = this.animation[animationName]) == null)
			{
				return false;
			}
			if (speed.defined)
			{
				animationState.speed = speed.value;
			}
			this.CrossFadeDirect(animationName, fadeLength, playMode);
			this.queuedAnimations.Clear();
			this.playingOneShot = true;
			this.oneShotAnimation = animationState;
			if (startTime.defined)
			{
				animationState.time = startTime.value;
			}
			return true;
		}

		// Token: 0x0600177B RID: 6011 RVA: 0x00056FF4 File Offset: 0x000551F4
		private bool ManualAnimationsPlaying(bool ClearWhenNone)
		{
			if (!this.playingOneShot)
			{
				return false;
			}
			while (object.ReferenceEquals(this.oneShotAnimation, null) || !this.oneShotAnimation.enabled)
			{
				if (this.queuedAnimations.Count == 0)
				{
					if (ClearWhenNone)
					{
						this.oneShotAnimation = null;
						this.playingOneShot = false;
					}
					return false;
				}
				this.SetOneShotAnimation(this.queuedAnimations.Dequeue());
			}
			return true;
		}

		// Token: 0x0600177C RID: 6012 RVA: 0x00057070 File Offset: 0x00055270
		private void UpdateChannel(ref global::AnimationBlender.Weighted<global::AnimationBlender.Channel> channel, float dt)
		{
			bool flag;
			if (flag = (channel.value.field.blockedByAnimation && this.animationBlocking && channel.value.active))
			{
				channel.value.active = false;
			}
			channel.weight.raw = channel.value.Update(dt);
			if (flag)
			{
				channel.value.active = true;
			}
		}

		// Token: 0x0600177D RID: 6013 RVA: 0x000570E8 File Offset: 0x000552E8
		private void UpdateTracker(ref global::AnimationBlender.Weighted<global::AnimationBlender.Tracker> tracker, float dt)
		{
			for (int i = 0; i < tracker.value.channelCount; i++)
			{
				this.UpdateChannel(ref this.channels[tracker.value.channels[i]], dt);
			}
			if (tracker.value.enabled = global::AnimationBlender.WeightOf<global::AnimationBlender.Channel>(this.channels, tracker.value.channels, out tracker.value.channelWeight))
			{
				tracker.value.startTime = this.channels[tracker.value.channels[tracker.value.channelWeight.winner]].value.startTime;
				float num = 0f;
				float num2 = 0f;
				for (int j = 0; j < tracker.value.channelWeight.count; j++)
				{
					float normalized;
					num += this.channels[tracker.value.channels[j]].value.playbackRate * (normalized = this.channels[tracker.value.channels[j]].weight.normalized);
					num2 += this.channels[tracker.value.channels[j]].value.maxBlend * normalized;
				}
				tracker.value.playbackRate = num;
				tracker.value.blendFraction = num2;
			}
			tracker.weight.raw = tracker.value.channelWeight.sum.raw;
		}

		// Token: 0x0600177E RID: 6014 RVA: 0x00057280 File Offset: 0x00055480
		private bool UpdateBlender(ref global::AnimationBlender.TrackerBlender blender, float dt, float externalBlend, out float residualBlend)
		{
			for (int i = 0; i < this.trackerCount; i++)
			{
				this.UpdateTracker(ref this.trackers[blender.trackers[i]], dt);
			}
			bool flag = global::AnimationBlender.WeightOf<global::AnimationBlender.Tracker>(this.trackers, blender.trackers, out blender.trackerWeight);
			for (int j = blender.trackerWeight.count; j < blender.trackerCount; j++)
			{
				this.DisableTracker(ref this.trackers[blender.trackers[j]].value);
			}
			float num = 0f;
			for (int k = 0; k < blender.trackerWeight.count; k++)
			{
				num += this.BindTracker(ref this.trackers[blender.trackers[k]], externalBlend);
			}
			return (residualBlend = (1f - num) * externalBlend) > 0f;
		}

		// Token: 0x0600177F RID: 6015 RVA: 0x00057374 File Offset: 0x00055574
		private void DisableTracker(ref global::AnimationBlender.Tracker tracker)
		{
			if (!tracker.wasEnabled)
			{
				return;
			}
			tracker.state.enabled = (tracker.wasEnabled = false);
			tracker.state.weight = 0f;
		}

		// Token: 0x06001780 RID: 6016 RVA: 0x000573B4 File Offset: 0x000555B4
		private float BindTracker(ref global::AnimationBlender.Weighted<global::AnimationBlender.Tracker> tracker, float externalBlend)
		{
			float num = tracker.weight.normalized;
			if (this.hasResidual)
			{
				num *= tracker.value.blendFraction;
			}
			if (this.blender.trackerWeight.sum.raw < 1f)
			{
				num *= this.blender.trackerWeight.sum.raw;
			}
			if (num > 0f)
			{
				if (!tracker.value.wasEnabled)
				{
					tracker.value.state.enabled = (tracker.value.wasEnabled = true);
					tracker.value.state.time = tracker.value.startTime;
				}
				tracker.value.state.weight = num * externalBlend;
				tracker.value.state.speed = tracker.value.playbackRate;
			}
			else if (tracker.value.wasEnabled)
			{
				this.DisableTracker(ref tracker.value);
			}
			return num;
		}

		// Token: 0x06001781 RID: 6017 RVA: 0x000574C4 File Offset: 0x000556C4
		public void SetActive(int channel, bool value)
		{
			this.channels[channel].value.active = value;
		}

		// Token: 0x06001782 RID: 6018 RVA: 0x000574E0 File Offset: 0x000556E0
		public void SetActive(string channel, bool value)
		{
			this.SetActive(this.nameToChannel[channel], value);
		}

		// Token: 0x06001783 RID: 6019 RVA: 0x000574F8 File Offset: 0x000556F8
		public void SetSolo(int channel)
		{
			for (int i = 0; i < this.channelCount; i++)
			{
				this.SetActive(i, i == channel);
			}
		}

		// Token: 0x06001784 RID: 6020 RVA: 0x00057528 File Offset: 0x00055728
		public void SetSolo(string channel)
		{
			this.SetSolo(this.nameToChannel[channel]);
		}

		// Token: 0x06001785 RID: 6021 RVA: 0x0005753C File Offset: 0x0005573C
		public void SetSolo(int channel, bool muteall)
		{
			if (muteall)
			{
				for (int i = 0; i < this.channelCount; i++)
				{
					this.SetActive(i, false);
				}
			}
			else
			{
				this.SetSolo(channel);
			}
		}

		// Token: 0x06001786 RID: 6022 RVA: 0x0005757C File Offset: 0x0005577C
		public void SetSolo(string channel, bool muteall)
		{
			this.SetSolo(this.nameToChannel[channel], muteall);
		}

		// Token: 0x06001787 RID: 6023 RVA: 0x00057594 File Offset: 0x00055794
		public bool SetOneShotAnimation(global::UnityEngine.AnimationState animationState)
		{
			if (animationState == null)
			{
				return false;
			}
			this.oneShotAnimation = animationState;
			return this.playingOneShot = true;
		}

		// Token: 0x06001788 RID: 6024 RVA: 0x000575C0 File Offset: 0x000557C0
		public bool SetOneShotAnimation(string animationName)
		{
			return !string.IsNullOrEmpty(animationName) && this.SetOneShotAnimation(this.animation[animationName]);
		}

		// Token: 0x06001789 RID: 6025 RVA: 0x000575F0 File Offset: 0x000557F0
		public bool Play(string animationName)
		{
			return this.PlayOpt(animationName, global::AnimationBlender.opt<global::UnityEngine.PlayMode>.none, global::AnimationBlender.opt<float>.none, global::AnimationBlender.opt<float>.none);
		}

		// Token: 0x0600178A RID: 6026 RVA: 0x00057608 File Offset: 0x00055808
		public bool Play(string animationName, global::UnityEngine.PlayMode playMode)
		{
			return this.PlayOpt(animationName, playMode, global::AnimationBlender.opt<float>.none, global::AnimationBlender.opt<float>.none);
		}

		// Token: 0x0600178B RID: 6027 RVA: 0x00057624 File Offset: 0x00055824
		public bool Play(string animationName, global::UnityEngine.PlayMode playMode, float speed)
		{
			return this.PlayOpt(animationName, playMode, speed, global::AnimationBlender.opt<float>.none);
		}

		// Token: 0x0600178C RID: 6028 RVA: 0x00057640 File Offset: 0x00055840
		public bool Play(string animationName, global::UnityEngine.PlayMode playMode, float speed, float startTime)
		{
			return this.PlayOpt(animationName, playMode, speed, startTime);
		}

		// Token: 0x0600178D RID: 6029 RVA: 0x00057668 File Offset: 0x00055868
		public bool Play(string animationName, global::UnityEngine.PlayMode playMode, float? speed, float startTime)
		{
			return this.PlayOpt(animationName, playMode, global::AnimationBlender.to_opt<float>(speed), startTime);
		}

		// Token: 0x0600178E RID: 6030 RVA: 0x00057690 File Offset: 0x00055890
		public bool Play(string animationName, float speed)
		{
			return this.PlayOpt(animationName, global::AnimationBlender.opt<global::UnityEngine.PlayMode>.none, speed, global::AnimationBlender.opt<float>.none);
		}

		// Token: 0x0600178F RID: 6031 RVA: 0x000576AC File Offset: 0x000558AC
		public bool Play(string animationName, float speed, float startTime)
		{
			return this.PlayOpt(animationName, global::AnimationBlender.opt<global::UnityEngine.PlayMode>.none, speed, startTime);
		}

		// Token: 0x06001790 RID: 6032 RVA: 0x000576C8 File Offset: 0x000558C8
		public bool Play(string animationName, float? speed, float startTime)
		{
			return this.PlayOpt(animationName, global::AnimationBlender.opt<global::UnityEngine.PlayMode>.none, global::AnimationBlender.to_opt<float>(speed), startTime);
		}

		// Token: 0x06001791 RID: 6033 RVA: 0x000576E4 File Offset: 0x000558E4
		public bool PlayQueued(string animationName)
		{
			return this.PlayQueuedOpt(animationName, global::AnimationBlender.opt<global::UnityEngine.QueueMode>.none, global::AnimationBlender.opt<global::UnityEngine.PlayMode>.none);
		}

		// Token: 0x06001792 RID: 6034 RVA: 0x000576F8 File Offset: 0x000558F8
		public bool PlayQueued(string animationName, global::UnityEngine.QueueMode queueMode)
		{
			return this.PlayQueuedOpt(animationName, queueMode, global::AnimationBlender.opt<global::UnityEngine.PlayMode>.none);
		}

		// Token: 0x06001793 RID: 6035 RVA: 0x0005770C File Offset: 0x0005590C
		public bool PlayQueued(string animationName, global::UnityEngine.QueueMode queueMode, global::UnityEngine.PlayMode playMode)
		{
			return this.PlayQueuedOpt(animationName, queueMode, playMode);
		}

		// Token: 0x06001794 RID: 6036 RVA: 0x00057724 File Offset: 0x00055924
		public bool CrossFade(string animationName)
		{
			return this.CrossFadeOpt(animationName, global::AnimationBlender.opt<float>.none, global::AnimationBlender.opt<global::UnityEngine.PlayMode>.none, global::AnimationBlender.opt<float>.none, global::AnimationBlender.opt<float>.none);
		}

		// Token: 0x06001795 RID: 6037 RVA: 0x00057744 File Offset: 0x00055944
		public bool CrossFade(string animationName, float fadeLen)
		{
			return this.CrossFadeOpt(animationName, fadeLen, global::AnimationBlender.opt<global::UnityEngine.PlayMode>.none, global::AnimationBlender.opt<float>.none, global::AnimationBlender.opt<float>.none);
		}

		// Token: 0x06001796 RID: 6038 RVA: 0x00057764 File Offset: 0x00055964
		public bool CrossFade(string animationName, float fadeLen, global::UnityEngine.PlayMode playMode)
		{
			return this.CrossFadeOpt(animationName, fadeLen, playMode, global::AnimationBlender.opt<float>.none, global::AnimationBlender.opt<float>.none);
		}

		// Token: 0x06001797 RID: 6039 RVA: 0x00057790 File Offset: 0x00055990
		public bool CrossFade(string animationName, float fadeLen, global::UnityEngine.PlayMode playMode, float speed)
		{
			return this.CrossFadeOpt(animationName, fadeLen, playMode, speed, global::AnimationBlender.opt<float>.none);
		}

		// Token: 0x06001798 RID: 6040 RVA: 0x000577BC File Offset: 0x000559BC
		public bool CrossFade(string animationName, float fadeLen, global::UnityEngine.PlayMode playMode, float speed, float startTime)
		{
			return this.CrossFadeOpt(animationName, fadeLen, playMode, speed, startTime);
		}

		// Token: 0x06001799 RID: 6041 RVA: 0x000577EC File Offset: 0x000559EC
		public bool CrossFade(string animationName, float fadeLen, global::UnityEngine.PlayMode playMode, float? speed, float startTime)
		{
			return this.CrossFadeOpt(animationName, fadeLen, playMode, global::AnimationBlender.to_opt<float>(speed), startTime);
		}

		// Token: 0x0600179A RID: 6042 RVA: 0x0005781C File Offset: 0x00055A1C
		public void Update(float blend, float dt)
		{
			if (this.playingOneShot)
			{
				if (!this.ManualAnimationsPlaying(true))
				{
					this.oneShotBlendInTime = this.oneShotBlendIn.start + dt;
					if (this.oneShotBlendInTime > this.oneShotBlendIn.end)
					{
						this.oneShotBlendInTime = this.oneShotBlendIn.end;
					}
					this.animationBlocking = false;
					for (int i = 0; i < this.trackerCount; i++)
					{
						this.trackers[i].value.wasEnabled = false;
					}
				}
				else
				{
					this.oneShotBlendInTime = this.oneShotBlendIn.start;
					if (!this.hasOneShotBlendIn)
					{
						blend = 0f;
					}
					this.animationBlocking = true;
				}
			}
			else
			{
				this.animationBlocking = false;
				if (this.oneShotBlendInTime < this.oneShotBlendIn.end && (this.oneShotBlendInTime += dt) > this.oneShotBlendIn.end)
				{
					this.oneShotBlendInTime = this.oneShotBlendIn.end;
				}
			}
			if (this.hasOneShotBlendIn)
			{
				blend *= this.oneShotBlendIn.SampleTime(this.oneShotBlendInTime);
			}
			if (blend > 1f)
			{
				blend = 1f;
			}
			else if (blend < 0f)
			{
				blend = 0f;
			}
			float weight;
			if (this.UpdateBlender(ref this.blender, dt, blend, out weight))
			{
				if (this.hasResidual)
				{
					bool flag = !this.residualState.enabled;
					this.residualState.enabled = true;
					this.residualState.weight = weight;
					if (flag)
					{
						this.residualState.time = this.residualField.startFrame;
						this.residualState.speed = this.residualField.playbackRate;
					}
				}
			}
			else if (this.hasResidual && this.residualState.enabled)
			{
				this.residualState.enabled = false;
				this.residualState.weight = 0f;
			}
		}

		// Token: 0x0600179B RID: 6043 RVA: 0x00057A30 File Offset: 0x00055C30
		public void Debug(global::UnityEngine.Rect rect, string name)
		{
			global::AnimationBlender.Mixer.DbgGUI.TableStart(rect);
			for (int i = 0; i < this.channels.Length; i++)
			{
				if (this.channels[i].weight.any)
				{
					global::AnimationBlender.Mixer.DbgGUI.Label(this.channels[i].value.name);
				}
			}
			for (int j = 0; j < this.trackers.Length; j++)
			{
				if (this.trackers[j].value.enabled)
				{
					global::AnimationBlender.Mixer.DbgGUI.Label(this.trackers[j].value.state.name);
				}
			}
			if (this.hasResidual)
			{
				global::AnimationBlender.Mixer.DbgGUI.Label(this.residualState.name);
			}
			global::AnimationBlender.Mixer.DbgGUI.ColumnNext();
			for (int k = 0; k < this.channels.Length; k++)
			{
				if (this.channels[k].weight.any)
				{
					global::AnimationBlender.Mixer.DbgGUI.Fract(this.channels[k].weight.normalized);
				}
			}
			for (int l = 0; l < this.trackers.Length; l++)
			{
				if (this.trackers[l].value.enabled)
				{
					global::AnimationBlender.Mixer.DbgGUI.Fract(this.trackers[l].weight.normalized);
				}
			}
			if (this.hasResidual)
			{
				global::AnimationBlender.Mixer.DbgGUI.Fract(this.residualState.weight);
			}
			global::AnimationBlender.Mixer.DbgGUI.TableEnd();
		}

		// Token: 0x04000C2A RID: 3114
		[global::System.NonSerialized]
		private global::UnityEngine.Animation animation;

		// Token: 0x04000C2B RID: 3115
		[global::System.NonSerialized]
		private global::AnimationBlender.ResidualField residualField;

		// Token: 0x04000C2C RID: 3116
		[global::System.NonSerialized]
		private global::UnityEngine.AnimationState residualState;

		// Token: 0x04000C2D RID: 3117
		[global::System.NonSerialized]
		private global::UnityEngine.AnimationBlendMode residualBlendMode;

		// Token: 0x04000C2E RID: 3118
		[global::System.NonSerialized]
		private global::UnityEngine.AnimationBlendMode channelBlendMode;

		// Token: 0x04000C2F RID: 3119
		[global::System.NonSerialized]
		private global::UnityEngine.AnimationState oneShotAnimation;

		// Token: 0x04000C30 RID: 3120
		[global::System.NonSerialized]
		private bool playingOneShot;

		// Token: 0x04000C31 RID: 3121
		[global::System.NonSerialized]
		private bool animationBlocking;

		// Token: 0x04000C32 RID: 3122
		[global::System.NonSerialized]
		private int trackerCount;

		// Token: 0x04000C33 RID: 3123
		[global::System.NonSerialized]
		private int channelCount;

		// Token: 0x04000C34 RID: 3124
		[global::System.NonSerialized]
		private int definedChannelCount;

		// Token: 0x04000C35 RID: 3125
		[global::System.NonSerialized]
		private int[] definedChannels;

		// Token: 0x04000C36 RID: 3126
		[global::System.NonSerialized]
		private global::AnimationBlender.TrackerBlender blender;

		// Token: 0x04000C37 RID: 3127
		[global::System.NonSerialized]
		private global::AnimationBlender.Weighted<global::AnimationBlender.Channel>[] channels;

		// Token: 0x04000C38 RID: 3128
		[global::System.NonSerialized]
		private global::AnimationBlender.Weighted<global::AnimationBlender.Tracker>[] trackers;

		// Token: 0x04000C39 RID: 3129
		[global::System.NonSerialized]
		private global::System.Collections.Generic.Dictionary<string, int> nameToChannel;

		// Token: 0x04000C3A RID: 3130
		[global::System.NonSerialized]
		private global::AnimationBlender.CurveInfo oneShotBlendIn;

		// Token: 0x04000C3B RID: 3131
		[global::System.NonSerialized]
		private bool hasOneShotBlendIn;

		// Token: 0x04000C3C RID: 3132
		[global::System.NonSerialized]
		private global::System.Collections.Generic.Queue<string> queuedAnimations = new global::System.Collections.Generic.Queue<string>();

		// Token: 0x04000C3D RID: 3133
		[global::System.NonSerialized]
		private float oneShotBlendInTime;

		// Token: 0x04000C3E RID: 3134
		[global::System.NonSerialized]
		private float sumWeight;

		// Token: 0x04000C3F RID: 3135
		[global::System.NonSerialized]
		private bool hasResidual;

		// Token: 0x02000292 RID: 658
		private static class DbgGUI
		{
			// Token: 0x0600179C RID: 6044 RVA: 0x00057BC4 File Offset: 0x00055DC4
			// Note: this type is marked as 'beforefieldinit'.
			static DbgGUI()
			{
			}

			// Token: 0x0600179D RID: 6045 RVA: 0x00057C18 File Offset: 0x00055E18
			public static void Label(string str)
			{
				global::UnityEngine.GUILayout.Label(str, global::AnimationBlender.Mixer.DbgGUI.Cell);
			}

			// Token: 0x0600179E RID: 6046 RVA: 0x00057C28 File Offset: 0x00055E28
			public static void Fract(float frac)
			{
				global::UnityEngine.GUILayout.HorizontalSlider(frac, 0f, 1f, global::AnimationBlender.Mixer.DbgGUI.Cell);
			}

			// Token: 0x0600179F RID: 6047 RVA: 0x00057C40 File Offset: 0x00055E40
			public static void ColumnNext()
			{
				global::UnityEngine.GUILayout.EndVertical();
				global::UnityEngine.GUILayout.BeginVertical(global::AnimationBlender.Mixer.DbgGUI.OtherColumn);
			}

			// Token: 0x060017A0 RID: 6048 RVA: 0x00057C54 File Offset: 0x00055E54
			public static void TableStart(global::UnityEngine.Rect rect)
			{
				global::UnityEngine.GUILayout.BeginArea(rect);
				global::UnityEngine.GUILayout.BeginHorizontal(new global::UnityEngine.GUILayoutOption[0]);
				global::UnityEngine.GUILayout.BeginVertical(global::AnimationBlender.Mixer.DbgGUI.FirstColumn);
			}

			// Token: 0x060017A1 RID: 6049 RVA: 0x00057C74 File Offset: 0x00055E74
			public static void TableEnd()
			{
				global::UnityEngine.GUILayout.EndVertical();
				global::UnityEngine.GUILayout.EndHorizontal();
				global::UnityEngine.GUILayout.EndArea();
			}

			// Token: 0x04000C40 RID: 3136
			private static readonly global::UnityEngine.GUILayoutOption[] Cell = new global::UnityEngine.GUILayoutOption[]
			{
				global::UnityEngine.GUILayout.Height(18f)
			};

			// Token: 0x04000C41 RID: 3137
			private static readonly global::UnityEngine.GUILayoutOption[] FirstColumn = new global::UnityEngine.GUILayoutOption[]
			{
				global::UnityEngine.GUILayout.Width(128f)
			};

			// Token: 0x04000C42 RID: 3138
			private static readonly global::UnityEngine.GUILayoutOption[] OtherColumn = new global::UnityEngine.GUILayoutOption[]
			{
				global::UnityEngine.GUILayout.ExpandWidth(true)
			};
		}
	}
}
