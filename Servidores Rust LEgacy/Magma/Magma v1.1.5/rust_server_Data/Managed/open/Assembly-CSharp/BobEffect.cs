using System;
using Facepunch.Precision;
using UnityEngine;

// Token: 0x02000296 RID: 662
public abstract class BobEffect : global::UnityEngine.ScriptableObject
{
	// Token: 0x060017A3 RID: 6051 RVA: 0x00057DD4 File Offset: 0x00055FD4
	protected BobEffect()
	{
	}

	// Token: 0x060017A4 RID: 6052
	protected abstract void InitializeNonSerializedData();

	// Token: 0x060017A5 RID: 6053
	protected abstract bool OpenData(out global::BobEffect.Data data);

	// Token: 0x060017A6 RID: 6054
	protected abstract void CloseData(global::BobEffect.Data data);

	// Token: 0x060017A7 RID: 6055
	protected abstract global::BOBRES SimulateData(ref global::BobEffect.Context ctx);

	// Token: 0x060017A8 RID: 6056 RVA: 0x00057DDC File Offset: 0x00055FDC
	public bool Create(out global::BobEffect.Data data)
	{
		if (!this.loaded)
		{
			this.InitializeNonSerializedData();
			this.loaded = true;
		}
		return this.OpenData(out data);
	}

	// Token: 0x060017A9 RID: 6057 RVA: 0x00057E00 File Offset: 0x00056000
	public void Destroy(ref global::BobEffect.Data data)
	{
		if (this.loaded && data != null)
		{
			this.CloseData(data);
			data = null;
		}
	}

	// Token: 0x060017AA RID: 6058 RVA: 0x00057E20 File Offset: 0x00056020
	public global::BOBRES Simulate(ref global::BobEffect.Context ctx)
	{
		if (this.loaded)
		{
			return this.SimulateData(ref ctx);
		}
		return global::BOBRES.ERROR;
	}

	// Token: 0x04000C62 RID: 3170
	[global::System.NonSerialized]
	private bool loaded;

	// Token: 0x02000297 RID: 663
	public class Data
	{
		// Token: 0x060017AB RID: 6059 RVA: 0x00057E38 File Offset: 0x00056038
		public Data()
		{
		}

		// Token: 0x060017AC RID: 6060 RVA: 0x00057E40 File Offset: 0x00056040
		public virtual global::BobEffect.Data Clone()
		{
			return (global::BobEffect.Data)base.MemberwiseClone();
		}

		// Token: 0x060017AD RID: 6061 RVA: 0x00057E50 File Offset: 0x00056050
		public virtual void CopyDataTo(global::BobEffect.Data target)
		{
			target.force = this.force;
			target.torque = this.torque;
		}

		// Token: 0x04000C63 RID: 3171
		public global::Facepunch.Precision.Vector3G force;

		// Token: 0x04000C64 RID: 3172
		public global::Facepunch.Precision.Vector3G torque;

		// Token: 0x04000C65 RID: 3173
		public global::BobEffect effect;
	}

	// Token: 0x02000298 RID: 664
	public struct Context
	{
		// Token: 0x04000C66 RID: 3174
		public double dt;

		// Token: 0x04000C67 RID: 3175
		public global::BobEffect.Data data;
	}
}
