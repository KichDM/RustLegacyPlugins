using System;
using UnityEngine;

// Token: 0x020004BC RID: 1212
public class VisEval : global::UnityEngine.ScriptableObject
{
	// Token: 0x06002A07 RID: 10759 RVA: 0x0009EA40 File Offset: 0x0009CC40
	public VisEval()
	{
	}

	// Token: 0x1700094E RID: 2382
	// (get) Token: 0x06002A08 RID: 10760 RVA: 0x0009EA48 File Offset: 0x0009CC48
	private int dataCount
	{
		get
		{
			return (this.data != null) ? this.data.Length : 0;
		}
	}

	// Token: 0x1700094F RID: 2383
	// (get) Token: 0x06002A09 RID: 10761 RVA: 0x0009EA64 File Offset: 0x0009CC64
	public int ruleCount
	{
		get
		{
			return this.dataCount / 4;
		}
	}

	// Token: 0x17000950 RID: 2384
	public global::Vis.Rule this[int i]
	{
		get
		{
			return global::Vis.Rule.Decode(this.data, i * 4);
		}
		set
		{
			global::Vis.Rule.Encode(ref value, this.data, i * 4);
			if (this.expanded)
			{
				this.rules[i] = value;
			}
		}
	}

	// Token: 0x06002A0C RID: 10764 RVA: 0x0009EAB0 File Offset: 0x0009CCB0
	public bool GetMessage(global::Vis.Mask current, ref global::Vis.Mask previous, global::Vis.Mask other)
	{
		return false;
	}

	// Token: 0x06002A0D RID: 10765 RVA: 0x0009EAB4 File Offset: 0x0009CCB4
	private void Swap(int i, int j)
	{
		int num = this.data[j];
		this.data[j++] = this.data[i];
		this.data[i++] = num;
		num = this.data[j];
		this.data[j++] = this.data[i];
		this.data[i++] = num;
		num = this.data[j];
		this.data[j++] = this.data[i];
		this.data[i++] = num;
	}

	// Token: 0x06002A0E RID: 10766 RVA: 0x0009EB48 File Offset: 0x0009CD48
	public bool EditorOnly_MoveUp(int index)
	{
		if (index == 0)
		{
			return false;
		}
		if (index >= this.ruleCount)
		{
			return false;
		}
		this.Swap((index - 1) * 4, index * 4);
		return true;
	}

	// Token: 0x06002A0F RID: 10767 RVA: 0x0009EB7C File Offset: 0x0009CD7C
	public bool EditorOnly_MoveDown(int index)
	{
		if (index >= this.ruleCount - 1)
		{
			return false;
		}
		this.Swap((index + 1) * 4, index * 4);
		return true;
	}

	// Token: 0x06002A10 RID: 10768 RVA: 0x0009EBA0 File Offset: 0x0009CDA0
	public bool EditorOnly_MoveTop(int index)
	{
		if (this.EditorOnly_MoveUp(index--))
		{
			while (this.EditorOnly_MoveUp(index--))
			{
			}
			return true;
		}
		return false;
	}

	// Token: 0x06002A11 RID: 10769 RVA: 0x0009EBD4 File Offset: 0x0009CDD4
	public bool EditorOnly_MoveBottom(int index)
	{
		if (this.EditorOnly_MoveUp(index--))
		{
			while (this.EditorOnly_MoveUp(index--))
			{
			}
			return true;
		}
		return false;
	}

	// Token: 0x06002A12 RID: 10770 RVA: 0x0009EC08 File Offset: 0x0009CE08
	public bool EditorOnly_New()
	{
		global::System.Array.Resize<int>(ref this.data, this.dataCount + 4);
		return true;
	}

	// Token: 0x06002A13 RID: 10771 RVA: 0x0009EC20 File Offset: 0x0009CE20
	public bool EditorOnly_Clone(int index)
	{
		if (index >= 0 && index < this.ruleCount)
		{
			this.EditorOnly_New();
			for (int i = this.ruleCount - 1; i > index; i--)
			{
				int num = i * 4;
				int num2 = (i - 1) * 4;
				for (int j = 0; j < 4; j++)
				{
					this.data[num] = this.data[i];
					num++;
					num2++;
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x06002A14 RID: 10772 RVA: 0x0009EC98 File Offset: 0x0009CE98
	public bool EditorOnly_Delete(int index)
	{
		if (index >= 0 && index < this.ruleCount)
		{
			for (int i = index; i < this.ruleCount - 1; i++)
			{
				int num = i * 4;
				int num2 = (i + 1) * 4;
				for (int j = 0; j < 4; j++)
				{
					this.data[num] = this.data[i];
					num++;
					num2++;
				}
			}
			if (this.ruleCount == 1)
			{
				this.data = null;
			}
			else
			{
				global::System.Array.Resize<int>(ref this.data, this.data.Length - 4);
			}
			return true;
		}
		return false;
	}

	// Token: 0x06002A15 RID: 10773 RVA: 0x0009ED38 File Offset: 0x0009CF38
	public bool EditorOnly_Clear()
	{
		if (this.data != null)
		{
			this.data = null;
			return true;
		}
		return false;
	}

	// Token: 0x06002A16 RID: 10774 RVA: 0x0009ED50 File Offset: 0x0009CF50
	public bool Pass(global::Vis.Mask self, global::Vis.Mask instigator)
	{
		if (!this.expanded)
		{
			int ruleCount = this.ruleCount;
			if (ruleCount <= 0)
			{
				return true;
			}
			this.rules = new global::Vis.Rule[ruleCount];
			for (int i = 0; i < ruleCount; i++)
			{
				this.rules[i] = global::Vis.Rule.Decode(this.data, i * 4);
			}
			this.expanded = true;
		}
		for (int j = this.rules.Length - 1; j >= 0; j--)
		{
			global::Vis.Rule.Failure failure = this.rules[j].Pass(self, instigator);
			if (failure != global::Vis.Rule.Failure.None)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x04001518 RID: 5400
	[global::UnityEngine.SerializeField]
	private int[] data;

	// Token: 0x04001519 RID: 5401
	[global::System.NonSerialized]
	private bool expanded;

	// Token: 0x0400151A RID: 5402
	[global::System.NonSerialized]
	private global::Vis.Rule[] rules;
}
