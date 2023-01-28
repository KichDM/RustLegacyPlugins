using System;
using uLink;
using UnityEngine;

// Token: 0x020000BC RID: 188
public class PlayerProxyTest : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060003B8 RID: 952 RVA: 0x00011F3C File Offset: 0x0001013C
	public PlayerProxyTest()
	{
	}

	// Token: 0x17000087 RID: 135
	// (get) Token: 0x060003B9 RID: 953 RVA: 0x00011F44 File Offset: 0x00010144
	// (set) Token: 0x060003BA RID: 954 RVA: 0x00011F5C File Offset: 0x0001015C
	public bool treatAsProxy
	{
		get
		{
			return !this.isMine || this.isFaking;
		}
		set
		{
			if (this.isMine && this.isFaking != value)
			{
				if (!this.hasFaked)
				{
					this.initialDisableListValues = new bool[this.proxyDisableList.Length];
					this.hasFaked = true;
				}
				this.isFaking = value;
				if (value)
				{
					for (int i = 0; i < this.initialDisableListValues.Length; i++)
					{
						this.initialDisableListValues[i] = (this.proxyDisableList[i] && this.proxyDisableList[i].enabled);
					}
					if (this.body)
					{
						this.body.SetActive(true);
					}
					if (this.armorRenderer)
					{
						this.armorRenderer.enabled = true;
					}
					this.ProxyInit();
				}
				else
				{
					for (int j = 0; j < this.initialDisableListValues.Length; j++)
					{
						if (this.initialDisableListValues[j] && this.proxyDisableList[j])
						{
							this.proxyDisableList[j].enabled = true;
						}
					}
					this.MineInit();
				}
			}
		}
	}

	// Token: 0x060003BB RID: 955 RVA: 0x00012084 File Offset: 0x00010284
	private void MineInit()
	{
		if (this.body)
		{
			this.body.SetActive(false);
		}
		if (this.proxyCollider)
		{
			this.proxyCollider.SetActive(false);
		}
		if (this.armorRenderer)
		{
			this.armorRenderer.enabled = false;
		}
	}

	// Token: 0x060003BC RID: 956 RVA: 0x000120E8 File Offset: 0x000102E8
	private void ProxyInit()
	{
		for (int i = 0; i < this.proxyDisableList.Length; i++)
		{
			if (this.proxyDisableList[i])
			{
				this.proxyDisableList[i].enabled = false;
			}
		}
	}

	// Token: 0x060003BD RID: 957 RVA: 0x00012130 File Offset: 0x00010330
	private void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		if (info.networkView.isMine)
		{
			this.isMine = true;
			this.MineInit();
		}
	}

	// Token: 0x0400037B RID: 891
	[global::PrefetchChildComponent(NameMask = "Soldier")]
	public global::UnityEngine.GameObject body;

	// Token: 0x0400037C RID: 892
	[global::PrefetchChildComponent(NameMask = "HB Hit")]
	public global::UnityEngine.GameObject proxyCollider;

	// Token: 0x0400037D RID: 893
	[global::PrefetchComponent]
	public global::ArmorModelRenderer armorRenderer;

	// Token: 0x0400037E RID: 894
	public global::UnityEngine.MonoBehaviour[] proxyDisableList;

	// Token: 0x0400037F RID: 895
	private bool[] initialDisableListValues;

	// Token: 0x04000380 RID: 896
	private bool isMine;

	// Token: 0x04000381 RID: 897
	private bool isFaking;

	// Token: 0x04000382 RID: 898
	private bool hasFaked;
}
