using System;

// Token: 0x02000949 RID: 2377
public struct UITextSelection
{
	// Token: 0x060050BF RID: 20671 RVA: 0x0013C4D0 File Offset: 0x0013A6D0
	public UITextSelection(global::UITextPosition carratPos, global::UITextPosition selectPos)
	{
		this.carratPos = carratPos;
		this.selectPos = selectPos;
	}

	// Token: 0x17000EFD RID: 3837
	// (get) Token: 0x060050C0 RID: 20672 RVA: 0x0013C4E0 File Offset: 0x0013A6E0
	public bool hasSelection
	{
		get
		{
			return this.carratPos.valid && this.selectPos.valid && this.carratPos.position != this.selectPos.position;
		}
	}

	// Token: 0x17000EFE RID: 3838
	// (get) Token: 0x060050C1 RID: 20673 RVA: 0x0013C52C File Offset: 0x0013A72C
	public bool showCarrat
	{
		get
		{
			return this.carratPos.valid && (!this.selectPos.valid || this.selectPos.position == this.carratPos.position);
		}
	}

	// Token: 0x17000EFF RID: 3839
	// (get) Token: 0x060050C2 RID: 20674 RVA: 0x0013C578 File Offset: 0x0013A778
	public bool valid
	{
		get
		{
			return this.carratPos.valid;
		}
	}

	// Token: 0x060050C3 RID: 20675 RVA: 0x0013C588 File Offset: 0x0013A788
	public bool GetHighlight(out global::UIHighlight h)
	{
		if (this.selectPos.position < this.carratPos.position)
		{
			if (this.carratPos.valid && this.selectPos.valid)
			{
				h.a.i = this.selectPos.position;
				h.a.L = this.selectPos.line;
				h.a.C = this.selectPos.column;
				h.b.i = this.carratPos.position;
				h.b.L = this.carratPos.line;
				h.b.C = this.carratPos.column;
				return true;
			}
		}
		else if (this.selectPos.position > this.carratPos.position && this.carratPos.valid && this.selectPos.valid)
		{
			h.b.i = this.selectPos.position;
			h.b.L = this.selectPos.line;
			h.b.C = this.selectPos.column;
			h.a.i = this.carratPos.position;
			h.a.L = this.carratPos.line;
			h.a.C = this.carratPos.column;
			return true;
		}
		h = global::UIHighlight.invalid;
		return false;
	}

	// Token: 0x17000F00 RID: 3840
	// (get) Token: 0x060050C4 RID: 20676 RVA: 0x0013C728 File Offset: 0x0013A928
	public int highlightBegin
	{
		get
		{
			if (this.carratPos.valid && this.selectPos.valid && this.selectPos.position != this.carratPos.position)
			{
				return (this.selectPos.position >= this.carratPos.position) ? this.carratPos.position : this.selectPos.position;
			}
			return -1;
		}
	}

	// Token: 0x17000F01 RID: 3841
	// (get) Token: 0x060050C5 RID: 20677 RVA: 0x0013C7A8 File Offset: 0x0013A9A8
	public int highlightEnd
	{
		get
		{
			if (this.carratPos.valid && this.selectPos.valid && this.selectPos.position != this.carratPos.position)
			{
				return (this.selectPos.position >= this.carratPos.position) ? this.selectPos.position : this.carratPos.position;
			}
			return -1;
		}
	}

	// Token: 0x17000F02 RID: 3842
	// (get) Token: 0x060050C6 RID: 20678 RVA: 0x0013C828 File Offset: 0x0013AA28
	public int carratIndex
	{
		get
		{
			if ((this.carratPos.position == this.selectPos.position || !this.selectPos.valid) && this.carratPos.valid)
			{
				return this.carratPos.position;
			}
			return -1;
		}
	}

	// Token: 0x17000F03 RID: 3843
	// (get) Token: 0x060050C7 RID: 20679 RVA: 0x0013C880 File Offset: 0x0013AA80
	public int selectIndex
	{
		get
		{
			if (this.carratPos.valid && this.selectPos.valid && this.selectPos.position != this.carratPos.position)
			{
				return this.selectPos.position;
			}
			return -1;
		}
	}

