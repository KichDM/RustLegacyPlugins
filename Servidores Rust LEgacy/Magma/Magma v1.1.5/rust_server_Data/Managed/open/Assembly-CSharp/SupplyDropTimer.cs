using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020000A3 RID: 163
public class SupplyDropTimer : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06000326 RID: 806 RVA: 0x0000F458 File Offset: 0x0000D658
	public SupplyDropTimer()
	{
	}

	// Token: 0x06000327 RID: 807 RVA: 0x0000F484 File Offset: 0x0000D684
	// Note: this type is marked as 'beforefieldinit'.
	static SupplyDropTimer()
	{
	}

	// Token: 0x06000328 RID: 808 RVA: 0x0000F498 File Offset: 0x0000D698
	private global::System.Collections.IEnumerator Start()
	{
		while (global::EnvironmentControlCenter.Singleton != null)
		{
			float nextDropTOD = global::UnityEngine.Random.Range(this.dropTimeDayMin, this.dropTimeDayMax);
			while (nextDropTOD < global::EnvironmentControlCenter.Singleton.GetTime())
			{
				yield return global::SupplyDropTimer.kCheckInterval;
			}
			while (nextDropTOD > global::EnvironmentControlCenter.Singleton.GetTime())
			{
				yield return global::SupplyDropTimer.kCheckInterval;
			}
			if (global::NetCull.connections.Length > global::airdrop.min_players)
			{
				try
				{
					global::SupplyDropZone.CallAirDrop();
				}
				catch (global::System.Exception ex)
				{
					global::System.Exception e = ex;
					global::UnityEngine.Debug.LogException(e);
				}
			}
			while (nextDropTOD <= global::EnvironmentControlCenter.Singleton.GetTime())
			{
				yield return global::SupplyDropTimer.kCheckInterval;
			}
		}
		yield break;
	}

	// Token: 0x06000329 RID: 809 RVA: 0x0000F4B4 File Offset: 0x0000D6B4
	public void ResetDropTime()
	{
		this.nextDropTime = global::UnityEngine.Random.Range(this.dropTimeDayMin, this.dropTimeDayMax);
	}

	// Token: 0x040002EA RID: 746
	protected float dropTimeDayMin = 13f;

	// Token: 0x040002EB RID: 747
	protected float dropTimeDayMax = 19f;

	// Token: 0x040002EC RID: 748
	protected float nextDropTime = 12f;

	// Token: 0x040002ED RID: 749
	private static readonly global::UnityEngine.WaitForSeconds kCheckInterval = new global::UnityEngine.WaitForSeconds(5f);

	// Token: 0x020000A4 RID: 164
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <Start>c__IteratorF : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x0600032A RID: 810 RVA: 0x0000F4D0 File Offset: 0x0000D6D0
		public <Start>c__IteratorF()
		{
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600032B RID: 811 RVA: 0x0000F4D8 File Offset: 0x0000D6D8
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600032C RID: 812 RVA: 0x0000F4E0 File Offset: 0x0000D6E0
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0000F4E8 File Offset: 0x0000D6E8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				goto IL_11A;
			case 1U:
				IL_6B:
				if (nextDropTOD < global::EnvironmentControlCenter.Singleton.GetTime())
				{
					this.$current = global::SupplyDropTimer.kCheckInterval;
					this.$PC = 1;
					return true;
				}
				break;
			case 2U:
				break;
			case 3U:
				goto IL_105;
			default:
				return false;
			}
			if (nextDropTOD > global::EnvironmentControlCenter.Singleton.GetTime())
			{
				this.$current = global::SupplyDropTimer.kCheckInterval;
				this.$PC = 2;
				return true;
			}
			if (global::NetCull.connections.Length > global::airdrop.min_players)
			{
				try
				{
					global::SupplyDropZone.CallAirDrop();
				}
				catch (global::System.Exception ex)
				{
					e = ex;
					global::UnityEngine.Debug.LogException(e);
				}
			}
			IL_105:
			if (nextDropTOD <= global::EnvironmentControlCenter.Singleton.GetTime())
			{
				this.$current = global::SupplyDropTimer.kCheckInterval;
				this.$PC = 3;
				return true;
			}
			IL_11A:
			if (global::EnvironmentControlCenter.Singleton != null)
			{
				nextDropTOD = global::UnityEngine.Random.Range(this.dropTimeDayMin, this.dropTimeDayMax);
				goto IL_6B;
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x0600032E RID: 814 RVA: 0x0000F648 File Offset: 0x0000D848
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0000F654 File Offset: 0x0000D854
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040002EE RID: 750
		internal float <nextDropTOD>__0;

		// Token: 0x040002EF RID: 751
		internal global::System.Exception <e>__1;

		// Token: 0x040002F0 RID: 752
		internal int $PC;

		// Token: 0x040002F1 RID: 753
		internal object $current;

		// Token: 0x040002F2 RID: 754
		internal global::SupplyDropTimer <>f__this;
	}
}
