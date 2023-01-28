using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x0200005B RID: 91
public class EnvironmentControlCenter : global::Facepunch.NetBehaviour
{
	// Token: 0x06000296 RID: 662 RVA: 0x0000D390 File Offset: 0x0000B590
	public EnvironmentControlCenter()
	{
	}

	// Token: 0x06000297 RID: 663 RVA: 0x0000D398 File Offset: 0x0000B598
	// Note: this type is marked as 'beforefieldinit'.
	static EnvironmentControlCenter()
	{
	}

	// Token: 0x06000298 RID: 664 RVA: 0x0000D39C File Offset: 0x0000B59C
	protected void Awake()
	{
		global::EnvironmentControlCenter.Singleton = this;
		base.StartCoroutine(this.SV_UpdateSkyState());
	}

	// Token: 0x06000299 RID: 665 RVA: 0x0000D3B4 File Offset: 0x0000B5B4
	private void OnDestroy()
	{
		if (global::EnvironmentControlCenter.Singleton == this)
		{
			global::EnvironmentControlCenter.Singleton = null;
		}
	}

	// Token: 0x0600029A RID: 666 RVA: 0x0000D3CC File Offset: 0x0000B5CC
	private void SV_SendSkyUpdate()
	{
		if (this.sky == null)
		{
			return;
		}
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<float>(global::env.daylength, new object[0]);
		bitStream.Write<float>(global::env.nightlength, new object[0]);
		bitStream.Write<float>(this.sky.Cycle.MoonPhase, new object[0]);
		bitStream.Write<global::UnityEngine.Vector4>(this.sky.Components.Animation.CloudUV, new object[0]);
		bitStream.Write<int>(this.sky.Cycle.Year, new object[0]);
		bitStream.Write<byte>((byte)this.sky.Cycle.Month, new object[0]);
		bitStream.Write<byte>((byte)this.sky.Cycle.Day, new object[0]);
		bitStream.Write<float>(this.sky.Cycle.Hour, new object[0]);
		global::NetCull.RemoveRPCsByName(base.networkView, "CL_UpdateSkyState");
		base.networkView.RPC<global::uLink.BitStream>("CL_UpdateSkyState", 5, bitStream);
	}

	// Token: 0x0600029B RID: 667 RVA: 0x0000D4E8 File Offset: 0x0000B6E8
	private global::System.Collections.IEnumerator SV_UpdateSkyState()
	{
		for (;;)
		{
			yield return new global::UnityEngine.WaitForSeconds(5f);
			this.SV_SendSkyUpdate();
		}
		yield break;
	}

	// Token: 0x0600029C RID: 668 RVA: 0x0000D504 File Offset: 0x0000B704
	[global::UnityEngine.RPC]
	private void CL_UpdateSkyState(global::uLink.BitStream stream)
	{
	}

	// Token: 0x0600029D RID: 669 RVA: 0x0000D508 File Offset: 0x0000B708
	public bool IsNight()
	{
		return this.sky && this.sky.IsNight;
	}

	// Token: 0x0600029E RID: 670 RVA: 0x0000D528 File Offset: 0x0000B728
	public float GetTime()
	{
		if (this.sky == null)
		{
			return 0f;
		}
		return this.sky.Cycle.Hour;
	}

	// Token: 0x0600029F RID: 671 RVA: 0x0000D554 File Offset: 0x0000B754
	public void SetTime(float fTime)
	{
		if (this.sky == null)
		{
			return;
		}
		this.sky.Cycle.Hour = fTime;
		this.SV_SendSkyUpdate();
	}

	// Token: 0x060002A0 RID: 672 RVA: 0x0000D580 File Offset: 0x0000B780
	protected void Update()
	{
		if (this.sky == null)
		{
			this.sky = (global::TOD_Sky)global::UnityEngine.Object.FindObjectOfType(typeof(global::TOD_Sky));
			if (this.sky == null)
			{
				return;
			}
		}
		float num = global::env.daylength * 60f;
		if (this.sky.IsNight)
		{
			num = global::env.nightlength * 60f;
		}
		float num2 = num / 24f;
		float num3 = global::UnityEngine.Time.deltaTime / num2;
		float num4 = global::UnityEngine.Time.deltaTime / (30f * num) * 2f;
		this.sky.Cycle.Hour += num3;
		this.sky.Cycle.MoonPhase += num4;
		if (this.sky.Cycle.MoonPhase < -1f)
		{
			this.sky.Cycle.MoonPhase += 2f;
		}
		else if (this.sky.Cycle.MoonPhase > 1f)
		{
			this.sky.Cycle.MoonPhase -= 2f;
		}
		if (this.sky.Cycle.Hour >= 24f)
		{
			this.sky.Cycle.Hour = 0f;
			int num5 = global::System.DateTime.DaysInMonth(this.sky.Cycle.Year, this.sky.Cycle.Month);
			if (++this.sky.Cycle.Day > num5)
			{
				this.sky.Cycle.Day = 1;
				if (++this.sky.Cycle.Month > 0xC)
				{
					this.sky.Cycle.Month = 1;
					this.sky.Cycle.Year++;
				}
			}
		}
	}

	// Token: 0x040001D8 RID: 472
	public static global::EnvironmentControlCenter Singleton;

	// Token: 0x040001D9 RID: 473
	private global::TOD_Sky sky;

	// Token: 0x0200005C RID: 92
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <SV_UpdateSkyState>c__IteratorC : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x060002A1 RID: 673 RVA: 0x0000D790 File Offset: 0x0000B990
		public <SV_UpdateSkyState>c__IteratorC()
		{
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x0000D798 File Offset: 0x0000B998
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x0000D7A0 File Offset: 0x0000B9A0
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000D7A8 File Offset: 0x0000B9A8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				break;
			case 1U:
				base.SV_SendSkyUpdate();
				break;
			default:
				return false;
			}
			this.$current = new global::UnityEngine.WaitForSeconds(5f);
			this.$PC = 1;
			return true;
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000D80C File Offset: 0x0000BA0C
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000D818 File Offset: 0x0000BA18
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040001DA RID: 474
		internal int $PC;

		// Token: 0x040001DB RID: 475
		internal object $current;

		// Token: 0x040001DC RID: 476
		internal global::EnvironmentControlCenter <>f__this;
	}
}
