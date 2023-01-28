using System;
using UnityEngine;

// Token: 0x020004B5 RID: 1205
public class VisActionMessageEnterExit : global::VisActionMessageEnter
{
	// Token: 0x060029DE RID: 10718 RVA: 0x0009DCF0 File Offset: 0x0009BEF0
	public VisActionMessageEnterExit()
	{
	}

	// Token: 0x060029DF RID: 10719 RVA: 0x0009DD18 File Offset: 0x0009BF18
	public override void UnAcomplish(global::IDMain self, global::IDMain instigator)
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
				if (this.exitSelfNonNull)
				{
					return;
				}
				global::UnityEngine.Debug.LogWarning("Self is null!", this);
			}
		}
		else if (flag2)
		{
			if (this.exitInstigatorNonNull)
			{
				return;
			}
			global::UnityEngine.Debug.LogWarning("Instigator is null!", this);
		}
		string text;
		string text2;
		if (this.exitSwapMessageOrder)
		{
			global::IDMain idmain = self;
			self = instigator;
			instigator = idmain;
			text = this.exitInstigatorMessage;
			text2 = this.exitSelfMessage;
			bool flag3 = flag;
			flag = flag2;
			flag2 = flag3;
		}
		else
		{
			text = this.exitSelfMessage;
			text2 = this.exitInstigatorMessage;
		}
		if (this.exitWithOtherAsArg)
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

	// Token: 0x040014F4 RID: 5364
	[global::UnityEngine.SerializeField]
	protected string exitSelfMessage = string.Empty;

	// Token: 0x040014F5 RID: 5365
	[global::UnityEngine.SerializeField]
	protected string exitInstigatorMessage = string.Empty;

	// Token: 0x040014F6 RID: 5366
	[global::UnityEngine.SerializeField]
	protected bool exitWithOtherAsArg = true;

	// Token: 0x040014F7 RID: 5367
	[global::UnityEngine.SerializeField]
	protected bool exitSwapMessageOrder;

	// Token: 0x040014F8 RID: 5368
	[global::UnityEngine.SerializeField]
	protected bool exitSelfNonNull;

	// Token: 0x040014F9 RID: 5369
	[global::UnityEngine.SerializeField]
	protected bool exitInstigatorNonNull;
}
