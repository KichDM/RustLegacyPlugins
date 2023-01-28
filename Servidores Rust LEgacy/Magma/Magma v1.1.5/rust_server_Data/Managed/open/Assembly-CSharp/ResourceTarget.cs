using System;
using System.Collections.Generic;
using Facepunch;
using Magma;
using Rust;
using UnityEngine;

// Token: 0x020005E0 RID: 1504
public class ResourceTarget : global::Facepunch.MonoBehaviour
{
	// Token: 0x060030E5 RID: 12517 RVA: 0x000BA2EC File Offset: 0x000B84EC
	public ResourceTarget()
	{
	}

	// Token: 0x060030E6 RID: 12518 RVA: 0x000BA300 File Offset: 0x000B8500
	public void TryInitialize()
	{
		if (this._initialized)
		{
			return;
		}
		foreach (global::ResourceGivePair resourceGivePair in this.resourcesAvailable)
		{
			resourceGivePair.CalcAmount();
		}
		this._initialized = true;
	}

	// Token: 0x060030E7 RID: 12519 RVA: 0x000BA378 File Offset: 0x000B8578
	public void Awake()
	{
		this.TryInitialize();
		this.startingTotal = this.GetTotalResLeft();
	}

	// Token: 0x060030E8 RID: 12520 RVA: 0x000BA38C File Offset: 0x000B858C
	public int GetTotalResLeft()
	{
		this.TryInitialize();
		int num = 0;
		foreach (global::ResourceGivePair resourceGivePair in this.resourcesAvailable)
		{
			num += resourceGivePair.AmountLeft();
		}
		return num;
	}

	// Token: 0x060030E9 RID: 12521 RVA: 0x000BA400 File Offset: 0x000B8600
	public float GetPercentFull()
	{
		return (float)this.GetTotalResLeft() / (float)this.startingTotal;
	}

	// Token: 0x060030EA RID: 12522 RVA: 0x000BA414 File Offset: 0x000B8614
	public bool DoGather(global::Inventory reciever, float efficiency)
	{
		if (this.resourcesAvailable.Count == 0)
		{
			return false;
		}
		global::ResourceGivePair resourceGivePair = this.resourcesAvailable[global::UnityEngine.Random.Range(0, this.resourcesAvailable.Count)];
		this.gatherProgress += efficiency * this.gatherEfficiencyMultiplier;
		int num = (int)global::UnityEngine.Mathf.Abs(this.gatherProgress);
		global::Magma.Hooks.PlayerGather(reciever, this, resourceGivePair, ref num);
		this.gatherProgress = global::UnityEngine.Mathf.Clamp(this.gatherProgress, 0f, (float)num);
		if (num > 0)
		{
			int num2 = reciever.AddItemAmount(resourceGivePair.ResourceItemDataBlock, num);
			if (num2 < num)
			{
				int num3 = num - num2;
				resourceGivePair.Subtract(num3);
				this.gatherProgress -= (float)num3;
				global::Rust.Notice.Inventory(reciever.networkView.owner, num3.ToString() + " x " + resourceGivePair.ResourceItemName);
				base.SendMessage("ResourcesGathered", 1);
			}
			else
			{
				global::Rust.Notice.Popup(reciever.networkView.owner, "", "Inventory full, can't gather.", 4f);
			}
		}
		if (!resourceGivePair.AnyLeft())
		{
			this.resourcesAvailable.Remove(resourceGivePair);
		}
		if (this.resourcesAvailable.Count == 0)
		{
			base.SendMessage("ResourcesDepletedMsg", 1);
		}
		return true;
	}

	// Token: 0x04001A9D RID: 6813
	[global::UnityEngine.SerializeField]
	public global::System.Collections.Generic.List<global::ResourceGivePair> resourcesAvailable;

	// Token: 0x04001A9E RID: 6814
	public float gatherEfficiencyMultiplier = 1f;

	// Token: 0x04001A9F RID: 6815
	private float gatherProgress;

	// Token: 0x04001AA0 RID: 6816
	public global::ResourceTarget.ResourceTargetType type;

	// Token: 0x04001AA1 RID: 6817
	private int startingTotal;

	// Token: 0x04001AA2 RID: 6818
	[global::System.NonSerialized]
	private bool _initialized;

	// Token: 0x020005E1 RID: 1505
	public enum ResourceTargetType
	{
		// Token: 0x04001AA4 RID: 6820
		Animal,
		// Token: 0x04001AA5 RID: 6821
		WoodPile,
		// Token: 0x04001AA6 RID: 6822
		StaticTree,
		// Token: 0x04001AA7 RID: 6823
		Rock1,
		// Token: 0x04001AA8 RID: 6824
		Rock2,
		// Token: 0x04001AA9 RID: 6825
		Rock3,
		// Token: 0x04001AAA RID: 6826
		LAST = 5
	}
}