	// Token: 0x060050C8 RID: 20680 RVA: 0x0013C8D8 File Offset: 0x0013AAD8
	public global::UITextSelection.Change GetChangesTo(ref global::UITextSelection value)
	{
		global::UITextSelection.Change result;
		if (this.carratPos.valid)
		{
			if (!value.carratPos.valid)
			{
				result = ((!this.hasSelection) ? global::UITextSelection.Change.CarratToNone : global::UITextSelection.Change.SelectionToNone);
			}
			else if (this.hasSelection)
			{
				if (!value.hasSelection)
				{
					result = global::UITextSelection.Change.SelectionToCarrat;
				}
				else if (value.carratPos.position != this.carratPos.position || value.selectPos.position != this.selectPos.position)
				{
					result = global::UITextSelection.Change.SelectionAdjusted;
				}
				else
				{
					result = global::UITextSelection.Change.None;
				}
			}
			else if (value.hasSelection)
			{
				result = global::UITextSelection.Change.CarratToSelection;
			}
			else if (value.carratPos.position != this.carratPos.position)
			{
				result = global::UITextSelection.Change.CarratMove;
			}
			else
			{
				result = global::UITextSelection.Change.None;
			}
		}
		else if (value.carratPos.valid)
		{
			result = ((!value.hasSelection) ? global::UITextSelection.Change.NoneToCarrat : global::UITextSelection.Change.NoneToSelection);
		}
		else
		{
			result = global::UITextSelection.Change.None;
		}
		return result;
	}

	// Token: 0x060050C9 RID: 20681 RVA: 0x0013C9E4 File Offset: 0x0013ABE4
	public override string ToString()
	{
		return string.Format("[hasSelection={0}, showCarrat={1}, highlight=[{2}->{3}], carratPos={4}, selectPos={5}]", new object[]
		{
			this.hasSelection,
			this.showCarrat,
			this.highlightBegin,
			this.highlightEnd,
			this.carratPos.ToString(),
			this.selectPos.ToString()
		});
	}

	// Token: 0x04002D70 RID: 11632
	private const global::UITextSelection.Change kSelectChange_None = global::UITextSelection.Change.None;

	// Token: 0x04002D71 RID: 11633
	private const global::UITextSelection.Change kSelectChange_DropCarrat = global::UITextSelection.Change.CarratToNone;

	// Token: 0x04002D72 RID: 11634
	private const global::UITextSelection.Change kSelectChange_MoveCarrat = global::UITextSelection.Change.CarratMove;

	// Token: 0x04002D73 RID: 11635
	private const global::UITextSelection.Change kSelectChange_NewCarrat = global::UITextSelection.Change.NoneToCarrat;

	// Token: 0x04002D74 RID: 11636
	private const global::UITextSelection.Change kSelectChange_DropSelection = global::UITextSelection.Change.SelectionToCarrat;

	// Token: 0x04002D75 RID: 11637
	private const global::UITextSelection.Change kSelectChange_MoveSelection = global::UITextSelection.Change.SelectionAdjusted;

	// Token: 0x04002D76 RID: 11638
	private const global::UITextSelection.Change kSelectChange_NewSelection = global::UITextSelection.Change.CarratToSelection;

	// Token: 0x04002D77 RID: 11639
	private const global::UITextSelection.Change kSelectChange_DropAll = global::UITextSelection.Change.SelectionToNone;

	// Token: 0x04002D78 RID: 11640
	private const global::UITextSelection.Change kSelectChange_NewAll = global::UITextSelection.Change.NoneToSelection;

	// Token: 0x04002D79 RID: 11641
	public global::UITextPosition carratPos;

	// Token: 0x04002D7A RID: 11642
	public global::UITextPosition selectPos;

	// Token: 0x0200094A RID: 2378
	public enum Change : sbyte
	{
		// Token: 0x04002D7C RID: 11644
		None,
		// Token: 0x04002D7D RID: 11645
		NoneToCarrat,
		// Token: 0x04002D7E RID: 11646
		CarratMove,
		// Token: 0x04002D7F RID: 11647
		CarratToNone,
		// Token: 0x04002D80 RID: 11648
		CarratToSelection,
		// Token: 0x04002D81 RID: 11649
		SelectionAdjusted,
		// Token: 0x04002D82 RID: 11650
		SelectionToCarrat,
		// Token: 0x04002D83 RID: 11651
		NoneToSelection,
		// Token: 0x04002D84 RID: 11652
		SelectionToNone
	}
}
