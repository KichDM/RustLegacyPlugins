using System;
using UnityEngine;

// Token: 0x020004E5 RID: 1253
public class VisQuery : global::UnityEngine.ScriptableObject
{
	// Token: 0x06002B77 RID: 11127 RVA: 0x000A35F0 File Offset: 0x000A17F0
	public VisQuery()
	{
	}

	// Token: 0x06002B78 RID: 11128 RVA: 0x000A35F8 File Offset: 0x000A17F8
	private void Enter(global::VisNode a, global::VisNode b)
	{
		global::IDMain idMain = a.idMain;
		global::IDMain instigator = (!this.nonInstance) ? b.idMain : null;
		for (int i = 0; i < this.actions.Length; i++)
		{
			if (this.actions[i])
			{
				this.actions[i].Accomplish(idMain, instigator);
			}
		}
	}

	// Token: 0x06002B79 RID: 11129 RVA: 0x000A3660 File Offset: 0x000A1860
	private void Exit(global::VisNode a, global::VisNode b)
	{
		global::IDMain idMain = a.idMain;
		global::IDMain instigator = (!this.nonInstance) ? b.idMain : null;
		for (int i = 0; i < this.actions.Length; i++)
		{
			if (this.actions[i])
			{
				this.actions[i].UnAcomplish(idMain, instigator);
			}
		}
	}

	// Token: 0x06002B7A RID: 11130 RVA: 0x000A36C8 File Offset: 0x000A18C8
	private bool Try(global::VisNode self, global::VisNode instigator)
	{
		global::Vis.Mask traitMask = self.traitMask;
		global::Vis.Mask traitMask2 = instigator.traitMask;
		return this.evaluation.Pass(traitMask, traitMask2);
	}

	// Token: 0x040015F6 RID: 5622
	[global::UnityEngine.SerializeField]
	protected global::VisEval evaluation;

	// Token: 0x040015F7 RID: 5623
	[global::UnityEngine.SerializeField]
	protected global::VisAction[] actions;

	// Token: 0x040015F8 RID: 5624
	[global::UnityEngine.SerializeField]
	protected bool nonInstance;

	// Token: 0x020004E6 RID: 1254
	public enum TryResult
	{
		// Token: 0x040015FA RID: 5626
		Outside,
		// Token: 0x040015FB RID: 5627
		Enter,
		// Token: 0x040015FC RID: 5628
		Stay,
		// Token: 0x040015FD RID: 5629
		Exit
	}

	// Token: 0x020004E7 RID: 1255
	public class Instance
	{
		// Token: 0x06002B7B RID: 11131 RVA: 0x000A36F0 File Offset: 0x000A18F0
		internal Instance(global::VisQuery outer, ref int bit)
		{
			this.outer = outer;
			this.applicable = new global::HSet<global::VisNode>();
			this.bit = 1L << (bit & 0x1F);
			this.bitNumber = (byte)bit;
			bit++;
		}

		// Token: 0x1700098E RID: 2446
		// (get) Token: 0x06002B7C RID: 11132 RVA: 0x000A3728 File Offset: 0x000A1928
		public int count
		{
			get
			{
				return this.num;
			}
		}

		// Token: 0x06002B7D RID: 11133 RVA: 0x000A3730 File Offset: 0x000A1930
		public bool Fits(global::VisNode other)
		{
			return this.applicable.Contains(other);
		}

		// Token: 0x06002B7E RID: 11134 RVA: 0x000A3740 File Offset: 0x000A1940
		public void ExecuteEnter(global::VisNode self, global::VisNode other)
		{
			if (this.execNum++ == 0 || !this.outer.nonInstance)
			{
				this.outer.Enter(self, other);
			}
		}

		// Token: 0x06002B7F RID: 11135 RVA: 0x000A3780 File Offset: 0x000A1980
		public void ExecuteExit(global::VisNode self, global::VisNode other)
		{
			if (--this.execNum == 0 || !this.outer.nonInstance)
			{
				this.outer.Exit(self, other);
			}
		}

		// Token: 0x06002B80 RID: 11136 RVA: 0x000A37C0 File Offset: 0x000A19C0
		public void Execute(global::VisQuery.TryResult res, global::VisNode self, global::VisNode other)
		{
			switch (res)
			{
			case global::VisQuery.TryResult.Enter:
				this.ExecuteEnter(self, other);
				break;
			case global::VisQuery.TryResult.Exit:
				this.ExecuteExit(self, other);
				break;
			}
		}

		// Token: 0x06002B81 RID: 11137 RVA: 0x000A3808 File Offset: 0x000A1A08
		public global::VisQuery.TryResult TryAdd(global::VisNode self, global::VisNode other)
		{
			if (!this.outer.Try(self, other))
			{
				return this.TryRemove(self, other);
			}
			if (this.applicable.Add(other))
			{
				this.num++;
				return global::VisQuery.TryResult.Enter;
			}
			return global::VisQuery.TryResult.Stay;
		}

		// Token: 0x06002B82 RID: 11138 RVA: 0x000A3854 File Offset: 0x000A1A54
		public global::VisQuery.TryResult TryRemove(global::VisNode self, global::VisNode other)
		{
			if (this.applicable.Remove(other))
			{
				this.num--;
				return global::VisQuery.TryResult.Exit;
			}
			return global::VisQuery.TryResult.Outside;
		}

		// Token: 0x06002B83 RID: 11139 RVA: 0x000A3884 File Offset: 0x000A1A84
		public void Clear(global::VisNode self)
		{
			while (--this.num >= 0)
			{
				global::HSetIter<global::VisNode> enumerator = this.applicable.GetEnumerator();
				enumerator.MoveNext();
				global::VisNode other = enumerator.Current;
				enumerator.Dispose();
				this.TryRemove(self, other);
			}
		}

		// Token: 0x06002B84 RID: 11140 RVA: 0x000A38DC File Offset: 0x000A1ADC
		public bool IsActive(long mask)
		{
			return (mask & this.bit) == this.bit;
		}

		// Token: 0x040015FE RID: 5630
		public readonly global::VisQuery outer;

		// Token: 0x040015FF RID: 5631
		private readonly global::HSet<global::VisNode> applicable;

		// Token: 0x04001600 RID: 5632
		private readonly long bit;

		// Token: 0x04001601 RID: 5633
		private readonly byte bitNumber;

		// Token: 0x04001602 RID: 5634
		private int num;

		// Token: 0x04001603 RID: 5635
		private int execNum;
	}
}
