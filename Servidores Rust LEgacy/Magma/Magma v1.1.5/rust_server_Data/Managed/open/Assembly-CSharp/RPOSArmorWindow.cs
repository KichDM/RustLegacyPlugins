using System;

// Token: 0x02000531 RID: 1329
public class RPOSArmorWindow : global::RPOSWindow
{
	// Token: 0x06002D2B RID: 11563 RVA: 0x000AB33C File Offset: 0x000A953C
	public RPOSArmorWindow()
	{
	}

	// Token: 0x06002D2C RID: 11564 RVA: 0x000AB344 File Offset: 0x000A9544
	protected override void WindowAwake()
	{
		base.WindowAwake();
		this.cellMan = base.GetComponentInChildren<global::RPOSInvCellManager>();
	}

	// Token: 0x06002D2D RID: 11565 RVA: 0x000AB358 File Offset: 0x000A9558
	public void ForceUpdate()
	{
		global::HumanBodyTakeDamage humanBodyTakeDamage;
		global::DamageTypeList damageTypeList;
		if (global::RPOS.GetObservedPlayerComponent<global::HumanBodyTakeDamage>(out humanBodyTakeDamage))
		{
			damageTypeList = humanBodyTakeDamage.GetArmorValues();
		}
		else
		{
			damageTypeList = new global::DamageTypeList();
		}
		this.leftText.text = string.Empty;
		this.rightText.text = string.Empty;
		for (int i = 0; i < 6; i++)
		{
			if (damageTypeList[i] != 0f)
			{
				global::UILabel uilabel = this.leftText;
				uilabel.text = uilabel.text + global::TakeDamage.DamageIndexToString((global::DamageTypeIndex)i) + "\n";
				global::UILabel uilabel2 = this.rightText;
				string text = uilabel2.text;
				uilabel2.text = string.Concat(new object[]
				{
					text,
					"+",
					(int)damageTypeList[i],
					"\n"
				});
			}
		}
	}

	// Token: 0x0400172E RID: 5934
	public global::UILabel leftText;

	// Token: 0x0400172F RID: 5935
	public global::UILabel rightText;

	// Token: 0x04001730 RID: 5936
	public global::RPOSInvCellManager cellMan;
}
