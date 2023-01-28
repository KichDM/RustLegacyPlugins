using System;
using System.Collections.Generic;
using Facepunch.Precision;
using UnityEngine;

// Token: 0x02000299 RID: 665
public class BobEffectStack : global::System.IDisposable
{
	// Token: 0x060017AE RID: 6062 RVA: 0x00057E6C File Offset: 0x0005606C
	public BobEffectStack()
	{
	}

	// Token: 0x060017AF RID: 6063 RVA: 0x00057E8C File Offset: 0x0005608C
	public bool IsForkOf(global::BobEffectStack stack)
	{
		return this.owner != null && this.owner == stack;
	}

	// Token: 0x060017B0 RID: 6064 RVA: 0x00057EA8 File Offset: 0x000560A8
	public bool CreateInstance(global::BobEffect effect)
	{
		global::BobEffect.Data data;
		if (effect && effect.Create(out data))
		{
			this.data.Add(data);
			foreach (global::BobEffectStack bobEffectStack in this.forks)
			{
				bobEffectStack.data.Add(data.Clone());
			}
			return true;
		}
		return false;
	}

	// Token: 0x060017B1 RID: 6065 RVA: 0x00057F40 File Offset: 0x00056140
	private void RunSim(ref int i, ref global::Facepunch.Precision.Vector3G force, ref global::Facepunch.Precision.Vector3G torque)
	{
		while (i < this.dataCount)
		{
			this.ctx.data = this.data[i];
			switch (this.ctx.data.effect.Simulate(ref this.ctx))
			{
			case global::BOBRES.CONTINUE:
				force.x += this.ctx.data.force.x;
				force.y += this.ctx.data.force.y;
				force.z += this.ctx.data.force.z;
				torque.x += this.ctx.data.torque.x;
				torque.y += this.ctx.data.torque.y;
				torque.z += this.ctx.data.torque.z;
				break;
			case global::BOBRES.EXIT:
				if (!this.isFork)
				{
					int index = i++;
					this.RunSim(ref i, ref force, ref torque);
					if (this.ctx.data != null)
					{
						if (this.ctx.data.effect != null)
						{
							this.ctx.data.effect.Destroy(ref this.ctx.data);
						}
						this.data.RemoveAt(index);
						foreach (global::BobEffectStack bobEffectStack in this.forks)
						{
							bobEffectStack.data.RemoveAt(index);
						}
					}
					else
					{
						this.data.RemoveAt(index);
					}
				}
				return;
			case global::BOBRES.ERROR:
				global::UnityEngine.Debug.LogError("Error with effect", this.ctx.data.effect);
				break;
			}
			i++;
		}
	}

	// Token: 0x060017B2 RID: 6066 RVA: 0x0005818C File Offset: 0x0005638C
	public void Simulate(ref double dt, ref global::Facepunch.Precision.Vector3G force, ref global::Facepunch.Precision.Vector3G torque)
	{
		this.dataCount = this.data.Count;
		if (this.dataCount > 0)
		{
			int num = 0;
			this.ctx.dt = dt;
			this.RunSim(ref num, ref force, ref torque);
		}
	}

	// Token: 0x060017B3 RID: 6067 RVA: 0x000581D0 File Offset: 0x000563D0
	private void DestroyAllEffects()
	{
		foreach (global::BobEffect.Data data in this.data)
		{
			this.ctx.data = data;
			if (this.ctx.data.effect)
			{
				this.ctx.data.effect.Destroy(ref this.ctx.data);
			}
		}
		this.ctx.data = null;
		this.data.Clear();
	}

	// Token: 0x060017B4 RID: 6068 RVA: 0x0005828C File Offset: 0x0005648C
	public void Dispose()
	{
		if (!this.isFork)
		{
			foreach (global::BobEffectStack bobEffectStack in this.forks)
			{
				bobEffectStack.DestroyAllEffects();
			}
		}
		else
		{
			this.DestroyAllEffects();
			this.owner.forks.Remove(this);
			this.owner = null;
			this.isFork = false;
		}
	}

	// Token: 0x060017B5 RID: 6069 RVA: 0x00058328 File Offset: 0x00056528
	public global::BobEffectStack Fork()
	{
		global::BobEffectStack bobEffectStack = new global::BobEffectStack();
		bobEffectStack.isFork = true;
		bobEffectStack.owner = ((!this.isFork) ? this : this.owner);
		bobEffectStack.owner.forks.Add(bobEffectStack);
		foreach (global::BobEffect.Data data in bobEffectStack.owner.data)
		{
			bobEffectStack.data.Add(data.Clone());
		}
		return bobEffectStack;
	}

	// Token: 0x060017B6 RID: 6070 RVA: 0x000583DC File Offset: 0x000565DC
	public void Join()
	{
		if (this.isFork)
		{
			this.dataCount = this.data.Count;
			for (int i = 0; i < this.dataCount; i++)
			{
				this.owner.data[i].CopyDataTo(this.data[i]);
			}
		}
	}

	// Token: 0x04000C68 RID: 3176
	private global::System.Collections.Generic.List<global::BobEffect.Data> data = new global::System.Collections.Generic.List<global::BobEffect.Data>();

	// Token: 0x04000C69 RID: 3177
	private global::System.Collections.Generic.List<global::BobEffectStack> forks = new global::System.Collections.Generic.List<global::BobEffectStack>();

	// Token: 0x04000C6A RID: 3178
	private global::BobEffectStack owner;

	// Token: 0x04000C6B RID: 3179
	private int dataCount;

	// Token: 0x04000C6C RID: 3180
	private bool isFork;

	// Token: 0x04000C6D RID: 3181
	private global::BobEffect.Context ctx;
}
