using System;
using UnityEngine;

// Token: 0x0200073A RID: 1850
public class LightStyleDefault : global::LightStyle
{
	// Token: 0x06003E75 RID: 15989 RVA: 0x000DC8E8 File Offset: 0x000DAAE8
	public LightStyleDefault()
	{
	}

	// Token: 0x06003E76 RID: 15990 RVA: 0x000DC8F0 File Offset: 0x000DAAF0
	private void OnEnable()
	{
		global::LightStyleDefault.singleton = this;
	}

	// Token: 0x06003E77 RID: 15991 RVA: 0x000DC8F8 File Offset: 0x000DAAF8
	private void OnDisable()
	{
		if (global::LightStyleDefault.singleton == this)
		{
			global::LightStyleDefault.singleton = null;
		}
	}

	// Token: 0x06003E78 RID: 15992 RVA: 0x000DC910 File Offset: 0x000DAB10
	protected override global::LightStyle.Simulation ConstructSimulation(global::LightStylist stylist)
	{
		global::LightStyleDefault.DefaultSimulation result;
		if ((result = this.singletonSimulation) == null)
		{
			result = (this.singletonSimulation = new global::LightStyleDefault.DefaultSimulation(this));
		}
		return result;
	}

	// Token: 0x06003E79 RID: 15993 RVA: 0x000DC93C File Offset: 0x000DAB3C
	protected override bool DeconstructSimulation(global::LightStyle.Simulation simulation)
	{
		return false;
	}

	// Token: 0x17000BCF RID: 3023
	// (get) Token: 0x06003E7A RID: 15994 RVA: 0x000DC940 File Offset: 0x000DAB40
	public static global::LightStyleDefault Singleton
	{
		get
		{
			if (global::LightStyleDefault.singleton)
			{
				return global::LightStyleDefault.singleton;
			}
			return global::UnityEngine.ScriptableObject.CreateInstance<global::LightStyleDefault>();
		}
	}

	// Token: 0x04001FEA RID: 8170
	private static global::LightStyleDefault singleton;

	// Token: 0x04001FEB RID: 8171
	private global::LightStyleDefault.DefaultSimulation singletonSimulation;

	// Token: 0x0200073B RID: 1851
	private class DefaultSimulation : global::LightStyle.Simulation
	{
		// Token: 0x06003E7B RID: 15995 RVA: 0x000DC95C File Offset: 0x000DAB5C
		public DefaultSimulation(global::LightStyleDefault def) : base(def)
		{
			float? value = new float?(1f);
			for (global::LightStyle.Mod.Element element = global::LightStyle.Mod.Element.Red; element < (global::LightStyle.Mod.Element)7; element++)
			{
				this.mod[element] = value;
			}
		}

		// Token: 0x06003E7C RID: 15996 RVA: 0x000DC99C File Offset: 0x000DAB9C
		protected override void Simulate(double currentTime)
		{
		}
	}
}
