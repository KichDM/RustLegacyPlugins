using System;
using UnityEngine;

// Token: 0x020004B4 RID: 1204
public class VisActionMessageEnter : global::VisAction
{
	// Token: 0x060029DB RID: 10715 RVA: 0x0009DB90 File Offset: 0x0009BD90
	public VisActionMessageEnter()
	{
	}

	// Token: 0x060029DC RID: 10716 RVA: 0x0009DBB8 File Offset: 0x0009BDB8
	public override void Accomplish(global::IDMain self, global::IDMain instigator)
	{
		bool flag = !self;
		bool flag2 = !instigator;
		if (flag)
		{
			if (flag2)
			{
				global::UnityEngine.Debug.LogError("Self and instgator are null", this);
			}
			else
			{
				if (this.selfNonNull)
				{
					return;
				}
				global::UnityEngine.Debug.LogWarning("Self is null!", this);
			}
		}
		else if (flag2)
		{
			if (this.instigatorNonNull)
			{
				return;
			}
			global::UnityEngine.Debug.LogWarning("Instigator is null!", this);
		}
		string text;
		string text2;
		if (this.swapMessageOrder)
		{
			global::IDMain idmain = self;
			self = instigator;
			instigator = idmain;
			text = this.instigatorMessage;
			text2 = this.selfMessage;
			bool flag3 = flag;
			flag = flag2;
			flag2 = flag3;
		}
		else
		{
			text = this.selfMessage;
			text2 = this.instigatorMessage;
		}
		if (this.withOtherAsArg)
		{
			if (!flag && !string.IsNullOrEmpty(text))
			{
				self.SendMessage(text, instigator, 1);
			}
			if (!flag2 && !string.IsNullOrEmpty(text2))
			{
				instigator.SendMessage(text2, self, 1);
			}
		}
		else
		{
			if (!flag && !string.IsNullOrEmpty(text))
			{
				self.SendMessage(text, 1);
			}
			if (!flag2 && !string.IsNullOrEmpty(text2))
			{
				instigator.SendMessage(text2, 1);
			}
		}
	}

	// Token: 0x060029DD RID: 10717 RVA: 0x0009DCEC File Offset: 0x0009BEEC
	public override void UnAcomplish(global::IDMain self, global::IDMain instigator)
	{
	}

	// Token: 0x040014EE RID: 5358
	[global::UnityEngine.SerializeField]
	protected string selfMessage = string.Empty;

	// Token: 0x040014EF RID: 5359
	[global::UnityEngine.SerializeField]
	protected string instigatorMessage = string.Empty;

	// Token: 0x040014F0 RID: 5360
	[global::UnityEngine.SerializeField]
	protected bool withOtherAsArg = true;

	// Token: 0x040014F1 RID: 5361
	[global::UnityEngine.SerializeField]
	protected bool swapMessageOrder;

	// Token: 0x040014F2 RID: 5362
	[global::UnityEngine.SerializeField]
	protected bool selfNonNull;

	// Token: 0x040014F3 RID: 5363
	[global::UnityEngine.SerializeField]
	protected bool instigatorNonNull;
}
