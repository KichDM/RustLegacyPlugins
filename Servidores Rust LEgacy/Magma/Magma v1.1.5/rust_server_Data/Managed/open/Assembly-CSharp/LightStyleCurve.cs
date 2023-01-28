using System;
using UnityEngine;

// Token: 0x02000738 RID: 1848
public class LightStyleCurve : global::LightStyle
{
	// Token: 0x06003E6F RID: 15983 RVA: 0x000DC82C File Offset: 0x000DAA2C
	public LightStyleCurve()
	{
	}

	// Token: 0x06003E70 RID: 15984 RVA: 0x000DC834 File Offset: 0x000DAA34
	private float GetCurveValue(double relativeStartTime)
	{
		return this.curve.Evaluate((float)relativeStartTime);
	}

	// Token: 0x06003E71 RID: 15985 RVA: 0x000DC844 File Offset: 0x000DAA44
	protected override global::LightStyle.Simulation ConstructSimulation(global::LightStylist stylist)
	{
		return new global::LightStyleCurve.Simulation(this);
	}

	// Token: 0x06003E72 RID: 15986 RVA: 0x000DC84C File Offset: 0x000DAA4C
	protected override bool DeconstructSimulation(global::LightStyle.Simulation simulation)
	{
		return true;
	}

	// Token: 0x04001FE8 RID: 8168
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.AnimationCurve curve;

	// Token: 0x02000739 RID: 1849
	protected new class Simulation : global::LightStyle.Simulation<global::LightStyleCurve>
	{
		// Token: 0x06003E73 RID: 15987 RVA: 0x000DC850 File Offset: 0x000DAA50
		public Simulation(global::LightStyleCurve creator) : base(creator)
		{
			this.lastValue = null;
		}

		// Token: 0x06003E74 RID: 15988 RVA: 0x000DC874 File Offset: 0x000DAA74
		protected override void Simulate(double currentTime)
		{
			float curveValue = base.creator.GetCurveValue(currentTime - this.startTime);
			if (this.lastValue == null || this.lastValue.Value != curveValue)
			{
				this.lastValue = new float?(curveValue);
				for (global::LightStyle.Mod.Element element = global::LightStyle.Mod.Element.Red; element < (global::LightStyle.Mod.Element)7; element++)
				{
					this.mod[element] = this.lastValue;
				}
			}
		}

		// Token: 0x04001FE9 RID: 8169
		private float? lastValue;
	}
}
